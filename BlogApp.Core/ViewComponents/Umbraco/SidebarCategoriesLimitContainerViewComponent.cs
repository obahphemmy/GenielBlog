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
    public class sidebarCategoriesLimitContainerViewComponent : ViewComponent
    {
        private readonly IPublishedValueFallback _publishedValueFallback;
        public sidebarCategoriesLimitContainerViewComponent(IPublishedValueFallback publishedValueFallback)
        {
                _publishedValueFallback = publishedValueFallback;
        }
        public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
        {
            var viewModel = new SidebarCategoriesLimitContainer(model, _publishedValueFallback);
            return View(viewModel); 
        }
    }
}
