using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectX.API.Auth;
using ProjectX.Core.Domain;
using ProjectX.Core.Repository;
using System;
using System.Threading.Tasks;

namespace ProjectX.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
						builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,

						ValidIssuer = Configuration.GetSection("Authentication:Issuer").Value,
						ValidAudience = Configuration.GetSection("Authentication:Audience").Value,
						IssuerSigningKey = JwtSecurityKey.Create(Configuration.GetSection("Authentication:SecurityKey").Value)
					};

					options.Events = new JwtBearerEvents
					{
						OnAuthenticationFailed = context =>
						{
							Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
							return Task.CompletedTask;
						},
						OnTokenValidated = context =>
						{
							Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
							return Task.CompletedTask;
						}
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
				options.AddPolicy("Moderator", policy => policy.RequireClaim("Moderator"));
				options.AddPolicy("User", policy => policy.RequireClaim("User"));
			});

			services.AddMvc();

			services.Configure<Settings>(options =>
			{
				options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
				options.Database = Configuration.GetSection("MongoConnection:Database").Value;
			});

			#region .   Repository   .
			services.AddTransient<IUserRepository, UserRepository>();
			#endregion
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			// if (env.IsDevelopment())
			// {
			//     app.UseDeveloperExceptionPage();
			// }

			app.UseCors("CorsPolicy");
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();

			app.UseMvc();
		}
	}
}
