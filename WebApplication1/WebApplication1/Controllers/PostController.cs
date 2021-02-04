using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models.Dtos;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepo;
        private readonly IUserRepository _userRepo;

        public PostController(IMapper mapper, IPostRepository postRepo, IUserRepository userRepo)
        {
            _mapper = mapper;
            _postRepo = postRepo;
            _userRepo = userRepo;
        }

        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult PostByIdUser(int id)
        {
            if (!_userRepo.existUserByID(id))
            {
                return Json(new ReplyMessages((int)ErrorCode.UserDontExist, MessageError.UserDontExist));
            }


            var listPost = _postRepo.GetAllPostByIdFriend(id);

            var listPostDto = new List<PostDto>();

            foreach (var list in listPost)
            {
                listPostDto.Add(_mapper.Map<PostDto>(list));
            }

            return Ok(listPostDto);
        }

    }
}
