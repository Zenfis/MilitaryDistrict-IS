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
    /// Логика взаимодействия для frEditArmy.xaml
    /// </summary>
    public partial class frEditArmy : Page
    {
        private _database.Army _currentArmy = new _database.Army();
        public frEditArmy(_database.Army selectArmy)
        {
            InitializeComponent();
            if (selectArmy != null)
                _currentArmy = selectArmy;

            DataContext = _currentArmy;
        }

        private void SaveArmy_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentArmy.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Army.Add(_currentArmy);
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
