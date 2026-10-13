using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Notification.Email.Models
{
	public sealed class SmtpConfiguration
	{
		public string Hostname { get; init; } = string.Empty;
		public int Port { get; init; }
		public string From => "noreply@cleanarchitecture.com";
		public string To => "sample-list@test.com";
	}
}
