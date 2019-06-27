using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProjectX.Core.Domain
{
	public class User
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Email")]
		public string Email { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("Password")]
		public string Password { get; set; }

		[BsonElement("UserType")]
		public string UserType { get; set; }

		[BsonElement("City")]
		public string City { get; set; }

		[BsonElement("Country")]
		public string Country { get; set; }

		[BsonElement("Phone")]
		public string Phone { get; set; }

		[BsonElement("AcceptedAd")]
		public bool AcceptedAd { get; set; }

		[BsonElement("LastLogon")]
		public DateTime LastLogon { get; set; }

		[BsonElement("Status")]
		public string Status { get; set; }

		[BsonElement("CreatedDate")]
		public DateTime CreatedDate { get; set; }

		[BsonElement("UpdatedDate")]
		public DateTime UpdatedDate { get; set; }
	}
}
