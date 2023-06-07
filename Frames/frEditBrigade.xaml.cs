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
    /// Логика взаимодействия для frEditBrigade.xaml
    /// </summary>
    public partial class frEditBrigade : Page
    {
        private _database.Brigade _currentBrigade = new _database.Brigade();
        public frEditBrigade(_database.Brigade selectBrigade)
        {
            InitializeComponent();
            if (selectBrigade != null)
                _currentBrigade = selectBrigade;

            DataContext = _currentBrigade;
        }

        private void SaveBrigade_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentBrigade.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Brigade.Add(_currentBrigade);
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
