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
    /// Логика взаимодействия для frEditConstructionsInMilitaryBase.xaml
    /// </summary>
    public partial class frEditConstructionsInMilitaryBase : Page
    {
        private _database.ConstructionsInMilitaryBase _currentConstructionsInMilitaryBase = new _database.ConstructionsInMilitaryBase();
        public frEditConstructionsInMilitaryBase(_database.ConstructionsInMilitaryBase selectConstructionsInMilitaryBase)
        {
            InitializeComponent();
            if (selectConstructionsInMilitaryBase != null)
                _currentConstructionsInMilitaryBase = selectConstructionsInMilitaryBase;

            DataContext = _currentConstructionsInMilitaryBase;
        }

        private void SaveConstructionsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentConstructionsInMilitaryBase.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().ConstructionsInMilitaryBase.Add(_currentConstructionsInMilitaryBase);
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
