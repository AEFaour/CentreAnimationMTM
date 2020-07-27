using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationAuthManyToManyTest.Models;

namespace WebApplicationAuthManyToManyTest.Controllers
{
    public class ActivitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activites
        public async Task<ActionResult> Index()
        {
            return View(await db.Activites.ToListAsync());
        }

        // GET: Activites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = await db.Activites.FindAsync(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // GET: Activites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activites/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Libelle")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                db.Activites.Add(activite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(activite);
        }

        // GET: Activites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = await db.Activites.FindAsync(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // POST: Activites/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Libelle")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(activite);
        }

        // GET: Activites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = await db.Activites.FindAsync(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Activite activite = await db.Activites.FindAsync(id);
            db.Activites.Remove(activite);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
