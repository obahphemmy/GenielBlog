using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
	public class Helper
	{
		public static string GetDocumentTypeId(string input)
		{
			// Define the regular expression pattern
			string pattern = @"/(\w+)$";

			// Use Regex.Match to find the GUID
			Match match = Regex.Match(input, pattern);

			if (match.Success)
			{
				string extractedGuid = match.Value;
				return extractedGuid.Replace("/", "");
			}
			return string.Empty;
		}
	}
}
