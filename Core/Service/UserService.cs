using AutoMapper;
using ProjectX.Core.Domain;
using ProjectX.Core.Entity;
using ProjectX.Core.Repository;
using ProjectX.Core.Service.Interface;
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

		public async Task<List<User>> GetAllUsersAsync()
		{
			var users = await _userRepository.GetAllUsersAsync();
			return _mapper.Map<List<UserEntity>, List<User>>(users);
		}

		public async Task<User> Authenticate(string login, string password)
		{
			var user = await _userRepository.Authenticate(login, password);
			return _mapper.Map<UserEntity, User>(user);
		}
	}
}
