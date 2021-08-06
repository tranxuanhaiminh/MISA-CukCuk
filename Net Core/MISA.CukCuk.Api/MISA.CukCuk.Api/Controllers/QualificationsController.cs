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
    public class QualificationsController : BaseEntityController<Qualification>
    {
        IBaseRepository<Qualification> _baseRepository;
        IBaseService<Qualification> _baseService;
        public QualificationsController(IBaseRepository<Qualification> baseRepository, IBaseService<Qualification> baseService):base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
    }
}
