using MagicVilla_VillaAPI.Modles.DTOs;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
                new VillaDTO  { Id=1 ,Name ="Villa1",Sqft=100,Occupancy=4}, 
                new VillaDTO { Id = 2, Name = "Villa1",Sqft=400,Occupancy=3}
            };
    }
}
