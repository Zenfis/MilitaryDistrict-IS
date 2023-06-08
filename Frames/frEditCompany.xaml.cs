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
    /// Логика взаимодействия для frEditCompany.xaml
    /// </summary>
    public partial class frEditCompany : Page
    {
        private _database.Company _currentCompany = new _database.Company();
        public frEditCompany(_database.Company selectCompany)
        {
            InitializeComponent();
            if (selectCompany != null)
                _currentCompany = selectCompany;

            DataContext = _currentCompany;
        }

        private void SaveCompany_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCompany.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Company.Add(_currentCompany);
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
