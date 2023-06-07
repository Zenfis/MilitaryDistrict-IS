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
    /// Логика взаимодействия для frEditCommander.xaml
    /// </summary>
    public partial class frEditCommander : Page
    {
        private _database.Commander _currentCommander = new _database.Commander();
        public frEditCommander(_database.Commander selectCommander)
        {
            InitializeComponent();
            if (selectCommander != null)
                _currentCommander = selectCommander;

            DataContext = _currentCommander;
        }

        private void SaveCommander_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCommander.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Commander.Add(_currentCommander);
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
