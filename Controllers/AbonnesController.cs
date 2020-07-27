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
    public class AbonnesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Abonnes
        public async Task<ActionResult> Index()
        {
            return View(await db.Abonnes.ToListAsync());
        }

        // GET: Abonnes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = await db.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            return View(abonne);
        }

        // GET: Abonnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abonnes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Prenom,Mail,Photo")] Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                db.Abonnes.Add(abonne);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(abonne);
        }

        // GET: Abonnes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = await db.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            return View(abonne);
        }

        // POST: Abonnes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Prenom,Mail,Photo")] Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonne).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(abonne);
        }

        // GET: Abonnes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonne abonne = await db.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return HttpNotFound();
            }
            return View(abonne);
        }

        // POST: Abonnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Abonne abonne = await db.Abonnes.FindAsync(id);
            db.Abonnes.Remove(abonne);
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
