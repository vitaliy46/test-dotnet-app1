using System;
using Kis.Base.Dto;

namespace Kis.Staff.Api.Dto
{
    public class KarmaTypeDto: BaseDto<Guid>
    {
        /// <summary>
        /// Название данного типа кармы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение у этого типа влияющее на суммарную карму сотрудника
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Весовой коэффициент
        /// </summary>
        public double Weight { get; set; }
    }
}