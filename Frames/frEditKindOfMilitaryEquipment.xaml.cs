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
    /// Логика взаимодействия для frEditKindOfMilitaryEquipment.xaml
    /// </summary>
    public partial class frEditKindOfMilitaryEquipment : Page
    {
        private _database.KindOfMilitaryEquipment _currentKindOfMilitaryEquipment = new _database.KindOfMilitaryEquipment();
        public frEditKindOfMilitaryEquipment(_database.KindOfMilitaryEquipment selectKindOfMilitaryEquipment)
        {
            InitializeComponent();
            if (selectKindOfMilitaryEquipment != null)
                _currentKindOfMilitaryEquipment = selectKindOfMilitaryEquipment;

            DataContext = _currentKindOfMilitaryEquipment;
        }

        private void SaveEditKindOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentKindOfMilitaryEquipment.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().KindOfMilitaryEquipment.Add(_currentKindOfMilitaryEquipment);
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
