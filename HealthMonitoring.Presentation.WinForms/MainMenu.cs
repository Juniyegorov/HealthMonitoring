using HealthMonitoring.BusinessLogic.Models;
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
using System.Windows.Forms;
using SimpleInjector;

namespace HealthMonitoring.Presentation.WinForms
{
    public partial class MainMenu : Form
    {
        private User _user;
        private UserInformation _userInformation;
        //private IUserServices _userServices;
        private CaloriesService _caloriesServices;
        //private IDishServices _dishServices;
        //private IExercisesService _exercisesService;
        private AllServices _services;

        public MainMenu(User user)
        {
            var container = new SimpleInjector.Container();
            container.Register<IDishServices, DishServices>();
            container.Register<IExercisesService, ExercisesService>();
            container.Register<IUserServices, UserServices>();
            container.Register<AllServices>();
            container.Verify();

            InitializeComponent();
            _services = container.GetInstance<AllServices>();
            _caloriesServices = new CaloriesService();
            _user = user;
            _userInformation = new UserInformation();
            SetUserInformation();
            UpdateDishList();
            UpdateExercisesList();
            _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedDayCalories(_userInformation.Id).ToString();
            _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedDayCalories(_userInformation.Id).ToString();
        }
        private void GetUserInformation()
        {
            var userInformation = _services.UserServices.GetUserInformation(_user.Login);
            _userInformation.Name = userInformation.Name;
            _userInformation.Surname = userInformation.Surname;
            _userInformation.Growth = userInformation.Growth;
            _userInformation.Weight = userInformation.Weight;
            _userInformation.Id = userInformation.Id;

        }
        public void SetUserInformation()
        {
            GetUserInformation();
            _userNameLabel.Text = _userInformation.Name;
            _userSurnameLabel.Text = _userInformation.Surname;
            _userWeightLabel.Text = _userInformation.Weight.ToString();
            _userGrowthLabel.Text = _userInformation.Growth.ToString();
        }
        private void _settingsButton_Click(object sender, EventArgs e)
        {
            SetPersonalIngormation setPersonalIngormation = new SetPersonalIngormation(_userInformation, this);
            setPersonalIngormation.Show();
            MessageBox.Show("Test");
        }
        public void UpdateDishList()
        {
            _dishListBox.Items.Clear();
            var dishes = _services.DishServices.ToList();
            foreach (var dish in dishes)
            {
                _dishListBox.Items.Add(dish.Name);
            }
        }
        private void UpdateExercisesList()
        {
            List<ExerciseModel> _exerciseModels = new List<ExerciseModel>();
            _exerciseModels = _services.ExercisesService.GetAllExercises();
            foreach (var e in _exerciseModels)
            {
                _exerciseListBox.Items.Add(e.Name);
            }
        }
        private void _eatenButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = _dateTime.Value;
                int weight = Convert.ToInt32(_weightTextBox.Text);
                if (weight > 0)
                {
                    var selectedDish = _dishListBox.SelectedItem;
                    if (selectedDish != null)
                    {


                        int dishId = _services.DishServices.GetDishId(selectedDish.ToString());
                        var dish = _services.DishServices.GetDish(dishId);
                        int calories = dish.Calories * weight / dish.Weight;
                        EatenDishModel eatenDish = new EatenDishModel()
                        {
                            Calories = calories,
                            Date = dateTime,
                            DishId = dishId,
                            UserId = _userInformation.Id,
                            Weight = weight
                        };
                        _services.DishServices.EatenDish(eatenDish);
                        MessageBox.Show("Dish successfull eaten");
                        _changeComboBox.Text = "Today";
                        _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedDayCalories(_userInformation.Id).ToString();
                        _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedDayCalories(_userInformation.Id).ToString();
                    }
                    else
                    {
                        MessageBox.Show("No chosen dish");
                    }
                }
                else
                {
                    MessageBox.Show("Weight must be greater than 0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrecr date");
            }
        }

        private void _doneButton_Click(object sender, EventArgs e)
        {
            CaloriesExpensesServices caloriexExpensis = new CaloriesExpensesServices();

            try
            {
                var time = Convert.ToInt32(_timeTextBox.Text);
                var distance = Convert.ToInt32(_distanceTextBox.Text);
                if (time > 0 && distance > 0)
                {
                    var exercise = _exerciseListBox.SelectedItem;
                    if (exercise != null)
                    {
                        var calories = caloriexExpensis.BurnedCalories(distance, time, _userInformation.Weight, _userInformation.Growth, exercise.ToString());
                        List<ExerciseModel> _exerciseModels = new List<ExerciseModel>();
                        _exerciseModels = _services.ExercisesService.GetAllExercises();
                        int exerciseId = _exerciseModels.Where(e => e.Name == exercise.ToString()).Select(e => e.Id).FirstOrDefault();
                        CompletedExerciseModel completedExercise = new CompletedExerciseModel()
                        {
                            Date = _exerciseDateTime.Value,
                            DistanceTraveled = distance,
                            ExerciseId = exerciseId,
                            ExpendedCalories = calories,
                            ExpendedTime = time,
                            UserId = _userInformation.Id
                        };
                        _services.ExercisesService.AddCompletedExercise(completedExercise);
                        MessageBox.Show("Exercise successfull completed");
                        _changeComboBox.Text = "Today";
                        _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedDayCalories(_userInformation.Id).ToString();
                        _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedDayCalories(_userInformation.Id).ToString();
                    }
                    else
                    {
                        MessageBox.Show("No chosen exercise");
                    }
                }
                else
                {
                    MessageBox.Show("Distance and time must be greater than 0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrecr distance or time");
            }
        }

        private void _changeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_changeComboBox.SelectedIndex)
            {
                case 0:
                    _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedDayCalories(_userInformation.Id).ToString();
                    _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedDayCalories(_userInformation.Id).ToString();
                    break;
                case 1:
                    _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedCaloriesPerWeek(_userInformation.Id).ToString();
                    _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedCaloriesPerWeek(_userInformation.Id).ToString();
                    break;
                case 2:
                    _expendedCaloriesLabel.Text = _caloriesServices.GetExpendedCaloriesPerYear(_userInformation.Id).ToString();
                    _receivedCaloriesLabel.Text = _caloriesServices.GetReceivedCaloriesPerYear(_userInformation.Id).ToString();
                    break;
            }
        }
        private void _menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CreateRecept createRecept = new CreateRecept(this);
            createRecept.Show();
        }
    }
}
