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
    /// Логика взаимодействия для frPartsOfMilitaryDistrict.xaml
    /// </summary>
    public partial class frPartsOfMilitaryDistrict : Page
    {
        public frPartsOfMilitaryDistrict()
        {
            InitializeComponent();
            dgPartsOfMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().PartsOfMilitaryDistrict.ToList();
        }
        private void AddDistrictPart_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditPartsOfMilitaryDistrict(null));
        }

        private void EditThisDistrictPart_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditPartsOfMilitaryDistrict((sender as Button).DataContext as _database.PartsOfMilitaryDistrict));
        }

        private void DeleteDistrictPart_Click(object sender, RoutedEventArgs e)
        {
            var PtR = dgPartsOfMilitaryDistrict.SelectedItems.Cast<PartsOfMilitaryDistrict>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {PtR.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().PartsOfMilitaryDistrict.RemoveRange(PtR);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgPartsOfMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().PartsOfMilitaryDistrict.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void dgPartsOfMilitaryDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgPartsOfMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().PartsOfMilitaryDistrict.ToList();
            }
        }
    }
}
