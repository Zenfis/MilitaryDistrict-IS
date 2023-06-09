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
    /// Логика взаимодействия для frEditMilitaryWeaponsInMilitaryBase.xaml
    /// </summary>
    public partial class frEditMilitaryWeaponsInMilitaryBase : Page
    {
        private _database.MilitaryWeaponsInMilitaryBase _currentMilitaryWeaponsInMilitaryBase = new _database.MilitaryWeaponsInMilitaryBase();
        public frEditMilitaryWeaponsInMilitaryBase(_database.MilitaryWeaponsInMilitaryBase selectMilitaryWeaponsInMilitaryBase)
        {
            InitializeComponent();
            if (selectMilitaryWeaponsInMilitaryBase != null)
                _currentMilitaryWeaponsInMilitaryBase = selectMilitaryWeaponsInMilitaryBase;

            DataContext = _currentMilitaryWeaponsInMilitaryBase;
        }

        private void SaveMilitaryWeaponsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryWeaponsInMilitaryBase.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryWeaponsInMilitaryBase.Add(_currentMilitaryWeaponsInMilitaryBase);
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
