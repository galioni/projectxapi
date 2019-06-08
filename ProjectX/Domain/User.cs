using ProjectX.Core.Enum;
using System;

namespace ProjectX.Core.Domain
{
	public class User
	{
		public string Id { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public UserTypeEnum Type { get; set; }

		public string City { get; set; }

		public string Country { get; set; }

		public string Phone { get; set; }

		public bool AcceptedAd { get; set; }

		public DateTime LastLogon { get; set; }

		public UserStatusEnum Status { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }
	}
}
