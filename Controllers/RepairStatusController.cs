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
    public class RepairStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RepairStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.RepairStatuses.ToListAsync());
        }

        // GET: RepairStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairStatus repairStatus = await db.RepairStatuses.FindAsync(id);
            if (repairStatus == null)
            {
                return HttpNotFound();
            }
            return View(repairStatus);
        }

        // GET: RepairStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RepairStatusId,Status")] RepairStatus repairStatus)
        {
            if (ModelState.IsValid)
            {
                db.RepairStatuses.Add(repairStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(repairStatus);
        }

        // GET: RepairStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairStatus repairStatus = await db.RepairStatuses.FindAsync(id);
            if (repairStatus == null)
            {
                return HttpNotFound();
            }
            return View(repairStatus);
        }

        // POST: RepairStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RepairStatusId,Status")] RepairStatus repairStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(repairStatus);
        }

        // GET: RepairStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairStatus repairStatus = await db.RepairStatuses.FindAsync(id);
            if (repairStatus == null)
            {
                return HttpNotFound();
            }
            return View(repairStatus);
        }

        // POST: RepairStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RepairStatus repairStatus = await db.RepairStatuses.FindAsync(id);
            db.RepairStatuses.Remove(repairStatus);
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
