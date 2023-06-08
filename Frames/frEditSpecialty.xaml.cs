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
    /// Логика взаимодействия для frEditSpecialty.xaml
    /// </summary>
    public partial class frEditSpecialty : Page
    {
        private _database.Specialty _currentSpecialty = new _database.Specialty();
        public frEditSpecialty(_database.Specialty selectSpecialty)
        {
            InitializeComponent();
            if (selectSpecialty != null)
                _currentSpecialty = selectSpecialty;

            DataContext = _currentSpecialty;
        }

        private void SaveSpecialty_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSpecialty.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Specialty.Add(_currentSpecialty);
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
