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
    /// Логика взаимодействия для frDepartament.xaml
    /// </summary>
    public partial class frDepartament : Page
    {
        public frDepartament()
        {
            InitializeComponent();
            dgDepartament.ItemsSource = Military_District_Information_SystemEntities.GetContext().Departament.ToList();
        }

        private void dgDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddDepartament_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditDepartament(null));
        }

        private void DeleteDepartament_Click(object sender, RoutedEventArgs e)
        {
            var a = dgDepartament.SelectedItems.Cast<Departament>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().Departament.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgDepartament.ItemsSource = Military_District_Information_SystemEntities.GetContext().Departament.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisDepartament_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditDepartament((sender as Button).DataContext as _database.Departament));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgDepartament.ItemsSource = Military_District_Information_SystemEntities.GetContext().Departament.ToList();
            }
        }
    }
}
