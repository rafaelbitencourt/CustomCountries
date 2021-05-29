using Microsoft.AspNetCore.Mvc;

namespace TESTE.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlGitHubController : ControllerBase
    {
        [HttpGet]
        public string Get() => "https://github.com/rafaelbitencourt/CustomCountries";
    }
}
