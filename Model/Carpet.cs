using System.ComponentModel.DataAnnotations;

namespace Dsd601CarpetCalcAsp.Model
{
    public class Carpet
    {
        [Required]
        public float RoomWidth { get; set; } = 1;
        [Required]
        public float RoomLength { get; set; } = 1;
        public float RoomArea { get; set; } = 1;

        public bool InstallationCost { get; set; }
        public bool UnderlayCost { get; set; }
        public int CarpetType { get; set; }

    }
}
