using BlogApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Trees;

namespace BlogApp.Core.Services
{
	public class MenuService : IMenuService
	{
		public IEnumerable<MenuItem> Menus => throw new NotImplementedException();
	}
}
