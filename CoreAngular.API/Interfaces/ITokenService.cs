using CoreAngular.API.Entities;

namespace CoreAngular.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (AppUser user);

    }
}