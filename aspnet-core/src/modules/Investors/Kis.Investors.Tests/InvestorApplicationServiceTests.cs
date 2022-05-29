using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kis.Investors.Service.Bl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;
using Kis.Investors.Api.Services.Bl;
using Kis.Investors.Api.Services.Crud;
using Kis.Organization.Api.Dto;
using Moq;

namespace Kis.Investors.Tests
{
    [TestClass]
    public class InvestorApplicationServiceTests
    {
        #region Генерирование тестовых данных

        private InvestedProjectDto GenerateInvestedProject()
        {
            var project = new InvestedProjectDto()
            {
                ProjectId = new Guid("99c15850-5f2c-4532-9359-671bfb794fb9"),
                ManagingCompany = new OrganizationUnitDto()
                {
                    Header = new PersonDto()
                    {
                        Id = new Guid("11673403-5bad-49ba-bc0e-13feed96d8ab"),
                        FullName = "Кузнецов Иван Петрович",
                        Contacts = new List<PersonContactDto>()
                        {
                            new PersonContactDto()
                            {
                                Contact = new ContactDto()
                                {
                                    Id = new Guid("ecfb2dbe-8e4a-4afb-a387-1060897e310a"),
                                    ContactType = ContactTypes.Email,
                                    Value = "123@ya.ru"
                                }
                            }

                        },
                        PersonUser = new PersonUserDto()
                        {
                            UserId = 12345

                        }
                    }
                }
            };

            return project;
        }

        private IList<InvestorDto> GenerateInvestorDtos()
        {
            var project = GenerateInvestedProject();

            var investorDtos = new List<InvestorDto>
            {
                #region Тут список инвесторов

                new InvestorDto()
                {
                    Id = new Guid("a4c6fbf8-6508-41d5-85c5-d1e2d4e5b91f"),
                    Member = new PartnershipMemberDto()
                    {
                        Contactor = new MemberContactorDto()
                        {
                            Person = new PersonDto()
                            {
                                PersonUser = new PersonUserDto()
                                {
                                    Id = new Guid("4bcbdc2d-a07c-4bb4-95e3-448133d525f4"),
                                    UserId = 890


                                },
                                FullName = new string("Синцов Антон Юрьевич"),
                                Surname = new string("Сидоров"),
                                Name = new string("Сидр"),
                                Patronymic = new string("Иванович"),


                            },

                            PersonContact = new PersonContactDto()
                            {
                                Contact = new ContactDto()
                                {
                                    Id = new Guid("e9306811-2272-413b-a7cf-0761d3d21e1f"),
                                    ContactType = ContactTypes.Email,
                                    Value = "2@2.2",
                                }
                            }
                        }

                    },
                    Project = project
                },
                new InvestorDto()
                {
                    Id=new Guid("d701b77b-9b25-43d2-8d45-4b0d29ef14f0"),
                    Member = new PartnershipMemberDto()
                    {
                        Contactor = new MemberContactorDto()
                        {
                            Person = new PersonDto()
                            {
                                PersonUser = new PersonUserDto()
                                {
                                    Id = new Guid("27263136-5d80-4cd6-97b3-75f061db7bbc"),
                                    UserId = 891


                                },
                                FullName = new string("Киркоров Филип Бедросович"),
                                Surname = new string("Сидоров"),
                                Name = new string("Сидр"),
                                Patronymic = new string("Иванович"),


                            },

                            PersonContact = new PersonContactDto()
                            {
                                Contact = new ContactDto()
                                {
                                    Id = new Guid("469ce345-97e8-4c97-9f45-d4303b09f645"),
                                    ContactType = ContactTypes.Email,
                                    Value = "3@3.3",
                                }
                            }
                        }

                    },
                    Project = project
                },
                new InvestorDto()
                {
                    Id = new Guid("857e78fe-2d8e-4d7d-9f83-6f8f6c573615"),
                    Member = new PartnershipMemberDto()
                    {
                        Contactor = new MemberContactorDto()
                        {
                            Person = new PersonDto()
                            {
                                PersonUser = new PersonUserDto()
                                {
                                    Id = new Guid("cbbfe1a0-2085-4186-b788-1a789f6759d9"),
                                    UserId = 892


                                },
                                FullName = new string("Сильвестрова Людмила Ипполитовна"),
                                Surname = new string("Сидоров"),
                                Name = new string("Сидр"),
                                Patronymic = new string("Иванович"),


                            },

                            PersonContact = new PersonContactDto()
                            {
                                Contact = new ContactDto()
                                {
                                    Id = new Guid("98d58ce5-9cf1-4c3e-aecf-0c7be7c94489"),
                                    ContactType = ContactTypes.Email,
                                    Value = "4@4.4",
                                }
                            }
                        }

                    },
                    Project = project
                },
                new InvestorDto()
                {
                    Id = new Guid("292c97db-92b4-4082-97cd-cfea5b269f17"),
                    Member = new PartnershipMemberDto()
                    {
                        Contactor = new MemberContactorDto()
                        {
                            Person = new PersonDto()
                            {
                                PersonUser = new PersonUserDto()
                                {
                                    Id = new Guid("29243973-0a1a-49d9-a97e-701f8f503a8c"),
                                    UserId = 890


                                },
                                FullName = new string("Сидоров Сидр Иванович"),
                                Surname = new string("Сидоров"),
                                Name = new string("Сидр"),
                                Patronymic = new string("Иванович"),


                            },

                            PersonContact = new PersonContactDto()
                            {
                                Contact = new ContactDto()
                                {
                                    Id = new Guid("ad498f56-ca85-416b-8711-07a6438c55f8"),
                                    ContactType = ContactTypes.Email,
                                    Value = "1@1.1",
                                }
                            }
                        }

                    },
                    Project = project
                }

                #endregion
            };

            return investorDtos;
        }

        #endregion

        [TestMethod]
        public void PrepareVoteMembers_GoodMembers_ReturnMembers()
        {
            //Подготовка инструментов и данных
            var mockInvestedProjectCrudAppService = new Mock<IInvestedProjectCrudAppService>();
            mockInvestedProjectCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).ReturnsAsync(GenerateInvestedProject());

            var mockInvestorCrudAppService = new Mock<IInvestorCrudAppService>();
            mockInvestorCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedInvestorRequestDto>())).ReturnsAsync(
                new PagedResultDto<InvestorDto>()
                {
                    Items = (IReadOnlyList<InvestorDto>)GenerateInvestorDtos()
                });
            mockInvestorCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).Returns<Guid>(id => Task.Run(() => GenerateInvestorDtos().FirstOrDefault(x => x.Id == id)));

            var mockPartnershipMemberCrudAppService = new Mock<IPartnershipMemberCrudAppService>();

            var investorApplicationService = new InvestorApplicationService(mockInvestorCrudAppService.Object, mockInvestedProjectCrudAppService.Object, mockPartnershipMemberCrudAppService.Object);

            Guid projectId = new Guid("99c15850-5f2c-4532-9359-671bfb794fb9");

            //Тестирование
            var prepareVoteMembers = investorApplicationService.PrepareVoteMembers(projectId).Result;

            //проверка  результатов теста
            Assert.AreEqual(prepareVoteMembers.Count, 5);
            Assert.AreEqual(prepareVoteMembers[0].Name, "Синцов Антон Юрьевич");
            Assert.AreEqual(prepareVoteMembers[0].UserId, 890); //имеется учетная запись для  члена товарищества
            Assert.AreEqual(prepareVoteMembers.Last().VoteMemberContact.ContactId.ToString(), "ecfb2dbe-8e4a-4afb-a387-1060897e310a"); //если указан email руководителя проектной организации
        }

        [TestMethod]
        public void PrepareVoteMembers_MissingUserId_ReturnException()
        {
            //Подготовка инструментов и данных

            // для вызова исключения, удаляю PersonUser c его Id 

            var investorDtos = GenerateInvestorDtos();

            investorDtos[0].Member.Contactor.Person.PersonUser = null;

            var mockInvestedProjectCrudAppService = new Mock<IInvestedProjectCrudAppService>();
            mockInvestedProjectCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).ReturnsAsync(GenerateInvestedProject());

            var mockInvestorCrudAppService = new Mock<IInvestorCrudAppService>();
            mockInvestorCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedInvestorRequestDto>())).ReturnsAsync(
                new PagedResultDto<InvestorDto>()
                {
                    Items = (IReadOnlyList<InvestorDto>)investorDtos
                });
            mockInvestorCrudAppService.Setup(a => a.Get(It.IsAny<Guid>()))
                .Returns<Guid>(id => Task.Run(() => investorDtos.FirstOrDefault(x => x.Id == id)));

            var mockPartnershipMemberCrudAppService = new Mock<IPartnershipMemberCrudAppService>();

            var investorApplicationService = new InvestorApplicationService(mockInvestorCrudAppService.Object, mockInvestedProjectCrudAppService.Object, mockPartnershipMemberCrudAppService.Object);

            Guid projectId = new Guid("99c15850-5f2c-4532-9359-671bfb794fb9");

            //проверка  результатов теста
            var test = Assert.ThrowsExceptionAsync<DllNotFoundException>(() => investorApplicationService.PrepareVoteMembers(projectId)).Result;
            Assert.AreEqual(test.Message, "не найдена учетная запись для члена товарищества");
        }

        [TestMethod]
        public void PrepareVoteMembers_MissingDirectorEmail_ReturnException()
        {
            //Подготовка инструментов и данных

            // изменю тип контакта для вызова исключения, при проверки наличия e-mail у директора

            var project = GenerateInvestedProject();
            var investorDtos = GenerateInvestorDtos();

            project.ManagingCompany.Header.Contacts[0].Contact.ContactType = ContactTypes.Another;

            var mockInvestedProjectCrudAppService = new Mock<IInvestedProjectCrudAppService>();
            mockInvestedProjectCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).ReturnsAsync(project);

            var mockInvestorCrudAppService = new Mock<IInvestorCrudAppService>();
            mockInvestorCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedInvestorRequestDto>())).ReturnsAsync(
                new PagedResultDto<InvestorDto>()
                {
                    Items = (IReadOnlyList<InvestorDto>)investorDtos
                });
            mockInvestorCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).Returns<Guid>(id => Task.Run(() => investorDtos.FirstOrDefault(x => x.Id == id)));

            var mockPartnershipMemberCrudAppService = new Mock<IPartnershipMemberCrudAppService>();

            var investorApplicationService = new InvestorApplicationService(mockInvestorCrudAppService.Object, mockInvestedProjectCrudAppService.Object, mockPartnershipMemberCrudAppService.Object);

            Guid projectId = new Guid("99c15850-5f2c-4532-9359-671bfb794fb9");

            //проверка  результатов теста
            var test = Assert.ThrowsExceptionAsync<DllNotFoundException>(() => investorApplicationService.PrepareVoteMembers(projectId)).Result;
            Assert.AreEqual(test.Message, "не найден email руководителя проектной организации");
        }

        [TestMethod]
        public void PrepareVoteMembers_MissingDirectorId_ReturnException()
        {
            //Подготовка инструментов и данных

            // для вызова исключения, удаляю PersonUser  у Header (руководителя компании) 

            var project = GenerateInvestedProject();
            var investorDtos = GenerateInvestorDtos();

            project.ManagingCompany.Header.PersonUser = null;

            var mockInvestedProjectCrudAppService = new Mock<IInvestedProjectCrudAppService>();
            mockInvestedProjectCrudAppService.Setup(a => a.Get(It.IsAny<Guid>())).ReturnsAsync(project);

            var mockInvestorCrudAppService = new Mock<IInvestorCrudAppService>();
            mockInvestorCrudAppService.Setup(a => a.GetAll(It.IsAny<PagedInvestorRequestDto>())).ReturnsAsync(
                new PagedResultDto<InvestorDto>()
                {
                    Items = (IReadOnlyList<InvestorDto>)investorDtos
                });
            mockInvestorCrudAppService.Setup(a => a.Get(It.IsAny<Guid>()))
                .Returns<Guid>(id => Task.Run(() => investorDtos.FirstOrDefault(x => x.Id == id)));

            var mockPartnershipMemberCrudAppService = new Mock<IPartnershipMemberCrudAppService>();

            var investorApplicationService = new InvestorApplicationService(mockInvestorCrudAppService.Object, mockInvestedProjectCrudAppService.Object, mockPartnershipMemberCrudAppService.Object);

            Guid projectId = new Guid("99c15850-5f2c-4532-9359-671bfb794fb9");

            //проверка  результатов теста
            var test = Assert.ThrowsExceptionAsync<DllNotFoundException>(() => investorApplicationService.PrepareVoteMembers(projectId)).Result;
            Assert.AreEqual(test.Message, "не найдена учетная запись для руководителя проектной организации");
        }
    }
}