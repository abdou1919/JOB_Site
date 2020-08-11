namespace JOB_Site.Controllers
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using WebApplication2.Models;

    public class RolesController : Controller
    {
        internal ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {

                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole r)
        {

            if (ModelState.IsValid)
            {
                db.Roles.Add(r);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            {
                return View(r);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {

            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole r)
        {
           
            if(ModelState.IsValid)
            {
                db.Entry(r).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(r);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            try
            {
                var mayRole = db.Roles.Find(role.Id);
                db.Roles.Remove(mayRole);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
