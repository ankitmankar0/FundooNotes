using CommonLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        //instance of  FundooContext Class
        FundooDBContext fundooDBContext;

        //Constructor
        public IConfiguration configuration { get; }
        public NoteRL(FundooDBContext fundooDBContext, IConfiguration configuration)
        {
            this.fundooDBContext = fundooDBContext;
            this.configuration = configuration;
        }
        public async Task AddNote(int userId, NotePostModel notePostModel)
        {
            try
            {
                //var user = fundooDBContext.Users.FirstOrDefault(u => u.userID == userId);
                Note note = new Note();

                note.userID = userId;

                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.BgColour = notePostModel.BgColour;

                note.IsPin = false;
                note.IsReminder = false;
                note.IsArchieve = false;
                note.IsTrash = false;
                note.RegsterDate = DateTime.Now;
                note.ModifiedDate = DateTime.Now;

                fundooDBContext.Add(note);
                await fundooDBContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(e => e.userID == userId && e.NoteId == noteId);
                if (note != null)
                {
                    note.Title = noteUpdateModel.Title;
                    note.Description = noteUpdateModel.Description;
                    note.IsArchieve = noteUpdateModel.IsArchieve;
                    note.BgColour = noteUpdateModel.BgColour;
                    note.IsPin = noteUpdateModel.IsPin;
                    note.IsReminder = noteUpdateModel.IsReminder;
                    note.IsTrash = noteUpdateModel.IsTrash;

                    await fundooDBContext.SaveChangesAsync();

                }
                return await fundooDBContext.Notes
                .Where(u => u.userID == u.userID && u.NoteId == noteId)
                .Include(u => u.User)
                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task DeleteNote(int noteId, int userId)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(u => u.NoteId == noteId && u.userID == userId);
                fundooDBContext.Notes.Remove(note);
                await fundooDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task ChangeColour(int userId, int noteId, string colour)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(e => e.userID == userId && e.NoteId == noteId);
                if (note != null)
                {
                    note.BgColour = colour;
                    await fundooDBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ArchiveNote(int userId, int noteId)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(e => e.userID == userId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsArchieve == true)
                    {
                        note.IsArchieve = false;
                    }

                    if (note.IsArchieve == false)
                    {
                        note.IsArchieve = true;
                    }
                }

                await fundooDBContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Note> PinNote(int userId, int noteId)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(e => e.userID == userId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsPin == true)
                    {
                        note.IsPin = false;
                    }

                    if (note.IsPin == false)
                    {
                        note.IsPin = true;
                    }
                }
                await fundooDBContext.SaveChangesAsync();
                return await fundooDBContext.Notes.Where(a => a.NoteId == noteId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Note> TrashNote(int userId, int noteId)
        {
            try
            {
                var note = fundooDBContext.Notes.FirstOrDefault(e => e.userID == userId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsTrash == true)
                    {
                        note.IsTrash = false;
                    }

                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                    }
                }
                await fundooDBContext.SaveChangesAsync();
                return await fundooDBContext.Notes.Where(a => a.NoteId == noteId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Note>> GetAllNote(int userId)
        {
            try
            {
                return await fundooDBContext.Notes.Where(u => u.userID == userId).Include(u => u.User).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
