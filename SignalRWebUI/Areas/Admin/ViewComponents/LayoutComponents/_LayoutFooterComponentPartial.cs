using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
