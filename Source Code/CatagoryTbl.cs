//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetsmartzOnlineStore.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatagoryTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatagoryTbl()
        {
            this.ProductTbls = new HashSet<ProductTbl>();
        }
    
        public int CategoryID_PK { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Nullable<int> MinPrice { get; set; }
        public Nullable<int> MaxPrice { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTbl> ProductTbls { get; set; }
    }
}
