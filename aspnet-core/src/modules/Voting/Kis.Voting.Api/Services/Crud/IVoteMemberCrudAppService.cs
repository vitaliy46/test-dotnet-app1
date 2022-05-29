using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.VoteMember;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteMemberCrudAppService : IAsyncCrudAppServiceBase<VoteMemberDto, Guid, PagedVoteMemberResultRequestDto, VoteMemberDto, VoteMemberDto, VoteMemberDto, VoteMemberDto>
    {
        /// <summary>
        /// Сохраняет изменения в составе учасников  голосования.
        /// Список учасников может изменяться (пополняться или уменьшаться)
        /// Поэтому внутри этого метода нужно добавлять новых и удалять отсутсвующих
        /// в списке участников голосования
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<VoteMemberDto> SaveVoteMembersAsync(IList<VoteMemberDto> members);
    }  
}
