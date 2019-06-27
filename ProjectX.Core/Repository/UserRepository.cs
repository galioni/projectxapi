using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectX.Core.Context;
using ProjectX.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectX.Core.Repository
{
	public class UserRepository : IUserRepository, IRepository<User>
	{
		private readonly UserContext _context = null;

		public string CollectionName => throw new NotImplementedException();

		public UserRepository(IOptions<Settings> settings)
		{
			this._context = new UserContext(settings);
		}

		public async Task<User> Authenticate(string email, string password)
		{
			var builder = Builders<User>.Filter;
			var filter = builder.Eq("Email", email) & builder.Eq("Password", password);

			var user = await _context.Users
									.Find(filter)
									.FirstOrDefaultAsync();

			if (user != null)
			{
				await this.UpdateLastLogon(user.Id.ToString());

				var userHistory = new UserHistory()
				{
					LoginDate = DateTime.Now,
					LoginSuccessful = true,
					UserId = user.Id.ToString()
				};

				await this.AddUserHistory(userHistory);
			}

			if (user == null)
				throw new ArgumentException("Usuário não encontrado");

			return user;
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			var builder = Builders<User>.Filter;
			return await _context.Users.Find(_=> true).ToListAsync();
		}

		public async Task AddUserHistory(UserHistory userHistory)
		{
			await _context.UserHistories.InsertOneAsync(userHistory);
		}

		public async Task UpdateLastLogon(String UserId)
		{
			var filter = Builders<User>.Filter.Eq("Id", UserId);
			var update = Builders<User>.Update.Set("LastLogon", DateTime.Now);

			await _context.Users.UpdateOneAsync(filter, update);
		}

		public void CreateIndex(IndexKeysDefinition<User> indexDefinition)
		{
			throw new NotImplementedException();
		}

		public void CreateIndex(IndexKeysDefinition<User> indexDefinition, CreateIndexOptions options)
		{
			throw new NotImplementedException();
		}

		public Task CreateIndexAsync(IndexKeysDefinition<User> indexDefinition, CreateIndexOptions options)
		{
			throw new NotImplementedException();
		}

		public Task<long> CountAsync(FilterDefinition<User> filter)
		{
			throw new NotImplementedException();
		}

		public Task<long> CountAsync(Expression<Func<User, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public IFindFluent<User, User> Find(Expression<Func<User, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public IFindFluent<User, User> Find(Expression<Func<User, bool>> filter, FindOptions options)
		{
			throw new NotImplementedException();
		}

		public IFindFluent<User, User> Find(FilterDefinition<User> filter)
		{
			throw new NotImplementedException();
		}

		public IFindFluent<User, User> Find(FilterDefinition<User> filter, FindOptions options)
		{
			throw new NotImplementedException();
		}

		public Task InsertOneAsync(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<User> UpsertOneAsync(Expression<Func<User, bool>> filter, User entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteManyAsync(Expression<Func<User, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public Task DeleteOneAsync(Expression<Func<User, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
