using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TwoWebAPIs.Contracts.Models
{
    public class SubCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "field must be atleast 6 characters")]
        public string Name { get; set; }

    }
}

