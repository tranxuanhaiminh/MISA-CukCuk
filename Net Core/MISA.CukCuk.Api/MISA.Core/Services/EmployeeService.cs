using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MISA.Core.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using MISA.Core.Interfaces.Services;
using MISA.Core.Const;
using MISA.Core.Properties;
using MISA.Core.Interfaces.Infrastructure;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields
        IEmployeeContext _employeeContext;
        #endregion

        #region Contructor
        public EmployeeService(IEmployeeContext employeeContext) : base(employeeContext)
        {
            _employeeContext = employeeContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức trả về phân trang
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public object GetPaging()
        {
            var res = _employeeContext.GetPaging();
            return res;
        }


        protected override ServiceResult ValidateCustom(Employee entity)
        {
            // 1. check mã hoặc tên nhân viên đã có hay chưa:
            if (string.IsNullOrEmpty(entity.EmployeeCode) || string.IsNullOrEmpty(entity.FullName))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorEmptyCode;
                ServiceResult.UserMsg = Resources.ValidateError_FieldEmpty;
                return ServiceResult;
            }

            // 2. Check nhân viên có trùng mã hay không:
            //if (_employeeContext.CheckDuplicateEmployeeCode(employee.EmployeeCode))
            //{
            //    ServiceResult.Success = false;
            //    ServiceResult.MISACode = MISAConst.MISAErrorDuplicateCode;
            //    ServiceResult.UserMsg = Resources.ValidateError_CodeExists;
            //    return ServiceResult;
            //}

            // 3. Check Email nhập có hợp lệ hay không:
            //if (entity.Email != null)
            //{
            //    if (!Regex.IsMatch(entity.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            //    {
            //        ServiceResult.Success = false;
            //        ServiceResult.MISACode = MISAConst.MISAErrorInvalidEmail;
            //        ServiceResult.UserMsg = Resources.ValidateError_InvalidEmail;
            //        return ServiceResult;
            //    }
            //}
            return ServiceResult;
        }
        #endregion
    }
}
