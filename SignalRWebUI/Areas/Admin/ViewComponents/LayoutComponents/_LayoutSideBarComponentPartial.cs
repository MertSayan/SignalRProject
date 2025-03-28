using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.ViewComponents.LayoutComponents
{
	public class _LayoutSideBarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
