using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MISA.Core.Entities;
using MISA.Core.Services;
using MISA.Core.Enum;
using MISA.Core.Const;
using MISA.Core.Interfaces.Services;
using MISA.Infrastructure.Repository;
using MISA.Core.Interfaces.Infrastructure;

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomersController : BaseEntityController<Customer>
    {
        #region Fields

        /// <summary>
        /// Đối tượng chứa thông tin lỗi
        /// </summary>
        /// CreatedBy: TXHMinh (28/07/2021)
        ErrorResponse _errorResponse = new();
        ICustomerService _customerService;
        IBaseRepository<Customer> _baseRepository;

        #endregion

        #region Constructor

        public CustomersController(IBaseRepository<Customer> baseRepository, ICustomerService customerService):base(baseRepository, customerService)
        {
            _baseRepository = baseRepository;
            _customerService = customerService;
        }

        #endregion

        #region Methods

        #endregion
    }
}
