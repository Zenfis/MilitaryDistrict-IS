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
    /// Логика взаимодействия для frEditConstruction.xaml
    /// </summary>
    public partial class frEditConstruction : Page
    {
        private _database.Construction _currentConstruction = new _database.Construction();
        public frEditConstruction(_database.Construction selectConstruction)
        {
            InitializeComponent();
            if (selectConstruction != null)
                _currentConstruction = selectConstruction;

            DataContext = _currentConstruction;
        }

        private void SaveConstruction_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentConstruction.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Construction.Add(_currentConstruction);
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
