using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileManagement.Models
{
    public class Experience
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public String CompanyName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public String JobName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(1000)]
        public String JobDescription { get; set; }
    }
}
