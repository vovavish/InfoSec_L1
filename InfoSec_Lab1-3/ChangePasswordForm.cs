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
    public partial class ChangePasswordForm : Form
    {
        private string currentUser;

        public ChangePasswordForm(string username)
        {
            currentUser = username;
            InitializeComponent();
            txtOldPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (UserManager.ValidatePassword(currentUser, oldPassword))
            {
                if (newPassword == confirmPassword)
                {
                    if (UserManager.IsPasswordValid(currentUser, newPassword))
                    {
                        UserManager.ChangePassword(currentUser, newPassword);
                        MessageBox.Show("Пароль успешно изменен.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пароль не соответствует требованиям.");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают.");
                }
            }
            else
            {
                MessageBox.Show("Неверный старый пароль.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Вишняков Владимир ИДБ-21-12\nЗадание: Наличие строчных и прописных букв.", "О программе");
        }
    }
}
