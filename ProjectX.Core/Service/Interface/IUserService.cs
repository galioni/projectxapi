using ProjectX.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Service.Interface
{
	public interface IUserService
	{
		Task<User> Authenticate(string email, string password);

		Task<List<User>> GetAllUsersAsync();
	}
}
