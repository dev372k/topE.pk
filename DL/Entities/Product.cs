using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Product : Base
    {
        public int Name { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public int AddedBy { get; set; }
        public string Color { get; set; } = string.Empty;
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
