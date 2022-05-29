using System;
using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.Staff.Api.Dto
{
    public class KarmaDto: BaseDto<Guid>
    {
        /// <summary>
        /// Id сотрудника, которому начисляется карма
        /// </summary>
        public Guid EmployeeId{ get; set; }       

        /// <summary>
        /// Список Id голосов отданных сотрудниками за карму для др. сотрудника
        /// </summary>
        public IList<Guid> KarmaVotesId { get; set; }        

        /// <summary>
        /// Id типа кармы определяющий величину, котрая будет добавлена/вычтена из общей кармы
        /// </summary>
        public Guid KarmaTypeId { get; set; }       

        /// <summary>
        /// Id сотрудника, который добавил карму
        /// </summary>
        public Guid CreatedById { get; set; }        
    }
}