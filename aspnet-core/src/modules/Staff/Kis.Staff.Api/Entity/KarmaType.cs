using System;
using Kis.Base.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Тип кармы, за который начисляются/отнимаются баллы. 
    /// Белая карма - положительная. Черная карма - отрицательная.
    /// </summary>
    public class KarmaType : EntityBase<Guid>
    {
        /// <summary>
        /// Название данного типа кармы.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение у этого типа влияющее на суммарную карму сотрудника.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Весовой коэффициент.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
    }
}
