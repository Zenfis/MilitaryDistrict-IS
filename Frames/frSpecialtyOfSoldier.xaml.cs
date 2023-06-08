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
    /// Логика взаимодействия для frSpecialtyOfSoldier.xaml
    /// </summary>
    public partial class frSpecialtyOfSoldier : Page
    {
        public frSpecialtyOfSoldier()
        {
            InitializeComponent();
            dgSpecialtyOfSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().SpecialtyOfSoldier.ToList();
        }

        private void dgSpecialtyOfSoldier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddSpecialtyOfSoldier_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditSpecialtyOfSoldier(null));
        }

        private void DeleteSpecialtyOfSoldier_Click(object sender, RoutedEventArgs e)
        {
            var a = dgSpecialtyOfSoldier.SelectedItems.Cast<SpecialtyOfSoldier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().SpecialtyOfSoldier.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgSpecialtyOfSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().SpecialtyOfSoldier.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisSpecialtyOfSoldier_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditSpecialtyOfSoldier((sender as Button).DataContext as _database.SpecialtyOfSoldier));
        }

        private void Page_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgSpecialtyOfSoldier.ItemsSource = Military_District_Information_SystemEntities.GetContext().SpecialtyOfSoldier.ToList();
            }
        }
    }
}
