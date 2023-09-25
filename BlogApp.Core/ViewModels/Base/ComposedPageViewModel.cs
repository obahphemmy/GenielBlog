using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlogApp.Core.ViewModels.Base
{
	public class ComposedPageViewModel<TUmbracoPage, TCumtomViewModel> where TUmbracoPage : PublishedContentModel
	{
		public TUmbracoPage UmbracoPage { get; set;}
		public TCumtomViewModel CustomViewModel { get; set;}
	}
}
