using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.ViewComponents.LayoutComponents
{
	public class _LayoutNavBarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
