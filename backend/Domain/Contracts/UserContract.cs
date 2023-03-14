using Domain.Entities;
using prmToolkit.NotificationPattern;

namespace Domain.Contracts
{
    public static class UserContract
    {
        public static void AddUserContract(this User user)
        {
            new AddNotifications<User>(user)
                .IfNullOrEmpty(u => u.Name)
                .IfNullOrInvalidLength(u => u.Email, 1, 200)
                .IfNullOrEmpty(u => u.Password)
                .IfNotEmail(u => user.Email);
        }

        public static void UpdateUserContract(this User user)
        {
            new AddNotifications<User>(user)
                .IfNullOrInvalidLength(u => u.Email, 1, 200)
                .IfNullOrEmpty(u => u.Password)
                .IfNotEmail(u => user.Email);
        }
    }
}