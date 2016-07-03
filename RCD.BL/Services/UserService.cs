using RCD.BL.Utils;
using RCD.DAL.Repositories;


namespace RCD.BL.Services
{
    public class UserService
    {
        public static int GetUserById(string username)
        {
           return RepositoryUser.GetUserById(username);
        }

        public static void RegisterUser(string username, string password)
        {
            RepositoryUser.RegisterUser(username, password);
        }

        public static int LoginUser(string username, string password)
        {
            return RepositoryUser.LoginUser(username, password);
        }

        public static bool EditUser(string username, string password)
        {
           return RepositoryUser.EditUser(username, password);
        }

    }
}
