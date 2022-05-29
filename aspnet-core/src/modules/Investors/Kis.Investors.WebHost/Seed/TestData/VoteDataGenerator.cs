using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Dependency;
using Bogus;
using Bogus.Extensions;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.General.Api.Dto.Comment;
using Kis.Investors.Api.Services.Crud;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Newtonsoft.Json;

namespace Kis.Investors.WebHost.Seed.TestData
{
    /// <summary>
    /// Генерирует данные используя библиотеку Bogus
    /// </summary>
    public class VoteDataGenerator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;
        private readonly string _file;

        public VoteDataGenerator([NotNull] IIocResolver iocResolver, string file)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
            _file = file;
        }

        public void Generate()
        {
           var repository = _iocResolver.Resolve<IVoteRepository>();

            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            if (repository.GetAllListAsync().Result.Any()) return;

            Console.WriteLine($"Начата загрузка тестовых данные типа {typeof(VoteDto).Name}");

            var voteService = _iocResolver.Resolve<IVoteCrudAppService>();
            var projectService = _iocResolver.Resolve<IInvestedProjectCrudAppService>();
            var voteMemberProvider = _iocResolver.Resolve<IVoteMembersProvider>();
            var voteMemberCrudAppService = _iocResolver.Resolve<IVoteMemberCrudAppService>();

            var projects = projectService.GetAll(new PagedInvestedProjectResultRequestDto()).Result;

            //Считываются данные из указанного файла каталога TestData в строковую переменную
            string data;
            using (StreamReader sr = new StreamReader(_file, System.Text.Encoding.UTF8))
            {
                data = sr.ReadToEnd();
            }

            IList<VoteDto> voteDtos = new List<VoteDto>();

            if (data != "")
            {
                //данные десерелизуются из json в переменную с указанным типом
                IList<CreateVoteDto> dtos = JsonConvert.DeserializeObject<IList<CreateVoteDto>>(data);

                foreach (var createDto in dtos)
                {
                    var dto = createDto.MapTo<VoteDto>();

                    var random = new Random();

                    dto.QuorumPct = (float)(random.Next(5000, 10000) * 0.01);
                    dto.DecisionMakersPct = (float)(random.Next(5000, 10000) * 0.01);
                    dto.IsMultilieChoice = false;
                    dto.IsPublished = true;

                    // Рандомное значение даты начала рассылки уведомления о предстоящем голосовании, диапазон от настоящего момента до -6 дней
                    var startDateTime = DateTime.Now - TimeSpan.FromDays(6);
                    var noteRange = (startDateTime.AddDays(3) - startDateTime).TotalSeconds;
                    var noteSendingDateTime = startDateTime.AddSeconds(random.Next(Convert.ToInt32(noteRange)));

                    // Рандомное значение даты начала голосования, диапазон от даты начала рассылки до +2 дня
                    var beginDateRange = (noteSendingDateTime.AddDays(2) - noteSendingDateTime).TotalSeconds;
                    var beginDateTime = noteSendingDateTime.AddSeconds(random.Next(Convert.ToInt32(beginDateRange)));

                    // Рандомное значение даты конца голосования, диапазон от +3 дня до +6 дней с даты начала голосования
                    var startEndTime = beginDateTime.AddDays(3);
                    var endDateRange = (beginDateTime.AddDays(6) - startEndTime).TotalSeconds;
                    var endDateTime = startEndTime.AddSeconds(random.Next(Convert.ToInt32(endDateRange)));

                    // Присваиваем сгенерированные даты соответствующим полям голосования
                    dto.NoteSendingDateTime = noteSendingDateTime;
                    dto.BeginDateTime = beginDateTime;
                    dto.EndDateTime = endDateTime;

                    voteDtos.Add(dto);
                }
            }

            foreach (var project in projects.Items)
            {
                foreach (var voteDto in voteDtos)
                {
                    Console.Write(".");
                    voteDto.ContextId = project.Id;
                    var v = voteService.Create(voteDto).Result;
                    var voteMembers = voteMemberProvider.GetVoteMembers(v.Id).Result;
                    foreach (var voteMember in voteMembers)
                    {
                        var vm = voteMemberCrudAppService.Create(voteMember).Result;
                    }
                }
            }

            //Логировать факт выгрузки данных
            Console.WriteLine();
            Console.WriteLine($"Данные типа {typeof(VoteDto).Name} выгружены в БД");
        }
    }
}

