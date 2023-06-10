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
    /// Логика взаимодействия для frKindOfMilitaryEquipment.xaml
    /// </summary>
    public partial class frKindOfMilitaryEquipment : Page
    {
        public frKindOfMilitaryEquipment()
        {
            InitializeComponent();
            dgKindOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryEquipment.ToList();
        }

        private void dgKindOfMilitaryEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddKindOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditKindOfMilitaryEquipment(null));
        }

        private void DeleteKindOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            var a = dgKindOfMilitaryEquipment.SelectedItems.Cast<KindOfMilitaryEquipment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().KindOfMilitaryEquipment.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgKindOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryEquipment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisKindOfMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditKindOfMilitaryEquipment((sender as Button).DataContext as _database.KindOfMilitaryEquipment));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgKindOfMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().KindOfMilitaryEquipment.ToList();
            }
        }
    }
}
