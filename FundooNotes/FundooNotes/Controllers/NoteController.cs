using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        FundooDBContext fundooDBContext;
        INoteBL noteBL;
        public NoteController(INoteBL noteBL, FundooDBContext fundooContext)
        {
            this.noteBL = noteBL;
            this.fundooDBContext = fundooContext;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNote(NotePostModel notePostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                await this.noteBL.AddNote(UserId, notePostModel);
                return this.Ok(new { success = true, message = "Note Added Successfully " });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Authorize]
        [HttpDelete]
        public ActionResult DeleteNote(int noteId)
        {
            try
            {
                if (noteBL.DeleteNote(noteId))
                {
                    return this.Ok(new { success = true, message = "Note Deleted Successfully" });
                }
                return this.BadRequest(new { success = true, message = "Note Deletion Failed" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
