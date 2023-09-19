using Microsoft.AspNetCore.Http;
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
    public class ProductMasterController : Controller
    {
        readonly private IConfiguration configuration;
        public ProductMasterController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        [HttpGet]
        // GET: ProductMasterController
        public JsonResult Get()
        {
            string query = @"select * from ProductMaster";
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
            string query = @"select * from ProductMaster where Product_Id = '" + id + "'";
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

        [HttpGet("{Uid}")]
        // GET: ProductMasterController/Details/5
        public JsonResult GetProductByUser(string Uid)
        {
            string query = @"select * from ProductMaster where User_Id = '" + Uid + "'";
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
        public JsonResult Create(ProductMaster product)
        {
            try
            {
                string query = @"insert into ProductMaster (Product_Name,Product_Description,User_Id) values ('" + product.ProductName + "','" + product.ProductDescription + "','" + product.Id + "')";
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

                return new JsonResult("Unauthorized User");

            }
        }

        [HttpPut]
        // GET: ProductMasterController/Edit/5
        public ActionResult Edit(ProductMaster product)
        {
            string query = @"Update ProductMaster set Product_Name ='" + product.ProductName + "', Product_Description = '" + product.ProductDescription + "',User_Id = '" + product.Id + "' where Product_Id = " + product.productId;
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
            string query = @"delete from dbo.ProductMaster where Product_Id = '" + id + "'";
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
