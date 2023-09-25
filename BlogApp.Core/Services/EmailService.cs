using BlogApp.Core.Interfaces;
using BlogApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
	public class EmailService : IEmailService
	{
		public void SendContactNotificationToAdmin(ContactFormViewModel vm)
		{
			throw new NotImplementedException();
		}

		public void SendPasswordChangedNotification(string membersEmail)
		{
			throw new NotImplementedException();
		}

		public void SendResetPasswordNotification(string membersEmail, string resetToken)
		{
			throw new NotImplementedException();
		}

		public void SendVerifyEmailAddressNotification(string membersEmail, string verificationToken)
		{
			throw new NotImplementedException();
		}
	}
}
