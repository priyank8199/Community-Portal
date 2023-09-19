﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SectionMaster
    {
        [Key]
        [Column("Section_Id")]
        public int SectionId { get; set; }
        [Required]
        [Column("Section_Name")]
        public string SectionName { get; set; }
        [Required]
        [Column("Section_Description")]
        public string SectionDescription { get; set; }
        [ForeignKey("AspNetUsers")]
        [Column("User_Id")]
        public string Id { get; set; }
        [ForeignKey("CategoryMaster")]
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }
        public CategoryMaster CategoryMaster { get; set; }
    }
}
