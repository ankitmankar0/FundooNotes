using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public void AddUser(UserPostModel user);
        public string LoginUser(string email, string password);
        public bool ForgotPassword(string email);
        public bool ResetPassword(ResetPassword resetPassword, string email);
        List<User> GetAllUsers();
    }
}
