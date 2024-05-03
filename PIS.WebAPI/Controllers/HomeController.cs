using Microsoft.AspNetCore.Mvc;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using PIS.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    [ApiController, Route("pis")]
    public class HomeController : Controller
    {
        private IService _service { get; set; }

        public HomeController(IService service)
        {
            _service = service;
        }

        [HttpGet, Route("test")]
        public string Test() {
            return _service.Test();
        }

        [HttpGet, Route("users_db")]
        public IEnumerable<PisUsersDrupcic> GetAllUsersDb() {
            return _service.GetAllUsers();
        }


        [HttpGet, Route("users")]
        [HttpGet, Route("users/{id}")]
        public IEnumerable<UsersDTO> GetAllUsersDTOs(int? id)
        {
            if (id != null) {
                return new List<UsersDTO>() { _service.GetUserDTOById((int)id) };
            }
            return _service.GetAllUsersDTOs();
        }

        [Route("users/add")]
        public async Task<IActionResult> AddUserAsync([FromBody] UsersREST user)
        {


            UsersDTO dto = new UsersDTO()
            {
                UserLoginName = user.UserLoginName,
                UserName = user.UserName,
                UserSurname = user.UserSurname
            };

            bool add_user = await _service.AddUserAsync(dto);
            if(add_user) 
                return Ok("User je dodan!"); 
            else return Ok("User nije dodan!"); 
        }
    }
}
