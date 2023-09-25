using BlogApp.Core.Interfaces;
using BlogApp.Core.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace BlogApp.Core.Services
{
	public class BlogService : IBlogService
	{
		private readonly IUmbracoContextAccessor _contextAccessor;
		private readonly ILogger<BlogService> _logger;
		private readonly IContentTypeService _contentTypeService;
		public BlogService(IUmbracoContextAccessor umbracoContextAccessor, ILogger<BlogService> logger, IContentTypeService contentTypeService)
        {
			_contextAccessor = umbracoContextAccessor;
			_logger = logger;
			_contentTypeService = contentTypeService;
        }
        public IEnumerable<CategoryViewModel> GetCategories()
		{
			var home = GetHomeNode();
			var categoryListing = home.DescendantsOrSelf<Categories>().FirstOrDefault();
			if (categoryListing != null)
			{
				return categoryListing.Descendants<Category>().Select(x => new CategoryViewModel
				{
					CategoryImageUrl = x.CategoryImage?.Url(),
					CategoryName = x.Name,
					Id = x.Id
				});
			}
			return Enumerable.Empty<CategoryViewModel>();
		}

		public PostViewModel GetPost(int id)
		{
			var result = GetPosts().FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
			return new PostViewModel();
        }

		//public IEnumerable<>

		public IEnumerable<PostViewModel> GetPosts()
		{
			var postListing = GetHomeNode().DescendantsOrSelf<ArticleList>().FirstOrDefault();
			if (postListing != null)
			{
				var posts = postListing.Descendants<Article>().OrderByDescending(y => y.CreateDate);

				var postModels = posts.Select(x => new PostViewModel
				{
					AuthorName = GetAuthor(x.PostWriter?.ToString()),
					Content = new HtmlString(x.PostContent?.ToString()),
					Id = x.Id,
					ImageUrl = x.PostImage?.GetCropUrl(1288, 738),
					PostDate = x.PostDate,
					Title = x.PostTitle,
					IsFeaturedPost = x.FeaturedPost,
					Absract = x.PostAbstract?.ToString() ?? string.Empty,
					Categories = x.PostCategory?.Select(k => new CategoryViewModel
					{
						CategoryName = k.Name
					}),
					PostUrl = x.Url()
				});
				return postModels;
			} 
			return Enumerable.Empty<PostViewModel>();
		}


		private Home GetHomeNode()
		{
			var cache = _contextAccessor.GetRequiredUmbracoContext();
			return cache.Content.GetAtRoot().DescendantsOrSelf<Home>().FirstOrDefault();
		}

		private string GetAuthor(string? DocTypeStr)
		{
			if (DocTypeStr != null)
			{
				var doctypeGuid = Helper.GetDocumentTypeId(DocTypeStr);
				var home = GetHomeNode();

				if (home != null)
				{
					var authorListing = GetHomeNode().DescendantsOrSelf<AuthorList>().FirstOrDefault();
					if (authorListing != null)
					{
						var author = authorListing.Descendants<Author>().FirstOrDefault(y => y.Key == new Guid(doctypeGuid));
						if (author != null)
						{
							return author.Name;
						}
					}
				}
			}
			return string.Empty;
		}
	}
}
