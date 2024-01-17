using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Services.Interfaces
{
    public interface IEmployeeService
    {
       public string Create(string name);
       bool DoesEmployeeExist(string name);
    }
}
