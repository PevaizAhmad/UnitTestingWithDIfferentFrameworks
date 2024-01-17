using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
    public class UserService
    {
        public readonly IEmployeeService _employeeService;

        public UserService(IEmployeeService EmployeeService)
        {
            this._employeeService = EmployeeService;
        }
        public string getName()
        {
            return "Pervaiz Ahmad";
        }

        public string getCombinedNameAndEmail(string name, string email)
        {
            return $"{name} <{email}>";
        }

        public bool isEmailConfirmed()
        {
            return true;
        }

        public DateTime getUserCreatedDate()
        {
            return DateTime.Now;
        }

        public UserModel getUser()
        {
            return new UserModel
            {
                Id = 1,
                Name = getName(),
                Email = "pervaiz.ahmad@speridian.com"
            };
        }

        public IEnumerable<UserModel> getUsers()
        {
            IEnumerable<UserModel> users = new List<UserModel>()
            {
                new UserModel
                {
                    Id = 1,
                    Name = "Pervaiz Ahmad",
                    Email = "pervaiz.ahmad@speridian.com",
                    IsDeleted = false,
                },
                new UserModel
                {
                    Id = 2,
                    Name = "Umer Awais Malik",
                    Email = "umer.awais@speridian.com",
                    IsDeleted = false,
                },
                new UserModel
                {
                    Id = 3,
                    Name = getName(),
                    Email = "ashraf.faheem@speridian.com",
                    IsDeleted = false,
                }
            };

            return users;
        }

        public string DoesUserExist(string username)
        {
            var result = this._employeeService.DoesEmployeeExist(username);

            if (result)
            {
                return "Success: User Exist";
            }
            else
            {
                return "Failed: User does not exist";
            }
        }
    }
}
