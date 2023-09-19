using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleMasterController : ControllerBase
    {
        readonly private IConfiguration configuration;
        public ArticleMasterController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        // GET: api/<ArticleMasterController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from ArticleMaster";
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

        // GET api/<ArticleMasterController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from ArticleMaster where Article_Id = '" + id + "'";
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
        // POST api/<ArticleMasterController>
        [HttpPost]
        public JsonResult Create(ArticleMaster article)
        {
            try
            {
                string query = @"insert into ArticleMaster (Article_Title,Category_Id,Section_Id,User_Id,Reviewer_Id,Product_Id,Description,Visibility,Status,CommentAllow,UseFullTotal,UseFullCount,Draft,Archive) values
                ('" + article.ArticleTitle + "','" 
                + article.CategoryId + "','" 
                + article.SectionId + "','" 
                + article.Id + "','"
                + article.ReviewerId + "','"
                + article.ProductId + "','"
                + article.Article_Description + "','"
                + article.Visible + "','"
                + article.status + "','"
                + article.CommentAllow + "','"
                + article.UseFullTotal + "','"
                + article.UseFullCount + "','"
                + article.Draft + "','"
                + article.Archive + "')";

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
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPut]
        // GET: ProductMasterController/Edit/5
        public ActionResult Edit(ArticleMaster article)
        {
            string query = @"Update ProductMaster set 
                Article_Title ='" + article.ArticleTitle + "', " +
                "Category_Id = '" + article.CategoryId +
                "Section_Id = '" + article.SectionId +
                "User_Id = '" + article.Id +
                "Reviewer_Id = '" + article.ReviewerId +
                "Product_Id = '" + article.ProductId +
                "Description = '" + article.Article_Description +
                "Visibility = '" + article.Visible +
                "Status = '" + article.status +
                "CommentAllow = '" + article.CommentAllow +
                "UseFullTotal = '" + article.UseFullTotal +
                "UseFullCount = '" + article.UseFullCount +
                "Draft = '" + article.Draft +
                "Archive = '" + article.Archive +
                "' where Article_Id = " + article.ArticleId;
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
            string query = @"delete from dbo.ArticleMaster where Article_Id = '" + id + "'";
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
