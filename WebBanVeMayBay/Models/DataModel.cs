using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections; 
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DataModel
    {
        public static string connectionString = "Server=(local);Database=csdl_doanpm;Trusted_Connection=True"
;
        public string xulydulieu(string text)
        {
            String s = text.Replace(",", "&44;");
            s = s.Replace("\"", "&34;");
            s = s.Replace("'", "&39;");
            return s;
        }
        public ArrayList get(String sql)
        {
            ArrayList datalist = new ArrayList();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            using (SqlDataReader r = command.ExecuteReader())
            {
                while (r.Read())
                {
                    ArrayList row = new ArrayList();
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        row.Add(xulydulieu(r.GetValue(i).ToString()));
                    }
                    datalist.Add(row);
                }
            }
            connection.Close();
            return datalist;
        }
    }
}