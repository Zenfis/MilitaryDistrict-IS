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
    /// Логика взаимодействия для frMilitaryEquipment.xaml
    /// </summary>
    public partial class frMilitaryEquipment : Page
    {
        public frMilitaryEquipment()
        {
            InitializeComponent();
            dgMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipment.ToList();
        }

        private void dgMilitaryEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditMilitaryEquipment(null));
        }

        private void DeleteMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            var a = dgMilitaryEquipment.SelectedItems.Cast<MilitaryEquipment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().MilitaryEquipment.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisMilitaryEquipment_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditMilitaryEquipment((sender as Button).DataContext as _database.MilitaryEquipment));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgMilitaryEquipment.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipment.ToList();
            }
        }
    }
}
