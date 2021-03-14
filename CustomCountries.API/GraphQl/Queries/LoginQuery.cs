using CustomCountries.API.Repository;
using HotChocolate;
using HotChocolate.Types;

namespace CustomCountries.API.GraphQl.Queries
{
    [ExtendObjectType(Name = "QueriesCustomContries")]
    public class LoginQuery
    {
        public string Login(string name, string password, [Service] IAuthService authService) =>
            authService.Authenticate(name, password);
    }
}
