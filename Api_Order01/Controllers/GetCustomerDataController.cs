using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using CarBrokerManagement.Class;
using System.Data;
using Newtonsoft.Json;
using Api_Order01.Class;
using System.Text.RegularExpressions;

namespace Api_Order01.Controllers
{
    public class GetCustomerDataController : ApiController
    {
        public object JSONConvert { get; private set; }


        // GET api/<controller>
        public string Get()
        {
            var json = JsonConvert.SerializeObject(new
            {
                results = new List<Get_set>()
    {
        new Get_set { id = 1, name  = "ABC", last  = "ABC",pw ="123"},
        new Get_set { id = 2, name  = "dfs", last  = "asdasd",pw ="15553"}
    }
        }
            );
            return json;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM user_account", conn))
                {
                    SqlDataAdapter adb = new SqlDataAdapter();
                    adb.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adb.Fill(table);
                    String JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(table);
                    return JSONString;
                }
                conn.Close();
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}