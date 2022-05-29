using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Inventory.Api.Entity
{
    public class ProductCategory : EntityBase<Guid>
    {
        public string Name { get; set; }
       
        public ProductCategory Parent { get; set; }
    }
}
