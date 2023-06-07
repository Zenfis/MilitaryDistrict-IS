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
    /// Логика взаимодействия для frCategoriesOfCategoriesOfRank.xaml
    /// </summary>
    public partial class frCategoriesOfRank : Page
    {
        public frCategoriesOfRank()
        {
            InitializeComponent();
            dgCategoriesOfRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoriesOfRank.ToList();
        }

        private void dgCategoriesOfRank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCategoriesOfRank_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCategoriesOfRank(null));
        }

        private void DeleteCategoriesOfRank_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCategoriesOfRank.SelectedItems.Cast<CategoriesOfRank>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().CategoriesOfRank.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCategoriesOfRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoriesOfRank.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCategoriesOfRank_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCategoriesOfRank((sender as Button).DataContext as _database.CategoriesOfRank));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCategoriesOfRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoriesOfRank.ToList();
            }
        }
    }
}
