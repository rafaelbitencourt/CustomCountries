using Microsoft.AspNetCore.Mvc;

namespace CustomCountries.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlGitHubController : ControllerBase
    {
        [HttpGet]
        public string Get() => "https://github.com/rafaelbitencourt/CustomCountries";
    }
}
