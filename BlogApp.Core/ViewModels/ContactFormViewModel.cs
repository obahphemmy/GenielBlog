using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.ViewModels
{
	public class ContactFormViewModel
	{
		[Required(ErrorMessage = "Please enter your name")]
		[MaxLength(80, ErrorMessage = "Please try and limit to 80 characters")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Please enter your email address")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address")]
		public string? EmailAddress { get; set; }
		[Required(ErrorMessage = "Please enter your comment")]
		[MaxLength(500, ErrorMessage = "Please try and limit your comments to 500 characters")]
		public string? Comment { get; set; }
		[Required(ErrorMessage = "Please enter the subject of your comment")]
		[MaxLength(250, ErrorMessage = "Please try and your subject to 250 characters")]
		public string? Subject { get; set; }
		public string? RecaptchaSiteKey { get; set; }
	}
}
