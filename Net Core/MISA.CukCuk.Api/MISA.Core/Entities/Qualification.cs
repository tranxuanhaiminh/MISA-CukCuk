using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{   
     /// <summary>
     /// Phòng ban
     /// </summary>
    public class Qualification : BaseEntity
    {
        #region Properties
        public Guid QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationCode { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
