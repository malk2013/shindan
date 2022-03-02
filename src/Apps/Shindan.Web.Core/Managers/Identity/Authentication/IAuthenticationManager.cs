using Shindan.Web.Core.Requests.Identity;
using Shindan.Web.Core.Shared.Wrapper;
using System.Security.Claims;

namespace Shindan.Web.Core.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}
