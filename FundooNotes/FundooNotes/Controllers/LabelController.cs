using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.FundooContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        FundooDBContext fundooDBContext;
        ILabelBL labelBL;
        public LabelController(ILabelBL labelBL, FundooDBContext fundooContext)
        {
            this.labelBL = labelBL;
            this.fundooDBContext = fundooContext;
        }
        [Authorize]
        [HttpPost("AddLabel")]
        public async Task<IActionResult> AddLabel(int userId, int noteId, string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                await this.labelBL.AddLabel(userId, noteId, LabelName);
                return this.Ok(new { success = true, message = "Label Added Successfully " });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
