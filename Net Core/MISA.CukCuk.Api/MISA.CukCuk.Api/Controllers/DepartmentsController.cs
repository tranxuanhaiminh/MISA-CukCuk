using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Services;

namespace MISA.CukCuk.Api.Controllers
{
    public class DepartmentsController : BaseEntityController<Department>
    {
        IBaseRepository<Department> _baseRepository;
        IBaseService<Department> _baseService;
        public DepartmentsController(IBaseRepository<Department> baseRepository, IBaseService<Department> baseService):base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
    }
}
