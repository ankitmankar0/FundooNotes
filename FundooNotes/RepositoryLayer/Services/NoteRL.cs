﻿using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
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
                Note note = new Note();
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
    }
}