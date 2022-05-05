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
    }
}
