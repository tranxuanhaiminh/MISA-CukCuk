using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common.Enum
{
    /// <summary>
    /// Giới tính
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,

        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,

        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Tình trạng hôn nhân
    /// </summary>
    public enum MartialStatus
    {
        /// <summary>
        /// Chưa kết hôn
        /// </summary>
        Single = 0,
        
        /// <summary>
        /// Đã kết hôn
        /// </summary>
        Married = 1
    }

    /// <summary>
    /// Bằng cấp chứng chỉ?
    /// </summary>
    public enum EducationalBackground
    {
        /// <summary>
        /// Có học?
        /// </summary>
        No = 0,

        /// <summary>
        /// Vô học?
        /// </summary>
        Yes = 1
    }

    /// <summary>
    /// Tình trạng làm việc
    /// </summary>
    public enum WorkStatus
    {
        /// <summary>
        /// Đã nghỉ làm
        /// </summary>
        Stopped = -1,

        /// <summary>
        /// Đang làm thử
        /// </summary>
        Trial = 0,

        /// <summary>
        /// Đang làm
        /// </summary>
        Working = 1,

        /// <summary>
        /// Đang nghỉ lễ
        /// </summary>
        Vacation = 2,

        /// <summary>
        /// Đã nghỉ hưu
        /// </summary>
        Retired = 3
    }
}
