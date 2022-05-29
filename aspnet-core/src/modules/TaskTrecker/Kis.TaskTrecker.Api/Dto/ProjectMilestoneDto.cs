using System;
using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Веха или стадия развития проекта
    /// </summary>
    public class ProjectMilestoneDto : BaseDto<Guid>
    {
        /// <summary>
        /// Метка, краткий ярлык, который удобней выводить в списках вменсто полного названия стадии
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Название стадии проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание стадии
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ключевые задачи по проекту из общего их перечня
        /// </summary>
        public virtual  IList<Guid> KeyIssueIdList { get; set; }
        
    }
}
