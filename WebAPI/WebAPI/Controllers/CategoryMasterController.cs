using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryMasterController : Controller
    {
        readonly private IConfiguration configuration;
        public CategoryMasterController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        [HttpGet]
        // GET: CategoryMasterController
        public JsonResult Get()
        {
            string query = @"select * from CategoryMaster";
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
        [HttpGet("{id}")]
        // GET: ProductMasterController/Details/5
        public JsonResult Get(int id)
        {
            string query = @"select * from CategoryMaster where Category_Id = '" + id + "'";
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

        // POST: ProductMasterController/Create
        [HttpPost]
        public JsonResult Create(CategoryMaster cat)
        {
            try
            {
                string query = @"insert into CategoryMaster (Category_Name,Category_Description,User_Id,Product_Id) values ('" + cat.CategoryName + "','" + cat.CategoryDescription + "','" + cat.Id + "','" +cat.ProductId+ "')";
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
                return new JsonResult("Data Inserted");
            }
            catch
            {
                return new JsonResult("Category Insert Error");
            }
        }

        [HttpPut]
        // GET: ProductMasterController/Edit/5
        public ActionResult Edit(CategoryMaster cat)
        {
            string query = @"Update CategoryMaster set Category_Name ='" + cat.CategoryName + "', Category_Description = '" + cat.CategoryDescription + "',Product_Id='" +cat.ProductId+ "' where Category_Id = " + cat.CategoryId;
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

        [HttpDelete]
        // GET: ProductMasterController/Delete/5
        public ActionResult Delete(int id)
        {
            string query = @"delete from dbo.CategoryMaster where Category_Id = '" + id + "'";
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
            return new JsonResult("Data Deleted");
        }
    }
}
