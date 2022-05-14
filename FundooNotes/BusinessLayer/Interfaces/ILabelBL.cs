using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILabelBL
    {
        Task AddLabel(int userId, int noteId, string LabelName);
        Task<RepositoryLayer.Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName);
        Task DeleteLabel(int LabelId, int userId);

        Task<List<RepositoryLayer.Entity.Label>> GetLabelByuserId(int userId);
        Task<List<RepositoryLayer.Entity.Label>> GetlabelByNoteId(int NoteId);
    }
}
