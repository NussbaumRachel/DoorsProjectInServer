using Microsoft.AspNetCore.Mvc;

namespace DoorsProjectInServer.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
