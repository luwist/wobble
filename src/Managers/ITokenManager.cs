using wobble.src.Models;

namespace wobble.src.Managers
{
    public interface ITokenManager
    {
        string CreateToken(User user);
    }
}