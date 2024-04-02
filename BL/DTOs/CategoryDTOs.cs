using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class GetCategoryDTO
    {
       
        public string Name { get; set; }
    }

    public class AddCategoryDTO
    {
        public string Name { get; set; }

    }

    public class DeleteCategoryDTO
    {
        public int Id { get; set; }

    }

    public class UpdateCategoryDTO {
    
    public string Name { get; set; }
    }
    

}
