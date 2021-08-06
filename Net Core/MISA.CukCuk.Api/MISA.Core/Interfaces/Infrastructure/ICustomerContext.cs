using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface dùng cho nghiệp vụ
    /// </summary>
    /// CreatedBy: TXHMinh (30/07/2021)
    public interface ICustomerContext : IBaseRepository<Customer>
    {
        /// <summary>
        /// Phương thức kiểm tra sự trùng lặp của mã nhân viên với data có sẵn
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns> bool - true: có bị trùng - false: không bị trùng</returns>
        /// CreatedBy: TXHMinh (30/07/2021)
        //bool CheckDuplicateCustomerCode(string customerCode);
    }
}
