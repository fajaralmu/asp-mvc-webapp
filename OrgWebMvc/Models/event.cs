//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrgWebMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class @event
    {
        public int id { get; set; }
        public int program_id { get; set; }
        public int user_id { get; set; }
        public System.DateTime date { get; set; }
        public string location { get; set; }
        public int participant { get; set; }
        public string info { get; set; }
        public int done { get; set; }
        public string name { get; set; }
    
        public virtual program program { get; set; }
    }
}
