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

        private void AddDistrict_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditMilitaryDistrict(null));
        }

        private void Page_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryDistrict.ToList();
            }
        }

        private void EditThisDistrict_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditMilitaryDistrict((sender as Button).DataContext as _database.MilitaryDistrict));
        }

        private void DeleteDistrict_Click(object sender, RoutedEventArgs e)
        {
            var DtR = dgMilitaryDistrict.SelectedItems.Cast<MilitaryDistrict>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {DtR.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().MilitaryDistrict.RemoveRange(DtR);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgMilitaryDistrict.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryDistrict.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }
}
