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
    public class SectionMasterController : Controller
    {
        readonly private IConfiguration configuration;
        public SectionMasterController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        [HttpGet]
        // GET: SectionMasterController
        public JsonResult Get()
        {
            string query = @"select * from SectionMaster";
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
        // GET: SectionMasterController/Details/5
        public JsonResult Get(int id)
        {
            string query = @"select * from SectionMaster where Section_Id = '" + id + "'";
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
        // GET: SectionMasterController/Details/5
        public JsonResult GetSectionByUser(string Uid)
        {
            string query = @"select * from SectionMaster where User_Id = '" + Uid + "'";
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
        // POST: SectionMasterController/Create
        [HttpPost]
        public JsonResult Create(SectionMaster section)
        {
            try
            {
                string query = @"insert into SectionMaster (Section_Name,Section_Description,User_Id,Category_Id) values ('" + section.SectionName + "','" + section.SectionDescription + "','" + section.Id + "','" + section.CategoryId + "')";
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
                return new JsonResult("Unauthorized user");
            }
        }
        [HttpPut]
        // GET: ProductMasterController/Edit/5
        public ActionResult Edit(SectionMaster section)
        {
            string query = @"Update SectionMaster set Section_Name ='" + section.SectionName + "', Section_Description = '" + section.SectionDescription + "',User_Id = '" + section.Id + "', Category_Id = '" + section.CategoryId + "' where Section_Id = " + section.SectionId;
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
        // GET: SectionMasterController/Delete/5
        public ActionResult Delete(int id)
        {
            string query = @"delete from dbo.SectionMaster where Section_Id = '" + id + "'";
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
