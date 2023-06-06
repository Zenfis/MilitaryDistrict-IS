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
    /// Логика взаимодействия для frEditPartsOfMilitaryDistrict.xaml
    /// </summary>
    public partial class frEditPartsOfMilitaryDistrict : Page
    {
        private _database.PartsOfMilitaryDistrict _currentPartsOfMilitaryDistrict = new _database.PartsOfMilitaryDistrict();
        public frEditPartsOfMilitaryDistrict(_database.PartsOfMilitaryDistrict selectPartsOfMilitaryDistrict)
        {
            InitializeComponent();
            if (selectPartsOfMilitaryDistrict != null)
                _currentPartsOfMilitaryDistrict = selectPartsOfMilitaryDistrict;

            DataContext = _currentPartsOfMilitaryDistrict;
        }

        private void SavePartOfDistrict_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentPartsOfMilitaryDistrict.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().PartsOfMilitaryDistrict.Add(_currentPartsOfMilitaryDistrict);
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
