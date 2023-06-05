using MilitaryDistrict_IS._database;
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
    /// Логика взаимодействия для frMilitaryDistrict.xaml
    /// </summary>
    public partial class frMilitaryDistrict : Page
    {
        public frMilitaryDistrict()
        {
            InitializeComponent();
            dgMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryDistrict.ToList();
        }
        private void dgMilitaryDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
