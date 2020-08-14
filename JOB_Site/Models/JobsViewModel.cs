using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOB_Site.Models
{
    public class JobsViewModel
    {
        public  string JobTitele { get; set; }
        public IEnumerable<ApplyForJob> Items { get; set; }
    }
}