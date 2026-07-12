namespace Car_Mod_net.Models
{
    public class VehicleModPart
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public int ModPartId { get; set; }
        public ModPart ModPart { get; set; } = null!;
    }
}
