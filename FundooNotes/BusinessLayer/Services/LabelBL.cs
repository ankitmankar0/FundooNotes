using BusinessLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }

        public async Task AddLabel(int userId, int noteId, string LabelName)
        {
            try
            {
                await this.labelRL.AddLabel(userId, noteId, LabelName);
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
                await this.labelRL.DeleteLabel(LabelId, userId);
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
                return await this.labelRL.GetlabelByNoteId(NoteId);
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
                return await this.labelRL.GetlabelByNoteId(userId);
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
                return await this.labelRL.UpdateLabel(userId, LabelId, LabelName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
