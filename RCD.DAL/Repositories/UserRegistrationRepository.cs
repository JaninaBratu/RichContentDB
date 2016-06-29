using RCD.Model;
using System;
using System.Windows.Forms;


namespace RCD.DAL.Repositories
{
   public class UserRegistrationRepository
    {

        public static int RegisterUser(User user, string username, string password, string confirmationPassword)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    int userId = (from u in context.Users
                                  where u.UserName == username
                                  select u.UserId).SingleOrDefault());

                    if (userId > 0)
                    {
                        //user exists 
                        return user.UserId;
                    }
                    else
                    {
                        // user does not exist

                        bool isValid = UserDataValidation.CheckPasswordForRegistration(user, password, confirmationPassword);
                        if (isValid)
                        {
                            user.Username = username;
                            user.Password = password;
                            user.IsActive = false;
                            context.Users.Add(user);
                            context.SaveChanges();

                            return user.UserId;
                        }
                        else
                        {
                            return 0;
                        }
                        
                    }
                }
                catch (System.InvalidOperationException ex)
                {
                    throw;
                }
            }
        }
       
    }
}
