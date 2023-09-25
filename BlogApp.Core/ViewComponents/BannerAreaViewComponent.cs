using BlogApp.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewComponents
{
	public class BannerAreaViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(IEnumerable<PostViewModel> posts)
		{
			return View(posts);
		}
	}

}
