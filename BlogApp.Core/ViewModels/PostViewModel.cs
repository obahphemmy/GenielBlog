using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewModels
{
	public class PostViewModel
	{
		public int? Id { get; set; }
		public string? Title { get; set; }
        public string? Absract { get; set; }		
        public string? PostUrl { get; set; }
		public HtmlString? Content { get; set; }
		public DateTimeOffset? PostDate { get; set; }
		public string? ImageUrl { get; set; }
		public string? AuthorName { get; set; }
        public bool IsFeaturedPost { get; set; }
        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
