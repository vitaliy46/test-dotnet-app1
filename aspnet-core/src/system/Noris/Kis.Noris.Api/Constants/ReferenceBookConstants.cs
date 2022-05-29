using System;

namespace Kis.Noris.Api.Constants
{
    public static class ReferenceBookConstants
    {
        /// <summary>
        /// Дата окончания релиза, которая принимается, как отсутствие даты окончания
        /// (достаточно большая дата). Она присваивается актуальным записям.
        /// </summary>
        public static DateTime ActualReleaseEndDate = new DateTime(9999, 01, 01);
    }
}
