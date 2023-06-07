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
    /// Логика взаимодействия для frTablesList.xaml
    /// </summary>
    public partial class frTablesList : Page
    {
        public frTablesList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frMilitaryDistrict());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frPartsOfMilitaryDistrict());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frArmy());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frCorps());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frDivision());
        }
    }
}
