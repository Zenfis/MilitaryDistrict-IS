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
    /// Логика взаимодействия для frEditPlatoon.xaml
    /// </summary>
    public partial class frEditPlatoon : Page
    {
        private _database.Platoon _currentPlatoon = new _database.Platoon();
        public frEditPlatoon(_database.Platoon selectPlatoon)
        {
            InitializeComponent();
            if (selectPlatoon != null)
                _currentPlatoon = selectPlatoon;

            DataContext = _currentPlatoon;
        }

        private void SavePlatoon_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPlatoon.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Platoon.Add(_currentPlatoon);
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
