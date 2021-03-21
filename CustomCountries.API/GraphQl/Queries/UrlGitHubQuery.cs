using HotChocolate.Types;

namespace CustomCountries.API.GraphQl.Queries
{
    [ExtendObjectType(Name = "QueriesCustomContries")]
    public class UrlGitHubQuery
    {
        public string GetGitHubUrl() =>
            "https://github.com/rafaelbitencourt/CustomCountries";
    }
}
