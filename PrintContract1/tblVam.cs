//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrintContract1
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblVam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVam()
        {
            this.tblPardakhtAghsats = new HashSet<tblPardakhtAghsat>();
        }
    
        public long Id { get; set; }
        public string VamType { get; set; }
        public string NumberContract { get; set; }
        public Nullable<long> MablaghVam { get; set; }
        public Nullable<long> PishDaryaft { get; set; }
        public Nullable<long> BaqhiMande { get; set; }
        public Nullable<int> NerkhSod { get; set; }
        public Nullable<int> TedadAghsat { get; set; }
        public Nullable<long> MablaghGhest { get; set; }
        public Nullable<long> MablaghAsloFara { get; set; }
        public Nullable<int> Eltezam { get; set; }
        public string DateOfStart { get; set; }
        public string DateOfEnd { get; set; }
        public Nullable<long> HesabId { get; set; }
    
        public virtual tblHesab tblHesab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPardakhtAghsat> tblPardakhtAghsats { get; set; }
    }
}
