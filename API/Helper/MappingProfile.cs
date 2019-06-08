using AutoMapper;
using ProjectX.Core.Domain;
using ProjectX.Core.Model;

namespace ProjectX.API.Helper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserModel, User>();
			CreateMap<User, UserModel>();

			CreateMap<UserHistoryModel, UserHistory>();
			CreateMap<UserHistory, UserHistoryModel>();
		}
	}
}
