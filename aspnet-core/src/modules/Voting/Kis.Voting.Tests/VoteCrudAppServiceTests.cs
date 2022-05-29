using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using AutoMapper.Configuration;
using JetBrains.Annotations;
using Kis.Base.Utilities;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Service.Crud;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Moq; 

namespace Kis.Voting.Tests
{
    [TestClass]
    public class VoteCrudAppServiceTests
    {
        //public VoteDto _vote = new VoteDto()
        //{
        //    Id = new Guid("8ec8e7de-2042-40fa-8a65-b0fd94cfbf3d"), 
        //    Number = 123,
        //    InitiatorId = 987654,
        //    VotingCalculationType = 0,
        //    ContextId = new Guid("977d4d20-518c-422a-8a0d-ba9ddb4fa712")
        //};

        public static VoteDto _voteDto = new VoteDto()
        {
            Id = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
            Number = 123,
            InitiatorId = 987654,
            VotingCalculationType = VotingCalculationTypes.Majority,
            ContextId = new Guid("977d4d20-518c-422a-8a0d-ba9ddb4fa712"),
            QuorumPct = 55, // минимально допустимый процент участников для свершения голосования
            DecisionMakersPct = 55, //Минимально допустимый процент голосов принимающих решения

            Options = new List<VoteOptionDto>()
            {
                new VoteOptionDto()  // варианты ответов при голосовании
                {
                    Id = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd"),
                    Text = "Вариант 1"
                },
                new VoteOptionDto()
                {
                    Id = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd"),
                    Text = "Вариант 2"
                },
                new VoteOptionDto()
                {
                    Id = new Guid("53f300bc-56d6-4504-8712-75ffa59cc053"),
                    Text = "Вариант 3"
                }

            }
        };

        public static Vote _vote = new Vote()
        {
            Id = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
            Number = 123,
            InitiatorId = 987654,
            VotingCalculationType = VotingCalculationTypes.Majority,
            ContextId = new Guid("977d4d20-518c-422a-8a0d-ba9ddb4fa712"),
            QuorumPct = 55, // минимально допустимый процент участников для свершения голосования
            DecisionMakersPct = 55, //Минимально допустимый процент голосов принимающих решения

            Options = new List<VoteOption>()
            {
                new VoteOption()  // варианты ответов при голосовании
                {
                    Id = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd"),
                    Text = "Вариант 1"
                },
                new VoteOption()
                {
                    Id = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd"),
                    Text = "Вариант 2"
                },
                new VoteOption()
                {
                    Id = new Guid("53f300bc-56d6-4504-8712-75ffa59cc053"),
                    Text = "Вариант 3"
                }

            }
        };

        public static IList<Vote> Votes = new List<Vote>()
        {
            new Vote()
            {
                Id = new Guid("8ec8e7de-2042-40fa-8a65-b0fd94cfbf3d"),
                ContextId = new Guid("281588bb-5acd-48e3-b351-e0068171d8bb")
            },
            new Vote()
            {
                Id = new Guid("e1dd640a-b4a0-4bb2-b66c-dfc5ddb22f6e"),
                ContextId = new Guid("a0f998c5-386a-4d06-9019-730cc1175c68")
            },
            new Vote()
            {
                Id = new Guid("81eb6a2c-e9ae-4597-9d0f-62afd60ff664"),
                ContextId = new Guid("77b04523-e451-4eeb-a64b-f36e55fc4b16")
            }
        };

        private IVoteCrudAppService _voteCrudAppService;

        [TestMethod]
        public void UpdateVoteOptions_AddNewVoteOptionDtos_ReturnVoteOptionDtos()
        {
            //Подготовка инструментов и данных
           
            
            
           IRepository<Vote, Guid> _repository = new FakeRepository();
            IVoteContextProvider _voteContextProvider = new FakeVoteContextProvider();
            IVoteOptionCrudAppService _voteOptionCrudAppService = new _FakeVoteOptionCrudAppService();

            //_voteCrudAppService = new Fake2VoteCrudAppService(_repository, _voteContextProvider, _voteOptionCrudAppService);
            

            //Тестирование

            var updatedVoteOPtions = _voteCrudAppService.Update(_voteDto).Result;

            //Проверка  результатов теста

            //Assert.AreEqual(_percent, 80);
        }

        [TestMethod]
        public void Create()
        {
            //Подготовка инструментов и данных
            //var iocManager = IocManager.Instance;

            var mockVoteRepository = new Mock<IVoteRepository>();
            mockVoteRepository.Setup(a => a.InsertAsync(It.IsAny<Vote>())).ReturnsAsync(_vote);
            mockVoteRepository.Setup(a => a.GetAllListAsync()).ReturnsAsync(Votes.ToList);

            var mockVoteContextProvider = new Mock<IVoteContextProvider>();

            var mockVoteOptionsCrudService = new Mock<IVoteOptionCrudAppService>();
            // Настраиваем mockVoteOptionsCrudService так чтобы он возвращал тот же объект что и принимает
            mockVoteOptionsCrudService.Setup(a => a.Create(It.IsAny<VoteOptionDto>())).ReturnsAsync((VoteOptionDto voteOptionDto) => voteOptionDto);

            // Инициализируем VoteCrudAppService, метод которого будем проверять
            //var mockVoteCrudAppService = Mock.Get(new VoteCrudAppService(mockVoteRepository.Object, mockVoteContextProvider.Object, mockVoteOptionsCrudService.Object));
            //mockVoteCrudAppService.CallBase = true;
            //mockVoteCrudAppService.Setup(a=>a.Cre)

            //var voteCrudAppService = mockVoteCrudAppService.Object;

            //var voteCrudAppService = new VoteCrudAppService(mockVoteRepository.Object, mockVoteContextProvider.Object, mockVoteOptionsCrudService.Object);

            //var mockvoteCrudAppService = Mock.Get(new VoteCrudAppService(mockVoteRepository.Object, mockVoteContextProvider.Object, mockVoteOptionsCrudService.Object));

            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new VotingAutoMapperProfile());  // <= Добавляем необходимый профиль автомаппера
            });

            //voteCrudAppService.ObjectMapper = new AutoMapperObjectMapper(new Mapper(mapperConfiguration));
            //mockvoteCrudAppService.Object.ObjectMapper = new AutoMapperObjectMapper(new Mapper(mapperConfiguration));

            //mockvoteCrudAppService.Object.Call

            //voteCrudAppService.UnitOfWorkManager = new Mock<IUnitOfWorkManager>().Object;

            //Тестирование
            //var voteDto = voteCrudAppService.Create(_voteDto).Result;

            //Проверка  результатов теста
            //Assert.Equals(_voteDto, voteDto);
        }
    }
    
    //class Fake2VoteCrudAppService : VoteCrudAppService,  IVoteCrudAppService
    //{
    //    public override Task<VoteDto> Update(VoteDto input)
    //    {
    //        return base.Update(input);
    //        //return new VoteDto()
    //        //{
    //        //    Options = new List<VoteOptionDto>
    //        //    {
    //        //        new VoteOptionDto(),
    //        //        new VoteOptionDto(),
    //        //    }
    //        //};
    //    }

    //    public override async Task<VoteDto> Get(VoteDto input)
    //    {
    //        return  new VoteDto()
    //        {
    //            IsPublished = false
    //        };

    //    }

    //    public Task<PagedResultDto<VoteDto>> GetAll(VotePagedAndSortedResultRequestDto input)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<VoteDto> Create(VoteDto input)
    //    {
    //        throw new NotImplementedException();
    //    }

        

    //    public Task Delete(VoteDto input)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<VoteDto> Get(Guid id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task Delete(Guid id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public Fake2VoteCrudAppService([NotNull] IRepository<Vote, Guid> repository, [NotNull] IVoteContextProvider voteContextProvider, [NotNull] IVoteOptionCrudAppService voteOptionCrudService) : base(repository, voteContextProvider, voteOptionCrudService)
    //    //{
    //    //}
    //}
    internal class FakeRepository : IRepository<Vote, Guid>
    {

        public async Task<Vote> GetAsync(Guid id)
        {
            Vote vote ;
            vote = VoteCrudAppServiceTests.Votes.FirstOrDefault(v => v.Id == id);
            return vote;


        }
        #region Balast

        
        public IQueryable<Vote> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> GetAllIncluding(params Expression<Func<Vote, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<Vote> GetAllList()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vote>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public List<Vote> GetAllList(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vote>> GetAllListAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<Vote>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public Vote Get(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public Vote Single(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> SingleAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Vote FirstOrDefault(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Vote FirstOrDefault(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> FirstOrDefaultAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Vote Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public Vote Insert(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> InsertAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Vote InsertOrUpdate(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> InsertOrUpdateAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Vote Update(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> UpdateAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Vote Update(Guid id, Action<Vote> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<Vote> UpdateAsync(Guid id, Func<Vote, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    internal class _FakeVoteOptionCrudAppService : IVoteOptionCrudAppService
    {
        #region Balast
        public Task<VoteOptionDto> Get(VoteOptionDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<VoteOptionDto>> GetAll(PagedVoteOptionResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<VoteOptionDto> Create(VoteOptionDto input)
        {
            throw new NotImplementedException();
        }

        public Task<VoteOptionDto> Update(VoteOptionDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(VoteOptionDto input)
        {
            throw new NotImplementedException();
        }

        public Task<VoteOptionDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
#endregion
    }

    internal class FakeVoteContextProvider : IVoteContextProvider
    {
        public Task<string> GetVoteContext(Guid contextId)
        {
            throw new NotImplementedException();
        }
    }
}