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
    public class LabelRL : ILabelRL
    {
        FundooDBContext fundooDBContext;

        //Constructor
        public IConfiguration configuration { get; }
        public LabelRL(FundooDBContext fundooDBContext, IConfiguration configuration)
        {
            this.fundooDBContext = fundooDBContext;
            this.configuration = configuration;
        }
        public async Task AddLabel(int userId, int noteId, string LabelName)
        {
            try
            //{
            //    var user = fundooDBContext.Users.FirstOrDefault(u => u.userID == userId);
            //    var note = fundooDBContext.Notes.FirstOrDefault(b => b.NoteId == noteId);
            //    Label label = new Label
            //    {
            //        User = user,
            //        Note = note
            //    };
            //    label.LabelName = LabelName;
            //    fundooDBContext.Label.Add(label);
            //    await fundooDBContext.SaveChangesAsync();
            //}

            {
                // checking with the notestable db to find NoteId
                var note = fundooDBContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (note != null)
                {
                    // Entity class Instance
                    Label label = new Label();
                    label.LabelName = LabelName;
                    label.NoteId = noteId;
                    label.UserId = userId;

                    this.fundooDBContext.Label.Add(label);
                    await fundooDBContext.SaveChangesAsync();
                }            
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Label> UpdateLabel(int userId, int LabelId, string LabelName)
        {
            try
            {

                var result = fundooDBContext.Label.FirstOrDefault(u => u.UserId == userId && u.LabelId == LabelId);
                if (result != null)
                {

                    result.LabelName = LabelName;

                    await fundooDBContext.SaveChangesAsync();
                }
                //return await fundooDBContext.Label.Where(u => u.UserId == userId && u.LabelId == LabelId).Include(u=>u.User).

                return await fundooDBContext.Label
                .Where(u => u.UserId == userId && u.LabelId == LabelId)
                .Include(u => u.User)
                .FirstOrDefaultAsync();
            }            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteLabel(int LabelId, int userId)
        {
            try
            {
                var result = fundooDBContext.Label.FirstOrDefault(u => u.LabelId == LabelId && u.UserId == userId);
                fundooDBContext.Label.Remove(result);
                await fundooDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Label>> GetLabelByuserId(int userId)
        {
            try
            {
                List<Label> reuslt = await fundooDBContext.Label.Where(u => u.UserId == userId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Label>> GetlabelByNoteId(int NoteId)
        {
            try
            {
                List<Label> reuslt = await fundooDBContext.Label.Where(u => u.NoteId == NoteId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
