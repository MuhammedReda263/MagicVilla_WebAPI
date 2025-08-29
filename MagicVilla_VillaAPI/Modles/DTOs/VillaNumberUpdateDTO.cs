using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Modles.DTOs
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; } = default!;
    }
}
