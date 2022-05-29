using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using System.Linq;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.Users.Dto;

namespace Kis.General
{
    public class GeneralAutoMapperProfile : AutoMapper.Profile
    {
        public GeneralAutoMapperProfile()
        {
            CreateMap<CreateAddressDto, AddressDto>();
            CreateMap<UpdateAddressDto, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();
            CreateMap<DocumentDto, Document>();
            CreateMap<Document, DocumentDto>();
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact, ContactDto>();
            CreateMap<CreateContactDto, ContactDto>();
            CreateMap<UpdateContactDto, ContactDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CreateCommentDto, CommentDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentLinkDto, CommentLink>()
                .ForMember(x => x.Link, x => x.Ignore());
            CreateMap<CommentLink, CommentLinkDto>();
            CreateMap<CommentMediaDto, CommentMedia>()
                .ForMember(x => x.Media, x => x.Ignore());
            CreateMap<CommentMedia, CommentMediaDto>();
            CreateMap<CreatePersonDto, PersonDto>();
            CreateMap<UpdatePersonDto, PersonDto>();
            CreateMap<PersonDto, Person>()
                .ForMember(e => e.Name, x => x.MapFrom(d => d.Name.Trim()))
                .ForMember(e => e.Patronymic, x => x.MapFrom(d => d.Patronymic.Trim()))
                .ForMember(e => e.Surname, x => x.MapFrom(d => d.Surname.Trim()))
                .ForMember(e => e.Contacts, x => x.Ignore())
                .ForMember(e => e.Policies, x => x.Ignore());
            CreateMap<Person, PersonDto>()
                .ForMember(d => d.Name, x => x.MapFrom(e => e.Name))
                .ForMember(d => d.Patronymic, x => x.MapFrom(e => e.Patronymic))
                .ForMember(d => d.Surname, x => x.MapFrom(e => e.Surname))
                //.ForMember(d => d.Contacts, x => x.MapFrom(e => e.Contacts.Select(c => c.Id).ToList()))
                .ForMember(d => d.Policies, x => x.MapFrom(e => e.Policies.Select(p => p.Id).ToList()));
            CreateMap<CreatePersonContactDto, PersonContactDto>();
            CreateMap<UpdatePersonContactDto, PersonContactDto>();
            CreateMap<PersonContactDto, PersonContact>()
                .ForMember(x => x.Contact, x => x.Ignore());
            CreateMap<PersonContact, PersonContactDto>();
            CreateMap<PersonAddressDto, PersonAddress>()
                .ForMember(x => x.Address, x => x.Ignore());
            CreateMap<PersonAddress, PersonAddressDto>();
            CreateMap<PersonUser, PersonUserDto>();
            CreateMap<PersonUserDto, PersonUser>()
               .ForMember(x=>x.Person, x=>x.Ignore());
            CreateMap<CreatePersonUserDto, PersonUserDto>();
            CreateMap<UpdatePersonUserDto, PersonUserDto>();
            CreateMap<PolicyDto, Policy>();
            CreateMap<Policy, PolicyDto>();
            CreateMap<LinkDto, Link>();
            CreateMap<Link, LinkDto>();
            CreateMap<MediaDto, Media>();
            CreateMap<Media, MediaDto>();
            CreateMap<CreateMediaDto, MediaDto>();
            CreateMap<MediaTypeDto, MediaType>();
            CreateMap<MediaType, MediaTypeDto>();
            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();
            CreateMap<CreateStateDto, StateDto>();
            CreateMap<UpdateStateDto, StateDto>();
            CreateMap<StateTransition, StateTransitionDto>();
            CreateMap<StateTransitionDto, StateTransition>();
            CreateMap<Workflow, WorkflowDto>();
            CreateMap<WorkflowDto, Workflow>();
            CreateMap<CreateOneTimePasswordDto, OneTimePasswordDto>();
            CreateMap<OneTimePasswordDto, OneTimePassword>();
            CreateMap<OneTimePassword, OneTimePasswordDto>();
            CreateMap<CreateUserDto, UserDto>();

            //TODO После перехода на нормальные Crud сервисы пожно удалить
            CreateMap<PersonUserDto, CreatePersonUserDto>();
            CreateMap<UserDto, CreateUserDto>()
                .ForMember(x=> x.Password, x=>x.MapFrom(y=> y.UserName));
        }
    }
}
