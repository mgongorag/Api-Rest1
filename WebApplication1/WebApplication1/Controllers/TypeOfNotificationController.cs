using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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


        [HttpGet("{idType:int}", Name = "GetTypeOfNotificationsById")]
        public IActionResult GetTypeOfNotificationsById(int idType)
        {
            var itemTypeOfNotifications = _tnRepo.GetTypeOfNotificationsById(idType);
            if(itemTypeOfNotifications == null)
            {
                ModelState.AddModelError("error:", "Type of notification not foud");
                return NotFound(ModelState);
            }
            var itemTypeOfNotificationDto = _mapper.Map<TypeOfNotificationDto>(itemTypeOfNotifications);
            return Ok(itemTypeOfNotificationDto);
        }
    }
}
