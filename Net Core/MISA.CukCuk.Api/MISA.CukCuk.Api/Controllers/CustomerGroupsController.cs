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
    public class CustomerGroupsController : BaseEntityController<CustomerGroup>
    {
        IBaseRepository<CustomerGroup> _baseRepository;
        IBaseService<CustomerGroup> _baseService;
        public CustomerGroupsController(IBaseRepository<CustomerGroup> baseRepository, IBaseService<CustomerGroup> baseService):base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
    }
}
