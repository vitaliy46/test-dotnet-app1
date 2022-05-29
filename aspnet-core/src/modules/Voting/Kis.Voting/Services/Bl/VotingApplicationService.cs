using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.BackgroundJobs;
using Abp.Extensions;
using Abp.Runtime.Session;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Crypto.Api;
using Kis.Crypto.Api.Services;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Bl;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Authorization;
using Kis.Voting.Exceptions;
using Kis.Voting.Services.HangFireJobs;
using Kis.Voting.Services.Sender;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Kis.Voting.Service.Bl
{
    public class VotingApplicationService : KisApplicationServiceBase, IVotingApplicationService
    {

        private readonly IVoteMemberRepository _voteMemberRepository;
        private readonly IBulletinRepository _bulletinRepository;
        private readonly IVoteCalculatorQualifier _voteCalculatorQualifier;
        private readonly IVoteCrudAppService _voteCrudService;
        private readonly IVoteMemberCrudAppService _voteMemberCrudAppService;
        private readonly IBulletinCrudAppService _bulletinCrudService;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IVoteResultCrudAppService _voteResultCrudService;
        private readonly IVoteReportCrudAppService _voteReportCrudAppService;
        private readonly ICryptoProvider _cryptoProvider;
        private readonly IVoteMembersProvider _voteMembersProvider;
        private readonly IConfiguration _configuration;
        private readonly IOneTimePasswordAppService _oneTimePasswordAppService;
  
        public VotingApplicationService([NotNull] IVoteCrudAppService voteCrudAppService,
                                        [NotNull] IBulletinCrudAppService bulletinCrudService,
                                        [NotNull] IVoteResultCrudAppService voteResultCrudAppService,
                                        [NotNull] IBulletinRepository bulletinRepository,
                                        [NotNull] IVoteMemberRepository voteMemberRepository,
                                        [NotNull] IVoteCalculatorQualifier voteCalculatorQualifier,
                                        [NotNull] IBackgroundJobManager backgroundJobManager,
                                        [NotNull] IVoteMemberCrudAppService voteMemberCrudAppService,
                                        [NotNull] IVoteMembersProvider voteMembersProvider, 
                                        [NotNull] IConfiguration configuration,
                                        [NotNull] IOneTimePasswordAppService oneTimePasswordAppService,
                                        [NotNull] ICryptoProvider cryptoProvider,
                                        [NotNull] IVoteReportCrudAppService voteReportCrudAppService)
        {
            _voteReportCrudAppService = voteReportCrudAppService ?? throw new ArgumentNullException(nameof(voteReportCrudAppService));
            _cryptoProvider = cryptoProvider ?? throw new ArgumentNullException(nameof(cryptoProvider));

            _oneTimePasswordAppService = oneTimePasswordAppService ?? throw new ArgumentNullException(nameof(oneTimePasswordAppService));
 	        
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _voteMembersProvider = voteMembersProvider ?? throw new ArgumentNullException(nameof(voteMembersProvider));
            _backgroundJobManager = backgroundJobManager ?? throw new ArgumentNullException(nameof(backgroundJobManager));
            _voteCalculatorQualifier = voteCalculatorQualifier ?? throw new ArgumentNullException(nameof(voteCalculatorQualifier));
            _bulletinRepository = bulletinRepository ?? throw new ArgumentNullException(nameof(bulletinRepository));
            _voteMemberRepository = voteMemberRepository ?? throw new ArgumentNullException(nameof(voteMemberRepository));
            _bulletinCrudService = bulletinCrudService ?? throw new ArgumentNullException(nameof(bulletinCrudService));
            _voteCrudService = voteCrudAppService ?? throw new ArgumentNullException(nameof(voteCrudAppService));
            _voteMemberCrudAppService = voteMemberCrudAppService ?? throw new ArgumentNullException(nameof(voteMemberCrudAppService));
            _voteResultCrudService = voteResultCrudAppService ?? throw new ArgumentNullException(nameof(voteResultCrudAppService));

        }

        /// <summary>
        /// Возвращает PagedResultDto с голосованиями для текущего пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<PagedResultDto<VoteShortDto>> GetVotesPagedResultDto()
        {
            var votes = new List<VoteDto>();

            // Формируем список голосований, где текущий пользователь является участником
            votes.AddRange((await _voteCrudService.GetAll(new VotePagedAndSortedResultRequestDto() { UserId = AbpSession.UserId, MaxResultCount = 2147483647 })).Items);

            // Дополняем список голосованиями, где пользователь является организатором
            if (PermissionChecker.IsGranted(PermissionNames.VoteManagement))
            {
                votes.AddRange((await _voteCrudService.GetAll(new VotePagedAndSortedResultRequestDto() { InitiatorId = AbpSession.UserId, MaxResultCount = 2147483647 })).Items);
            }

            var votesPagedResultDto = new PagedResultDto<VoteShortDto>
            {
                TotalCount = votes.Count,
                // Сортируем голосования по убыванию даты начала, сортировка, которую делаем в crud сервисе, сбивается
                Items = votes.Select(x => x.MapTo<VoteShortDto>()).OrderByDescending(x => x.BeginDateTime).ToList()
            };

            return votesPagedResultDto;
        }

        /// <summary>
        /// Возвращает результат подсчета голосов в  формате  указаном в голосовании
        /// </summary>
        public async Task<byte[]> GetResultReportAsync(Guid voteId)
        {
            //Поднимаем голосование по идентификатору
            //var vote = await _voteCrudService.Get(voteId);

            //Поднимаем результат по идентификатору голосования
            //var voteResult = (await _voteResultCrudService.GetAll(new VoteResultPagedAndSortedRequestDto{ VoteId = voteId})).Items.FirstOrDefault();

            //Проверить, подведены ли итоги по голосованию
            //Проверка должна быть универсальной, метод всегда возвращает bytes[] но может содержать различные типы: Xml, Pdf и т.д.

            //Используя полученный результат, производится приведение его к Xml формату для 
            //его электронной подписи и отправки участника голосования
            //var resultXml = TransformToXml(input, result);

            ///Подписываются данные электронной подписью
            /// ...
            /// Данные записываются в БД
            /// 
            /// Производится преобразование результатов голосования в выходной формат

            var voteReportDto = (await _voteReportCrudAppService.GetAll(new PagedVoteReportResultRequestDto() {VoteId = voteId}))
                .Items.FirstOrDefault();

            if (voteReportDto == null) return null;

            // TODO: пока отчет о результатах голосований выдается только в pdf формате, просто считываем байтовый массив byte[] из подписанного файла
            string signedFilePath = Path.Combine(Path.GetFullPath("./SignedFiles"), voteReportDto.ReportFile.Media.FileName);
            return File.ReadAllBytes(signedFilePath);
        }

        /// <summary>
        /// Участник голосует.
        /// Бюллетень создается только тогда, когда голосующий проголосует и отправит
        /// результат своего голосования. До этого момента, бюллетеня ни в каком виде не существует
        /// </summary>
        /// <param name="input">информация о заполненном бюллетене </param>
        /// <param name="token">токен </param>
        /// <returns>бюллетень и процент уже проголососвавших</returns>
        public async Task<(BulletinDto bulletin, float votersPersent)> Voted(BulletinDto input)
        {
            // Проверяем прошел ли пользователь проверку с помощью одноразового пароля
            // TODO временно отключен
            //await _oneTimePasswordAppService.CheckPasswordConfirmed();

            var voteMember = await _voteMemberCrudAppService.Get(input.VoteMemberId);

            // Проверяем что пользователь голосует от своего имени
            if (AbpSession.UserId != voteMember.UserId) throw new AccessViolationBulletingException();

            // Проверяем что пользователь является участником голосования
           if (voteMember.VoteId != input.VoteId) throw new NotVoteMemberBulletingException();

            // Если пользователь уже голосовал, выбрасываем исключение
            var resultBulletin = (await _bulletinCrudService.GetAll(new PagedBulletinResultRequestDto() { VoteMemberId = input.VoteMemberId, VoteId = input.VoteId })).Items.FirstOrDefault();
            if (resultBulletin != null) throw new IsVotedBulletingException();

            var bulletin = await _bulletinCrudService.Create(input);

            /// Подписывается бюллетень эл. подписью
            if (bulletin.VotingResultXml.IsNullOrEmpty()) 
                //Возможно, что на стороне клиента данные уже подписаны
                //TODO Возникает проблема при подписи данных на стороне клиента. 
                //На сервере данные подписываются с идентификатором, а на стороне клиента - нет
            {
                bulletin.VotingResultXml = SignBulletin(bulletin, voteMember);
            }
            else
            {
               // проверить действительно ли данные подписаны
            }

            /// Обновляем бюллетень с подписанными данными
            /// TODO не очень хороший вариант. В последствии нужно разделить данные с подписью
            /// и подписываемые данные. Задача в беклог поставлена
            bulletin = await _bulletinCrudService.Update(bulletin);

            ///  Вычисляем процент уже проголосовавших
            var percent = await GetVotedPercent(input.VoteId);

            return (bulletin, percent);
        }
        /// <summary>
        /// Подписывается проголосованный бюллетень
        /// </summary>
        /// <param name="bulletin"></param>
        /// <param name="voteMember"></param>
        /// <returns></returns>
        private string SignBulletin(BulletinDto bulletin, VoteMemberDto voteMember)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BulletinDto));

            StringBuilder sb = new StringBuilder("");

            using (TextWriter writer = new StringWriter(sb))
            {
                bulletin.VotingResultXml = null; //Для однозначности

                writer.Write(sb);

                serializer.Serialize(writer, bulletin);
            }

            var signerInfo = new SignerInfo
            {
                Contact = voteMember.VoteMemberContact.Contact.Value,
                ContactType = (int)voteMember.VoteMemberContact.Contact.ContactType,
                Name = voteMember.Name
            };

            var xmlDocument = sb.ToString();

            var signedDocument = _cryptoProvider.SingXml(xmlDocument, signerInfo).Result;

            return signedDocument;
        }

        /// <summary>
        /// Публикуется подготовленное голосование. Не исключено что перед публикацийе
        /// были внесены последние изменения
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        public async Task<VoteDto> Publish(VoteDto vote)
        {
            vote = await SaveAsync(vote);

            /// Подписать голосвание эл. подписью и снова обновить голосование с 
            /// подписью
            /// TODO ...
            /// 
            /// Поставить задачу в HangFire рассылки всем участникам
            /// уведомления об опубликованом голосовании с сылкой на это голосование


            ///Выбираем всех участников 
            IList<VoteMemberDto> voteMembers = await AddVoteMembers(await _voteMembersProvider.GetVoteMembers(vote.Id));

            ///и для каждого ставим задачу по рассылке
            ///За постановку задачи отвечает функционал диспетчера задач -  HangFire:

            //https://aspnetboilerplate.com/Pages/Documents/Hangfire-Integration
            //https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers

            // формируем ссылку на голосование
            string voteLink = _configuration.GetValue<string>("App:ClientRootAddress") + _configuration.GetValue<string>("App:BulletinCreateApi") + "/" + vote.Id;

            string message = $"Сообщаем, что {vote.BeginDateTime.Date} числа состоится " +
                             $"голосование на тему {vote.Theme}. Предлагаем перейти по <a href=\"{voteLink}\">ссылке</a> " +
                             $"для предварительного ознакомления с материалами голосования.";
            await _backgroundJobManager.EnqueueAsync<SendingNotificationsJob, (IList<VoteMemberDto>, string)>((voteMembers, message), BackgroundJobPriority.Normal, vote.NoteSendingDateTime - DateTime.Now);

            /// 
            /// Поставить задачу в HangFier рассылки всем участникам
            /// уведомления о начале голосования с сылкой на это голосование
            message = $"Сообщаем о начале голосования" +
                              $"голосование на тему {vote.Theme}. Предлагаем перейти по <a href=\"{voteLink}\">ссылке</a> " + 
                              $"для участия в голосовании.";
            await _backgroundJobManager.EnqueueAsync<SendingNotificationsJob, (IList<VoteMemberDto>, string)>((voteMembers, message), BackgroundJobPriority.Normal, vote.BeginDateTime - DateTime.Now);
            /// 
            /// Поставить задачу в HangFier о подведении итогов голосования
            /// А после подведения уведомить пользователей о результатах.
            /// ...
            await _backgroundJobManager.EnqueueAsync<CalculateVotingResultJob, Guid>(vote.Id, BackgroundJobPriority.Normal, vote.EndDateTime - DateTime.Now);

            vote.IsPublished = true;

            vote = await _voteCrudService.Update(vote);

            return vote;
        }

        private async Task<IList<VoteMemberDto>> AddVoteMembers(IList<VoteMemberDto> voteVoteMembers)
        {
            var result = new List<VoteMemberDto>();

            foreach (var voteMemberDto in voteVoteMembers)
            {
                result.Add(await _voteMemberCrudAppService.Create(voteMemberDto));
            }

            return result;
        }

        /// <summary>
        /// Сохраняет голосование вместе со списком участников, переданых в составе 
        /// голосования
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<VoteDto> SaveAsync(VoteDto input)
        {
            VoteDto dto;

            if (input.Id.Equals(Guid.Empty))
            {
                dto = await _voteCrudService.Create(input);
            }
            else
            {
                dto = await _voteCrudService.Update(input);
            }

            return dto;
        }

        /// <summary>
        /// Вычисляет процент проголосовавших
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        private async  Task<float> GetVotedPercent(Guid voteId)
        {
            var bulletinsCount =  (await  _bulletinRepository.GetAllListAsync(b => b.VoteId == voteId)).Count;

            var voteMembersCount = (await _voteMemberRepository.GetAllListAsync(b => b.VoteId == voteId)).Count;

            float percent = 0;

            if (voteMembersCount != 0)
            {
                percent = ((float)bulletinsCount / (float)voteMembersCount) * 100;
            }
            return percent;
        }

        /// <summary>
        /// В зависимости от типа механизма подсчета голосов производится выбор соответсвующего
        /// алгоритма (стратегии) и рассчет голосов
        /// TODO пока расчет производится одним простым алгоритмом
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        public async Task CalculateAndSaveResult(Guid voteId)
        {
            var vote = await _voteCrudService.Get(voteId);

            var voteCalculator = _voteCalculatorQualifier.Define(vote.VotingCalculationType);

            var result = voteCalculator.Calculate(vote, await GetVotedPercent(voteId));

            //подписать эл. подписью результат голосования
            //...

            //сохранить результат голосования
            //...
            result.VoteId = vote.Id;

            var voteResult = await _voteResultCrudService.Create(result);

            TransformToPdf(vote, voteResult);

            PdfFile pdfFile = _cryptoProvider.SingPdf($"{vote.Id}.pdf", new SignerInfo()
            {
                // TODO: SignerInfo пока захардкодил
                Name = "name",
                Contact = "contact@mail.ru",
                ContactType = 2
            }).Result;

            string signedFilePath = Path.Combine(Path.GetFullPath("./SignedFiles"), pdfFile.Name);
            File.WriteAllBytes(signedFilePath, Convert.FromBase64String(pdfFile.Data));
            await _voteReportCrudAppService.Create(new VoteReportDto()
            {
                VoteId = vote.Id,
                ReportFile = new VoteReportMediaDto()
                {
                    Media = new MediaDto()
                    {
                        Label = vote.Id.ToString(),
                        FileName = pdfFile.Name
                    }
                }
            });

            // задача на отсылку уведомлений об итогах голосования участникам
            // формируем ссылку на результат голосования
            string voteResultReportLink = _configuration.GetValue<string>("App:ServerRootAddress") + _configuration.GetValue<string>("App:GetResultReportApi") + "/" + vote.Id;

            string message = $"Подведены итоги голосования на тему {vote.Theme}. Предлагаем перейти по <a href=\"{voteResultReportLink}\">ссылке</a> для ознакомления.";

            IList<VoteMemberDto> voteMemberDtoList = (await _voteMemberCrudAppService.GetAll(new PagedVoteMemberResultRequestDto(){VoteId = vote.Id})).Items.ToList();

            await _backgroundJobManager.EnqueueAsync<SendingNotificationsJob, (IList<VoteMemberDto>, string)>((voteMemberDtoList, message));
        }

        /// <summary>
        /// Преобразуется результат в читабельный Xml формат для последующей эл. подписи
        /// и сохранении в БД
        /// </summary>
        /// <param name="vote"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private XDocument TransformToXml(Vote vote, IDictionary<Guid, decimal> result)
        {
            ///В этих данных должны быть оражены все важные детали голосования
            /// и подведенных итогов голосования
            /// 
            var document = new XDocument();

            return document;
        }

        /// <summary>
        /// Производится преобразование результата голосования в Pdf формат
        /// TODO в последствии нужно ориентироваться на тот выходной формат, котрый
        /// указан в голосовании
        /// </summary>
        /// <returns></returns>
        private void TransformToPdf(VoteDto vote, VoteResultDto voteResultDto)
        {
            PdfDocument pdf;

            if (voteResultDto != null)
            {
                var header = File.ReadAllText("VoteReportTemplates/header.html");
                var row = File.ReadAllText("VoteReportTemplates/row.html");
                var footer = File.ReadAllText("VoteReportTemplates/footer.html");

                var signedVoteResult = JsonConvert.DeserializeObject<IList<(uint quantity, VoteOptionDto option)>>(voteResultDto.SignedResult);

                StringBuilder builder = new StringBuilder();

                builder.AppendFormat(header, vote.Theme);

                foreach ((uint quantity, VoteOptionDto option) item in signedVoteResult)
                {
                    builder.AppendFormat(row, item.option.Text, item.quantity);
                }

                builder.AppendFormat(footer);

                pdf = PdfGenerator.GeneratePdf(builder.ToString(), PageSize.A4);
            }
            else
            {
                pdf = PdfGenerator.GeneratePdf("Итоги голосования не подведены", PageSize.A4);
            }
            
            pdf.Save($"./Temp/{vote.Id}.pdf");
        }
    }
}
