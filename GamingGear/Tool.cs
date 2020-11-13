using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GamingGear
{
    public class Tool
    {
        string strcon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection connection;

        private void GetConnect()
        {
            connection = new SqlConnection(strcon);
            connection.Open();
        }

        private void CloseConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable GetData(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                GetConnect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(table);
            }
            catch
            {
                table = null;
            }
            finally
            {
                CloseConnect();
            }
            return table;
        }

        public int UpdateData(string sql)
        {
            int kq = 0;
            try
            {
                GetConnect();
                SqlCommand command = new SqlCommand(sql, connection);
                kq = command.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
            }
            finally { CloseConnect(); }
            return kq;
        }

        public int Action(string sql)
        {
            int kq = 0;
            try
            {
                GetConnect();
                SqlCommand command = new SqlCommand(sql, connection);
                kq = command.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
            }
            finally { CloseConnect(); }
            return kq;
        }
    }
}