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
    /// Логика взаимодействия для frConstruction.xaml
    /// </summary>
    public partial class frConstruction : Page
    {
        public frConstruction()
        {
            InitializeComponent();
            dgConstruction.ItemsSource = Military_District_Information_SystemEntities.GetContext().Construction.ToList();
        }

        private void dgConstruction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddConstruction_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditConstruction(null));
        }

        private void DeleteConstruction_Click(object sender, RoutedEventArgs e)
        {
            var a = dgConstruction.SelectedItems.Cast<Construction>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Construction.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgConstruction.ItemsSource = Military_District_Information_SystemEntities.GetContext().Construction.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisConstruction_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditConstruction((sender as Button).DataContext as _database.Construction));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgConstruction.ItemsSource = Military_District_Information_SystemEntities.GetContext().Construction.ToList();
            }
        }
    }
}
