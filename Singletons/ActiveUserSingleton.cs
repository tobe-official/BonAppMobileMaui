using BonAppMobileMaui.models;

namespace BonAppMobileMaui.Singletons
{
    public class ActiveUserSingleton
    {
        private static ActiveUserSingleton _instance;
        public User ActiveUser { get; private set; }

        private ActiveUserSingleton() { }

        public static ActiveUserSingleton Instance => _instance ??= new ActiveUserSingleton();

        public void SetUser(User user)
        {
            ActiveUser = user;
        }
    }
}