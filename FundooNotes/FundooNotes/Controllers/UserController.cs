using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.FundooContext;
using System;
using System.Linq;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [ApiController]  // Handle the Client error, Bind the Incoming data with parameters using more attribute
    [Route("[controller]")]
    public class UserController : ControllerBase // Provide many method and properties to handle Http req.
    {
        IUserBL userBL;  // can only be assigned a value from within the constructor(s) of a class.
        FundooDBContext fundooDBContext;

        //Constructor
        public UserController(IUserBL userBL, FundooDBContext fundooDBContext)
        {
            this.userBL = userBL;
            this.fundooDBContext = fundooDBContext;
        }

        //Register a User
        [HttpPost("register")]
        public IActionResult AddUser(UserPostModel user) //IActionResult lets you return both data and HTTP codes.
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = $"Registration Successfull" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //user Login
        [HttpPost("login/{email}/{password}")]
        public IActionResult LoginUser(string email, string password)
        {
            try
            {
                var userdata = fundooDBContext.Users.FirstOrDefault(u => u.email == email && u.password == password); //Linq
                if (userdata == null)
                {
                    return this.BadRequest(new { success = false, message = $"Email And PassWord Is Invalid" });
                }
                var result = this.userBL.LoginUser(email, password);


                return this.Ok(new { success = true, message = $"Login Successfull {result}" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Forget Pass
        [HttpPost("ForgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgotPassword(email);
                if (result != false)
                {
                    return this.Ok(new
                    {

                        success = true,
                        message = $"Mail Sent Successfully " +
                        $" token:  {result}"
                    });

                }
                return this.BadRequest(new { success = false, message = $"mail not sent" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            try
            {
    
                string email = User.FindFirst(ClaimTypes.Email).Value.ToString();                    
                bool res = userBL.ResetPassword(resetPassword, email);

                if (res == false)
                {
                    return this.BadRequest(new { success = false, message = "enter valid password" });

                }
                return this.Ok(new { success = true, message = "reset password set successfully" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
