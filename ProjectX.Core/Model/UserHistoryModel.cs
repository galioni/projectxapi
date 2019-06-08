using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProjectX.Core.Domain
{
	public class UserHistoryModel
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("UserId")]
		public string UserId { get; set; }

		[BsonElement("LoginSuccessful")]
		public bool LoginSuccessful { get; set; }

		[BsonElement("Message")]
		public string Message { get; set; }

		[BsonElement("LoginDate")]
		public DateTime LoginDate { get; set; }

		[BsonElement("LogoutDate")]
		public DateTime LogoutDate { get; set; }
	}
}
