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
    public class PositionsController : BaseEntityController<Position>
    {
        IBaseRepository<Position> _baseRepository;
        IBaseService<Position> _baseService;
        public PositionsController(IBaseRepository<Position> baseRepository, IBaseService<Position> baseService):base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
    }
}
