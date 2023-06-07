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
    /// Логика взаимодействия для frDivision.xaml
    /// </summary>
    public partial class frDivision : Page
    {
        public frDivision()
        {
            InitializeComponent();
            dgDivision.ItemsSource = Military_District_Information_SystemEntities.GetContext().Division.ToList();
        }

        private void dgDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddDivision_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditDivision(null));
        }

        private void DeleteDivision_Click(object sender, RoutedEventArgs e)
        {
            var a = dgDivision.SelectedItems.Cast<Division>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Division.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgDivision.ItemsSource = Military_District_Information_SystemEntities.GetContext().Division.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisDivision_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditDivision((sender as Button).DataContext as _database.Division));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgDivision.ItemsSource = Military_District_Information_SystemEntities.GetContext().Division.ToList();
            }
        }
    }
}
