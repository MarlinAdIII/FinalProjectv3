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
    
    public partial class SKILL
    {
        public int IDSkill { get; set; }
        public int IDBraider { get; set; }
        public byte IDStyle { get; set; }
    
        public virtual BRAIDER BRAIDER { get; set; }
        public virtual STYLE STYLE { get; set; }
    }
}
