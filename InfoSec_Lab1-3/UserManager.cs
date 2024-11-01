using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
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
        public static string passPhrase { get; set; }

        public static void DeleteTemporaryFile(string tempFilePath)
        {
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }


        public static byte[] GenerateKeyFromPasswordMD2(string password, byte[] salt, int keySize = 32)
        {
            MD2Digest md2 = new MD2Digest();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            md2.BlockUpdate(passwordBytes, 0, passwordBytes.Length);

            byte[] hash = new byte[md2.GetDigestSize()];
            md2.DoFinal(hash, 0);

            using (var deriveBytes = new Rfc2898DeriveBytes(hash, salt, 10000))
            {
                return deriveBytes.GetBytes(keySize);
            }
        }

        public static void EncryptFileWithAES(string inputFile, string outputFile, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.GenerateIV();
                byte[] iv = aesAlg.IV;

                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                {
                    fsOutput.Write(iv, 0, iv.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(fsOutput, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                    {
                        fsInput.CopyTo(csEncrypt);
                    }
                }
            }
        }

        public static void DecryptFileWithAES(string inputFile, string outputFile, byte[] key)
        {
            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.Mode = CipherMode.CBC;

                    byte[] iv = new byte[16];
                    fsInput.Read(iv, 0, iv.Length);
                    aesAlg.IV = iv;

                    using (CryptoStream csDecrypt = new CryptoStream(fsInput, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                    {
                        csDecrypt.CopyTo(fsOutput);
                    }
                }
            }
        }

        public static byte[] LoadOrCreateSalt(string saltFilePath = "salt.dat", int saltSize = 16)
        {
            if (File.Exists(saltFilePath))
            {
                return File.ReadAllBytes(saltFilePath);
            }
            else
            {
                byte[] salt = new byte[saltSize];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                File.WriteAllBytes(saltFilePath, salt);
                return salt;
            }
        }

        public static string PromptUserForPassphrase()
        {
            using (var passphraseForm = new PassphraseForm())
            {
                if (passphraseForm.ShowDialog() == DialogResult.OK)
                {
                    return passphraseForm.Passphrase;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void LoadUsers(string fpath = "user.dat")
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(fpath, FileMode.Open))
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

        public static void SaveUsers(string fpath = "users.dat")
        {
            using (FileStream fs = new FileStream(fpath, FileMode.Create))
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
                SaveUsers("users_temp.dat");
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
                bool hasUpper = password.Any(char.IsUpper);
                bool hasLower = password.Any(char.IsLower);

                return hasUpper && hasLower;
            }

            return true;
        }
    }
}
