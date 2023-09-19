using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Configuration;
//using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Http.Results;
using Microsoft.Data.SqlClient;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public CategoryController(IConfiguration config)
        {
            this.configuration = config;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from category";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DataConnection");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from category where CategoryId = " + id;
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DataConnection");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post(Category cat)
        {
            string query = @"insert into category (CategoryName) values ('" + cat.CategoryName + "')";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DataConnection");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Data Added");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Category cat)
        {
            string query = @"Update category set CategoryName ='" + cat.CategoryName + "' where CategoryId = " + id;
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DataConnection");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Data Updated");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from category where CategoryId = " + id;
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DataConnection");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Data deleted");
        }
    }
}
