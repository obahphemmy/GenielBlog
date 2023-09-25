using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Web;
using Umbraco.Community.Contentment.DataEditors;
using Umbraco.Extensions;

namespace MyProject.Web.App_Code
{
	public class PeopleDataListSource : IDataListSource
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public PeopleDataListSource(IUmbracoContextAccessor umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public string Name => "Author Content Items";

		public string Description => "Use authors content items as a data source.";

		public string Icon => "icon-users";

		public OverlaySize OverlaySize => OverlaySize.Small;

		public Dictionary<string, object> DefaultValues => new Dictionary<string, object>();

		public IEnumerable<ConfigurationField> Fields => Enumerable.Empty<ConfigurationField>();

		public string Group => "Custom";

		public IEnumerable<DataListItem> GetItems(Dictionary<string, object> config)
		{
			var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();

			List<DataListItem> results = new List<DataListItem>();

			//get call content items which are using the document type alias of 'author'
			var authours = umbracoContext.Content.GetByXPath(false, "//author");

			//make sure there are some people items
			if (authours != null && authours.Any())
			{

				//loop through the people itmes
				foreach (var author in authours)
				{

					//generate a udi from the key property of the content item
					//we will use this to store as the value of the author picker
					var udi = Udi.Create(Constants.UdiEntityType.Document, author.Key);
					if (udi == null) break;

					//create a new DataListItem object to store the data
					var item = new DataListItem()
					{
						Name = author.Name,
						Value = udi.ToString()
					};

					//check if the person record has a photo
					if (author.HasValue("profileImage"))
					{
						var photo = author.Value<IPublishedContent>("profileImage");
						item.Icon = photo.GetCropUrl(120, 120);
					}

					//add the item to our list of results
					results.Add(item);
				}

				return results;
			}

			return Enumerable.Empty<DataListItem>();
		}

	}
}