using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serviser.DAL.Entity;

namespace Serviser.Web.Models
{
    public class Problems
    {
        public List<VehicleProblem> carProblems { get; set; }
        public List<VehicleProblem> bikeProblems { get; set; }
        
    }
    public class Location
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}