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
    /// Логика взаимодействия для frEditKindOfMilitaryWeapon.xaml
    /// </summary>
    public partial class frEditKindOfMilitaryWeapon : Page
    {
        private _database.KindOfMilitaryWeapon _currentKindOfMilitaryWeapon = new _database.KindOfMilitaryWeapon();
        public frEditKindOfMilitaryWeapon(_database.KindOfMilitaryWeapon selectKindOfMilitaryWeapon)
        {
            InitializeComponent();
            if (selectKindOfMilitaryWeapon != null)
                _currentKindOfMilitaryWeapon = selectKindOfMilitaryWeapon;

            DataContext = _currentKindOfMilitaryWeapon;
        }

        private void SaveEditKindOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentKindOfMilitaryWeapon.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().KindOfMilitaryWeapon.Add(_currentKindOfMilitaryWeapon);
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
