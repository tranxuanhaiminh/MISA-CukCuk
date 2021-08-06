using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MISA.Common.Entity;
using MISA.Business.Service;
using MISA.Common.Enum;
using MISA.Business.Const;
using MISA.DataAccess;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Đối tượng chứa thông tin lỗi
        /// </summary>
        /// CreatedBy: TXHMinh (28/07/2021)
        ErrorResponse _errorResponse = new();

        #endregion

        #region Methods

        /// <summary>
        /// Phương thức lấy tất cả khách hàng
        /// </summary>
        /// <returns> Danh sách thông tin các khách hàng dưới dạng JSON
        /// - 200: OK
        /// - 201: Thêm mới dữ liệu thành công vào database.
        /// - 204: Không có dữ liệu
        /// - 400: - BadRequest - dữ liệu đầu vào từ client không hợp lệ
        /// - 404: - Không tìm thấy resource
        /// - 500: - Lỗi phía server
        /// </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var customerContext = new CustomerContext();
                var customers = customerContext.GetAll();

                // Kiểm tra thông tin trả về từ database nếu rỗng báo lỗi 204 (No Content)
                if (customers.Count > 0)
                    return Ok(customers); // StatusCode(200, employees)
                else
                    return NoContent();
            }

            // Các lỗi khác
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = Common.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }

        /// <summary>
        /// Phương thức lấy cả khách hàng theo Id
        /// </summary>
        /// <returns> Thông tin nhân viên dưới dạng JSON
        /// - 200: OK
        /// - 201: Thêm mới dữ liệu thành công vào database.
        /// - 204: Không có dữ liệu
        /// - 400: - BadRequest - dữ liệu đầu vào từ client không hợp lệ
        /// - 404: - Không tìm thấy resource
        /// - 500: - Lỗi phía server
        /// </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var customerContext = new CustomerContext();
                var customers = customerContext.GetById(customerId);

                // Kiểm tra dữ liệu nếu trống trả về lỗi 204 (No Content)
                if (customers != null)
                    return Ok(customers); // StatusCode(200, "MISA")
                else
                    return NoContent();
            }

            // Các lỗi khác
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = Common.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }

        /// <summary>
        /// Phương thức thêm nhân viên lên database
        /// </summary>
        /// <returns> Danh sách thông tin các nhân viên dưới dạng JSON
        /// - 200: OK
        /// - 201: Thêm mới dữ liệu thành công vào database.
        /// - 204: Không có dữ liệu
        /// - 400: - BadRequest - dữ liệu đầu vào từ client không hợp lệ
        /// - 404: - Không tìm thấy resource
        /// - 500: - Lỗi phía server
        /// </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //[HttpPost]
        //public IActionResult Post([FromBody] Customer customer)
        //{
        //    try
        //    {
        //        //Thực hiện thêm dữ liệu vào database
        //        CustomerService customerService = new();
        //        var serviceResult = customerService.Post(customer);

        //        // Kiểm tra dữ liệu trả về bởi EmployeeService
        //        if (serviceResult.Success == false)
        //        {
        //            return BadRequest(serviceResult);
        //        }

        //        // Kiểm tra kết quả
        //        var rowAffected = (int)serviceResult.Data;
        //        if (rowAffected == 1)
        //        {
        //            return Created($"~api/v1/customers/'{customer.CustomerId}'", customer);
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }

        //        // Các lỗi khác
        //    }
        //    catch (Exception e)
        //    {
        //        _errorResponse.ErrorCode = MISAConst.MISAErrorException;
        //        _errorResponse.UserMsg = Common.Properties.Resources.ErrorException;
        //        _errorResponse.DevMsg = e.Message;

        //        return StatusCode(500, _errorResponse);
        //    }

        //}

        /// <summary>
        /// Phương thức xóa nhân viên khỏi database
        /// </summary>
        /// <returns> 
        /// - 200: OK
        /// - 201: Thêm mới dữ liệu thành công vào database.
        /// - 204: Không có dữ liệu
        /// - 400: - BadRequest - dữ liệu đầu vào từ client không hợp lệ
        /// - 404: - Không tìm thấy resource
        /// - 500: - Lỗi phía server
        /// </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var customerContext = new CustomerContext();
                var rowAffected = customerContext.DeleteById(customerId);

                // Kiểm tra dữ liệu nếu trống trả về lỗi 204 (No Content)
                if (rowAffected == 1)
                    return Ok("Đã xóa " + rowAffected + " dòng khỏi database"); // StatusCode(200, "MISA")
                else
                    return NoContent();
            }

            // Các lỗi khác
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = Common.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }

        #endregion
    }
}
