using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Dtos;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/TypeOfNotification")]
    [ApiController]
    public class TypeOfNotificationController : Controller
    {
        private readonly ITypeOfNotificationRepository _tnRepo;
        private readonly IMapper _mapper;

        public TypeOfNotificationController(ITypeOfNotificationRepository tnrepo, IMapper mapper)
        {
            _tnRepo = tnrepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTypesOfNotification()
        {
            var listTypes = _tnRepo.GetTypeOfNotifications();
            var listTypesDto = new List<TypeOfNotificationDto>();
            foreach(var list in listTypes)
            {
                listTypesDto.Add(_mapper.Map<TypeOfNotificationDto>(list));
            }
            return Ok(listTypesDto);
        }

    }
}
