using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Enum;

namespace MISA.Common.Entity
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// CreatedBy: TXHMinh (28/07/2021)
    public class Employee
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên họ của nhân viên
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Tên đầy đủ nhân viên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email nhân viên
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số CMND nhân viên
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp CMND của nhân viên
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND của nhân viên
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân của nhân viên
        /// </summary>
        public int? MartialStatus { get; set; }

        /// <summary>
        /// Học bạ nhân viên
        /// </summary>
        public int? EducationalBackground { get; set; }

        /// <summary>
        /// Chứng chỉ nhân viên
        /// </summary>
        public Guid? QualificationId { get; set; }

        /// <summary>
        /// Phòng ban nhân viên
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Vị trí nhân viên
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tình trạng làm việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Người thêm nhân viên
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa thông tin nhân viên
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa thông tin nhân viên
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion


    }
}
