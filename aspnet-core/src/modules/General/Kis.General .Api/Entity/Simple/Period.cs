using System;

namespace Kis.General.Api.Entity.Simple
{
    /// <summary>
    /// Период времени, определенный датой/временем начала и окончания.
    /// https://fhir-ru.github.io/datatypes.html#period
    /// </summary>
    public class Period
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

    }
}
