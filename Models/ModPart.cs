using System.Collections.Generic;

namespace Car_Mod_net.Models
{
    public class ModPart
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty; // e.g. Body Kit, Custom Paint, Window Tint, Wheels
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Many-to-many compatibility join collection
        public ICollection<VehicleModPart> VehicleModParts { get; set; } = new List<VehicleModPart>();
    }
}
