using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        const string ConnectionSting = "Data Source=VARZA-E7400/SQLEXPRESS; Database = tempdb;Persist Security Info=False;" +
                                       "Initial Catalog=tempdb;Connect Timeout=30;";

        readonly List<Model.Employee> _employeeList = new List<Model.Employee>();


        public void CreateEmployeeDetails(Model.Employee employee)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionSting))
            {
                SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.EMPLOYEES");
                cmd.Connection = connection;
                connection.Open();
                if (employee != null)
                {
                    if (employee.Name != "" && employee.Designation != "" && employee.Skills != "")
                    {
                        cmd.CommandText = "INSERT INTO dbo.EMPLOYEES (Name,Designation,Skills,BirthDate) " + "VALUES (@Name, @Designation, @Skills,@BirthDate)"; ;
                        cmd.Parameters.AddWithValue("@Name", employee.Name.Trim());
                        cmd.Parameters.AddWithValue("@Designation", employee.Designation.Trim());
                        cmd.Parameters.AddWithValue("@Skills", employee.Skills.Trim());
                        cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                    }
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void DeleteEmployeeDetails(int id)
        {
           
                using (SqlConnection connection = new SqlConnection(ConnectionSting))
                {
                    SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.EMPLOYEES");
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "DELETE FROM dbo.Books WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
        
        }

        public List<Model.Employee> GetEmployeeDetails()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSting))
            {
                SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.EMPLOYEES");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _employeeList.Add(new Model.Employee()
                    {
                        Name = reader["Name"].ToString(),
                        Designation = reader["Designation"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirtDate"]),
                        Skills = reader["Skills"].ToString()
                    });
                }
                connection.Close();
            }

            return _employeeList.ToList();
        }

        public void UpdateEmployeeDetails(int id, Model.Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSting))
            {
                SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.EMPLOYEES");
                cmd.Connection = connection;
                connection.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                if (employee != null)
                {
                    if (employee.Name != "" && employee.Designation != "" && employee.Skills != "")
                    {
                        cmd.CommandText = "UPDATE dbo.EMPLOYEES SET Name = @Name, Designation = @Designation,Skills=@Skills, BirthDate=@BirthDate WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Name", employee.Name.Trim());
                        cmd.Parameters.AddWithValue("@Designation", employee.Designation.Trim());
                        cmd.Parameters.AddWithValue("@Skills", employee.Skills.Trim());
                        cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                    }
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
