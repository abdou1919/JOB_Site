using JOB_Site.Migrations;
using JOB_Site.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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


        public ActionResult GetJoByOff ()
            
            
            {
            var user = User.Identity.GetUserId();


            var job = from a in db.ApplyForJobs
                      join j in db.Jobs
                      on a.JobId equals j.Id
                      where j.User.Id == user
                      select a;

            var grouped = from j in job
                          group j by j.job.JobTitle
                         into gr
                          select new JobsViewModel {

                              JobTitele = gr.Key,
                              Items = gr

                          };



            return View(grouped.ToList());

        
        
        
        }

        [Authorize(Roles ="Azienda")]
        public ActionResult GetAllJobByOff()


        {
            var user = User.Identity.GetUserId();


            var job = from a in db.Jobs
                      where a.UserId == user
                      select a;
            return View(job.ToList());




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

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {

            var jobm = db.ApplyForJobs.Find(id);
            if (jobm == null)
            {
                return HttpNotFound();
            }

            return View(jobm);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyForJob jobm)
        {

            if (ModelState.IsValid)
            {
                db.Entry(jobm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobByUser");
            }

            return View(jobm);
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