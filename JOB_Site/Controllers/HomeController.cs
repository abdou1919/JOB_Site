using JOB_Site.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           
            return View(db.Categories.ToList());
        }


        public ActionResult Details(int id)

        {
            var job = db.Jobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();


            }
            Session["jobId"] = id;

            return View(job);


        }


        [Authorize]


        public ActionResult Apply()
        
        {

            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Message)

        {
            var userId = User.Identity.GetUserId();
            var jobId = (int)Session["jobId"];

            var check = db.ApplyForJobs.Where(a => a.JobId == jobId && a.UserId == userId).ToList();

            if (check.Count < 1)


            {

                var Job = new ApplyForJob();



                Job.UserId = userId;
                Job.JobId = jobId;
                Job.ApplyDate = DateTime.Now;
                Job.Message = Message;

                db.ApplyForJobs.Add(Job);
                db.SaveChanges();
                ViewBag.r = "Richiesta inviata";
                


            }

            else
            {

                ViewBag.r = "Sei gia presentato ";
            
            }

            return View();

        }

        public ActionResult GetJobByUser()
        {

            var userid = User.Identity.GetUserId();
            var jobs = db.ApplyForJobs.Where(a => a.UserId == userid);
            return View(jobs.ToList());
        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}