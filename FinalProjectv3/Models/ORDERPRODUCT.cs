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
    
    public partial class ORDERPRODUCT
    {
        public int IDOrderProd { get; set; }
        public int IDOrder { get; set; }
        public int IDProd { get; set; }
        public Nullable<byte> QttyOrder { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}