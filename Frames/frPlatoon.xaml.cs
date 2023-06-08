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
    /// Логика взаимодействия для frPlatoon.xaml
    /// </summary>
    public partial class frPlatoon : Page
    {
        public frPlatoon()
        {
            InitializeComponent();
            dgPlatoon.ItemsSource = Military_District_Information_SystemEntities.GetContext().Platoon.ToList();
        }

        private void dgPlatoon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddPlatoon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditPlatoon(null));
        }

        private void DeletePlatoon_Click(object sender, RoutedEventArgs e)
        {
            var a = dgPlatoon.SelectedItems.Cast<Platoon>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Platoon.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgPlatoon.ItemsSource = Military_District_Information_SystemEntities.GetContext().Platoon.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisPlatoon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditPlatoon((sender as Button).DataContext as _database.Platoon));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgPlatoon.ItemsSource = Military_District_Information_SystemEntities.GetContext().Platoon.ToList();
            }
        }
    }
}
