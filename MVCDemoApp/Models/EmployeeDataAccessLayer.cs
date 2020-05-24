using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVCDemoApp.Models
{
    public class EmployeeDataAccessLayer
    {
        private readonly string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myAPITestDB;Data Source=DESKTOP-O6C86PJ\\SQLEXPRESS";

        //To View all employees details
        public IEnumerable<Employee> GetAllDetails()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (var con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee
                    {
                        ID = Convert.ToInt32(rdr["EmployeeID"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        KnownAs = rdr["KnownAs"].ToString(),
                        Department = rdr["Department"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        DateStart = Convert.ToDateTime(rdr["DateStart"].ToString()),
                        DateEnd = Convert.ToDateTime(rdr["DateEnd"].ToString()),
                    };

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        //To Add new employee record
        public void AddEmployee(Employee employee)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spAddEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@KnownAs", employee.KnownAs);
            cmd.Parameters.AddWithValue("@Department", employee.Department);
            cmd.Parameters.AddWithValue("@DateStart", employee.DateStart);
            cmd.Parameters.AddWithValue("@DateEnd", employee.DateEnd);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //To Update the records of a particluar employee
        public void UpdateEmployee(Employee employee)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@EmpId", employee.ID);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@KnownAs", employee.KnownAs);
            cmd.Parameters.AddWithValue("@Department", employee.Department);
            cmd.Parameters.AddWithValue("@DateStart", employee.DateStart);
            cmd.Parameters.AddWithValue("@DateEnd", employee.DateEnd);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Get the details of a particular employee
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.KnownAs = rdr["KnowAs"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.DateStart = Convert.ToDateTime(rdr["DateStart"].ToString());
                    employee.DateEnd = Convert.ToDateTime(rdr["DateEnd"].ToString());
                }
            }
            return employee;
        }

        //To Delete the record on a particular employee
        public void DeleteEmployee(int? id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@EmpId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}