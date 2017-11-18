using SEG.Azure.Data;
using SEG.Azure.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG.Azure.Data
{
    /// <summary>
    /// Class representing Employee data / operations
    /// </summary>
    public class EmployeeData : DBAccessBase, IEmployeeData
    {
        private SqlConnection GetSQLConnection()
        {
            SqlConnection sqlconnection = new SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["AzureConnectionString"].ConnectionString;

                sqlconnection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                sqlconnection.Close();

                LogAndThrowApplicationException("Datasource unavailable!", ex);
            }

            return sqlconnection;
        }

        public int InsertEmployee(Employee employee)
        {
            SqlConnection sqlconnection = GetSQLConnection();
            int employeeid = new int();

            try
            {
                SqlCommand sqlcommand = new SqlCommand("dbo.usp_InsertUpdateEmployee", sqlconnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employee.Id;
                sqlcommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = employee.FName;
                sqlcommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = employee.LName;
                //sqlcommand.Parameters.Add("@Age", SqlDbType.Binary).Value = employee.Age;
                sqlcommand.Parameters.Add("@DOB", SqlDbType.Date).Value = employee.DateOfBirth;

                if (string.IsNullOrEmpty(employee.Address))
                {
                    employee.Address = string.Empty;
                }

                sqlcommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = employee.Address;
                sqlcommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = employee.IsActive;
                sqlcommand.Parameters.Add("@EmployeeIDOut", SqlDbType.Int).Value = 0;

                sqlcommand.Parameters["@EmployeeIDOut"].Direction = ParameterDirection.Output;
                sqlcommand.Parameters["@EmployeeIDOut"].SqlDbType = SqlDbType.Int;
                sqlcommand.Parameters["@EmployeeIDOut"].Size = 18;

                sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();

                employeeid = Convert.ToInt32(sqlcommand.Parameters["@EmployeeIDOut"].Value.ToString());
            }
            catch (Exception ex)
            {
                LogAndThrowApplicationException("Error saving employee to datasource.", ex);
            }
            finally
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }

            return employeeid;
        }

        public List<Employee> GetEmployees(int employeeid)
        {
            SqlConnection sqlconnection = GetSQLConnection();
            List<Employee> employeelist = new List<Employee>();
            SqlDataReader reader = null;

            try
            {
                SqlCommand sqlcommand = new SqlCommand("dbo.usp_GetEmployees", sqlconnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeid;

                sqlconnection.Open();

                reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = reader["EmployeeID"] != DBNull.Value ? 
                        int.Parse(reader["EmployeeID"].ToString()) : 0;

                    employee.FName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() :
                            string.Empty;

                    employee.LName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : 
                            string.Empty;

                    employee.Age = reader["Age"] != DBNull.Value ? int.Parse(reader["Age"].ToString()) :
                            int.Parse("0");

                    employee.DateOfBirth = reader["DOB"] != DBNull.Value ? 
                        DateTime.Parse(reader["DOB"].ToString()) : DateTime.Parse("01/01/0001");

                    employee.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() :
                                                string.Empty;

                    employee.IsActive = bool.Parse(reader["IsActive"].ToString());

                    employeelist.Add(employee);
                }

                reader.Close();
                sqlconnection.Close();
            }
            catch (Exception ex)
            {
                LogAndThrowApplicationException("Error getting employee from datasource.", ex);
            }
            finally
            {
                reader.Close();

                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }

            return employeelist;
        }

        public int UpdateEmployeeDOB()
        {
            SqlConnection sqlconnection = GetSQLConnection();
            int noofemployeesupdated = 0;

            try
            {   
                SqlCommand sqlcommand = new SqlCommand("dbo.usp_UpdateEmployeeDOB", sqlconnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                sqlconnection.Open();
                noofemployeesupdated = sqlcommand.ExecuteNonQuery();

                sqlconnection.Close();
            }
            catch (Exception ex)
            {
                LogAndThrowApplicationException("Error saving employee to datasource.", ex);
            }
            finally
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }

            return noofemployeesupdated;
        }
    }
}

