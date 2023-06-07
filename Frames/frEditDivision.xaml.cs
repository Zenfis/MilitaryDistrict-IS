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
    /// Логика взаимодействия для frEditDivision.xaml
    /// </summary>
    public partial class frEditDivision : Page
    {
        private _database.Division _currentDivision = new _database.Division();
        public frEditDivision(_database.Division selectDivision)
        {
            InitializeComponent();
            if (selectDivision != null)
                _currentDivision = selectDivision;

            DataContext = _currentDivision;
        }

        private void SaveDivision_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDivision.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Division.Add(_currentDivision);
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
