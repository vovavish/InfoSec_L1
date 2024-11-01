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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnChangeAdminPassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm("ADMIN");
            changePasswordForm.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text;
            if (!UserManager.AddUser(newUsername))
            {
                MessageBox.Show("Пользователь уже существует.");
            }
            else
            {
                MessageBox.Show("Пользователь добавлен.");
            }
        }

        private void btnBlockUser_Click(object sender, EventArgs e)
        {
            string username = txtUsernameToBlock.Text;
            if (!UserManager.toggleIsBlockUser(username))
            {
                MessageBox.Show("Пользователь не найден.");
            }
            else
            {
                MessageBox.Show("Блокировка пользователя изменена.");
            }
        }

        private void btnTogglePasswordRestrictions_Click(object sender, EventArgs e)
        {
            string username = txtUsernameRestrictions.Text;
            if (!UserManager.TogglePasswordRestrictions(username))
            {
                MessageBox.Show("Пользователь не найден.");
            }
            else
            {
                MessageBox.Show("Ограничения на пароли изменены.");
            }
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            var users = UserManager.GetUsers();
            lstUsers.Items.Clear();
            foreach (var user in users)
            {
                string isBlocked = user.IsBlocked ? "Да" : "Нет";
                string PasswordRestrictions = user.PasswordRestrictions ? "Да" : "Нет";
                lstUsers.Items.Add($"{user.Username} - Заблокирован: {isBlocked}, Ограничения: {PasswordRestrictions}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            UserManager.SaveUsers("users_temp.dat");
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
