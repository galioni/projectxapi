using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectX.Core.Domain;
using ProjectX.Core.Model;

namespace ProjectX.Core.Context
{
	public class UserContext
	{
		private readonly IMongoDatabase _database = null;

		public UserContext(IOptions<Settings> settings)
		{
			var client = new MongoClient(settings.Value.ConnectionString);
			if (client != null)
				_database = client.GetDatabase(settings.Value.Database);
		}

		public IMongoCollection<UserModel> Users
		{
			get
			{
				return _database.GetCollection<UserModel>("User");
			}
		}

		public IMongoCollection<UserHistoryModel> UserHistories
		{
			get
			{
				return _database.GetCollection<UserHistoryModel>("UserHistory");
			}
		}
	}
}
