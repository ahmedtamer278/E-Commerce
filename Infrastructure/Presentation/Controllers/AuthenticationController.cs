using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Shared.Authentication;

namespace Presentation.Controllers
{
    public class AuthenticationController (IServiceManager serviceManager)
        : APIController
    {
        // [HttpPost]
        // Login (LoginRequest (string email , string password))
        // => UserResponse {string Token , string Email , string DisplayName}
        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
            => Ok(await serviceManager.AuthenticationService.LoginAysnc(request));
        // [HttpPost]
        // Register(RegisterRequest{string Email , string UserName , string Password , string DisplayName})
        // => UserResponse {string Token , string Email , string DisplayName}
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
          => Ok(await serviceManager.AuthenticationService.RegisterAsync(request));


        //CheckEmail(string email) => bool
         [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
            => Ok(await serviceManager.AuthenticationService.CheckEmailAsync(email));

        // GetCurrentUserAddress() => AddressDTO
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDTO>> GetAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationService.GetUserAddressAsync(email!));
        }

        // UpdateCurrentUserAddress(AddressDTO) => AddressDTO
        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress( AddressDTO addressDTO)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationService.UpdateUserAddressAsync(addressDTO,email!));
        }

        // GetCurrentUser()
        // => UserResponse {string Token , string Email , string DisplayName}
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await serviceManager.AuthenticationService.GetUserByEmail(email!));
        }
    }
}
