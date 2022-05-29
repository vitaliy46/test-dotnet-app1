using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    public class UpdateStateDto : IShouldNormalize
    {
        /// <summary>
        /// Значение.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        public void Normalize()
        {
        }
    }
}
