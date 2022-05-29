using System;
using System.Linq;
using Abp.AutoMapper;
using Abp.Dependency;
using AutoMapper;
using Castle.Core.Logging;
using JetBrains.Annotations;
using Kis.General.Api.Constant;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Dto.InvestedProject;
using Kis.Investors.Api.Entity;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.Investors
{
    /// <summary>
    /// Профиль, описывающий нестандартные мапинги объектов для AutoMapper
    /// </summary>
    public class InvestorsAutoMapperProfile : AutoMapper.Profile
    {
        public IocManager IocManager { get; set; }
        public ILogger Logger { get; set; }

        public InvestorsAutoMapperProfile()
        {
            CreateMap<CreateInvestorDto, InvestorDto>();
            CreateMap<UpdateInvestorDto, InvestorDto>();
            CreateMap<InvestorForProjectDto, InvestorDto>();
            CreateMap<InvestorDto, InvestorForProjectDto>()
                .ForMember(x => x.MemberName, x => x.MapFrom(y => y.Member.Organization.Name))
                .ForMember(x => x.HeaderFullName, x => x.MapFrom(y => y.Member.Organization.Header.FullName));
            CreateMap<InvestorDto, InvestorsProjectDto>()
                .ForMember(x => x.InvestedProjectName, x => x.MapFrom(y => y.Project.Project.Title))
                .ForMember(x => x.InvestedProjectId, x => x.MapFrom(y => y.Project.Id))
                .ForMember(x => x.OrganizationUnitMediaId,
                    x => x.MapFrom(y =>
                        y.Member.Organization.Medias.FirstOrDefault(o =>
                            o.Media.Label == "inn") != null ?
                            (Guid?)y.Member.Organization.Medias.FirstOrDefault(o => o.Media.Label == "inn").Id : null
                    ));
            CreateMap<InvestorDto, Investor>()
                .ForMember(x => x.Member, x => x.Ignore())
                .ForMember(x => x.Project, x => x.Ignore());
            CreateMap<Investor, InvestorDto>();

            CreateMap<CreateInvestedProjectDto, InvestedProjectDto>();
          
            CreateMap<InvestedProjectDto, InvestedProjectShortDto>()
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Project.Title))
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Project.Description))
                .ForMember(x => x.StateName, x => x.MapFrom(y => y.Project.ProjectState.State.Name));
            CreateMap<InvestedProject, InvestedProjectDto>();
            CreateMap<InvestedProjectDto, InvestedProject>();
            CreateMap<InvestedProjectDto, PlaneInvestedProjectDto>()
                .ForMember(x => x.Address, x => x.MapFrom(y => y.ManagingCompany.OrganizationUnitAddress.Address.FullAddress))
                .ForMember(x => x.CompanyName, x => x.MapFrom(y => y.ManagingCompany.Name))
                .ForMember(x => x.HeaderFio, x => x.MapFrom(y => y.ManagingCompany.Header.FullName))
                .ForMember(x => x.Inn, x => x.MapFrom(y => y.ManagingCompany.AccountingDetails.Inn))
                .ForMember(x => x.Ogrn, x => x.MapFrom(y => y.ManagingCompany.AccountingDetails.Ogrn))
                .ForMember(x => x.Phone, x => x.MapFrom(y => 
                    y.ManagingCompany.Header.Contacts
                    .FirstOrDefault(d=> d.Contact.ContactType == ContactTypes.MobilePhone
                    || d.Contact.ContactType == ContactTypes.Phone).Contact.Value))
                .ForMember(x => x.PhoneId, x => x.MapFrom(y =>
                    y.ManagingCompany.Header.Contacts
                        .FirstOrDefault(d => d.Contact.ContactType == ContactTypes.MobilePhone
                                             || d.Contact.ContactType == ContactTypes.Phone).Contact.Id))
                .ForMember(x => x.Mail, x => x.MapFrom(y =>
                    y.ManagingCompany.Header.Contacts
                        .FirstOrDefault(d => d.Contact.ContactType == ContactTypes.Email).Contact.Value))
                .ForMember(x => x.MailId, x => x.MapFrom(y =>
                    y.ManagingCompany.Header.Contacts
                        .FirstOrDefault(d => d.Contact.ContactType == ContactTypes.Email).Contact.Id))
                .ForMember(x => x.ProjectDescription, x => x.MapFrom(y => y.Project.Description))
                .ForMember(x => x.ProjectTitle, x => x.MapFrom(y => y.Project.Title))
                .ForMember(x => x.ProjectStateId, x => x.MapFrom(y => y.Project.ProjectStateId));
            CreateMap<PlaneInvestedProjectDto, InvestedProjectDto>()
                .ForPath(x => x.Project.Description, d => d.MapFrom(y => y.ProjectDescription))
                .ForPath(x => x.Project.Title, d => d.MapFrom(y => y.ProjectTitle))
                .ForPath(x => x.Project.ProjectStateId, d => d.MapFrom(y => y.ProjectStateId))
                .ForPath(x => x.ManagingCompany.Name, d => d.MapFrom(y => y.CompanyName))
                .ForPath(x => x.ManagingCompany.AccountingDetails.Inn, d => d.MapFrom(y => y.Inn))
                .ForPath(x => x.ManagingCompany.AccountingDetails.Ogrn, d => d.MapFrom(y => y.Ogrn))
                .ForPath(x => x.ManagingCompany.OrganizationUnitAddress.Address.FullAddress, d => d.MapFrom(y => y.Address))
                .ForPath(x => x.ManagingCompany.Header.FullName, d => d.MapFrom(y => y.HeaderFio));
            CreateMap<PlaneCreateInvestedProjectDto, InvestedProjectDto>()
                .ForPath(x => x.Project.Description, d => d.MapFrom(y => y.ProjectDescription))
                .ForPath(x => x.Project.Title, d => d.MapFrom(y => y.ProjectTitle))
                .ForPath(x => x.Project.ProjectStateId, d => d.MapFrom(y => y.ProjectStateId))
                .ForPath(x => x.ManagingCompany.Name, d => d.MapFrom(y => y.CompanyName))
                .ForPath(x => x.ManagingCompany.AccountingDetails.Inn, d => d.MapFrom(y => y.Inn))
                .ForPath(x => x.ManagingCompany.AccountingDetails.Ogrn, d => d.MapFrom(y => y.Ogrn))
                .ForPath(x => x.ManagingCompany.OrganizationUnitAddress.Address.FullAddress, d => d.MapFrom(y => y.Address))
                .ForPath(x => x.ManagingCompany.Header.FullName, d => d.MapFrom(y => y.HeaderFio));
            CreateMap<CreateMemberContactorDto, MemberContactorDto>();
            CreateMap<UpdateMemberContactorDto, MemberContactorDto>();
            CreateMap<MemberContactorDto, MemberContactor>()
                .ForMember(x => x.PartnershipMember, x => x.Ignore());
            CreateMap<MemberContactor, MemberContactorDto>();

            CreateMap<PartnershipDto, Partnership>();
            CreateMap<Partnership, PartnershipDto>();
            CreateMap<CreatePartnershipDto, PlanePartnershipDto>();
            CreateMap<PartnershipDto, PlanePartnershipDto>()
                .ForMember(x=> x.OrganizationName, x=>x.MapFrom(y=>y.Organization.Name));
            CreateMap<PlanePartnershipDto, PartnershipDto>()
                .ForPath(x => x.Organization.Name, x => x.MapFrom(y => y.OrganizationName));

            CreateMap<PlanePartnershipMemberDto, PartnershipMemberDto>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.Organization, x => x.Ignore())
                .ForMember(x => x.OrganizationId, x => x.Ignore())
                .ForPath(x => x.Organization.Name, x => x.MapFrom(y => y.Name))
                .ForPath(x => x.Organization.AccountingDetails.Inn, x => x.MapFrom(y => y.Inn))
                .ForPath(x => x.Organization.AccountingDetails.Ogrn, x => x.MapFrom(y => y.Ogrn))
                .ForPath(x => x.Organization.OrganizationUnitAddress.Address.FullAddress,
                    x => x.MapFrom(y => y.Address))
                .ForPath(x => x.Organization.Header.FullName, x => x.MapFrom(y => y.HeaderFio))
                .ForMember(x => x.Contactor, x => x.Ignore())
                .ForPath(x => x.Contactor.PersonContact.Contact.Value, x => x.MapFrom(y => y.Mail))
                .ForPath(x => x.Contactor.PersonContact.Contact.ContactType, x => x.MapFrom(y => ContactTypes.Email))
                .ForPath(x => x.Contactor.Person.FullName, x => x.MapFrom(y => y.ContactorFio));
            CreateMap<PartnershipMemberShortDto, PartnershipMemberDto>();
            CreateMap<PartnershipMemberDto, PartnershipMemberShortDto>()
                .ForMember(x => x.OrganizationName, x => x.MapFrom(y => y.Organization.Name))
                .ForMember(x => x.ContactorName, x => x.MapFrom(y => y.Contactor.Person.FullName));
            CreateMap<CreatePartnershipMemberDto, PlanePartnershipMemberDto>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.MailId, x => x.Ignore())
                .ForMember(x => x.PhoneId, x => x.Ignore());
            CreateMap<PartnershipMemberDto, PartnershipMember>();
            CreateMap<PartnershipMemberDto, PartnershipMemberShortDto>();
            CreateMap<PartnershipMemberDto, PlanePartnershipMemberDto>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Organization.Name))
                .ForMember(x => x.Inn, x => x.MapFrom(y => y.Organization.AccountingDetails.Inn))
                .ForMember(x => x.Ogrn, x => x.MapFrom(y => y.Organization.AccountingDetails.Ogrn))
                .ForMember(x => x.Address,
                    x => x.MapFrom(y => y.Organization.OrganizationUnitAddress.Address.FullAddress))
                .ForMember(x => x.HeaderFio, x => x.MapFrom(y => y.Organization.Header.FullName))
                .ForMember(x => x.Mail,
                    x => x.MapFrom(y =>
                        y.Contactor.PersonContact.Contact.Value))
                .ForMember(x => x.MailId, x => x.MapFrom(y => y.Contactor.PersonContact.Id))
                .ForMember(x => x.Phone,
                    x => x.MapFrom(y =>
                        y.Organization.Header.Contacts.FirstOrDefault(c => c.Contact.ContactType == ContactTypes.Phone).Contact.Value))
                .ForMember(x => x.PhoneId, x => x.MapFrom(y =>
                    y.Organization.Header.Contacts.FirstOrDefault(c => c.Contact.ContactType == ContactTypes.Phone).Id))
                .ForMember(x => x.Login, x => x.MapFrom(y => y.Contactor.Person.PersonUser.User.UserName))
                .ForMember(x => x.ContactorFio, x => x.MapFrom(y => y.Contactor.Person.FullName));
           CreateMap<PartnershipMember, PartnershipMemberDto>();
        }


    }
}
