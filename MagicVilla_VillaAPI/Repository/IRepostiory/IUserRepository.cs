using MagicVilla_VillaAPI.Modles;
using MagicVilla_VillaAPI.Modles.DTOs;

namespace MagicVilla_VillaAPI.Repository.IRepostiory
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
