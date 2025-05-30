using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UsersSystem.DTOs.User;
using UsersSystem.Interfaces;
using UsersSystem.Models;

namespace UsersSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet("get")]
        public async Task<ActionResult<ResponseModel<UserController>>> SearchUser(string email)
        {
            var user = await _user.SearchUser(email);
            return Ok(user);    
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseModel<UserController>>> CreateUser(UserDTO userDTO)
        {
            var user = await _user.CreateUser(userDTO);
            return Ok(user);
        } 
        [HttpPost("update")]
        public async Task<ActionResult<ResponseModel<UserController>>> UpDateUser(int id, UserModel userObject)
        {
            var user = await _user.UpdateUser(id, userObject);
            return Ok(user);
        }
    }
}
