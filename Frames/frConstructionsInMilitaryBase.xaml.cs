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
    /// Логика взаимодействия для frConstructionsInMilitaryBase.xaml
    /// </summary>
    public partial class frConstructionsInMilitaryBase : Page
    {
        public frConstructionsInMilitaryBase()
        {
            InitializeComponent();
            dgConstructionsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().ConstructionsInMilitaryBase.ToList();
        }

        private void dgConstructionsInMilitaryBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddConstructionsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditConstructionsInMilitaryBase(null));
        }

        private void DeleteConstructionsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            var a = dgConstructionsInMilitaryBase.SelectedItems.Cast<ConstructionsInMilitaryBase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().ConstructionsInMilitaryBase.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgConstructionsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().ConstructionsInMilitaryBase.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisConstructionsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditConstructionsInMilitaryBase((sender as Button).DataContext as _database.ConstructionsInMilitaryBase));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgConstructionsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().ConstructionsInMilitaryBase.ToList();
            }
        }
    }
}
