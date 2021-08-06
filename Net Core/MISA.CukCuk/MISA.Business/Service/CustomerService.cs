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
    public class CustomerService
    {
        #region Fields

        public ServiceResult ServiceResult;

        #endregion

        #region Constructor
        public CustomerService()
        {
            ServiceResult = new ServiceResult();
        }
        #endregion

        #region Methods

        public ServiceResult Post(Customer customer)
        {
            var customerContext = new CustomerContext();

            // 1. check mã hoặc tên nhân viên đã có hay chưa:
            if (string.IsNullOrEmpty(customer.CustomerCode) || string.IsNullOrEmpty(customer.FullName))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorEmptyCode;
                ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_FieldEmpty;
                return ServiceResult;
            }

            // 2. Check nhân viên có trùng mã hay không:
            if (customerContext.CheckDuplicateCustomerCode(customer.CustomerCode))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorDuplicateCode;
                ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_CodeExists;
                return ServiceResult;
            }

            // 3. Check Email nhập có hợp lệ hay không:
            if (customer.Email != null)
            {
                if (!Regex.IsMatch(customer.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    ServiceResult.Success = false;
                    ServiceResult.MISACode = MISAConst.MISAErrorInvalidEmail;
                    ServiceResult.UserMsg = Common.Properties.Resources.ValidateError_InvalidEmail;
                    return ServiceResult;
                }
            }

            // Thực hiện gọi employeeContext để thêm dữ liệu sau khi đã validate
            ServiceResult.Data = customerContext.Post(customer);
            return ServiceResult;
        }



        #endregion
    }
}
