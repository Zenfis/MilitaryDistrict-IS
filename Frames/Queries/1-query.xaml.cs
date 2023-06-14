using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

namespace MilitaryDistrict_IS.Frames.Queries
{
    /// <summary>
    /// Логика взаимодействия для _1_query.xaml
    /// </summary>
    public partial class _1_query : Page
    {
        private readonly string connectionString = "Data Source=DESKTOP-GT7VQGQ\\SQLEXPRESS;Initial Catalog=Military_District_Information_System;Integrated Security=True";
        private string storedProcedureName = "";
        private string value = "";
        private string table = "";
        public _1_query()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void queryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void availabeItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            try
            {
                int input = 1;
                if (availableItems.SelectedItem != null)
                {
                    input = (int)availableItems.SelectedItem;
                }
                else
                    input = 1;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(value, input);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        queryGrid.ItemsSource = dataTable.DefaultView;
                    }
                    else
                    {
                        queryGrid.ItemsSource = null;                       
                        MessageBox.Show("Нет данных для отображения\nпо идентификатору: " + (int)availableItems.SelectedItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FillComboBox()
        {
            string str = " Id ";
            string sqlQuery = "SELECT"+str+"FROM"+table;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    if (availableItems != null)
                    {
                        availableItems.Items.Add(Id);
                    }
                }

                reader.Close();
            }
        }

        private void availableQueries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (availableQueries.SelectedIndex == 0) { storedProcedureName = "GetMilitaryWeaponsInMilitaryBase"; value = "@MilitaryBaseId"; table = " MilitaryBase"; }
            else if (availableQueries.SelectedIndex == 1) { storedProcedureName = "GetSubordinationChain"; value = "@soldierId"; table = " Soldier"; }
            else if (availableQueries.SelectedIndex == 2) { storedProcedureName = "GetMilitaryBasesWithEquipment"; value = "EquipmentId"; table = " MilitaryEquipment"; }
            availableItems.Items.Clear();
            FillComboBox();
            availableItems.SelectedIndex = 0;
        }
    }
}
