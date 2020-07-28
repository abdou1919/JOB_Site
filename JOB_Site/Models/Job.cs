using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_Site.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobContent { get; set; }
        public string JobImage { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }

    }
}