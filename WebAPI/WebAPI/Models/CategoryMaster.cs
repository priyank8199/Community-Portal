using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CategoryMaster
    {
        [Key]
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [Column("Category_Name")]
        public string CategoryName { get; set; }
        [Column("Category_Description")]
        public string CategoryDescription { get; set; }
        [ForeignKey("AspNetUsers")]
        [Column("User_Id")]
        public string Id { get; set; }
        [ForeignKey("ProductMaster")]
        [Column("Product_Id")]
        public int ProductId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }
        public ProductMaster ProductMaster { get; set; }
    }
}
