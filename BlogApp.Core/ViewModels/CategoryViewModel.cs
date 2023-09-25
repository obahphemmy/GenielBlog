using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewModels
{
	public class CategoryViewModel
	{
		public int? Id { get; set; }
		public string? CategoryName { get; set; }
		public string? CategoryImageUrl { get; set; }
	}

	public class SidebarCategoriesViewModel
	{
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
