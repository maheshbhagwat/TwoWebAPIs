using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWebAPIs.Contracts.Models
{
    public class Items
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "field must be atleast 3 characters")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
