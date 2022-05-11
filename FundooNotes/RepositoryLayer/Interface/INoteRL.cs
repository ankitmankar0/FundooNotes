using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        Task AddNote(int userId, NotePostModel notePostModel);
        Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel);
        Task DeleteNote(int noteId, int userId);
        Task<List<Note>> GetAllNote(int userId);
        Task ChangeColour(int userId, int noteId, string colour);

        Task ArchiveNote(int userId, int noteId);
        Task<Note> PinNote(int userId, int noteId);
        Task<Note> TrashNote(int userId, int noteId);
    }
}
