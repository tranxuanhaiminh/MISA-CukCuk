using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Quốc tịch
    /// </summary>
    public class Nationality : BaseEntity
    {
        #region Properties
        public Guid NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string NationalityCode { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
