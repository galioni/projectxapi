using ProjectX.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Repository
{
	public interface IUserRepository
	{
		Task<List<UserEntity>> GetAllUsersAsync();

		Task<UserEntity> Authenticate(string login, string password);
	}
}
