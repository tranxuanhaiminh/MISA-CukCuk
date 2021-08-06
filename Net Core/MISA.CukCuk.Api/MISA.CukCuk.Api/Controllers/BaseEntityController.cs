 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Const;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Services;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Đối tượng chứa thông tin lỗi
        /// </summary>
        /// CreatedBy: TXHMinh (28/07/2021)
        ErrorResponse _errorResponse = new();
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức lấy tất cả nhân viên
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
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var entities = _baseRepository.GetAll();

                // Kiểm tra thông tin trả về từ database nếu rỗng báo lỗi 204 (No Content)
                if (entities.Count > 0)
                    return Ok(entities); // StatusCode(200, employees)
                else
                    return NoContent();
            }

            // Các lỗi khác
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = Core.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }

        /// <summary>
        /// Phương thức lấy cả nhân viên theo Id
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
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var entity = _baseRepository.GetById(entityId);

                // Kiểm tra dữ liệu nếu trống trả về lỗi 204 (No Content)
                if (entity != null)
                    return Ok(entity); // StatusCode(200, "MISA")
                else
                    return NoContent();
            }

            // Các lỗi khác
            catch (Exception e)
            {
                _errorResponse.DevMsg = e.Message;
                _errorResponse.UserMsg = MISA.Core.Properties.Resources.ErrorException;
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;

                return StatusCode(500, _errorResponse);
            }
        }

        /// <summary>
        /// Phương thức trả về phân trang
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TXHMinh (05/08/2021)
        [HttpGet("paging")]
        public virtual IActionResult GetPaging(int pageNumber, int pageSize)
        {
            return Ok(pageNumber + " " + pageSize);
        }

        /// <summary>
        /// Phương thức thêm thông tin lên database
        /// </summary>
        /// <returns> Danh sách thông tin dưới dạng JSON
        /// - 200: OK
        /// - 201: Thêm mới dữ liệu thành công vào database.
        /// - 204: Không có dữ liệu
        /// - 400: - BadRequest - dữ liệu đầu vào từ client không hợp lệ
        /// - 404: - Không tìm thấy resource
        /// - 500: - Lỗi phía server
        /// </returns>
        /// CreatedBy: TXHMinh (05/08/2021)
        [HttpPost]
        public virtual IActionResult Post(MISAEntity entity)
        {
            try
            {
                //Thực hiện thêm dữ liệu vào database
                var serviceResult = _baseService.Post(entity);

                // Kiểm tra dữ liệu trả về bởi EmployeeService
                if (serviceResult.Success == false)
                {
                    return BadRequest(serviceResult);
                }

                // Kiểm tra kết quả
                var rowAffected = (int)serviceResult.Data;
                var className = entity.GetType().Name;
                var entityId = entity.GetType().GetProperty($"{className}Id").GetValue(entity);
                if (rowAffected >= 1)
                {
                    return Created($"~api/v1/{className}s/'{entityId}'", entity);
                }
                else
                {
                    return StatusCode(409, serviceResult);
                }

                // Các lỗi khác
            }
            catch (Exception e)
            {
                _errorResponse.ErrorCode = MISAConst.MISAErrorException;
                _errorResponse.UserMsg = MISA.Core.Properties.Resources.ErrorException;
                _errorResponse.DevMsg = e.Message;

                return StatusCode(500, _errorResponse);
            }
        }

        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                //Thực hiện lấy dữ liệu từ database
                var rowAffected = _baseRepository.DeleteById(entityId);

                // Kiểm tra dữ liệu nếu trống trả về lỗi 204 (No Content)
                if (rowAffected >= 1)
                    return Ok("Đã xóa " + rowAffected + " dòng khỏi database"); // StatusCode(200, "MISA")
                else
                    return NoContent();
            }

            // Các lỗi khác
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
