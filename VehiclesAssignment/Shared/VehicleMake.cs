using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehiclesAssignment.Shared
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        
        public List<VehicleModel>? Models { get; set; }
    }
}
