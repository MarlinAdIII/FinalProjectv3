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
    
    public partial class COMPANY
    {
        public byte IDComp { get; set; }
        public string TitleComp { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneOwner { get; set; }
        public string StreetComp { get; set; }
        public string CountyComp { get; set; }
        public Nullable<short> ZipcodeComp { get; set; }
        public string EmailComp { get; set; }
        public string WebsiteComp { get; set; }
        public Nullable<double> PartPayeBraid { get; set; }
        public Nullable<int> IDOwnerBraider { get; set; }
        public Nullable<decimal> CostHairDeduct { get; set; }
        public Nullable<byte> PercentBrader { get; set; }
        public Nullable<decimal> PriceTakeOff { get; set; }
    
        public virtual BRAIDER BRAIDER { get; set; }
    }
}
