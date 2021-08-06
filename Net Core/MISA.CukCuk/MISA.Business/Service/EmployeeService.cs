using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using MISA.Common.Entity;
using MISA.DataAccess;
using System.Globalization;
using System.Text.RegularExpressions;
using MISA.Business.Const;

namespace MISA.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        #region Fields

        public ServiceResult ServiceResult;
        IEmployeeContext _employeeContext;

        #endregion

        #region Contructor
        public EmployeeService(IEmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            ServiceResult = new ServiceResult();
        }

        public EmployeeService()
        {
            ServiceResult = new ServiceResult();
        }
        #endregion

        #region Methods

        public ServiceResult Post(Employee employee)
        {

            //var employeeContext = new EmployeeContext2();

            // 1. check mã hoặc tên nhân viên đã có hay chưa:
            if (string.IsNullOrEmpty(employee.EmployeeCode) || string.IsNullOrEmpty(employee.FullName))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorEmptyCode;
                ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_FieldEmpty;
                return ServiceResult;
            }

            // 2. Check nhân viên có trùng mã hay không:
            if (_employeeContext.CheckDuplicateEmployeeCode(employee.EmployeeCode))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorDuplicateCode;
                ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_CodeExists;
                return ServiceResult;
            }

            // 3. Check Email nhập có hợp lệ hay không:
            if (employee.Email != null)
            {
                if (!Regex.IsMatch(employee.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    ServiceResult.Success = false;
                    ServiceResult.MISACode = MISAConst.MISAErrorInvalidEmail;
                    ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_InvalidEmail;
                    return ServiceResult;
                }
            }

            // Thực hiện gọi employeeContext để thêm dữ liệu sau khi đã validate
            int rowAffected = _employeeContext.Post(employee);
            ServiceResult.Data = rowAffected;
            return ServiceResult;
        }



        #endregion
    }
}
