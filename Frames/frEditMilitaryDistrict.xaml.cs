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
    /// Логика взаимодействия для frEditMilitaryDistrict.xaml
    /// </summary>
    public partial class frEditMilitaryDistrict : Page
    {
        private _database.MilitaryDistrict _currentMilitaryDistrict = new _database.MilitaryDistrict();
        public frEditMilitaryDistrict(_database.MilitaryDistrict selectMilitaryDistrict)
        {
            InitializeComponent();
            if (selectMilitaryDistrict != null)
                _currentMilitaryDistrict = selectMilitaryDistrict;

            DataContext = _currentMilitaryDistrict;
        }

        private void SaveDistrict_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryDistrict.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryDistrict.Add(_currentMilitaryDistrict);
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
