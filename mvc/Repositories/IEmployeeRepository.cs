using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models;

namespace mvc.Repositories
{
    public interface IEmployeeRepository
    {
        List<tblEmployee> GetAllEmployee();
    }
}