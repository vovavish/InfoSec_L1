using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoSec_Lab1_3
{
    public partial class UserForm : Form
    {
        private string currentUser;

        public UserForm(string username)
        {
            currentUser = username;
            InitializeComponent();
            usernameLabel.Text = "Пользователь: " + currentUser;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(currentUser);
            changePasswordForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Вишняков Владимир ИДБ-21-12\nЗадание: Наличие строчных и прописных букв.", "О программе");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Получаем ключ для шифрования
            string passphrase = UserManager.passPhrase;
            byte[] key = UserManager.GenerateKeyFromPasswordMD2(passphrase, UserManager.LoadOrCreateSalt());

            // Шифруем данные перед закрытием
            UserManager.EncryptFileWithAES("users_temp.dat", "users.dat", key);

            // Удаляем временный файл
            UserManager.DeleteTemporaryFile("users_temp.dat");
        }
    }
}
