using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Services;

namespace MobileAheresisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Fields
        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;
        #endregion
        #region CTOR
        public UserController(IUserService userService,
            IEncryptionService EncryptionService)
        {
            _userService = userService;
            this._encryptionService = EncryptionService;
        }
        #endregion
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserModel userParam)
        {
            ResultModel _Respose = new ResultModel();
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (user == null)
            {
                

                _Respose.Message = ValidationMessages.MobileUserError;
                _Respose.Status = 0;
                _Respose.Response = null;
                return Ok(_Respose);
            }
            else
            {
                UserModel userdata = new UserModel();
                userdata.FirstName = _encryptionService.DecryptText(user.FirstName);
                userdata.LastName = _encryptionService.DecryptText(user.LastName);
                userdata.Username = _encryptionService.DecryptText(user.Username);
                userdata.Token = user.Token;
                userdata.Password = user.Password;
                _Respose.Message = "Success";
                _Respose.Status = 1;
                _Respose.Response = userdata;
                return Ok(_Respose);
            }

            
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok();
        }
    }
}