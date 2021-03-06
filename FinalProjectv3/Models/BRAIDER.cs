//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProjectv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BRAIDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BRAIDER()
        {
            this.COMPANies = new HashSet<COMPANY>();
            this.JOBEXECUTERs = new HashSet<JOBEXECUTER>();
            this.SKILLS = new HashSet<SKILL>();
        }

        [Display(Name = "Braider ID")]
        public int IDBraider { get; set; }

        [Display(Name = "First Name")]
        public string FnameBraider { get; set; }

        [Display(Name = "Middle Name")]
        public string MnameBraider { get; set; }

        [Display(Name = "Last Name")]
        public string LnameBraider { get; set; }

        [Display(Name = "Phone Number:")]
        public string PhoneBraider { get; set; }

        [Display(Name = "Cell Number:")]
        public string CelBraider { get; set; }

        [Display(Name = "Street Address:")]
        public string StreetBraider { get; set; }

        [Display(Name = "County:")]
        public string CountyBraider { get; set; }

        [Display(Name = "Zipcode:")]
        public Nullable<short> ZipCodeBraider { get; set; }

        [Display(Name = "Email:")]
        public string EmailBraider { get; set; }
        public string IDUserBraider { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPANY> COMPANies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOBEXECUTER> JOBEXECUTERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKILL> SKILLS { get; set; }
    }
}
