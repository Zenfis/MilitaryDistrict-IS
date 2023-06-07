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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frBrigade());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frCommander());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frRank());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frCategoriesOfRank());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frMilitaryBase());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //FrameManager.MainFrame.Navigate(new frPlacesOfDeployment());
        }
    }
}
