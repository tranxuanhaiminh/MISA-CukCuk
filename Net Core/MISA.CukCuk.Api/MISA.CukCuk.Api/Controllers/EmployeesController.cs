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
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region Fields
        /// <summary>
        /// Đối tượng chứa thông tin lỗi
        /// </summary>
        /// CreatedBy: TXHMinh (28/07/2021)
        ErrorResponse _errorResponse = new();
        IEmployeeService _employeeService;
        IBaseRepository<Employee> _baseRepository;
        #endregion

        #region Constructor
        public EmployeesController(IBaseRepository<Employee> baseRepository, IEmployeeService employeeService):base(baseRepository, employeeService)
        {
            _baseRepository = baseRepository;
            _employeeService = employeeService;
        }
        #endregion

        #region Methods

        [HttpGet("paging")]
        public override IActionResult GetPaging(int pageNumber, int pageSize)
        {
            try
            {
                var res = _employeeService.GetPaging();
                return Ok(res);
            }
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = MISA.Core.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }
        #endregion
    }
}
