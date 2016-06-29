using RCD.DAL.Repositories;
using RCD.Model;



namespace RCD.BL.Services
{
    public class UserRegistrationService
    {
        public static int RegisterUser(User user, string username, string password)
        {
            return UserRegistrationRepository.RegisterUser(user, username, password);
        }
    }
}
