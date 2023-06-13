using System;
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

        private void querySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-GT7VQGQ\\SQLEXPRESS;Initial Catalog=Military_District_Information_System;Integrated Security=True";
            string storedProcedureName = "GetMilitaryWeaponsInMilitaryBase";
            if (Int32.TryParse(querySearch.Text, out int input))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MilitaryBaseId", input);

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
                            MessageBox.Show("Нет данных для отображения по идентификатору: " + querySearch.Text);
                            querySearch.Text = "";
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
