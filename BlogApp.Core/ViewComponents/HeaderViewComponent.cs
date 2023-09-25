using BlogApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewComponents
{
    [ViewComponent(Name ="Header")]
	public class HeaderViewComponent : ViewComponent
	{
		private readonly IMenuService _menuService;
        public HeaderViewComponent(IMenuService menuService)
        {
             _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
