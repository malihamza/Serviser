//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serviser.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleProblems
    {
        public int Id { get; set; }
        public int VehicleNameId { get; set; }
        public string Name { get; set; }
        public int MinRate { get; set; }
        public int MaxRate { get; set; }
    
        public virtual VehicleNames VehicleNames { get; set; }
    }
}
