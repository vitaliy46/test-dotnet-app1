using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Authorization.Users;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;
using Kis.Users;
using Kis.Users.Dto;

namespace Kis.General.Services.Crud
{
    public class OneTimePasswordCrudAppService : AsyncCrudAppServiceBase<
        OneTimePassword, OneTimePasswordDto, Guid, PagedOneTimePasswordResultRequestDto, OneTimePasswordDto, OneTimePasswordDto, OneTimePasswordDto, OneTimePasswordDto>, IOneTimePasswordCrudAppService
    {
        public OneTimePasswordCrudAppService(
            [NotNull] IRepository<OneTimePassword, Guid> repository) : base(repository)

        {
        }

        protected override IQueryable<OneTimePassword> CreateFilteredQuery(PagedOneTimePasswordResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.Id != null)
            {
                query = query.Where(x => x.Id == input.Id);
            }

            if (input.UserId != null)
            {
                query = query.Where(x => x.UserId == input.UserId);
            }

            if (input.Confirmed != null)
            {
                query = query.Where(x => x.Confirmed == input.Confirmed);
            }

            return query;
        }
    }
}
