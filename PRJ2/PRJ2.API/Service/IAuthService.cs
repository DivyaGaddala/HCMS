using PRJ2.API.DTO;

namespace PRJ2.API.Service
{
    public interface IAuthService
    {
        Task<LogiResponseDTO?> LoginAsync(LoginRequestDTO request);

    }
}
