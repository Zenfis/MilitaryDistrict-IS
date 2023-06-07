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
    /// Логика взаимодействия для frEditRank.xaml
    /// </summary>
    public partial class frEditRank : Page
    {
        private _database.Rank _currentRank = new _database.Rank();
        public frEditRank(_database.Rank selectRank)
        {
            InitializeComponent();
            if (selectRank != null)
                _currentRank = selectRank;

            DataContext = _currentRank;
        }

        private void SaveRank_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRank.Id == 0)
                _database.Military_District_Information_SystemEntities.GetContext().Rank.Add(_currentRank);
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
