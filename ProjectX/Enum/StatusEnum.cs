using System.Runtime.Serialization;

namespace ProjectX.Core.Enum
{
	public enum StatusEnum
	{
		[EnumMember(Value = "Disabled")]
		Disabled = 0,

		[EnumMember(Value = "Enabled")]
		Enabled = 1,

		[EnumMember(Value = "Deleted")]
		Deleted = 2
	}
}
