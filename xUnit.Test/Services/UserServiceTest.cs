using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;
using TestProject.Services.Implementations;

namespace xUnit.Test.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void UserService_GetName_ReturnString()
        {
            //Arrange - variables, classes, mocks
            var userService = new UserService();
            //Act
            var result = userService.getName();

            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Pervaiz Ahmad");
        }

        [Theory]
        [InlineData("Pervaiz Ahmad", "pervaiz.ahmad@speridian.com", "Pervaiz Ahmad <pervaiz.ahmad@speridian.com>")]
        public void UserService_GetCombinedNameAndEmail_ReturnString(string name, string email, string expectedResult)
        {
            //Arange
            var userService = new UserService();

            //Act
            var result = userService.getCombinedNameAndEmail(name, email);

            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void UserService_IsEmailConfirmed_ReturnBoolean()
        {
            //Arrange
            var userService = new UserService();

            //Act
            var result = userService.isEmailConfirmed();

            //Assert
            result.Should().BeTrue();
            result.Should().NotBe(false);
        }

        [Fact]
        public void UserService_GetUserCreatedDate_ReturnDate()
        {
            //Arrange - variables, classes, mocks
            var userService = new UserService();
            //Act
            var result = userService.getUserCreatedDate();

            //Assert
            result.Should().NotBeBefore(1.January(2024));
            result.Should().NotBeAfter(17.January(2024));
        }

        [Fact]
        public  void UserService_GetUser_ReturnObject()
        {
            var userService = new UserService();
            var result = userService.getUser();

            result.Should().NotBeNull();
            result.Should().BeOfType<UserModel>();

            //we can compare a property of an object
            result.Name.Should().Be("Pervaiz Ahmad");

        }
        [Fact]
        public  void UserService_GetUsers_ReturnObject()
        {
            var userService = new UserService();
            var result = userService.getUsers();

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<UserModel>>();

            result.Should().HaveCountGreaterThanOrEqualTo(1);
            //result.Should().HaveCount(1);  // if we want exact number of count
            result.Should().Contain(x=>x.IsDeleted == false);

        }
    }
}
