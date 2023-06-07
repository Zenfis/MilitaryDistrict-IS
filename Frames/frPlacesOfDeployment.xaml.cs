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
    /// Логика взаимодействия для frPlacesOfDeployment.xaml
    /// </summary>
    public partial class frPlacesOfDeployment : Page
    {
        public frPlacesOfDeployment()
        {
            InitializeComponent();
            dgPlacesOfDeployment.ItemsSource = Military_District_Information_SystemEntities.GetContext().PlacesOfDeployment.ToList();
        }

        private void dgPlacesOfDeployment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddPlacesOfDeployment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditPlacesOfDeployment(null));
        }

        private void DeletePlacesOfDeployment_Click(object sender, RoutedEventArgs e)
        {
            var a = dgPlacesOfDeployment.SelectedItems.Cast<PlacesOfDeployment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().PlacesOfDeployment.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgPlacesOfDeployment.ItemsSource = Military_District_Information_SystemEntities.GetContext().PlacesOfDeployment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisPlacesOfDeployment_Click_1(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditPlacesOfDeployment((sender as Button).DataContext as _database.PlacesOfDeployment));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgPlacesOfDeployment.ItemsSource = Military_District_Information_SystemEntities.GetContext().PlacesOfDeployment.ToList();
            }
        }
    }
}
