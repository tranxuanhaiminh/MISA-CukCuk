using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Entity
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreatedBy: TXHMinh (28/07/2021)
    public class Customer
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Id khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Tên đầy đủ khách hàng
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email nhân viên
        /// </summary>
        public string Email { get; set; }

    }
}
