using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ArticleMaster
    {
        [Key]
        [Column("Article_Id")]
        public int ArticleId { get; set; }
        [Column("Article_Title")]
        public string ArticleTitle { get; set; }
        [ForeignKey("CategoryMaster")]
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [ForeignKey("SectionMaster")]
        [Column("Section_Id")]
        public int SectionId { get; set; }
        [ForeignKey("AspNetUsers")]
        [Column("User_Id")]
        public string Id { get; set; }
        
        [Column("Reviewer_Id")]
        public string ReviewerId { get; set; }
        [ForeignKey("ProductMaster")]
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("Description")]
        public string Article_Description { get; set; }
        [Column("Visibility")]
        public string Visible { get; set; }
        [Column("Status")]
        public bool status { get; set; }
        [Column("CommentAllow")]
        public bool CommentAllow { get; set; }
        [Column("UseFullTotal")]
        public int UseFullTotal { get; set; }
        [Column("UseFullCount")]
        public int UseFullCount { get; set; }
        [Column("Draft")]
        public bool Draft { get; set; }
        [Column("Archive")]
        public bool Archive { get; set; }
    }
}
