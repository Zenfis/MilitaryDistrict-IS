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
    /// Логика взаимодействия для frEditMilitaryBase.xaml
    /// </summary>
    public partial class frEditMilitaryBase : Page
    {
        private _database.MilitaryBase _currentMilitaryBase = new _database.MilitaryBase();
        public frEditMilitaryBase(_database.MilitaryBase selectMilitaryBase)
        {
            InitializeComponent();
            if (selectMilitaryBase != null)
                _currentMilitaryBase = selectMilitaryBase;

            DataContext = _currentMilitaryBase;
        }

        private void SaveMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryBase.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryBase.Add(_currentMilitaryBase);
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
