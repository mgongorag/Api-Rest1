using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _pstRepository;

        public PostController(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _pstRepository = postRepository;
        }
    }
}
