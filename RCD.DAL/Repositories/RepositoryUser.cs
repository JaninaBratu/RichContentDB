using RCD.Model;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity.Validation;


namespace RCD.DAL.Repositories
{
    public class RepositoryUser
    {

        public static int GetUserById(string username)
        {
            using (var context = new ModelContext())
            {

                try
                {
                    return (from u in context.Users
                                  where u.Username == username
                                  select u.UserId).SingleOrDefault();
                }
                catch (System.InvalidOperationException)
                {
                    throw;
                }
            }
        }

        public static void RegisterUser(string username, string password)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    User user = new User();
                    user.Username = username;
                    user.Password = password;
                    user.IsAdmin = false;
                    user.IsActive = true;
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        public static int LoginUser(string username, string password)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from u in context.Users
                                   where u.Username == username
                                        && u.Password == password
                                   select u.UserId).SingleOrDefault();

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
           
        }

        public static int CheckAdmin(string username, bool isAdmin)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from u in context.Users
                            where u.Username == username
                                  && u.IsAdmin == isAdmin
                            select u.UserId).SingleOrDefault();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public static bool EditUser(string username, string password)
        {
            return false;
        }

       
    }
}
