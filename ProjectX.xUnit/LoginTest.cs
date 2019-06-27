using System;
using Xunit;

namespace ProjectX.xUnit
{
	public class LoginTest
	{
		TestHelper _testHelper;

		public LoginTest()
		{
			_testHelper = new TestHelper();
		}

		[Fact]
		public async void Task_Login_Wrong_Password()
		{
			var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
				 _testHelper._userRepository.Authenticate("deh.galioni@gmail.com", "45678")
			);

			Assert.Equal("Usuário não encontrado", exception.Message);
		}

		[Fact]

		public async void Task_Login_Ok()
		{
			var user = await _testHelper._userRepository.Authenticate("deh.galioni@gmail.com", "1234");

			Assert.Equal("André Galioni", user.Name);
		}
	}
}
