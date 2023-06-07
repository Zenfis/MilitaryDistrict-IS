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
    /// Логика взаимодействия для frEditCategoriesOfCategoriesOfRank.xaml
    /// </summary>
    public partial class frEditCategoriesOfRank : Page
    {
        private _database.CategoriesOfRank _currentCategoriesOfRank = new _database.CategoriesOfRank();
        public frEditCategoriesOfRank(_database.CategoriesOfRank selectCategoriesOfRank)
        {
            InitializeComponent();
            if (selectCategoriesOfRank != null)
                _currentCategoriesOfRank = selectCategoriesOfRank;

            DataContext = _currentCategoriesOfRank;
        }

        private void SaveCategoriesOfRank_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCategoriesOfRank.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().CategoriesOfRank.Add(_currentCategoriesOfRank);
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
