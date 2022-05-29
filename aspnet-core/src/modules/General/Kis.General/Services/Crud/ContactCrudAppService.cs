using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class ContactCrudAppService : AsyncCrudAppServiceBase<Contact, ContactDto, Guid>, IContactCrudAppService
    {
        public ContactCrudAppService([NotNull]IRepository<Contact, Guid> repository) : base(repository)
        {
        }
    }
    
}
