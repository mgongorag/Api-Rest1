using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _usrRepor;
        private readonly IMapper _mapper;

        public UserController(IUserRepository usrRepo, IMapper mapper)
        {
            _usrRepor = usrRepo;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login(UserAuthDto userAuthDto)
        {
            userAuthDto.username = userAuthDto.username.ToLower().Trim();
            var userAuth = _usrRepor.LoginAuth(userAuthDto.username, userAuthDto.password);
            if (userAuth == null)
            {
                return Unauthorized();
            }
            return Ok(userAuth);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto userRegisterDto)
        {
            userRegisterDto.username = userRegisterDto.username.ToLower().Trim();
            userRegisterDto.email = userRegisterDto.email.ToLower().Trim();
            userRegisterDto.firstName = new CultureInfo("en-US", false).TextInfo.ToTitleCase(userRegisterDto.firstName);
            userRegisterDto.lastName = new CultureInfo("en-US", false).TextInfo.ToTitleCase(userRegisterDto.lastName);
            userRegisterDto.password = UserRegisterDto.EncrypthPassword(userRegisterDto.password);
                
            if (_usrRepor.existEmail(userRegisterDto.email))
            {
                ModelState.AddModelError("", "The email already exist");
                return StatusCode(404, ModelState);
            }

            if (_usrRepor.existUsername(userRegisterDto.username))
            {
                ModelState.AddModelError("", "The username already exist");
                return StatusCode(404, ModelState);
            }

            var user = _mapper.Map<User>(userRegisterDto);
            if (!_usrRepor.registerUser(user))
            {
                ModelState.AddModelError("", $"We have problems with register this user");
                return StatusCode(500, ModelState);
            }
            WsEmail.Email.emailRegister(userRegisterDto);
            return CreatedAtRoute("GetUser", new { userId = user.idUSer }, user);

        }

        [HttpGet("UserId:int", Name = "GetUser")]
        public IActionResult GetUser(int UserId)
        {
            var itemUser = _usrRepor.getUser(UserId);
            if(itemUser == null)
            {
                ModelState.AddModelError("", "Not found");
                return StatusCode(404, ModelState);
            }

            var itemUserDto = _mapper.Map<UserDto>(itemUser);
            
            return Ok(itemUserDto);
        }


    }
}
