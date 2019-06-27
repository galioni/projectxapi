using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectX.API.Auth;
using ProjectX.Core.Domain;
using ProjectX.Core.Enum;
using ProjectX.Core.Repository;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectX.API.Controllers
{
	[AllowAnonymous]
	[Route("api/login")]
	public class LoginController : Controller
	{
		public LoginController(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			Configuration = configuration;
		}

		private IUserRepository _userRepository;
		public IConfiguration Configuration { get; }

		// POST api/login
		[HttpPost]
		public async Task<IActionResult> Authenticate([FromBody] Login login)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var usr = await _userRepository.Authenticate(login.Email, login.Password);

			if (usr != null)
			{
				var token = new JwtTokenBuilder()
														.AddSecurityKey(JwtSecurityKey.Create("token-login-expires"))
														.AddSubject(login.Email)
														.AddIssuer(Configuration.GetSection("Authentication:Issuer").Value)
														.AddAudience(Configuration.GetSection("Authentication:Audience").Value)
														.AddClaim(ClaimTypes.Role, UserTypeEnum.User.ToString())
														.AddExpiry(Configuration.GetSection("Authentication:ExpireInMinutes").Value)
														.Build();

				var loginSuccess = new LoginSuccess() {
					AccessToken = token.Value,
					AccessTokenExpiration = token.ValidTo,
					Email = usr.Email,
					Name = usr.Name,
					RefreshToken =  string.Empty //TODO: Implement Refresh Token
				};

				return Ok(loginSuccess);

			}
			else
				return Unauthorized();
		}
	}
}
