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
            {
                Label label = new Label();
                label.UserId = userId;
                label.NoteId = noteId;
                label.LabelName = LabelName;

                fundooDBContext.Add(label);
                await fundooDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
