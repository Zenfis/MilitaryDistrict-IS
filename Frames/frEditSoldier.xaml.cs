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
    /// Логика взаимодействия для frEditSoldier.xaml
    /// </summary>
    public partial class frEditSoldier : Page
    {
        private _database.Soldier _currentSoldier = new _database.Soldier();
        public frEditSoldier(_database.Soldier selectSoldier)
        {
            InitializeComponent();
            if (selectSoldier != null)
                _currentSoldier = selectSoldier;

            DataContext = _currentSoldier;
        }

        private void SaveSoldier_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSoldier.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Soldier.Add(_currentSoldier);
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
