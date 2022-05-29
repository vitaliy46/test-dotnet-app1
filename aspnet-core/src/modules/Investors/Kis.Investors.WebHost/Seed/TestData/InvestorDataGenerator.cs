using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Dependency;
using JetBrains.Annotations;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;

namespace Kis.Investors.WebHost.Seed.TestData
{
    /// <summary>
    /// Генерирует данные используя библиотеку Bogus
    /// </summary>
    public class InvestorDataGenerator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;

        private static Random rnd;

        public InvestorDataGenerator([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));

            rnd = new Random();
        }

        public void Generate()
        {
           
            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            var investorRepository = _iocResolver.Resolve<IInvestorRepository>();
            var count =  investorRepository.GetAllListAsync().Result.Count;
            if (count > 0) return;

            Console.WriteLine($"Начата загрузка тестовых данных типа {typeof(Investor).Name}");

            var investedProjectRepository = _iocResolver.Resolve<IInvestedProjectRepository>();
            var partnershipMemberRepository = _iocResolver.Resolve<IPartnershipMemberRepository>();
            var partnershipMemberCrudService = _iocResolver.Resolve<IPartnershipMemberCrudAppService>();

            var projects = investedProjectRepository.GetAllListAsync().Result;
            var projectIds = projects.Select(p => p.Id).ToList();

            var members = partnershipMemberRepository.GetAllListAsync().Result;
            var memberIds = members.Select(m => m.Id).ToList();
            // Тестовый участник в каждый проект для демонстрации заказчику
            var voteMember = partnershipMemberCrudService.GetAll(new PagedPartnershipMemberResultRequestDto()).Result.Items.FirstOrDefault(p => p.Contactor.Person.PersonUser.User.UserName == "votemember");
            var voteMemberZaplatin = partnershipMemberCrudService.GetAll(new PagedPartnershipMemberResultRequestDto()).Result.Items.FirstOrDefault(p => p.Contactor.Person.PersonUser.User.UserName == "m_zaplatin");
            var voteMemberBerezin = partnershipMemberCrudService.GetAll(new PagedPartnershipMemberResultRequestDto()).Result.Items.FirstOrDefault(p => p.Contactor.Person.PersonUser.User.UserName == "m_berezin");

            //Если хотя бы один список пуст, то создать инвесторов будет невозможно
            var membersCount = members.Count;
            if (projects.Any() && membersCount > 0)
            {
                Investor investor;
                foreach (var projectId in projectIds)
                {
                    // В каждый проект добавить в пределах пяти инвесторов
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(".");
                        investor = new Investor
                        {
                            ProjectId = projectId,
                            MemberId = memberIds[rnd.Next(0, membersCount)],
                            InvestmentShare = rnd.Next(5, 100)
                        };
                        //
                        if (!investorRepository.GetAllListAsync(i => i.MemberId == investor.MemberId && i.ProjectId == projectId).Result.Any())
                        {
                            investorRepository.Insert(investor);
                        }
                    }

                    // В каждый проект добавляем тестового участника для демонстрации заказчику
                    if (voteMember != null)
                    {
                        if (!investorRepository.GetAllListAsync(i => i.MemberId == voteMember.Id && i.ProjectId == projectId).Result.Any())
                        {
                            var voteMemberInvestor = new Investor
                            {
                                ProjectId = projectId,
                                MemberId = voteMember.Id,
                                InvestmentShare = rnd.Next(5, 100)
                            };

                            investorRepository.Insert(voteMemberInvestor);
                        }
                    }

                    // В каждый проект добавляем 2 дополнительных тестовых участников для разработчиков
                    if (voteMemberZaplatin != null)
                    {
                        if (!investorRepository.GetAllListAsync(i => i.MemberId == voteMemberZaplatin.Id && i.ProjectId == projectId).Result.Any())
                        {
                            var voteMemberInvestor = new Investor
                            {
                                ProjectId = projectId,
                                MemberId = voteMemberZaplatin.Id,
                                InvestmentShare = rnd.Next(5, 100)
                            };

                            investorRepository.Insert(voteMemberInvestor);
                        }
                    }

                    if (voteMemberBerezin != null)
                    {
                        if (!investorRepository.GetAllListAsync(i => i.MemberId == voteMemberBerezin.Id && i.ProjectId == projectId).Result.Any())
                        {
                            var voteMemberInvestor = new Investor
                            {
                                ProjectId = projectId,
                                MemberId = voteMemberBerezin.Id,
                                InvestmentShare = rnd.Next(5, 100)
                            };

                            investorRepository.Insert(voteMemberInvestor);
                        }
                    }
                }
            }

            //Логировать факт выгрузки данных
            Console.WriteLine();
            Console.WriteLine($"Данные типа {typeof(Investor).Name} выгружены в БД");
        }
    }
}

