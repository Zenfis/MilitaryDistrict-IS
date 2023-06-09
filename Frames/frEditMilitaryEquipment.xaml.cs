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
    /// Логика взаимодействия для frEditMilitaryEquipment.xaml
    /// </summary>
    public partial class frEditMilitaryEquipment : Page
    {
        private _database.MilitaryEquipment _currentMilitaryEquipment = new _database.MilitaryEquipment();
        public frEditMilitaryEquipment(_database.MilitaryEquipment selectMilitaryEquipment)
        {
            InitializeComponent();
            if (selectMilitaryEquipment != null)
                _currentMilitaryEquipment = selectMilitaryEquipment;

            DataContext = _currentMilitaryEquipment;
        }

        private void SaveEditMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMilitaryEquipment.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().MilitaryEquipment.Add(_currentMilitaryEquipment);
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
