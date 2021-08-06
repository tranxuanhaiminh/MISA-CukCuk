using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<MISAEntity>
    {
        List<MISAEntity> GetAll();
        MISAEntity GetById(Guid entityId);
        int Post(MISAEntity entity);
        int DeleteById(Guid entityId);
        bool CheckDuplicateEntityCode(string entityCode);
    }
}
