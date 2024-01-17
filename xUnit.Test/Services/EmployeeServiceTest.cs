using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Services.Implementations;
using TestProject.Services.Interfaces;

namespace xUnit.Test.Services
{
    public class EmployeeServiceTest
    {
        public readonly UserService _userService;
        public readonly IEmployeeService _service;

        public EmployeeServiceTest() 
        {
            //dependencies
            _service = A.Fake<IEmployeeService>();

            //SUT
            _userService = new UserService(_service);
        }

        [Theory]
        [InlineData("PervaizABC")]
        public void UserService_DoesUserExist_ReturnBool(string name)
        {
            //Arrange
            A.CallTo(()=>_service.DoesEmployeeExist(name)).Returns(true);
            //A.CallTo() method fake the object that you want to test

            var result = _userService.DoesUserExist(name);

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: User Exist");
            result.Should().Contain("Success", Exactly.Once());
            
        }
    }
}
