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
    /// Логика взаимодействия для frEditCategoryOfMilitaryWeapon.xaml
    /// </summary>
    public partial class frEditCategoryOfMilitaryWeapon : Page
    {
        private _database.CategoryOfMilitaryWeapon _currentCategoryOfMilitaryWeapon = new _database.CategoryOfMilitaryWeapon();
        public frEditCategoryOfMilitaryWeapon(_database.CategoryOfMilitaryWeapon selectCategoryOfMilitaryWeapon)
        {
            InitializeComponent();
            if (selectCategoryOfMilitaryWeapon != null)
                _currentCategoryOfMilitaryWeapon = selectCategoryOfMilitaryWeapon;

            DataContext = _currentCategoryOfMilitaryWeapon;
        }

        private void SaveEditCategoryOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCategoryOfMilitaryWeapon.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryWeapon.Add(_currentCategoryOfMilitaryWeapon);
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
