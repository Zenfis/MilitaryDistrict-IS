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
                        MessageBox.Show("Нет данных для отображения\nпо выбранному идентификатору"); //+(int)availableItems.SelectedItem
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
            string sqlQuery;
            if (availableQueries.SelectedIndex == 6 || 
                availableQueries.SelectedIndex == 7 || 
                availableQueries.SelectedIndex == 8 || 
                availableQueries.SelectedIndex == 9) { sqlQuery = "SELECT" + str + "FROM" + table + " " + "WHERE" + str + "<=6" ; }
            else if (availableQueries.SelectedIndex == 10 ||
                availableQueries.SelectedIndex == 11 ||
                availableQueries.SelectedIndex == 12 ||
                availableQueries.SelectedIndex == 13) { sqlQuery = "SELECT" + str + "FROM" + table + " " + "WHERE" + str + ">=7"; }
            else sqlQuery = "SELECT"+str+"FROM"+table;

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
            if (availableQueries.SelectedIndex == 0) { storedProcedureName = "GetMilitaryWeaponsInMilitaryBase"; value = "@MilitaryBaseId"; table = " MilitaryBase"; }                          //1
            else if (availableQueries.SelectedIndex == 1) { storedProcedureName = "GetMilitaryBasesWithWeapon"; value = "@WeaponId"; table = " MilitaryWeapon"; }                               //4
            else if (availableQueries.SelectedIndex == 2) { storedProcedureName = "getCommandersAtMilitaryBase"; value = "@commanderId"; table = " Commander"; }                                //5.1
            else if (availableQueries.SelectedIndex == 3) { storedProcedureName = "getCommandersAtArmy"; value = "@commanderId"; table = " Commander"; }                                        //5.2
            else if (availableQueries.SelectedIndex == 4) { storedProcedureName = "getCommandersAtDivision"; value = "@commanderId"; table = " Commander"; }                                    //5.3
            else if (availableQueries.SelectedIndex == 5) { storedProcedureName = "getCommandersAtCorps"; value = "@commanderId"; table = " Commander"; }                                       //5.4
            else if (availableQueries.SelectedIndex == 6) { storedProcedureName = "getOfficersInMilitaryBase"; value = "@rank"; table = " Rank"; }                                              //6.1
            else if (availableQueries.SelectedIndex == 7) { storedProcedureName = "getOfficersInArmy"; value = "@rank"; table = " Rank"; }                                                      //6.2
            else if (availableQueries.SelectedIndex == 8) { storedProcedureName = "getOfficersInDivision"; value = "@rank"; table = " Rank"; }                                                  //6.3
            else if (availableQueries.SelectedIndex == 9) { storedProcedureName = "getOfficersInCorps"; value = "@rank"; table = " Rank"; }                                                     //6.4
            else if (availableQueries.SelectedIndex == 10) { storedProcedureName = "getLowerRanksInMilitaryBase"; value = "@rank"; table = " Rank"; }                                            //7.1
            else if (availableQueries.SelectedIndex == 11) { storedProcedureName = "getLowerRanksInArmy"; value = "@rank"; table = " Rank"; }                                                    //7.2
            else if (availableQueries.SelectedIndex == 12) { storedProcedureName = "getLowerRanksInDivision"; value = "@rank"; table = " Rank"; }                                                //7.3
            else if (availableQueries.SelectedIndex == 13) { storedProcedureName = "getLowerRanksInCorps"; value = "@rank"; table = " Rank"; }                                                   //7.4
            else if (availableQueries.SelectedIndex == 14) { storedProcedureName = "GetSubordinationChain"; value = "@soldierId"; table = " Soldier"; }                                         //8
            else if (availableQueries.SelectedIndex == 15) { storedProcedureName = "getPlacesOfDeploymentOfMiltaryBase"; value = "@placeOfDeploymentId"; table = " PlacesOfDeployment"; }       //9.1
            else if (availableQueries.SelectedIndex == 16) { storedProcedureName = "getPlacesOfDeploymentOfArmy"; value = "@placeOfDeploymentId"; table = " PlacesOfDeployment"; }              //9.2
            else if (availableQueries.SelectedIndex == 17) { storedProcedureName = "getPlacesOfDeploymentOfDivision"; value = "@placeOfDeploymentId"; table = " PlacesOfDeployment"; }          //9.3
            else if (availableQueries.SelectedIndex == 18) { storedProcedureName = "getPlacesOfDeploymentOfCorps"; value = "@placeOfDeploymentId"; table = " PlacesOfDeployment"; }             //9.4
            else if (availableQueries.SelectedIndex == 19) { storedProcedureName = "getMilitaryEquipmentInMilitaryDistrict"; value = "@districtId"; table = " MilitaryDistrict"; }             //10
            else if (availableQueries.SelectedIndex == 20) { storedProcedureName = "GetMilitaryBasesWithEquipment"; value = "EquipmentId"; table = " MilitaryEquipment"; }                      //11
            availableItems.Items.Clear();
            FillComboBox();
            availableItems.SelectedIndex = 0;
        }
    }
}
