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
    /// Логика взаимодействия для frEditDepartament.xaml
    /// </summary>
    public partial class frEditDepartament : Page
    {
        private _database.Departament _currentDepartament = new _database.Departament();
        public frEditDepartament(_database.Departament selectDepartament)
        {
            InitializeComponent();
            if (selectDepartament != null)
                _currentDepartament = selectDepartament;

            DataContext = _currentDepartament;
        }

        private void SaveDepartament_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDepartament.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Departament.Add(_currentDepartament);
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
