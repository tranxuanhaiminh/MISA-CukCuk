using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Vị trí
    /// </summary>
    public class Position : BaseEntity
    {
        #region Properties
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionCode { get; set; }
        public string Description { get; set; }
        #endregion

    }
}
