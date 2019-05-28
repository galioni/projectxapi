﻿using MongoDB.Bson;

namespace ProjectX.Core.Domain
{
	public class User
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
	}
}