using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public bool DoesEmployeeExist(string name)
        {
            if(name == "Pervaiz")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Create(string name)
        {
            throw new NotImplementedException();
        }

    }
}
