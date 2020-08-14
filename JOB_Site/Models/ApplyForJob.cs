using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using WebApplication2.Models;

namespace JOB_Site.Models
{
    
    public class ApplyForJob
    {

       
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }



        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}