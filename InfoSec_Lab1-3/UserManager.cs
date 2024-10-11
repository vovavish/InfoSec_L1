using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InfoSec_Lab1_3
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public bool PasswordRestrictions { get; set; }

        public User(string username)
        {
            Username = username;
            Password = string.Empty;
            IsBlocked = false;
            PasswordRestrictions = false;
        }
    }

    public static class UserManager
    {
        private static List<User> users = new List<User>();
        private static string filePath = "users.dat";

        public static void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    users = (List<User>)formatter.Deserialize(fs);
                }
            }
            else
            {
                users.Add(new User("ADMIN"));
                SaveUsers();
            }
        }

        public static void SaveUsers()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, users);
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null && !user.IsBlocked && user.Password == password)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePassword(string username, string oldPassword)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            return user != null && user.Password == oldPassword;
        }

        public static void ChangePassword(string username, string newPassword)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Password = newPassword;
                SaveUsers();
            }
        }

        public static bool AddUser(string username)
        {
            if (users.Any(u => u.Username == username)) return false;
            users.Add(new User(username));
            SaveUsers();
            return true;
        }

        public static bool toggleIsBlockUser(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.IsBlocked = !user.IsBlocked;
                SaveUsers();
                return true;
            }
            return false;
        }

        public static bool TogglePasswordRestrictions(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.PasswordRestrictions = !user.PasswordRestrictions;
                SaveUsers();
                return true;
            }
            return false;
        }

        public static List<User> GetUsers()
        {
            return users;
        }

        public static bool IsPasswordValid(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.PasswordRestrictions)
            {
                bool hasUpper = password.Any(char.IsUpper); // Проверяет наличие заглавных букв
                bool hasLower = password.Any(char.IsLower); // Проверяет наличие строчных букв

                return hasUpper && hasLower;
            }
            return true;
        }
    }
}
