using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlogApp.Core.ViewComponents.Umbraco
{
	public class bloggerProfileViewComponent : ViewComponent
	{
		private readonly IPublishedValueFallback _publishedValueFallback;
        public bloggerProfileViewComponent(IPublishedValueFallback publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
        }
        public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
		{
			var viewModel = new BloggerProfile(model, _publishedValueFallback);
			return View(viewModel);
		}
	}
}
