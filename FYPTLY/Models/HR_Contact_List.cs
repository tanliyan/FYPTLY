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
    
    public partial class HR_Contact_List
    {
        public int hr_id { get; set; }
        public string hr_name { get; set; }
        public string hr_contact { get; set; }
        public string hr_email { get; set; }
        public int corporate_id { get; set; }
    
        public virtual Corporate Corporate { get; set; }
    }
}
