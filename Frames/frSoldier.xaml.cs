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
    /// Логика взаимодействия для frSoldier.xaml
    /// </summary>
    public partial class frSoldier : Page
    {
        public frSoldier()
        {
            InitializeComponent();
            dgSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().Soldier.ToList();
        }

        private void dgSoldier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddSoldier_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditSoldier(null));
        }

        private void DeleteSoldier_Click(object sender, RoutedEventArgs e)
        {
            var a = dgSoldier.SelectedItems.Cast<Soldier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Soldier.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().Soldier.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisSoldier_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditSoldier((sender as Button).DataContext as _database.Soldier));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().Soldier.ToList();
            }
        }
    }
}
