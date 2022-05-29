using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.BackgroundJobs;
using Abp.Runtime.Session;
using Abp.TestBase;
using Abp.TestBase.Runtime.Session;
using Kis.Crypto.Api.Services;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Bl;
using Kis.Tests;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Service.Bl;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Kis.Voting.Tests
{
    /// <summary>
    /// модульные тесты для метода посдчета процента проголосовавших GetVotedPercent класса VotingApplicationService.cs 
    /// 1 тест результат голосования должен быть 80%
    /// </summary>
    [TestClass]
    public class VotingApplicationServiceTests : AbpIntegratedTestBase<VoteTestModule>
    {
        private IVotingApplicationService _votingApplicationService;

        public static BulletinDto _input = new BulletinDto() // эти данные для метода Voted() чтобы добраться до метода GetVotedPercent(input.VoteId)
        {
            VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e"),
            BulletinSelectedOptions = new List<BulletinSelectedOptionDto>
            {
                new BulletinSelectedOptionDto
                {
                    SelectedOptionId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e44"),
                }
            }

        };

        public static IList<Bulletin> Bulletins = new List<Bulletin> // эти данные для метода Voted() чтобы добраться до метода GetVotedPercent(input.VoteId)
        {
            #region Список бюллетеней с голосованием

            

            
          new Bulletin()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e"),
                BulletinSelectedOptions = new List<BulletinSelectedOption>   // в этом бюллетене проголосавали за 1 вариант ответа и 2
                {
                    new BulletinSelectedOption()
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    },
                    new BulletinSelectedOption()
                    {
                        SelectedOptionId = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd")
                    },


                }

            },
            new Bulletin()
            {
                 VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e"),
                BulletinSelectedOptions = new List<BulletinSelectedOption>// в этом бюллетене проголосвали  за 2 вариант и 3
                {
                    new BulletinSelectedOption()
                    {
                        SelectedOptionId = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd")
                    },
                    new BulletinSelectedOption()
                    {
                        SelectedOptionId = new Guid("53f300bc-56d6-4504-8712-75ffa59cc053")
                    }
                }
            },

            new Bulletin()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e"),
                BulletinSelectedOptions = new List<BulletinSelectedOption>
                {
                    new BulletinSelectedOption()// в этом проголосовали за 1 вариант
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    }
                }
            },

            new Bulletin()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e"),
                BulletinSelectedOptions = new List<BulletinSelectedOption>
                {
                    new BulletinSelectedOption()// в этом проголосовали за 1 вариант
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    }
                }
            },
            new Bulletin()  // просто левая бюллетень
            {
                VoteId = new Guid("97c49dd5-5cdd-4207-85c8-804115139138"),
                BulletinSelectedOptions = new List<BulletinSelectedOption>
                {
                    new BulletinSelectedOption()
                    {
                        SelectedOptionId = new Guid("a0188dc0-cca2-496d-8452-68b2fb182e0d")
                    }
                }
            },
            #endregion
        };

        public static IList<VoteMember> VoteMembers = new List<VoteMember> //репозиторий участников голосований
        {
            #region репозиторий участников голосований

            

            
            new VoteMember()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
            },
            new VoteMember()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
            },
            new VoteMember()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
            },
            new VoteMember()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
            },
            new VoteMember()
            {
                VoteId = new Guid("cdc41c1e-a504-4987-9437-7e55c9179d8c")
            },
            new VoteMember()
            {
                VoteId = new Guid("81985741-0e4f-4f45-81af-19c19b07cae9")
            },
            new VoteMember()
            {
                VoteId = new Guid("fef8540c-4a47-4b3c-bfe0-e2bccf97a8db")
            },
            new VoteMember()
            {
                VoteId = new Guid("c788abf9-d8d8-4945-9895-6e79775d0482")
            },
            new VoteMember()
            {
                VoteId = new Guid("cdc41c1e-a504-4987-9437-7e55c9179d8c")
            },
            new VoteMember()
            {
                VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
            },

            #endregion
        };

        [TestMethod]
        public void GetVotedPercent_Voted_PercentVoited()
        {
            //https://stackoverflow.com/questions/1877225/how-do-i-unit-test-a-controller-method-that-has-the-authorize-attribute-applie
            //var controller = new UserController();
            //var mock = new Mock<ControllerContext>();
            //mock.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("admin");
            //mock.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
            //controller.ControllerContext = mock.Object;

            //Подготовка инструментов и данных
            var mockVoteCrudAppService = new Mock<IVoteCrudAppService>();
            var mockBulletinCrudAppService = new Mock<IBulletinCrudAppService>();
            mockBulletinCrudAppService.Setup(a => a.Create(It.IsAny<BulletinDto>()))
                .ReturnsAsync(VotingApplicationServiceTests._input);
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(() => new PagedResultDto<BulletinDto>() { Items = new List<BulletinDto>() });
            var mockVoteResultCrudAppService = new Mock<IVoteResultCrudAppService>();
            var mockBulletinRepository = new Mock<IBulletinRepository>();
            mockBulletinRepository.Setup(a => a.GetAllListAsync(It.IsAny<Expression<Func<Bulletin, bool>>>()))
                .Returns<Expression<Func<Bulletin, bool>>>(predicate => Task.Run(() => Bulletins.AsQueryable().Where(predicate).ToList()));
            var mockVoteMemberRepository = new Mock<IVoteMemberRepository>();
            mockVoteMemberRepository.Setup(a => a.GetAllListAsync(It.IsAny<Expression<Func<VoteMember, bool>>>()))
                .Returns<Expression<Func<VoteMember, bool>>>(predicate => Task.Run(() => VoteMembers.AsQueryable().Where(predicate).ToList()));
            var mockVoteCalculatorQualifier = new Mock<IVoteCalculatorQualifier>();
            var mockBackgroundJobManager = new Mock<IBackgroundJobManager>();
            var mockVoteMemberCrudAppService = new Mock<IVoteMemberCrudAppService>();
            mockVoteMemberCrudAppService.Setup(a => a.Get(It.IsAny<Guid>()))
                .ReturnsAsync(() => new VoteMemberDto
                {
                    Name = "Кристофер",
                    VoteMemberContact = new VoteMemberContactDto
                    {
                        Contact = new ContactDto
                        {
                            Value = "8 9089478984",
                            ContactType = ContactTypes.Telegram
                        }
                    },
                    UserId = 0,
                    VoteId = new Guid("7a8f68fb-349d-496a-a446-9784410e8e9e")
                });
            var mockVoteMembersProvider = new Mock<IVoteMembersProvider>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockOneTimePasswordAppService = new Mock<IOneTimePasswordAppService>();
            var mockCryptoProvaier = new Mock<ICryptoProvider>();
            var mocVoteReportCrudAppService = new Mock<IVoteReportCrudAppService>();




            using (AbpSession.Use(1, 0))
            {
                _votingApplicationService = new VotingApplicationService(
                        mockVoteCrudAppService.Object,
                        mockBulletinCrudAppService.Object,
                        mockVoteResultCrudAppService.Object,
                        mockBulletinRepository.Object,
                        mockVoteMemberRepository.Object,
                        mockVoteCalculatorQualifier.Object,
                        mockBackgroundJobManager.Object,
                        mockVoteMemberCrudAppService.Object,
                        mockVoteMembersProvider.Object,
                        mockConfiguration.Object,
                        mockOneTimePasswordAppService.Object,
                        mockCryptoProvaier.Object,
                        mocVoteReportCrudAppService.Object
                    )
                { AbpSession = AbpSession };

                Guid token = Guid.NewGuid();

                //Тестирование

                var _percent = _votingApplicationService.Voted(_input).Result.votersPersent;

                //проверка  результатов теста
                Assert.AreEqual(_percent, 80);
            }
        }



    }


}
