using Microsoft.AspNetCore.Mvc;

namespace HolyRosary.Controllers
{
    [Route("about")]
    public class AboutController : Controller 
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
