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
    public class PartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parts
        public async Task<ActionResult> Index()
        {
            return View(await db.parts.ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts parts = await db.parts.FindAsync(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PartsId,Part_Name,Part_Cost")] Parts parts)
        {
            if (ModelState.IsValid)
            {
                db.parts.Add(parts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parts);
        }

        // GET: Parts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts parts = await db.parts.FindAsync(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PartsId,Part_Name,Part_Cost")] Parts parts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parts).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parts);
        }

        // GET: Parts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts parts = await db.parts.FindAsync(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Parts parts = await db.parts.FindAsync(id);
            db.parts.Remove(parts);
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
