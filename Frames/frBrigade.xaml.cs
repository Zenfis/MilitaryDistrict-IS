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
    /// Логика взаимодействия для frBrigade.xaml
    /// </summary>
    public partial class frBrigade : Page
    {
        public frBrigade()
        {
            InitializeComponent();
            dgBrigade.ItemsSource = Military_District_Information_SystemEntities.GetContext().Brigade.ToList();
        }

        private void dgBrigade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBrigade_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditBrigade(null));
        }

        private void DeleteBrigade_Click(object sender, RoutedEventArgs e)
        {
            var a = dgBrigade.SelectedItems.Cast<Brigade>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Brigade.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgBrigade.ItemsSource = Military_District_Information_SystemEntities.GetContext().Brigade.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisBrigade_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditBrigade((sender as Button).DataContext as _database.Brigade));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgBrigade.ItemsSource = Military_District_Information_SystemEntities.GetContext().Brigade.ToList();
            }
        }
    }
}
