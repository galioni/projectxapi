using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectX.Core.Context;
using ProjectX.Core.Domain;
using ProjectX.Core.Model;
using System;
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

		public async Task AddUserHistory(UserHistoryModel userHistoryModel)
		{
			await _context.UserHistories.InsertOneAsync(userHistoryModel);
		}

		public async Task<UserModel> Authenticate(string email, string password)
		{
			var builder = Builders<UserModel>.Filter;
			var filter = builder.Eq("Email", email) & builder.Eq("Password", password);

			return await _context.Users
									.Find(filter)
									.FirstOrDefaultAsync();
		}

		public async Task<List<UserModel>> GetAllUsersAsync()
		{
			var builder = Builders<User>.Filter;
			return await _context.Users.Find(_=> true).ToListAsync();
		}

		public async Task UpdateLastLogon(String UserId)
		{
			var filter = Builders<UserModel>.Filter.Eq("Id", UserId);
			var update = Builders<UserModel>.Update.Set("LastLogon", DateTime.Now);

			await _context.Users.UpdateOneAsync(filter, update);
		}
	}
}
