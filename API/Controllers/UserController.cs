using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Domain;
using ProjectX.Core.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Authorize]
	[Produces("application/json")]
	[Route("api/user")]
	public class UserController : Controller
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		// GET: api/user/
		[HttpGet]
		public async Task<List<User>> GetAllUsers()
		{
			return await _userService.GetAllUsersAsync();
		}
	}
}