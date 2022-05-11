using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    //Service Class of Business Layer
    public class UserBL : IUserBL
    {
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        IUserRL userRL;

        //Method to return UserRegistration obj to Repo Layer User.
        public void AddUser(UserPostModel user)
        {
            try
            {
                this.userRL.AddUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //User Login
        public string LoginUser(string email, string password)
        {
            try
            {
                return this.userRL.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // User ForgotPasssword
        public bool ForgotPassword(string email)
        {
            try
            {
                return this.userRL.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ResetPassword(ResetPassword resetPassword, string email)
        {
            try
            {
                return this.userRL.ResetPassword(resetPassword, email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return userRL.GetAllUsers();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
