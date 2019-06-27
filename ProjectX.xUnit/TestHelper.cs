using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.Core.Domain;
using ProjectX.Core.Repository;
using System;

namespace ProjectX.xUnit
{
	public class TestHelper
	{
		private IConfiguration _configuration;
		private ServiceProvider serviceProvider;

		public IUserRepository _userRepository;

		public TestHelper()
		{
			var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
			var config = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.AddEnvironmentVariables();
			_configuration = config.Build();

			var services = new ServiceCollection();

			//Add all repositories to be used
			services.AddTransient<IUserRepository, UserRepository>();

			services.AddOptions();
			services.Configure<Settings>(options =>
			{
				options.ConnectionString = _configuration.GetSection("MongoConnection:ConnectionString").Value;
				options.Database = _configuration.GetSection("MongoConnection:Database").Value;
			});
			serviceProvider = services.BuildServiceProvider();

			_userRepository = serviceProvider.GetRequiredService<IUserRepository>();
		}
	}
}
