using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TestProject
{
    public class EmployeeData
    {
        private string strConn = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private SqlConnection sCon;
        DataSet dtSet;

        public EmployeeData()
        {
        }

        public int AddEmployee(string Loginid,string fname, string lname,string gender,string imguploaded,string addrs, DateTime dob,DateTime fdate,DateTime tdate,string basic,string hra, string Travel)
        {
            sCon = new SqlConnection(strConn);
            sqlCommand = new SqlCommand("Sp_GetRecords", sCon);
            sCon.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Event", "Add");
            sqlCommand.Parameters.AddWithValue("@Login_Id", Loginid);
            sqlCommand.Parameters.AddWithValue("@FirstName", fname);
            sqlCommand.Parameters.AddWithValue("@LastName", lname);
           
            sqlCommand.Parameters.AddWithValue("@Gender", gender);
            sqlCommand.Parameters.AddWithValue("@PHOTOUPLOAD",imguploaded);
          
            sqlCommand.Parameters.AddWithValue("@AreaAddress", addrs);
            sqlCommand.Parameters.AddWithValue("@From_Date", fdate);
            sqlCommand.Parameters.AddWithValue("@To_Date", tdate);
            sqlCommand.Parameters.AddWithValue("@DOB", dob);
            sqlCommand.Parameters.AddWithValue("@BasicS", basic);
            sqlCommand.Parameters.AddWithValue("@HRA", hra);
            sqlCommand.Parameters.AddWithValue("@Travel", Travel);
            int result = sqlCommand.ExecuteNonQuery();
            return result;

        }
        public int UpdateEmployee(string Loginid, string fname, string lname, string gender, string imguploaded, string addrs, DateTime dob, DateTime fdate, DateTime tdate, string basic, string hra, string Travel)
        {
            sCon = new SqlConnection(strConn);
            sqlCommand = new SqlCommand("Sp_GetRecords", sCon);
            sCon.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Event", "Update");
            sqlCommand.Parameters.AddWithValue("@Login_Id", Loginid);
            sqlCommand.Parameters.AddWithValue("@FirstName", fname);
            sqlCommand.Parameters.AddWithValue("@LastName", lname);

            sqlCommand.Parameters.AddWithValue("@Gender", gender);
            sqlCommand.Parameters.AddWithValue("@PHOTOUPLOAD", imguploaded);

            sqlCommand.Parameters.AddWithValue("@AreaAddress", addrs);
            sqlCommand.Parameters.AddWithValue("@From_Date", fdate);
            sqlCommand.Parameters.AddWithValue("@To_Date", tdate);
            sqlCommand.Parameters.AddWithValue("@DOB", dob);
            sqlCommand.Parameters.AddWithValue("@BasicS", basic);
            sqlCommand.Parameters.AddWithValue("@HRA", hra);
            sqlCommand.Parameters.AddWithValue("@Travel", Travel);
            int result = sqlCommand.ExecuteNonQuery();
            return result;

        }



        public DataTable GetRecords()
        {
            sCon = new SqlConnection(strConn);
            sqlDataAdapter = new SqlDataAdapter("select * from Employee e join Salary_Details sd on e.Login_Id=sd.Login_Id", sCon);
            sCon.Open();
            dtSet = new DataSet();
            sqlDataAdapter.Fill(dtSet);
            return dtSet.Tables[0];
         }
        public void DeleteRow(string Loginid)
        {
            sCon = new SqlConnection(strConn);
            sqlCommand = new SqlCommand("DeleteRecords", sCon);
            sCon.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Login_Id",Loginid);
            sqlCommand.ExecuteNonQuery();
            
        }
        
        public DataTable GetID(string Login_Id)
        {
            sCon = new SqlConnection(strConn);
            sqlDataAdapter = new SqlDataAdapter("select e.Login_Id from Employee e join Salary_Details sd on e.Login_Id=sd.Login_Id where e.Login_Id='"+Login_Id+"'", sCon);
            sCon.Open();
            dtSet = new DataSet();
            sqlDataAdapter.Fill(dtSet);
            return dtSet.Tables[0];
        }
        public void New()
        {
        
        }
    }
}
