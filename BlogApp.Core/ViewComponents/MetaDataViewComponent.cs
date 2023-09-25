using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewComponents
{
	[ViewComponent(Name ="MetaData")]
	public class MetaDataViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
