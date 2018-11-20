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
    
    public partial class JOBDONE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOBDONE()
        {
            this.JOBCONSUMPTIONs = new HashSet<JOBCONSUMPTION>();
            this.JOBEXECUTERs = new HashSet<JOBEXECUTER>();
        }
    
        public int IDJobDone { get; set; }
        public int IDAppoint { get; set; }
        public System.DateTime DateJobDone { get; set; }
        public System.TimeSpan TimeEndJob { get; set; }
        public Nullable<byte> IDDiscount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public string feedback { get; set; }
    
        public virtual APPOINTMENT APPOINTMENT { get; set; }
        public virtual DISCOUNT DISCOUNT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOBCONSUMPTION> JOBCONSUMPTIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOBEXECUTER> JOBEXECUTERs { get; set; }
    }
}
