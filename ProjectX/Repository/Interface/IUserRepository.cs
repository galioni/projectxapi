using ProjectX.Core.Domain;
using ProjectX.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Repository
{
	public interface IUserRepository
	{
		Task<UserModel> Authenticate(string email, string password);

		Task<List<UserModel>> GetAllUsersAsync();

		Task AddUserHistory(UserHistoryModel userHistoryModel);

		Task UpdateLastLogon(string UserId);
	}
}
