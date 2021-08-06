using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common.Entity
{
    public class ServiceResult
    {
        /// <summary>
        ///  Trạng thái service: true - thành công, false - có lỗi validate
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public string UserMsg   { get; set; }

        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã trả về
        /// </summary>
        public string MISACode { get; set; }


    }
}
