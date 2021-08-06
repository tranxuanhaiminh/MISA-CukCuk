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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Fields
        ICustomerContext _customerContext;
        #endregion

        #region Contructor
        public CustomerService(ICustomerContext customerContext) : base(customerContext)
        {
            _customerContext = customerContext;
        }
        #endregion

        #region Methods
        public override ServiceResult Post(Customer customer)
        {

            //var employeeContext = new EmployeeContext2();

            // 1. check mã hoặc tên nhân viên đã có hay chưa:
            if (string.IsNullOrEmpty(customer.CustomerCode) || string.IsNullOrEmpty(customer.FullName))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorEmptyCode;
                ServiceResult.UserMsg = Resources.ValidateError_FieldEmpty;
                return ServiceResult;
            }

            // 2. Check nhân viên có trùng mã hay không:
            //if (_customerContext.CheckDuplicateCustomerCode(customer.CustomerCode))
            //{
            //    ServiceResult.Success = false;
            //    ServiceResult.MISACode = MISAConst.MISAErrorDuplicateCode;
            //    ServiceResult.UserMsg = Resources.ValidateError_CodeExists;
            //    return ServiceResult;
            //}

            // 3. Check Email nhập có hợp lệ hay không:
            if (customer.Email != null)
            {
                if (!Regex.IsMatch(customer.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    ServiceResult.Success = false;
                    ServiceResult.MISACode = MISAConst.MISAErrorInvalidEmail;
                    ServiceResult.UserMsg = Resources.ValidateError_InvalidEmail;
                    return ServiceResult;
                }
            }

            // Thực hiện gọi employeeContext để thêm dữ liệu sau khi đã validate
            int rowAffected = _customerContext.Post(customer);
            ServiceResult.Data = rowAffected;
            return ServiceResult;
        }
        #endregion
    }
}
