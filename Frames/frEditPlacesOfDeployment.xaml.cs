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
    /// Логика взаимодействия для frEditPlacesOfDeployment.xaml
    /// </summary>
    public partial class frEditPlacesOfDeployment : Page
    {
        private _database.PlacesOfDeployment _currentPlacesOfDeployment = new _database.PlacesOfDeployment();
        public frEditPlacesOfDeployment(_database.PlacesOfDeployment selectPlacesOfDeployment)
        {
            InitializeComponent();
            if (selectPlacesOfDeployment != null)
                _currentPlacesOfDeployment = selectPlacesOfDeployment;

            DataContext = _currentPlacesOfDeployment;
        }

        private void SavePlacesOfDeployment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPlacesOfDeployment.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().PlacesOfDeployment.Add(_currentPlacesOfDeployment);
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
