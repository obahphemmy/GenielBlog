using BlogApp.Core.Interfaces;
using BlogApp.Core.ViewModels;
using BlogApp.Core.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlogApp.Core.ViewComponents.Umbraco
{
    public class sidebarCategoryLimitViewComponent : ViewComponent
    {
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly IBlogService _blogService;
        public sidebarCategoryLimitViewComponent(IPublishedValueFallback publishedValueFallback, IBlogService blogService)
        {
            _publishedValueFallback = publishedValueFallback;
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
        {
            var categoriesLimitBlock = new SidebarCategoryLimit(model, _publishedValueFallback);
            var categories = _blogService.GetCategories().Take(categoriesLimitBlock.CategoriesDisplayNum);
            var viewModel = new PublishedElementViewModel<SidebarCategoryLimit, SidebarCategoriesViewModel>
            {
                Block = categoriesLimitBlock,
                ViewModel = new SidebarCategoriesViewModel
                {
                    Categories = categories
                }
            };
            return View(viewModel);
        }
    }
}
