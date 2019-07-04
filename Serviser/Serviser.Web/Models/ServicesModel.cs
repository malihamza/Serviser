using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serviser.DAL.Entity;

namespace Serviser.Web.Models
{
    public class Problems
    {
        public List<VehicleProblem> CarProblems { get; set; }
        public List<VehicleProblem> BikeProblems { get; set; }
        
    }
    public class Location
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}