using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Common.Entity;

namespace MISA.DataAccess
{
    public interface IEmployeeContext
    {
        int Post(Employee employee);

        bool CheckDuplicateEmployeeCode(string employeeCode);
    }
}
