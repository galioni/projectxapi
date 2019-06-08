using System.Runtime.Serialization;

namespace ProjectX.Core.Enum
{
	public enum UserStatusEnum
	{
		[EnumMember(Value = "Disabled")]
		Disabled = 0,

		[EnumMember(Value = "Enabled")]
		Enabled = 1,

		[EnumMember(Value = "Deleted")]
		Deleted = 2,

		[EnumMember(Value = "Blocked")]
		Blocked = 3,

		[EnumMember(Value = "BlockedAfterTries")]
		BlockedAfterTries = 5,

		[EnumMember(Value = "PasswordExpired")]
		PasswordExpired = 6
	}
}
