using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewModels
{
	public class HomeViewModel
	{
        public IEnumerable<PostViewModel> BannerPosts { get; set; }
		public IEnumerable<PostViewModel> EntryPosts { get; set; }
	}
}
