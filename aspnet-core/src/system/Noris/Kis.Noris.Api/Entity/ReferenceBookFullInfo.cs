using System.Collections.Generic;
using System.Linq;
using Kis.Noris.Api.Dpo;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Класс агрегирует информацию о справочнике и информацию об ошибках, связанных с ним
    /// </summary>
    public class ReferenceBookFullInfo
    {
        public ReferenceBookShortInfo Info { get; set; }
        public IList<ReferenceErrorDetailDpo> Errors { get; set; }
        public string Description => Info.Description;
        public int ErrorsCountAll => Errors.Count();
        public int ErrorsCountNew => Errors.Count(x => x.State == Constants.ReferenceErrorStates.New);
        public int ErrorsCountInWork => Errors.Count(x => x.State == Constants.ReferenceErrorStates.InWork);
    }
}
