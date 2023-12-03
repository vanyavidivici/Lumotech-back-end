using Microsoft.AspNetCore.Identity;

namespace Service.Contracts;

public interface IUserService
{
    Task<IdentityResult> DeleteUser(string userId);
}