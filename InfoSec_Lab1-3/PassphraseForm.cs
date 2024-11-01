using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfoSec_Lab1_3
{
    public partial class PassphraseForm : Form
    {
        private TextBox txtPassphrase;

        // Свойство для доступа к тексту парольной фразы из внешнего класса
        public string Passphrase => txtPassphrase.Text;

        public PassphraseForm()
        {
            InitializeComponent();

            // Настройки формы
            this.Text = "Введите парольную фразу";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(300, 150);

            // Создаем и настраиваем TableLayoutPanel
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(10),
                AutoSize = true
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));

            // Добавляем метку
            var label = new Label
            {
                Text = "Введите парольную фразу:",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            layout.SetColumnSpan(label, 2);
            layout.Controls.Add(label, 0, 0);

            // Поле ввода пароля
            txtPassphrase = new TextBox
            {
                UseSystemPasswordChar = true,
                Anchor = AnchorStyles.None,
                Width = 200
            };
            layout.SetColumnSpan(txtPassphrase, 2);
            layout.Controls.Add(txtPassphrase, 0, 1);

            // Кнопка ОК
            var btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Anchor = AnchorStyles.None
            };
            layout.Controls.Add(btnOk, 0, 2);

            // Кнопка Отмена
            var btnCancel = new Button
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Anchor = AnchorStyles.None
            };
            layout.Controls.Add(btnCancel, 1, 2);

            // Добавляем TableLayoutPanel на форму
            this.Controls.Add(layout);

            // Задаем кнопки по умолчанию
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}
