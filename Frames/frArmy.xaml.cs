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
    /// Логика взаимодействия для frArmy.xaml
    /// </summary>
    public partial class frArmy : Page
    {
        public frArmy()
        {
            InitializeComponent();
            dgArmy.ItemsSource = Military_District_Information_SystemEntities.GetContext().Army.ToList();
        }

        private void dgArmy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddArmy_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditArmy(null));
        }

        private void DeleteArmy_Click(object sender, RoutedEventArgs e)
        {
            var a = dgArmy.SelectedItems.Cast<Army>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Army.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgArmy.ItemsSource = Military_District_Information_SystemEntities.GetContext().Army.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisArmy_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditArmy((sender as Button).DataContext as _database.Army));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgArmy.ItemsSource = Military_District_Information_SystemEntities.GetContext().Army.ToList();
            }
        }
    }
}
