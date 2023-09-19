using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Category
    {
        [Key]
        public short CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
