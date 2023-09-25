using BlogApp.Core.Interfaces;
using BlogApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace BlogApp.Core.Composer
{
	public class RegisterDependencies : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.Services.AddTransient<IBlogService, BlogService>();
			builder.Services.AddTransient<IEmailService, EmailService>();
			builder.Services.AddTransient<IMenuService, MenuService>();
		}
	}
}
