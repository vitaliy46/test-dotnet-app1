using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Hangfire.Annotations;
using Kis.Base.Utilities;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Services.Bl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Kis.Voting.Tests
{
    /// <summary>
    ///  Модульные тесты для класса MajorityVoteCalculator.cs.
    /// 1 тест вывод результата успешного голосования
    /// 2 тест вывод результата на несостоявшийся кворум
    /// 3 тест вывод результата на не набранный минимальный процент голосов для принятия решения
    /// </summary>

    [TestClass]
    public class MajorityVoteCalculatorTests
    {
        public static VoteDto _vote = new VoteDto()
        {
            Id = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
            QuorumPct = 50, // минимально допустимый процент участников для свершения голосования
            DecisionMakersPct = 50, //Минимально допустимый процент голосов принимающих решения

            Options = new List<VoteOptionDto>()
            {
                new VoteOptionDto()  // варианты ответов при голосовании
                {
                    Id = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                },
                new VoteOptionDto()
                {
                    Id = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd")
                },
                new VoteOptionDto()
                {
                    Id = new Guid("53f300bc-56d6-4504-8712-75ffa59cc053")
                }
               
            }
        
        };

        public static IList<BulletinDto> BulletinDtos = new List<BulletinDto> //список бюллетеней с голосованием
        {
            new BulletinDto()
            {
                VoteId = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>   // в этом бюллетене проголосавали за 1 вариант ответа и 2
                {
                    new BulletinSelectedOptionDto() 
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    },
                    new BulletinSelectedOptionDto()  
                    {
                        SelectedOptionId = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd")
                    },
                   
                    
                }

            },
            new BulletinDto()
            {
                 VoteId = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>// в этом бюллетене проголосвали  за 2 вариант и 3
                {
                    new BulletinSelectedOptionDto()  
                    {
                        SelectedOptionId = new Guid("2becc3bb-bb14-4142-9495-76249e41e3cd")
                    },
                    new BulletinSelectedOptionDto()
                    {
                        SelectedOptionId = new Guid("53f300bc-56d6-4504-8712-75ffa59cc053")
                    }
                }
            },

            new BulletinDto()
            {
                VoteId = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>
                {
                    new BulletinSelectedOptionDto()// в этом проголосовали за 1 вариант
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    }
                }
            },

            new BulletinDto()
            {
                VoteId = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>
                {
                    new BulletinSelectedOptionDto()// в этом проголосовали за 1 вариант
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    }
                }
            },
        };
        private MajorityVoteCalculator _majorityVoteCalculator ;

        // голосование состоялось
        [TestMethod] 
        public void Calculate_VotePass_ReturnVoteResult()
        {

            //Подготовка инструментов и данных
            var mockBulletinCrudAppService= new Mock<IBulletinCrudAppService>();
          
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>) MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct = 50; //

            //Тестирование
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);
            //проверка  результатов теста
            Assert.AreEqual(calculated.TextResult, "голосование : решение принято с вариантом: , количество голосов: 3");
        }

        // кворума не состоялось, для проведения голосования
        [TestMethod]
        public void Calculate_FailQuorum_ReturnVoteResult()
        {

            //Подготовка инструментов и данных
           
            var mockBulletinCrudAppService = new Mock<IBulletinCrudAppService>();
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>)MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct =40; //
            
            //Тестирование
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);

            //проверка  результатов теста
           Assert.AreEqual(calculated.TextResult, "голосование  не состоялось, т.к. процент проголосовавших 40% менее 50%");
        }

        // голосование не состоялось, не набран минимальный процент голосов для принятия решения
        [TestMethod]
        public void Calculate_SmallСountMaxVotesPercent_ReturnVoteResult()
        {

            //Подготовка инструментов и данных
            var mockBulletinCrudAppService = new Mock<IBulletinCrudAppService>();
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>)MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct = 50; //
            _vote.DecisionMakersPct = 60;// 


            //Тестирование
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);
            //проверка  результатов теста
            Assert.AreEqual(calculated.TextResult, "голосование : решение не принято, вариант:  с наибольшим количеством голосов: 3");
        }

    }

 
}
