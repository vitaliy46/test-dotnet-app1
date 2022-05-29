using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;

namespace Kis.Hr
{
    /// <summary>
    /// Профиль, описывающий нестандартные мапинги объектов для AutoMapper
    /// </summary>
    public class HrAutoMapperProfile : AutoMapper.Profile
    {

        public HrAutoMapperProfile()
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

            CreateMap<KarmaType, KarmaTypeDto>().ReverseMap();

            CreateMap<Karma, KarmaDto>()
                .ForMember(s => s.EmployeeId, x => x.MapFrom(d => d.Employee.Id))
                .ForMember(s => s.CreatedById, x => x.MapFrom(d => d.CreatedBy.Id))
                .ForMember(s => s.KarmaTypeId, x => x.MapFrom(d => d.KarmaType.Id));

            //временные мапинги
            CreateMap<KarmaVote, KarmaVoteDto>().ReverseMap();
            CreateMap<Candidate, CandidateDto>().ReverseMap();
        }


    }
}
