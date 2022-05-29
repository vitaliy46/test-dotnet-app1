using System;
using System.IO;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Runtime.Session;
using JetBrains.Annotations;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using Kis.Investors.Api.Services.Crud;
using Kis.Investors.WebHost.Seed.TestData;
using Kis.Investors.WebHost.TestData;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.ProjectState;
using Kis.TaskTrecker.Api.Entity;
using Kis.TaskTrecker.Api.Services;

namespace Kis.Investors.WebHost.Seed
{
    public  class SeedHelper : ApplicationService
    {
        private static string _path = Path.Join("Seed","TestData");
        private readonly IIocManager _iocManager;
        private readonly IAbpSession _session;

        public SeedHelper(IIocManager iocManager, [NotNull] IAbpSession session)
        {
            _iocManager = iocManager;
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void SeedDb()
        {
            using (_session.Use(1, 2))
            {
                var dc = new DataCreator(_iocManager);

                dc.Create<CreateStateDto, StateDto,
                        PagedStateResultRequestDto, IStateCrudAppService,
                        IStateRepository, State>
                    (Path.Join(_path, "CreateState.json"));

                dc.Create<CreateProjectStateDto, ProjectStateDto,
                        PagedProjectStateResultRequestDto, IProjectStateCrudAppService,
                        IProjectStateRepository, ProjectState>
                    (Path.Join(_path, "CreateProjectState.json"));

                dc.Create<CreateInvestedProjectDto, InvestedProjectDto,
                        PagedInvestedProjectResultRequestDto, IInvestedProjectCrudAppService,
                        IInvestedProjectRepository, InvestedProject>
                    (Path.Join(_path, "CreateInvestedProject.json"));

                new PartnershipMemberDataGenerator(_iocManager).Create(Path.Join(_path, "CreatePartnershipMember.json"));

                new InvestorDataGenerator(_iocManager).Generate();

                new VoteDataGenerator(_iocManager, Path.Join(_path, "CreateVote.json")).Generate();

                //new BulletinDataGenerator(_iocManager).Generate();

                new PartnershipDataGenerator(_iocManager).Generate();
            }

            Console.WriteLine("Тестовые данные полностью успешно выгружены БД");
        }
    }
}
