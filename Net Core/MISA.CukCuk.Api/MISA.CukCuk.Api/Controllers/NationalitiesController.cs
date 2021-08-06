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
    public class NationalitiesController : BaseEntityController<Nationality>
    {
        IBaseRepository<Nationality> _baseRepository;
        IBaseService<Nationality> _baseService;
        public NationalitiesController(IBaseRepository<Nationality> baseRepository, IBaseService<Nationality> baseService):base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
    }
}
