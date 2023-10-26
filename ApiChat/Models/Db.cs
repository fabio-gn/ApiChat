using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiChat.Models
{
    static class Db
    {
        static string connString = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
        static SqlConnection conn = new SqlConnection(connString);
        static public void GetAll()
        {
            try
            {
                Person.PeopleList.Clear();
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Persone", conn);
                
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if(reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        Person Pers = new Person();
                        Pers.Id = reader.GetInt32(0);
                        Pers.Name = reader.GetString(1);
                        Pers.Surname = reader.GetString(2);
                        Person.PeopleList.Add(Pers);
                       
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Source = connString;
            }
            finally { conn.Close(); }
        }
        //static public void Aggiungi(string nomepersona, string cognomepersona)
        //{


        //}
    }
}