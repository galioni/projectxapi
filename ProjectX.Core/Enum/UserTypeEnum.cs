using System.Runtime.Serialization;

namespace ProjectX.Core.Enum
{
	public enum UserTypeEnum
	{
		[EnumMember(Value = "Administrator")]
		Administrator = 1,

		[EnumMember(Value = "Moderator")]
		Moderator = 2,

		[EnumMember(Value = "User")]
		User = 3
	}
}
