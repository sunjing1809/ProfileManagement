using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfileManagement.ViewModels
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        [MinLength(2, ErrorMessage = "The Company Name must contain at least 2 characters")]
        [MaxLength(50, ErrorMessage = "The Company Name can't contain more than 30 characters")]
        public String CompanyName { get; set; }

        [Required]
        [DisplayName("Job Name")]
        [MinLength(2, ErrorMessage = "The Job Name must contain at least 2 characters")]
        [MaxLength(50, ErrorMessage = "The Job Name can't contain more than 30 characters")]
        public String JobName { get; set; }

        [Required]
        [DisplayName("Job Description")]
        [MinLength(2, ErrorMessage = "The Job Description must contain at least 2 characters")]
        [MaxLength(1000, ErrorMessage = "The Job Description can't contain more than 30 characters")]
        public String JobDescription { get; set; }
    }
}
