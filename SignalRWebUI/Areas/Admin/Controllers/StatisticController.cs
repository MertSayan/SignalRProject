using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Statistic")]
	public class StatisticController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
