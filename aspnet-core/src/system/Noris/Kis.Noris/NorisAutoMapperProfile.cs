using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;

namespace Kis.Hr
{
    /// <summary>
    /// Профиль, описывающий нестандартные мапинги объектов для AutoMapper
    /// </summary>
    public class NorisAutoMapperProfile : AutoMapper.Profile
    {

        public NorisAutoMapperProfile()
        {
            //CreateMap<AddressDto, Address>();
            //CreateMap<ContactDto, Contact>();
            //CreateMap<EmployeeDto, Employee>()
            //   .ForMember(e => e.Person, x => x.MapFrom(d => (Person)d.PersonDto.Entity));
            //CreateMap<PersonDto, Person>()
            //    .ForMember(e => e.Name, x => x.MapFrom(d => d.Name.Trim().ToUpper()))
            //    .ForMember(e => e.Patronymic, x => x.MapFrom(d => d.Patronymic.Trim().ToUpper()))
            //    .ForMember(e => e.Surname, x => x.MapFrom(d => d.Surname.Trim().ToUpper()));
            //CreateMap<PolicyDto, Policy>();
            //CreateMap<PositionAppointmentDto, PositionAppointment>();

            
        }


    }
}
