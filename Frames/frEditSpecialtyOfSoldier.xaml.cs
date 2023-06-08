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
    /// Логика взаимодействия для frEditSpecialtyOfSoldier.xaml
    /// </summary>
    public partial class frEditSpecialtyOfSoldier : Page
    {
        private _database.SpecialtyOfSoldier _currentSpecialtyOfSoldier = new _database.SpecialtyOfSoldier();
        public frEditSpecialtyOfSoldier(_database.SpecialtyOfSoldier selectSpecialtyOfSoldier)
        {
            InitializeComponent();
            if (selectSpecialtyOfSoldier != null)
                _currentSpecialtyOfSoldier = selectSpecialtyOfSoldier;

            DataContext = _currentSpecialtyOfSoldier;
        }

        private void SaveSpecialtyOfSoldier_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSpecialtyOfSoldier.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().SpecialtyOfSoldier.Add(_currentSpecialtyOfSoldier);
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
