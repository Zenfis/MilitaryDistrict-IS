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
    /// Логика взаимодействия для frKindOfKindOfMilitaryWeapon.xaml
    /// </summary>
    public partial class frKindOfMilitaryWeapon : Page
    {
        public frKindOfMilitaryWeapon()
        {
            InitializeComponent();
            dgKindOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryWeapon.ToList();
        }

        private void dgKindOfMilitaryWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddKindOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditKindOfMilitaryWeapon(null));
        }

        private void DeleteKindOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            var a = dgKindOfMilitaryWeapon.SelectedItems.Cast<KindOfMilitaryWeapon>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().KindOfMilitaryWeapon.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgKindOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryWeapon.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisKindOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditKindOfMilitaryWeapon((sender as Button).DataContext as _database.KindOfMilitaryWeapon));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgKindOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryWeapon.ToList();
            }
        }
    }
}
