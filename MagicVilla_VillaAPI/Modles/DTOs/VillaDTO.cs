using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Modles.DTOs
{
    public class VillaDTO
    {

        public int Id { get; set; }
        [Required]
        [Length(3,15)]
        public string Name { get; set; } = default!;
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}
