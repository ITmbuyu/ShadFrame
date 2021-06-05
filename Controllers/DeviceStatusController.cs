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
    public class DeviceStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeviceStatus
        public async Task<ActionResult> Index()
        {
            var deviceStatuses = db.DeviceStatuses.Include(d => d.RepairStatus);
            return View(await deviceStatuses.ToListAsync());
        }

        // GET: DeviceStatus/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = await db.DeviceStatuses.FindAsync(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Create
        public ActionResult Create()
        {
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status");
            return View();
        }

        // POST: DeviceStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,Price,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId")] DeviceStatus deviceStatus)
        {
            if (ModelState.IsValid)
            {
                db.DeviceStatuses.Add(deviceStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = await db.DeviceStatuses.FindAsync(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // POST: DeviceStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,Price,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId")] DeviceStatus deviceStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RepairStatusId = new SelectList(db.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceStatus deviceStatus = await db.DeviceStatuses.FindAsync(id);
            if (deviceStatus == null)
            {
                return HttpNotFound();
            }
            return View(deviceStatus);
        }

        // POST: DeviceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DeviceStatus deviceStatus = await db.DeviceStatuses.FindAsync(id);
            db.DeviceStatuses.Remove(deviceStatus);
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
