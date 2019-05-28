using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectX.Core.Context;
using ProjectX.Core.Domain;
using ProjectX.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly UserContext _context = null;

		public UserRepository()
		{
		}

		public UserRepository(IOptions<Settings> settings)
		{
			_context = new UserContext(settings);
		}

		public async Task<List<UserEntity>> GetAllUsersAsync()
		{
			var builder = Builders<User>.Filter;
			return await _context.Users.Find(_=> true).ToListAsync();
		}

		public async Task<UserEntity> Authenticate(string login, string password)
		{
			var builder = Builders<UserEntity>.Filter;
			var filter = builder.Eq("Login", login) & builder.Eq("Password", password);

			return await _context.Users
									.Find(filter)
									.FirstOrDefaultAsync();
		}
	}
}
