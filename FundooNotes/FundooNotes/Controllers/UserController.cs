using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.FundooContext;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserBL userBL;
        FundooDBContext fundooDBContext;
        public UserController(IUserBL userBL, FundooDBContext fundooDBContext)
        {
            this.userBL = userBL;
            this.fundooDBContext = fundooDBContext;
        }
        [HttpPost("register")]
        public IActionResult AddUser(UserPostModel user)
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

        [HttpPost("login/{email}/{password}")]
        public IActionResult LoginUser(string email, string password)
        {
            try
            {
                var userdata= fundooDBContext.Users.FirstOrDefault(u => u.email == email && u.password==password);
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
    }
}
