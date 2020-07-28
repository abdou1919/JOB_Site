using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_Site.Models
{
    public class Category
    {
        public int Id { get; set; }
       [Required]
       [DisplayName("Categoria")]
        public string CategoryName{ get; set; }

        [Required]
        [DisplayName("Discrezione")]
        public string CategoryDescription{ get; set; }

        public ICollection<Job> Jobs { get; set; }


    }
}