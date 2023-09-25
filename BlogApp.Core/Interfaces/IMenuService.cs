using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Trees;

namespace BlogApp.Core.Interfaces
{
	public interface IMenuService
	{
		IEnumerable<MenuItem> Menus { get; }
	}
}
