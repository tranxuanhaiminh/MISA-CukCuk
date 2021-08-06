using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CSharp
{
    public class Base<TEntity> where TEntity : class
    {
        /// <summary>
        /// Set tên cho đổi tượng
        /// </summary>
        /// <typeparam name="TEntity">Kiểu của đối tượng</typeparam>
        /// <param name="entity">Đối tượng muốn đặt tên</param>
        /// <param name="name">Tên muốn đặt</param>
        /// CreatedBy: TXHMinh (23/07/2021)
        public static void SetName(TEntity entity, string name)
        {
            entity.GetType().GetProperty("FullName").SetValue(entity, name);
        }
    }
}
