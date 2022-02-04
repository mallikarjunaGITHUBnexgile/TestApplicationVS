using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
            String s = "string";
        }
        [HttpGet("Index")]
        public string /*IActionResult**/ Index()
        {
            return "Hello";
        }
        [HttpGet("welcome")]
        public string welcome()
        {
            return "From Welcome";
        }
    }
}
