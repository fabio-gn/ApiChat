using ApiChat.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiChat.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("api/GetAll")]
        public List<Person> Get()
        {
            Db.GetAll();
            return Person.PeopleList;
        }
        [HttpGet]
        [Route("api/GetNames")]
        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            foreach (Person p in Person.PeopleList) {
            names.Add(p.Name);
            }
            return names;
        }
        [HttpGet]
        [Route("api/GetSingle/{id}")]
        public Person Get(int id)
        {
            return Person.PeopleList.Where(pers => pers.Id == id).FirstOrDefault(); //linq
        }
        [HttpPost]
        [Route("api/Add")]
        public void Post([FromBody] PersonaCuscinetto p)
        {
            string name = p.Name;
            string surname = p.Surname;
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO Persone(Nome, Cognome) VALUES ('@nomepers', '@cognomepers'),", conn);

                sqlCmd.Parameters.AddWithValue("nomepers", name);
                sqlCmd.Parameters.AddWithValue("cognomepers", surname);
                int IsOk = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ex.Source = connString;
            }
            finally { conn.Close(); }
            //Person pers = new Person(p.Name, p.Surname);
            //Person.PeopleList.Add(pers);  //non c'era bisogno di fare PeopleList.Add perché viene già fatto dal costruttore ogni volta che un'istanza viene creata
        }
        [HttpPut]
        [Route("api/Edit/{id}")]
        public void Put( int id, [FromBody] PersonaCuscinetto p)
        {
            foreach (Person item in Person.PeopleList)
            {
                if(id == item.Id)
                {
                    item.Name = p.Name;
                    item.Surname = p.Surname;
                }
            }
        }
        [HttpDelete]
        [Route("api/Delete/{id}")]
        public void Delete(int id)
        {
            Person per = Person.PeopleList.Where(p => p.Id == id).FirstOrDefault();
            Person.PeopleList.Remove(per);
        }
    }
}
