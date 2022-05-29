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
    ///  ��������� ����� ��� ������ MajorityVoteCalculator.cs.
    /// 1 ���� ����� ���������� ��������� �����������
    /// 2 ���� ����� ���������� �� �������������� ������
    /// 3 ���� ����� ���������� �� �� ��������� ����������� ������� ������� ��� �������� �������
    /// </summary>

    [TestClass]
    public class MajorityVoteCalculatorTests
    {
        public static VoteDto _vote = new VoteDto()
        {
            Id = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
            QuorumPct = 50, // ���������� ���������� ������� ���������� ��� ��������� �����������
            DecisionMakersPct = 50, //���������� ���������� ������� ������� ����������� �������

            Options = new List<VoteOptionDto>()
            {
                new VoteOptionDto()  // �������� ������� ��� �����������
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

        public static IList<BulletinDto> BulletinDtos = new List<BulletinDto> //������ ���������� � ������������
        {
            new BulletinDto()
            {
                VoteId = new Guid("7f1c0034-6f05-41be-92b9-4e068b90c550"),
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>   // � ���� ��������� ������������� �� 1 ������� ������ � 2
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
                BulletinSelectedOptions = new List<BulletinSelectedOptionDto>// � ���� ��������� ������������  �� 2 ������� � 3
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
                    new BulletinSelectedOptionDto()// � ���� ������������� �� 1 �������
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
                    new BulletinSelectedOptionDto()// � ���� ������������� �� 1 �������
                    {
                        SelectedOptionId = new Guid("03c38460-7285-478d-872e-ebb4ebdd61bd")
                    }
                }
            },
        };
        private MajorityVoteCalculator _majorityVoteCalculator ;

        // ����������� ����������
        [TestMethod] 
        public void Calculate_VotePass_ReturnVoteResult()
        {

            //���������� ������������ � ������
            var mockBulletinCrudAppService= new Mock<IBulletinCrudAppService>();
          
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>) MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct = 50; //

            //������������
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);
            //��������  ����������� �����
            Assert.AreEqual(calculated.TextResult, "����������� : ������� ������� � ���������: , ���������� �������: 3");
        }

        // ������� �� ����������, ��� ���������� �����������
        [TestMethod]
        public void Calculate_FailQuorum_ReturnVoteResult()
        {

            //���������� ������������ � ������
           
            var mockBulletinCrudAppService = new Mock<IBulletinCrudAppService>();
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>)MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct =40; //
            
            //������������
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);

            //��������  ����������� �����
           Assert.AreEqual(calculated.TextResult, "�����������  �� ����������, �.�. ������� ��������������� 40% ����� 50%");
        }

        // ����������� �� ����������, �� ������ ����������� ������� ������� ��� �������� �������
        [TestMethod]
        public void Calculate_Small�ountMaxVotesPercent_ReturnVoteResult()
        {

            //���������� ������������ � ������
            var mockBulletinCrudAppService = new Mock<IBulletinCrudAppService>();
            mockBulletinCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedBulletinResultRequestDto>()))
                .ReturnsAsync(new PagedResultDto<BulletinDto>()
                {
                    Items = (IReadOnlyList<BulletinDto>)MajorityVoteCalculatorTests.BulletinDtos
                });
            _majorityVoteCalculator = new MajorityVoteCalculator(mockBulletinCrudAppService.Object);
            float _factQuorumPct = 50; //
            _vote.DecisionMakersPct = 60;// 


            //������������
            var calculated = _majorityVoteCalculator.Calculate(_vote, _factQuorumPct);
            //��������  ����������� �����
            Assert.AreEqual(calculated.TextResult, "����������� : ������� �� �������, �������:  � ���������� ����������� �������: 3");
        }

    }

 
}
