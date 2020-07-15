using CRM.Services.Customers;
using CRM.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobileAheresisAPI.Helpers;
using MobileAheresisAPI.Models;
using MobileAheresisAPI.Models.Result;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        //IEnumerable<UserModel> GetAll();
        //UserModel GetById(int id);
    }
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<UserModel> _users = new List<UserModel>
        //{
        //    new UserModel { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin"},
        //    new UserModel { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user"}
        //};
        #region Fields
        private readonly AppSettings _appSettings;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IPermissionService _permissionService;
        #endregion

        #region CTOR
        public UserService(ICustomerRegistrationService customerRegistrationService, IOptions<AppSettings> appSettings, IPermissionService permissionService)
        {
            _appSettings = appSettings.Value;
            this._customerRegistrationService = customerRegistrationService;
            this._permissionService = permissionService;
        }
        #endregion

        public UserModel Authenticate(string username, string password)
        {
            //this code have to use after creating database
            var user = _customerRegistrationService.ValidateCustomer(username, password);

            //this is for Static User
            //var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                ValidationMessages.MobileUserError = "Username or Password is Incorect";
                return null;
            }
            //permissions
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMobileAdmin, user))
            {
                ValidationMessages.MobileUserError = "Unauthorise Access";
                return null;
            }


            //// return null if user not found
            

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserModel userModel = new UserModel();
            userModel.Token = tokenHandler.WriteToken(token);
            userModel.Username = user.Username;
            userModel.Password = password;
            userModel.FirstName = user.BillingAddress.FirstName;
            userModel.LastName = user.BillingAddress.LastName;
            userModel.Id = user.Id;
            // remove password before returning

            return userModel;
        }

        //public IEnumerable<UserModel> GetAll()
        //{
        //    // return users without passwords
        //    return _users.Select(x => {
        //        x.Password = null;
        //        return x;
        //    });
        //}
        //public UserModel GetById(int id)
        //{
        //    var user = _users.FirstOrDefault(x => x.Id == id);

        //    // return user without password
        //    if (user != null)
        //        user.Password = null;

        //    return user;
        //}
    }
}