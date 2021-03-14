using CustomCountries.API.Models;
using CustomCountries.API.Services;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Options;

namespace CustomCountries.API.GraphQl.Queries
{
    [ExtendObjectType(Name = "QueriesCustomContries")]
    public class LoginQuery
    {
        public string Login(string name, string password, [Service] IAuthService authService, [Service] IOptions<TokenSettings> tokenSettings) =>
            authService.Authenticate(tokenSettings, name, password);
    }
}
