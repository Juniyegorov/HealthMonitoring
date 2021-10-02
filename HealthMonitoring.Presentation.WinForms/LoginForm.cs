using HealthMonitoring.BusinessLogic.Services;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthMonitoring.Presentation.WinForms
{
    public partial class LoginForm : Form
    {
        public string _name = string.Empty;
        public LoginForm()
        {
            InitializeComponent();
            this._passField.AutoSize = false;
            this._passField.Size = new Size(this._passField.Size.Width, 42);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            _closeButton.ForeColor = Color.Gray;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            _closeButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void topLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void topLabel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void signIN_Click(object sender, EventArgs e)
        {
            string userLogin = _loginField.Text;
            string userPass = _passField.Text;

            IUserServices userServices = new UserServices();

            var doesUserExist = userServices.CheckUser(userLogin, userPass);
            if (doesUserExist)
            {
                Hide();
                User user = new User()
                {
                    Login = userLogin,
                    Password = userPass
                };
                MainMenu mainMenu = new MainMenu(user);
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void passField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIN_Click(sender, e);
            }
        }
    }
}
