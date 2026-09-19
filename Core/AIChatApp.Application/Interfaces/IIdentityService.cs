using AIChatApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetCurrentUserIdAsync();
        Task<UserInfoDto> GetCurrentUserAsync();
        Task RegisterAsync(RegisterDto registerDto);
        Task<bool> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
    }
}
