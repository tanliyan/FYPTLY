//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYPTLY.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff_has_Patient
    {
        public int Staff_id { get; set; }
        public int Patient_id { get; set; }
        public Nullable<System.DateTime> First_consultation_date { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
