using Microsoft.AspNetCore.Mvc;
using ProjectX.API.Auth;
using ProjectX.Core.Domain;
using ProjectX.Core.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		// POST api/user
		[HttpPost]
		public async Task<IActionResult> Authentication([FromBody] User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var usr = await _userService.Authenticate(user.Login, user.Password);

			if (usr != null)
			{

				var token = new JwtTokenBuilder()
														.AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
														.AddSubject(user.Login)
														.AddIssuer("issuerTest")
														.AddAudience("bearerTest")
														.AddClaim("MembershipId", "111")
														.AddExpiry(1)
														.Build();

				return Ok(token.Value);

			}
			else
				return Unauthorized();
		}

		// GET: api/users
		[HttpGet]
		public async Task<List<User>> GetProjects()
		{
			return await _userService.GetAllUsersAsync();
		}
	}
}