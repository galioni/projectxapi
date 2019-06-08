using System;

namespace ProjectX.Core.Domain
{
	public class UserHistory
	{
		public string Id { get; set; }

		public string UserId { get; set; }

		public bool LoginSuccessful { get; set; }

		public string Message { get; set; }

		public DateTime LoginDate { get; set; }

		public DateTime LogoutDate { get; set; }
	}
}
