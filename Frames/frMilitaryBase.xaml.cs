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
    /// Логика взаимодействия для frMilitaryBase.xaml
    /// </summary>
    public partial class frMilitaryBase : Page
    {
        public frMilitaryBase()
        {
            InitializeComponent();
            dgMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryBase.ToList();
        }

        private void dgMilitaryBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditMilitaryBase(null));
        }

        private void DeleteMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            var a = dgMilitaryBase.SelectedItems.Cast<MilitaryBase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().MilitaryBase.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryBase.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditMilitaryBase((sender as Button).DataContext as _database.MilitaryBase));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryBase.ToList();
            }
        }
    }
}
