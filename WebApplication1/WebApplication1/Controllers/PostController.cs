using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostinEnviroment;

        public PostController(IMapper mapper, IPostRepository postRepo, IUserRepository userRepo, IWebHostEnvironment hostEnvironment)
        {
            _mapper = mapper;
            _postRepo = postRepo;
            _userRepo = userRepo;
            _hostinEnviroment = hostEnvironment;
        }
        [HttpGet("PostOfFriends/{idUSer:int}")]
        public IActionResult PostOfFriends(int idUSer)
        {
            if (!_userRepo.existUserByID(idUSer))
            {
                return Json(new ReplyMessages((int)ErrorCode.UserDontExist, MessageError.UserDontExist));
            }

            var listPost = _postRepo.GetAllPostFromFriends(idUSer);

            if (listPost.Count == 0)
            {
                return NotFound(new ReplyMessages((int)ErrorCode.NotFound, MessageError.POST_DONT_EXIST));
            }

            return Ok(listPost);

        }

        [HttpGet("{id:int}", Name = "PostByIdUser")]
        public IActionResult PostByIdUser(int id)
        {
            if (!_userRepo.existUserByID(id))
            {
                return Json(new ReplyMessages((int)ErrorCode.UserDontExist, MessageError.UserDontExist));
            }

            var listPost = _postRepo.GetAllPostByIdFriend(id);

            if (listPost.Count == 0)
            {
                return NotFound(new ReplyMessages((int)ErrorCode.NotFound, MessageError.POST_DONT_EXIST));
            }

            return Ok(listPost);
        }

        [HttpPost]
        public IActionResult Add([FromForm] CreatePostDto post)
        {
            
            if(post.description == null && post.images == null)
            {
                return BadRequest(new ReplyMessages ((int) ErrorCode.BAD_REQUEST, MessageError.BAD_REQUEST) );
            }

            if (!_userRepo.existUserByID(post.idUser))
            {
                return BadRequest(new ReplyMessages((int)ErrorCode.UserDontExist, MessageError.UserDontExist));

            }

            var file = post.images;
            string path = _hostinEnviroment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            
            var postDB = new PostCreateDto();
            var ListImages = new List<ImagePostDto>();
            postDB.description = post.description;
            postDB.idTypePost = post.idTypePost;
            postDB.idUser = post.idUser;

            
            if (file != null)
            {
                if(file.Count > 0 )
                {
                   for(int i = 0; i < file.Count; i++)
                    {
                        var extension = Path.GetExtension(files[i].FileName);
                        if (extension != ".jpg" && extension != ".png")
                        {
                            return BadRequest(new ReplyMessages((int)ErrorCode.BAD_REQUEST, MessageError.FORMAT_IMAGES));
                        }
                    }
                   for(int i = 0; i < file.Count; i++)
                    {
                        var imageDto = new ImagePostDto();
                        var extension = Path.GetExtension(files[i].FileName);
                            
                            string nameImage = Guid.NewGuid().ToString();
                            var up = Path.Combine(path, @"Images");
                            using (var fileStream = new FileStream(Path.Combine(up, nameImage + extension), FileMode.Create))
                            {
                                files[i].CopyTo(fileStream);
                            }
                        imageDto.path = @"\Images\" + nameImage + extension;
                        ListImages.Add(imageDto);
                    }

                    postDB.images = ListImages;
                    
                }
            }

            if (!_postRepo.AddPost(postDB))
            {
                return BadRequest(new ReplyMessages((int) ErrorCode.NotSuccess, MessageError.NotSuccess));
            }

            return Ok(new ReplyMessages((int)ErrorCode.Success, MessageError.Success));
        }


    }
}
