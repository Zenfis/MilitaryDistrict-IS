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
    /// Логика взаимодействия для frCategoryOfMilitaryWeapon.xaml
    /// </summary>
    public partial class frCategoryOfMilitaryWeapon : Page
    {
        public frCategoryOfMilitaryWeapon()
        {
            InitializeComponent();
            dgCategoryOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryWeapon.ToList();
        }

        private void dgCategoryOfMilitaryWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCategoryOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCategoryOfMilitaryWeapon(null));
        }

        private void DeleteCategoryOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCategoryOfMilitaryWeapon.SelectedItems.Cast<CategoryOfMilitaryWeapon>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryWeapon.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCategoryOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryWeapon.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCategoryOfMilitaryWeapon_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCategoryOfMilitaryWeapon((sender as Button).DataContext as _database.CategoryOfMilitaryWeapon));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCategoryOfMilitaryWeapon.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryWeapon.ToList();
            }
        }
    }
}
