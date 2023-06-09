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
    /// Логика взаимодействия для frEditMilitaryWeapon.xaml
    /// </summary>
    public partial class frEditMilitaryWeapon : Page
    {
        private _database.MilitaryWeapon _currentMilitaryWeapon = new _database.MilitaryWeapon();
        public frEditMilitaryWeapon(_database.MilitaryWeapon selectMilitaryWeapon)
        {
            InitializeComponent();
            if (selectMilitaryWeapon != null)
                _currentMilitaryWeapon = selectMilitaryWeapon;

            DataContext = _currentMilitaryWeapon;
        }

        private void SaveMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryWeapon.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryWeapon.Add(_currentMilitaryWeapon);
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
