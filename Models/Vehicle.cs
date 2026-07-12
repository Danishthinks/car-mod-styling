using System.Collections.Generic;

namespace Car_Mod_net.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }

        // Many-to-many compatibility join collection
        public ICollection<VehicleModPart> VehicleModParts { get; set; } = new List<VehicleModPart>();
    }
}
