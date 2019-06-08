using AutoMapper;
using ProjectX.Core.Domain;
using ProjectX.Core.Model;
using ProjectX.Core.Repository;
using ProjectX.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Core.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			this._userRepository = userRepository;
			this._mapper = mapper;
		}

		public async Task<User> Authenticate(string email, string password)
		{
			var user = await _userRepository.Authenticate(email, password);

			if (user != null)
			{
				await _userRepository.UpdateLastLogon(user.Id);

				var userHistory = new UserHistory()
				{
					LoginDate = DateTime.Now,
					LoginSuccessful = true,
					UserId = user.Id
				};

				await this.AddUserHistory(userHistory);
			}

			return _mapper.Map<UserModel, User>(user);
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			var users = await _userRepository.GetAllUsersAsync();
			return _mapper.Map<List<UserModel>, List<User>>(users);
		}

		#region .   Internal   .

		private async Task AddUserHistory(UserHistory userHistory)
		{
			var userHistoryModel = _mapper.Map<UserHistory, UserHistoryModel>(userHistory);
			await _userRepository.AddUserHistory(userHistoryModel);
		}

		#endregion
	}
}
