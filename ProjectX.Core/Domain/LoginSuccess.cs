using System;

namespace ProjectX.Core.Domain
{
	public class LoginSuccess
	{
		public string AccessToken { get; set; }

		public DateTime AccessTokenExpiration { get; set; }

		public string RefreshToken { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }
	}
}
