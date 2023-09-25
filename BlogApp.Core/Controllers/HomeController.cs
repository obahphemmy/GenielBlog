using BlogApp.Core.Interfaces;
using BlogApp.Core.ViewModels;
using BlogApp.Core.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlogApp.Core.Controllers
{
	public class HomeController : RenderController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUmbracoContextAccessor _contextAccessor;
		private readonly IBlogService _blogService;
		private readonly IPublishedValueFallback _publishedValueFallback;
		public HomeController(ILogger<HomeController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IBlogService blogService, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_blogService = blogService;
			_publishedValueFallback = publishedValueFallback;
		}

		public IActionResult Home()
		{
			var homePage = new Home(CurrentPage, _publishedValueFallback);
			var viewModel = new ComposedPageViewModel<Home, HomeViewModel>
			{
				UmbracoPage = homePage,
				CustomViewModel = new HomeViewModel
				{
					BannerPosts = _blogService.GetPosts().Where(x => x.IsFeaturedPost).Take(homePage.BannerPostsNum).ToList(),
					EntryPosts = _blogService.GetPosts().Where(x => x.IsFeaturedPost == false).Take(homePage.EntryPostsNum).ToList()
				}
			};
			return View("~/Views/Home.cshtml", viewModel);
		}

	}
}
