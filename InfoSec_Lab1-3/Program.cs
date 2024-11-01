namespace InfoSec_Lab1_3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string passphrase = UserManager.PromptUserForPassphrase();
            UserManager.passPhrase = passphrase;

            byte[] key = UserManager.GenerateKeyFromPasswordMD2(UserManager.passPhrase, UserManager.LoadOrCreateSalt());

            if (!File.Exists("users.dat"))
            {
                // Первый запуск: создаем начальные данные
                UserManager.LoadUsers(); // Загружаем расшифрованные данные
                UserManager.SaveUsers("users_temp.dat"); // Сохраняем пользователей временно

                // Зашифровываем с начальной парольной фразой
                UserManager.EncryptFileWithAES("users_temp.dat", "users.dat", key);
                File.Delete("users_temp.dat");
            }
            else
            {
                // Зашифрованный файл существует: расшифровываем для использования
                try
                {
                    UserManager.DecryptFileWithAES("users.dat", "users_temp.dat", key);
                    UserManager.LoadUsers("users_temp.dat"); // Загружаем расшифрованные данные
                }
                catch
                {
                    MessageBox.Show("Неверная парольная фраза. Программа завершится.");
                    return;
                }
            }

            Application.Run(new LoginForm());
        }
    }
}