using Microsoft.AspNetCore.Mvc;

namespace HolyRosary.Controllers
{
    [Route("credits")]
    public class CreditsController : Controller 
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
