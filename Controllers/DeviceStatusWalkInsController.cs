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
    public class DeviceStatusWalkInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeviceStatusWalkIns
        public async Task<ActionResult> Index()
        {
            var deviceStatusesWalkIns = db.DeviceStatusesWalkIns.Include(d => d.RepairStatus);
            return View(await deviceStatusesWalkIns.ToListAsync());
        }

        // GET: DeviceStatusWalkIns/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatusWalkIns deviceStatusWalkIns = await db.DeviceStatusesWalkIns.FindAsync(id);
            if (deviceStatusWalkIns == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Create
        public ActionResult Create()
        {
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status");
            return View();
        }

        // POST: DeviceStatusWalkIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,WalkInDate,WalkInTime,Price,WalkInStatus,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId")] DeviceStatusWalkIns deviceStatusWalkIns)
        {
            if (ModelState.IsValid)
            {
                db.DeviceStatusesWalkIns.Add(deviceStatusWalkIns);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatusWalkIns deviceStatusWalkIns = await db.DeviceStatusesWalkIns.FindAsync(id);
            if (deviceStatusWalkIns == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // POST: DeviceStatusWalkIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,WalkInDate,WalkInTime,Price,WalkInStatus,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId")] DeviceStatusWalkIns deviceStatusWalkIns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceStatusWalkIns).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatusWalkIns deviceStatusWalkIns = await db.DeviceStatusesWalkIns.FindAsync(id);
            if (deviceStatusWalkIns == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatusWalkIns);
        }

        // POST: DeviceStatusWalkIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DeviceStatusWalkIns deviceStatusWalkIns = await db.DeviceStatusesWalkIns.FindAsync(id);
            db.DeviceStatusesWalkIns.Remove(deviceStatusWalkIns);
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
