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
                // ������ ������: ������� ��������� ������
                UserManager.LoadUsers(); // ��������� �������������� ������
                UserManager.SaveUsers("users_temp.dat"); // ��������� ������������� ��������

                // ������������� � ��������� ��������� ������
                UserManager.EncryptFileWithAES("users_temp.dat", "users.dat", key);
                File.Delete("users_temp.dat");
            }
            else
            {
                // ������������� ���� ����������: �������������� ��� �������������
                try
                {
                    UserManager.DecryptFileWithAES("users.dat", "users_temp.dat", key);
                    UserManager.LoadUsers("users_temp.dat"); // ��������� �������������� ������
                }
                catch
                {
                    MessageBox.Show("�������� ��������� �����. ��������� ����������.");
                    return;
                }
            }

            Application.Run(new LoginForm());
        }
    }
}