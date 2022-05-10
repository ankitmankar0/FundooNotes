using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public async Task AddNote(int userId, NotePostModel notePostModel)
        {
            try
            {
                await this.noteRL.AddNote(userId, notePostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteNote(int noteId)
        {
            try
            {
                if (noteRL.DeleteNote(noteId))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
