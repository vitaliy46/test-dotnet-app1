using System;
using Kis.Base.Entity;


namespace Kis.Investors.Api.Entity
{
    /// <summary>
    /// Товарищ учавствующий в инвестировании в проект
    /// </summary>
    public class Investor : EntityBase<Guid>
    {
        /// <summary>
        /// Член товарищества
        /// </summary>
        public virtual PartnershipMember Member { get; set; }
        public Guid MemberId { get; set; }
        
        /// <summary>
        /// Проект в котором учавствует инвестор своими ресурсами 
        /// </summary>
        public virtual InvestedProject Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }
        

    }

    
}
