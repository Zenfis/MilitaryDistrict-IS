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
    /// Логика взаимодействия для frCompany.xaml
    /// </summary>
    public partial class frCompany : Page
    {
        public frCompany()
        {
            InitializeComponent();
            dgCompany.ItemsSource = Military_District_Information_SystemEntities.GetContext().Company.ToList();
        }

        private void dgCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCompany(null));
        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCompany.SelectedItems.Cast<Company>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Company.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCompany.ItemsSource = Military_District_Information_SystemEntities.GetContext().Company.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCompany_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCompany((sender as Button).DataContext as _database.Company));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCompany.ItemsSource = Military_District_Information_SystemEntities.GetContext().Company.ToList();
            }
        }
    }
}
