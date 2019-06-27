using ProjectX.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Repository
{
	public interface IUserRepository
	{
		Task<User> Authenticate(string email, string password);

		Task<List<User>> GetAllUsersAsync();

		Task AddUserHistory(UserHistory userHistoryModel);

		Task UpdateLastLogon(string UserId);
	}
}
