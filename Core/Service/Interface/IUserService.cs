using ProjectX.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Service.Interface
{
	public interface IUserService
	{
		Task<List<User>> GetAllUsersAsync();

		Task<User> Authenticate(string login, string password);
	}
}
