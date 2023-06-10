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
    /// Логика взаимодействия для frCategoryOfMilitaryEquipment.xaml
    /// </summary>
    public partial class frCategoryOfMilitaryEquipment : Page
    {
        public frCategoryOfMilitaryEquipment()
        {
            InitializeComponent();
            dgCategoryOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryEquipment.ToList();
        }

        private void dgCategoryOfMilitaryEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCategoryOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditCategoryOfMilitaryEquipment(null));
        }

        private void DeleteCategoryOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCategoryOfMilitaryEquipment.SelectedItems.Cast<CategoryOfMilitaryEquipment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryEquipment.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgCategoryOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryEquipment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisCategoryOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditCategoryOfMilitaryEquipment((sender as Button).DataContext as _database.CategoryOfMilitaryEquipment));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgCategoryOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().CategoryOfMilitaryEquipment.ToList();
            }
        }
    }
}
