using BlogApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Interfaces
{
	public interface IBlogService
	{
		IEnumerable<PostViewModel> GetPosts();
		IEnumerable<CategoryViewModel> GetCategories();
		PostViewModel GetPost(int id);
	}
}
