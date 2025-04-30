using Shared.Authentication;

namespace ServicesAbstractions
{
    public interface IAuthenticationService
    {
        // Login (LoginRequest (string email , string password))
        // => UserResponse {string Token , string Email , string DisplayName}
        Task<UserResponse> LoginAysnc(LoginRequest request);

        // Register(RegisterRequest{string Email , string UserName , string Password , string DisplayName})
        // => UserResponse {string Token , string Email , string DisplayName}
        Task<UserResponse> RegisterAsync(RegisterRequest request);

        //CheckEmail(string email) => bool
        Task<bool> CheckEmailAsync(string email);
        // GetCurrentUserAddress() => AddressDTO
        Task<AddressDTO> GetUserAddressAsync(string email);
        // UpdateCurrentUserAddress(AddressDTO) => AddressDTO
        Task<AddressDTO> UpdateUserAddressAsync(AddressDTO addressDTO , string email);
        // GetCurrentUser()
        // => UserResponse {string Token , string Email , string DisplayName}
        Task<UserResponse> GetUserByEmail(string email);
    }
}
