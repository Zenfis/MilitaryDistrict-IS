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
    /// Логика взаимодействия для frRank.xaml
    /// </summary>
    public partial class frRank : Page
    {
        public frRank()
        {
            InitializeComponent();
            dgRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().Rank.ToList();
        }

        private void dgRank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddRank_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditRank(null));
        }

        private void DeleteRank_Click(object sender, RoutedEventArgs e)
        {
            var a = dgRank.SelectedItems.Cast<Rank>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Rank.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().Rank.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisRank_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditRank((sender as Button).DataContext as _database.Rank));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgRank.ItemsSource = Military_District_Information_SystemEntities.GetContext().Rank.ToList();
            }
        }
    }
}
