using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Dependency;
using Bogus;
using JetBrains.Annotations;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Newtonsoft.Json;

namespace Kis.Investors.WebHost.Seed.TestData
{
    /// <summary>
    /// Генерирует данные используя библиотеку Bogus
    /// </summary>
    public class BulletinDataGenerator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;
        private static Random _rnd;
        private IVoteOptionCrudAppService _voteOptonsCrudService;
        private IVoteMemberCrudAppService _voteMemberCrudAppService;


        public BulletinDataGenerator([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
            _rnd = new Random();
            _voteOptonsCrudService = _iocResolver.Resolve<IVoteOptionCrudAppService>();
            _voteMemberCrudAppService = _iocResolver.Resolve<IVoteMemberCrudAppService>();
        }

        public void Generate()
        {
            var reposytory = _iocResolver.Resolve<IBulletinRepository>();

            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            if (reposytory.GetAllListAsync().Result.Any()) return;

            Console.WriteLine($"Начата загрузка тестовых данных типа {typeof(BulletinDto).Name}");

            var voteCrudService = _iocResolver.Resolve<IVoteCrudAppService>();
            // !!! Генерирование участников голосования перенесено в VoteDataGenerator, здесь достаем участников через crud сервис
            //var voteMemberProvider = _iocResolver.Resolve<IVoteMembersProvider>();
            var bulletinService = _iocResolver.Resolve<IBulletinCrudAppService>();

            var result = voteCrudService.GetAll(new VotePagedAndSortedResultRequestDto()).Result;

            var bulletinGenerator = new Faker<CreateBulletinDto>()
                .StrictMode(true)
                .RuleFor(x=> x.VoteId, () => Guid.Empty)
                .RuleFor(x => x.AgreeWithAgenda, () => false)
                .RuleFor(x => x.AuthoritiesConfirm, () => false)
                .RuleFor(x => x.ReadInformation, () => false)
                .RuleFor(x => x.VoteMemberId, () => Guid.Empty)
                .RuleFor(x => x.VotingResultXml, f=> f.Lorem.Text())
                .RuleFor(x => x.BulletinSelectedOptions, () => new List<CreateBulletinSelectedOptionDto>());
            
            foreach (var vote in result.Items)
            {
                //// !!! Генерирование участников голосования перенесено в VoteDataGenerator, здесь достаем участников через crud сервис
                ////var voteMembers = voteMemberProvider.GetVoteMembers(vote.Id).Result;
                //var voteMembers = voteMemberCrudService.GetAll(new PagedVoteMemberResultRequestDto() {VoteId = vote.Id}).Result.Items.ToList();

                //if (!voteMembers.Any())
                //{
                //    throw new Exception("Нет членов для голосования");
                //}

                //var members = new List<VoteMemberDto>();

                //foreach (var voteMemberDto in voteMembers)
                //{
                //   members.Add(_voteMemberCrudAppService.Create(voteMemberDto).Result);
                //}

                // !!! Генерирование участников голосования перенесено в VoteDataGenerator, здесь достаем участников через crud сервис
                var members = _voteMemberCrudAppService.GetAll(new PagedVoteMemberResultRequestDto() {VoteId = vote.Id}).Result.Items.ToList();

                BulletinDto b = null;
                foreach (var member in members)
                {
                    Console.Write(".");
                    var bulletin = bulletinGenerator.Generate();

                    bulletin.VoteId = vote.Id;
                    bulletin.VoteMemberId = member.Id;
                    //bulletin.BulletinSelectedOptions = BulletinSelectedOptionsGenerator(vote);
                    bulletin.BulletinSelectedOptions = new List<CreateBulletinSelectedOptionDto>();
                    bulletin.VotingResultXml = JsonConvert.SerializeObject(bulletin);

                    b = bulletinService.Create(bulletin.MapTo<BulletinDto>()).Result;
                }
            }

            //Логировать факт выгрузки данных
           Console.WriteLine();
           Console.WriteLine($"Данные типа {typeof(BulletinDto).Name} выгружены в БД");
        }

        private IList<CreateBulletinSelectedOptionDto> BulletinSelectedOptionsGenerator(VoteDto vote)
        {
            var optionsCount = vote.Options.Count;

            var generator = new Faker<CreateBulletinSelectedOptionDto>()
                .StrictMode(true)
                .RuleFor(x => x.SelectedOptionId, f => vote.Options[_rnd.Next(0, optionsCount-1)].Id);

            if (!vote.IsMultilieChoice)
            {
                return generator.Generate(1);
            }

            return generator.Generate(_rnd.Next(1, optionsCount));
        }

    }
}

