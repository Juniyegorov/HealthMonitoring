using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HealthMonitoring.Presentation.WinForms
{
    public partial class CreateRecept : Form
    {
        private bool _receptIsCreate;
        private string _receptName = string.Empty;
        private List<CompositionOfTheDishModel> _compositionOfTheDishModelList;
        private CharacteristicsOfTheDishModel _characteristicsOfTheDishModel;
        private ProductServices _productServices;
        private List<CategoriesOfProductModel> _productCategories;
        private List<ProductModel> _products;
        private int _dishId;
        private MainMenu _mainMenu;
        public CreateRecept(MainMenu mainMenu)
        {
            InitializeComponent();
            _productServices = new ProductServices();
            _compositionOfTheDishModelList = new List<CompositionOfTheDishModel>();
            _productCategories = _productServices.GetAllCategories();
            foreach (var product in _productCategories)
            {
                _categoryComboBox.Items.Add(product.Name);
            }
            _mainMenu = mainMenu;
        }

        private void _categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _productsComboBox.Items.Clear();
            var selectedCategory = _categoryComboBox.SelectedItem.ToString();
            _products = _productServices.GetProductsByCategory(selectedCategory);
            foreach (var product in _products)
            {
                _productsComboBox.Items.Add(product.Name);
            }
        }

        private void _createButton_Click(object sender, EventArgs e)
        {
            if (!_receptIsCreate && _receptNameTextBox.Text != string.Empty)
            {
                _receptName = _receptNameTextBox.Text;
                _receptIsCreate = true;
                _receptListBox.Items.Add(_receptName+":");
            }
        }

        private void _addButton_Click(object sender, EventArgs e)
        {
            if (_receptIsCreate)
            {
                try
                {
                    var selectedCategory = _categoryComboBox.SelectedItem.ToString();
                    var products = _productServices.GetProductsByCategory(selectedCategory).
                        Where(p => p.Name == _productsComboBox.Text).SingleOrDefault();
                    var count = Convert.ToInt32(_countTextBox.Text);
                    CompositionOfTheDishModel compositionOfTheDishModel = new CompositionOfTheDishModel()
                    {
                        ProductId = products.Id,
                        Count = count,
                        Calories = products.Calories * count / 100
                    };
                    _compositionOfTheDishModelList.Add(compositionOfTheDishModel);
                    _receptListBox.Items.Add($"Product: {_productsComboBox.Text}    Count: {_countTextBox.Text}");
                }
                catch (Exception)
                {

                    MessageBox.Show("Incorrect count");
                }
            }
            else
            {
                MessageBox.Show("Recept is not created");
            }
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            DishServices dishServices = new DishServices();
            dishServices.AddDish(_receptName);
            _dishId = dishServices.GetDishId(_receptName);
            _characteristicsOfTheDishModel = new CharacteristicsOfTheDishModel()
            {
                DishId = _dishId,
                Weight = 0,
                Calories = 0
            };
            foreach (var i in _compositionOfTheDishModelList)
            {
                i.DishId = _dishId;
                _characteristicsOfTheDishModel.Weight += i.Count;
                _characteristicsOfTheDishModel.Calories += i.Calories;
                dishServices.AddCompositionOfTheDish(i);
            }
            dishServices.AddCharacteristicsOfTheDish(_characteristicsOfTheDishModel);
            MessageBox.Show("Dish is create");
            _mainMenu.UpdateDishList();
            Close();
        }
    }
}
