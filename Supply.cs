//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KURSACH
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public int SupplyID { get; set; }
        public int TheSupplierID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal SupplyPrice { get; set; }
        public System.DateTime DateOfSupply { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual The_Supplier The_Supplier { get; set; }
    }
}
