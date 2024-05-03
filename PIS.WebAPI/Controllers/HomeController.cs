using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Common;
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
        #region Properties
        
        private IService _service { get; set; }
        private int _requestUserId;
        #endregion

        #region Constructor

        public HomeController(IService service)
        {
            _service = service;
            _requestUserId = -1;
        }
        #endregion

        #region Methods
        [HttpGet, Route("test")]
        public string Test() {
            return _service.Test();
        }

        [HttpGet, Route("users_db")]
        public Task<Tuple<List<PisUsersDrupcic>, List<ErrorMessage>>> GetAllUsersDb() {
            HttpRequestResponse<IEnumerable<PisUsersDrupcic>> reponse = new HttpRequestResponse<IEnumerable<PisUsersDrupcic>>();

            var users = _service.GetAllUsers();

            //if (users != null) {
            //    reponse = users.Result.Item1;
            //}
            //return reponse;
            return users;
        }


        [HttpGet, Route("users")]
        [HttpGet, Route("users/{id}")]
        //public IEnumerable<UsersDTO> GetAllUsersDTOs(int? id)
        public async Task<Tuple<List<UsersDTO>, List<ErrorMessage>>> GetAllUsersDTOs(int? id)
        {
            if (id != null) {
                var result = _service.GetUserDTOById((int)id);
                
                return Tuple.Create(new List<UsersDTO>() { result.Item1 }, result.Item2);
            }
            return _service.GetAllUsersDTOs();
        }

        [Route("users/add")]
        public async Task<IActionResult> AddUserAsync([FromBody] UsersREST user)
        {
            bool reqUser = await PickLastRequestUserId();
            if (!reqUser)
            {
                return BadRequest("Missing params in request header.");
            }

            if (user.UserLoginName == string.Empty ||
                user.UserLoginName.Length >= 128 ||
                user.UserSurname.Length >= 128 ||
                user.UserName.Length >= 128) {
                return BadRequest(StatusCodes.Status406NotAcceptable +  ": Invalid input.");
            }

            UsersDTO dto = new UsersDTO() {
                UserLoginName = user.UserLoginName,
                UserName = user.UserName,
                UserSurname = user.UserSurname
            };

            bool add_user = await _service.AddUserAsync(dto);
            if(add_user) 
                return Ok("User je dodan!"); 
            else return BadRequest("User nije dodan!"); 
        }

        #region Test
        private async Task<bool> PickLastRequestUserId()
        {
            _requestUserId = -1;
            try
            {
                IHeaderDictionary headers = this.Request.Headers;
                if (headers.ContainsKey("RequestUserId"))
                {
                    if (int.TryParse(headers["RequestUserId"].ToString(), out _requestUserId))
                    {
                        return await _service.IsValidUser(_requestUserId);
                    }
                    else return false;
                }
                else return false;
            }
            catch
            {
                _requestUserId = -1;
                return false;
            }
        }
        #endregion Test
        #endregion Methods
    }
}
