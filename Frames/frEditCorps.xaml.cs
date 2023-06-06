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
    /// Логика взаимодействия для frEditCorps.xaml
    /// </summary>
    public partial class frEditCorps : Page
    {
        private _database.Corps _currentCorps = new _database.Corps();
        public frEditCorps(_database.Corps selectCorps)
        {
            InitializeComponent();
            if (selectCorps != null)
                _currentCorps = selectCorps;

            DataContext = _currentCorps;
        }

        private void SaveCorps_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCorps.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Corps.Add(_currentCorps);
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
