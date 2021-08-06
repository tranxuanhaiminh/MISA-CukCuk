using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Nhóm khách hàng
    /// </summary>
    public class CustomerGroup : BaseEntity
    {
        #region Properties
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string CustomerGroupCode { get; set; }
        public string Description { get; set; }
        #endregion

    }
}
