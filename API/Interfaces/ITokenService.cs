using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService
    {
          string CreateTokent (AppUser user);
    }
}