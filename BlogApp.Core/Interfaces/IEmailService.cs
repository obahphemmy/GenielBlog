using BlogApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Interfaces
{
	public interface IEmailService
	{
		void SendContactNotificationToAdmin(ContactFormViewModel vm);
		void SendVerifyEmailAddressNotification(string membersEmail, string verificationToken);
		void SendResetPasswordNotification(string membersEmail, string resetToken);
		void SendPasswordChangedNotification(string membersEmail);
	}
}
