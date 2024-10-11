namespace InfoSec_Lab1_3
{
    public partial class LoginForm : Form
    {
        private int attempt = 0;
        private const int MaxAttempts = 3;

        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (UserManager.ValidateUser(username, password))
            {
                if (username == "ADMIN")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    UserForm userForm = new UserForm(username);
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                attempt++;
                if (attempt >= MaxAttempts)
                {
                    MessageBox.Show("Превышено количество попыток ввода. Программа завершена.");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль.");
                }
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Вишняков Владимир ИДБ-21-12\nЗадание: Наличие строчных и прописных букв.", "О программе");
        }
    }
}