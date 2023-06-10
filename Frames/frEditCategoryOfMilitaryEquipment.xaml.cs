using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MilitaryDistrict_IS.Frames
{
    /// <summary>
    /// Логика взаимодействия для frEditCategoryOfMilitaryEquipment.xaml
    /// </summary>
    public partial class frEditCategoryOfMilitaryEquipment : Page
    {
        private _database.CategoryOfMilitaryEquipment _currentCategoryOfMilitaryEquipment = new _database.CategoryOfMilitaryEquipment();
        public frEditCategoryOfMilitaryEquipment(_database.CategoryOfMilitaryEquipment selectCategoryOfMilitaryEquipment)
        {
            InitializeComponent();
            if (selectCategoryOfMilitaryEquipment != null)
                _currentCategoryOfMilitaryEquipment = selectCategoryOfMilitaryEquipment;

            DataContext = _currentCategoryOfMilitaryEquipment;
        }

        private void SaveEditCategoryOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCategoryOfMilitaryEquipment.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryEquipment.Add(_currentCategoryOfMilitaryEquipment);
            try
            {
                _database.Military_District_Information_SystemEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                //Manager.MainFrame.GoBack();  
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
