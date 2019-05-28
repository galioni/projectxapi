using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectX.Core.Entity
{
	public class UserEntity
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
	}
}
