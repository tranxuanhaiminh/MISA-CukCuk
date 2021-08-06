using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Common.Entity;

namespace MISA.Business.Service
{
    public interface IEmployeeService
    {
        ServiceResult Post(Employee employee);
    }
}
