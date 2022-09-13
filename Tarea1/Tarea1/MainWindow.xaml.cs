using System;
using System.Collections.Generic;
using System.Data;
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

namespace Tarea1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"data source=DESKTOP-LQNH57I\SQLEXPRESS;
            initial catalog = School; Integrated Security=True;");

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender , RoutedEventArgs e)
        {
            List<Person> people = new List<Person>();
            connection.Open();
            SqlCommand command = new SqlCommand("Person3", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 50;

            parameter1.Value = "";
            parameter1.ParameterName = "@PersonID";

            SqlParameter parameter3 = new SqlParameter();
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 50;

            parameter3.Value = "";
            parameter3.ParameterName = "@FirstName";

            SqlParameter parameter2= new SqlParameter();
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 50;

            parameter2.Value = "";

            parameter2.ParameterName = "@LastName";

            SqlParameter parameter4 = new SqlParameter();
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;

            parameter4.Value = "";
            parameter4.ParameterName = "@HireDate";

            SqlParameter parameter5 = new SqlParameter();
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;

            parameter5.Value = "";
            parameter5.ParameterName = "@EnrollmentDate";



            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter4);
            command.Parameters.Add(parameter5);
           

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonID = dataReader["PersonID"].ToString(),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    HireDate = dataReader["HireDate"].ToString(),
                    EnrollmentDate = dataReader["EnrollmentDate"].ToString(),




                }); ;
            }
            connection.Close();
            dgvPeople.ItemsSource = people;
        }
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {


        }
        
    }
}
