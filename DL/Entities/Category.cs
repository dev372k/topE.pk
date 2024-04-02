using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Category : Base
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
