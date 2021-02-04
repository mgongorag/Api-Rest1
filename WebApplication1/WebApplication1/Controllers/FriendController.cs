using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;
using WebApplication1.Repository;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/friend")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFriendRepository _ifrnRepo;
        private readonly IUserRepository _usrRepository;

        public FriendController(IMapper mapper, IFriendRepository ifrnRepo, IUserRepository userRepository)
        {
            _mapper = mapper;
            _ifrnRepo = ifrnRepo;
            _usrRepository = userRepository;
        }


        [HttpPost("AddFriend")]
        public IActionResult AddFriend( [FromBody] ListFriendDto listFriendDto )
        {

            if (!_usrRepository.existUserByID( listFriendDto.idUser ) || !_usrRepository.existUserByID( listFriendDto.idFriend ))
            {
                return Json( new ReplyMessages((int)ErrorCode.UserDontExist, MessageError.UserDontExist));
            }

            if (_ifrnRepo.existFriend( listFriendDto ))
            {
                return Json ( new ReplyMessages((int)ErrorCode.FriendAlreadyExist, MessageError.FriendAlreadyExist) );
            }

            var listFriend = _mapper.Map<ListFriend>(listFriendDto);
            if (!_ifrnRepo.addFriend(listFriend))
            {
                return Json(new ReplyMessages((int)ErrorCode.NotSuccess, MessageError.NotSuccess));

            }
            //return CreatedAtRoute("GetUser", new { userId = user.idUSer }, user);
            return Json( new ReplyMessages(1, "Agregado"));
        }


    }

}
