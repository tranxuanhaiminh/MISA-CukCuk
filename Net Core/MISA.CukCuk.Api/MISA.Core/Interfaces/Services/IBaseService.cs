using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Phương thức thêm dữ liệu lên database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: TXHMinh (03/08/2021)
        ServiceResult Post(MISAEntity entity);
    }
}
