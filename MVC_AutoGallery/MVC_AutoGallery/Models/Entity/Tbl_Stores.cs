//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_AutoGallery.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Stores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Stores()
        {
            this.Tbl_Cars = new HashSet<Tbl_Cars>();
            this.Tbl_Employee = new HashSet<Tbl_Employee>();
        }
    
        public int Store_Id { get; set; }
        public string Store_Name { get; set; }
        public string Store_Adress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cars> Tbl_Cars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Employee> Tbl_Employee { get; set; }
    }
}