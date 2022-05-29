using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;

namespace Kis.Organization
{
    /// <summary>
    /// Профиль, описывающий нестандартные мапинги объектов для AutoMapper
    /// </summary>
    public class OrganizationAutoMapperProfile : AutoMapper.Profile
    {

        public OrganizationAutoMapperProfile()
        {
            CreateMap<OrganizationUnitDto, OrganizationUnit>()
                .ForMember(x => x.OrganizationUnitAddress, x => x.Ignore())
                .ForMember(x => x.Medias, x => x.Ignore());
            CreateMap<CreateOrganizationUnitDto, OrganizationUnitDto>();
            CreateMap<UpdateOrganizationUnitDto, OrganizationUnitDto>();
            CreateMap<OrganizationUnit, OrganizationUnitDto>();
            CreateMap<OrganizationUnitUserDto, OrganizationUnitUser>();
            CreateMap<OrganizationUnitUser, OrganizationUnitUserDto>();
            CreateMap<OrganizationUnitAddressDto, OrganizationUnitAddress>();
            CreateMap<CreateOrganizationUnitAddressDto, OrganizationUnitAddressDto>();
            CreateMap<UpdateOrganizationUnitAddressDto, OrganizationUnitAddressDto>();
            CreateMap<OrganizationUnitAddress, OrganizationUnitAddressDto>();
            CreateMap<OrganizationUnitContactDto, OrganizationUnitContact>();
            CreateMap<OrganizationUnitContact, OrganizationUnitContactDto>();
            CreateMap<OrganizationUnitMediaDto, OrganizationUnitMedia>();
            CreateMap<OrganizationUnitMedia, OrganizationUnitMediaDto>();
            CreateMap<CreateOrganizationUnitMediaDto, OrganizationUnitMediaDto>();

            CreateMap<AccountingDetailsDto, AccountingDetails>();
            CreateMap<AccountingDetails, AccountingDetailsDto>();
            CreateMap<CreateAccountingDetailsDto, AccountingDetailsDto>();
            //   .ForMember(e => e.Header, x => x.MapFrom(d => (Header)d.PersonDto.Entity));
            //CreateMap<PersonDto, Header>()
            //    .ForMember(e => e.Name, x => x.MapFrom(d => d.Name.Trim().ToUpper()))
            //    .ForMember(e => e.Patronymic, x => x.MapFrom(d => d.Patronymic.Trim().ToUpper()))
            //    .ForMember(e => e.Surname, x => x.MapFrom(d => d.Surname.Trim().ToUpper()));
            //CreateMap<PolicyDto, Policy>();
            //CreateMap<PositionAppointmentDto, PositionAppointment>();


        }


    }
}
