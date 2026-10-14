using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Notification.Abstractions
{
    public interface INotifier
    {
		void Notify(
		string subject,
		string message,
		params string[] destination);
	}
}
