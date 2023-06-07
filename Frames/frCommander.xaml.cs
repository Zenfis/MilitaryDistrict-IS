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
    /// Логика взаимодействия для frCommander.xaml
    /// </summary>
    public partial class frCommander : Page
    {
        public frCommander()
        {
            InitializeComponent();
            dgCommander.ItemsSource = Military_District_Information_SystemEntities.GetContext().Commander.ToList();
        }

        private void dgCommander_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCommander_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCommander(null));
        }

        private void DeleteCommander_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCommander.SelectedItems.Cast<Commander>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Commander.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCommander.ItemsSource = Military_District_Information_SystemEntities.GetContext().Commander.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCommander_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCommander((sender as Button).DataContext as _database.Commander));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCommander.ItemsSource = Military_District_Information_SystemEntities.GetContext().Commander.ToList();
            }
        }
    }
}
