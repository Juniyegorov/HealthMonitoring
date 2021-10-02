using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Services;
using HealthMonitoring.Presentation.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthMonitoring.Presentation.WinForms
{
    public partial class SetPersonalIngormation : Form
    {
        private UserInformation _user;
        private MainMenu _mainMenu;
        public SetPersonalIngormation(UserInformation user, MainMenu mainMenu)
        {
            InitializeComponent();
            _user = user;
            _mainMenu = mainMenu;
            _nameTextBox.Text = user.Name;
            _surnameTextBox.Text = user.Surname;
            _weightTextBox.Text = user.Weight.ToString();
            _growthTextBox.Text = user.Growth.ToString();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserServices userServices = new UserServices();
                UserInformationModel userInformationModel = new UserInformationModel()
                {
                    Id = _user.Id,
                    Growth = Convert.ToInt32(_growthTextBox.Text),
                    Name = _nameTextBox.Text,
                    Surname = _surnameTextBox.Text,
                    Weight = Convert.ToInt32(_weightTextBox.Text)
                };
                userServices.SetUserInformation(userInformationModel);
                _mainMenu.SetUserInformation();
                Close();
            }
            catch 
            {
                MessageBox.Show("Incorrect data format");
            }
            
        }
    }
}
