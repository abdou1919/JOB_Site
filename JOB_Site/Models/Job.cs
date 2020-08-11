using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_Site.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Il Titolo del lavoro")]
        public string JobTitle { get; set; }
        [Required]
        [DisplayName("La Descrizione del lavoro")]
        public string JobContent { get; set; }
        [DisplayName("La Foto")]
        public string JobImage { get; set; }

        public int CategoryId { get; set; }
       
        public virtual  Category Category { get; set; }

    }
}