using System;
using Kis.Base.Dto;

namespace Kis.Staff.Api.Dto
{
    public class KarmaVoteDto : BaseDto<Guid>
    {
        /// <summary>
        /// Id сотрудника, который голосует за карму
        /// </summary>       
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Id кармы за которую голосует сотрудник
        /// </summary>
        public Guid KarmaId { get; set; }
    }
}