//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serviser_Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class BiLLItem
    {
        public int booking_id { get; set; }
        public int problem_id { get; set; }
        public int price { get; set; }
    
        public virtual booking booking { get; set; }
        public virtual vehicleProblems vehicleProblems { get; set; }
    }
}
