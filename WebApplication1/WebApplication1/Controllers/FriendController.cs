using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/friend")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly IMapper _imapper;
        private readonly FriendRepository _ifrnRepo;

        public FriendController(IMapper imapper, FriendRepository ifrnRepo)
        {
            _imapper = imapper;
            _ifrnRepo = ifrnRepo;
        }


        [HttpPost("AddFriend")]
        public IActionResult AddFriend(ListFriend listFriend)
        {
            if (_ifrnRepo.existFriend(listFriend))
            {
                return BadRequest(listFriend);
            }

        }


    }

}
