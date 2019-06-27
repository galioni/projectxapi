using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Domain;
using ProjectX.Core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.API.Controllers
{
	[Authorize]
	[Produces("application/json")]
	[Route("api/user")]
	public class UserController : Controller
	{
		private IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		// GET: api/user/
		[HttpGet]
		public async Task<List<User>> GetAllUsers()
		{
			return await _userRepository.GetAllUsersAsync();
		}
	}
}