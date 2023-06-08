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
    /// Логика взаимодействия для frSpecialty.xaml
    /// </summary>
    public partial class frSpecialty : Page
    {

        public frSpecialty()
        {
            InitializeComponent();
            dgSpecialty.ItemsSource = Military_District_Information_SystemEntities.GetContext().Specialty.ToList();
        }

        private void dgSpecialty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddSpecialty_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditSpecialty(null));
        }

        private void DeleteSpecialty_Click(object sender, RoutedEventArgs e)
        {
            var a = dgSpecialty.SelectedItems.Cast<Specialty>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Specialty.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgSpecialty.ItemsSource = Military_District_Information_SystemEntities.GetContext().Specialty.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisSpecialty_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditSpecialty((sender as Button).DataContext as _database.Specialty));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgSpecialty.ItemsSource = Military_District_Information_SystemEntities.GetContext().Specialty.ToList();
            }
        }
    }
}
