using Microsoft.AspNetCore.Identity;

namespace MagicVilla_VillaAPI.Modles
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
