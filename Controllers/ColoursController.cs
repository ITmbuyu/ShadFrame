using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShadFrame.Models;

namespace ShadFrame.Controllers
{
    public class ColoursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Colours
        public async Task<ActionResult> Index()
        {
            return View(await db.Colours.ToListAsync());
        }

        // GET: Colours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = await db.Colours.FindAsync(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // GET: Colours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ColourId,Name")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Colours.Add(colour);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(colour);
        }

        // GET: Colours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = await db.Colours.FindAsync(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ColourId,Name")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colour).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(colour);
        }

        // GET: Colours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = await db.Colours.FindAsync(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Colour colour = await db.Colours.FindAsync(id);
            db.Colours.Remove(colour);
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
