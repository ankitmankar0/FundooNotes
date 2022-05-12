using BusinessLayer.Interfaces;
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
    }
}
