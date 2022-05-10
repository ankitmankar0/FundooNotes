using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooContext;
using System;
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
    }

}
