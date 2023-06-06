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
    /// Логика взаимодействия для frCorps.xaml
    /// </summary>
    public partial class frCorps : Page
    {
        public frCorps()
        {
            InitializeComponent();
            dgCorps.ItemsSource = Military_District_Information_SystemEntities.GetContext().Corps.ToList();
        }

        private void dgCorps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCorps_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCorps(null));
        }

        private void DeleteCorps_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCorps.SelectedItems.Cast<Corps>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Corps.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCorps.ItemsSource = Military_District_Information_SystemEntities.GetContext().Corps.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCorps_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCorps((sender as Button).DataContext as _database.Corps));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCorps.ItemsSource = Military_District_Information_SystemEntities.GetContext().Corps.ToList();
            }
        }
    }
}
