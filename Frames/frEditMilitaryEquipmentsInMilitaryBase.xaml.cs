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
    /// Логика взаимодействия для frEditMilitaryEquipmentsInMilitaryBase.xaml
    /// </summary>
    public partial class frEditMilitaryEquipmentsInMilitaryBase : Page
    {
        private _database.MilitaryEquipmentsInMilitaryBase _currentMilitaryEquipmentsInMilitaryBase = new _database.MilitaryEquipmentsInMilitaryBase();
        public frEditMilitaryEquipmentsInMilitaryBase(_database.MilitaryEquipmentsInMilitaryBase selectMilitaryEquipmentsInMilitaryBase)
        {
            InitializeComponent();
            if (selectMilitaryEquipmentsInMilitaryBase != null)
                _currentMilitaryEquipmentsInMilitaryBase = selectMilitaryEquipmentsInMilitaryBase;

            DataContext = _currentMilitaryEquipmentsInMilitaryBase;
        }

        private void SaveMilitaryEquipmentsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryEquipmentsInMilitaryBase.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryEquipmentsInMilitaryBase.Add(_currentMilitaryEquipmentsInMilitaryBase);
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
