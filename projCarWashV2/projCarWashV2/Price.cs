//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projCarWashV2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Price()
        {
            this.Detail_Washing_Data = new HashSet<Detail_Washing_Data>();
            this.Transaction_Data = new HashSet<Transaction_Data>();
        }
    
        public int ID_Type { get; set; }
        public string Name_Price { get; set; }
        public int Small { get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Washing_Data> Detail_Washing_Data { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction_Data> Transaction_Data { get; set; }
    }
}
