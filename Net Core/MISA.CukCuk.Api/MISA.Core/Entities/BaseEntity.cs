using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo thông tin
        /// </summary>
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Người thêm thông tin
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa thông tin
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa thông tin
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
