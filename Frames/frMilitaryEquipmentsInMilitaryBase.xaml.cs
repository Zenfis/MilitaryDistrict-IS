﻿using MilitaryDistrict_IS._database;
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
    /// Логика взаимодействия для frMilitaryEquipmentsInMilitaryBase.xaml
    /// </summary>
    public partial class frMilitaryEquipmentsInMilitaryBase : Page
    {
        public frMilitaryEquipmentsInMilitaryBase()
        {
            InitializeComponent();
            dgMilitaryEquipmentsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipmentsInMilitaryBase.ToList();
        }

        private void dgMilitaryEquipmentsInMilitaryBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddMilitaryEquipmentsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new frEditMilitaryEquipmentsInMilitaryBase(null));
        }

        private void DeleteMilitaryEquipmentsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            var a = dgMilitaryEquipmentsInMilitaryBase.SelectedItems.Cast<MilitaryEquipmentsInMilitaryBase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Military_District_Information_SystemEntities.GetContext().MilitaryEquipmentsInMilitaryBase.RemoveRange(a);
                    Military_District_Information_SystemEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    dgMilitaryEquipmentsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipmentsInMilitaryBase.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void EditThisMilitaryEquipmentsInMilitaryBase_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Frames.frEditMilitaryEquipmentsInMilitaryBase((sender as Button).DataContext as _database.MilitaryEquipmentsInMilitaryBase));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Military_District_Information_SystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgMilitaryEquipmentsInMilitaryBase.ItemsSource = Military_District_Information_SystemEntities.GetContext().MilitaryEquipmentsInMilitaryBase.ToList();
            }
        }
    }
}
