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
    /// Логика взаимодействия для frMilitaryWeaponsInMilitaryBase.xaml
    /// </summary>
    public partial class frMilitaryWeaponsInMilitaryBase : Page
    {
        public frMilitaryWeaponsInMilitaryBase()
        {
            InitializeComponent();
            dgMilitaryWeaponsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryWeaponsInMilitaryBase.ToList();
        }

        private void dgMilitaryWeaponsInMilitaryBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddMilitaryWeaponsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditMilitaryWeaponsInMilitaryBase(null));
        }

        private void DeleteMilitaryWeaponsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            var a = dgMilitaryWeaponsInMilitaryBase.SelectedItems.Cast<MilitaryWeaponsInMilitaryBase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().MilitaryWeaponsInMilitaryBase.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgMilitaryWeaponsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryWeaponsInMilitaryBase.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisMilitaryWeaponsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditMilitaryWeaponsInMilitaryBase((sender as Button).DataContext as _database.MilitaryWeaponsInMilitaryBase));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgMilitaryWeaponsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryWeaponsInMilitaryBase.ToList();
            }
        }
    }
}
