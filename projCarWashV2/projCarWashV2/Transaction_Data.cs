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
    
    public partial class Transaction_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction_Data()
        {
            this.Detail_Washing_Data = new HashSet<Detail_Washing_Data>();
        }
    
        public int ID_Transaction { get; set; }
        public Nullable<int> ID_Customer { get; set; }
        public Nullable<int> ID_Type { get; set; }
        public Nullable<System.DateTime> Date_Transaction { get; set; }
        public Nullable<int> Total_Price { get; set; }
        public string Number_Of_Vehicles { get; set; }
    
        public virtual Customer_Data Customer_Data { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Washing_Data> Detail_Washing_Data { get; set; }
        public virtual Price Price { get; set; }
    }
}