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
    public class WalkInRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WalkInRequests
        public async Task<ActionResult> Index()
        {
            var walkInRequests = db.WalkInRequests.Include(w => w.Colour).Include(w => w.DeviceDescription).Include(w => w.DeviceProblem).Include(w => w.PaymentStatus).Include(w => w.Storage).Include(w => w.WalkInTimes);
            return View(await walkInRequests.ToListAsync());
        }

        // GET: WalkInRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInRequest walkInRequest = await db.WalkInRequests.FindAsync(id);
            if (walkInRequest == null)
            {
                return HttpNotFound();
            }
            return View(walkInRequest);
        }

        // GET: WalkInRequests/Create
        public ActionResult Create()
        {
            ViewBag.ColourId = new SelectList(db.Colours, "ColourId", "Name");
            ViewBag.DeviceDescriptionId = new SelectList(db.DeviceDescriptions, "DeviceDescriptionId", "DeviceName");
            ViewBag.DeviceProblemId = new SelectList(db.DeviceProblems, "DeviceProblemId", "Description");
            ViewBag.PaymentStatusId = new SelectList(db.PaymentStatus, "PaymentStatusId", "Status");
            ViewBag.StorageId = new SelectList(db.Storage, "StorageId", "StorageCapacity");
            ViewBag.WalkInTimesId = new SelectList(db.WalkInTimes, "WalkInTimesId", "WalkInTime");
            return View();
        }

        // POST: WalkInRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WalkInRequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,WalkInDate,WalkInTimesId,Price,RequestDateTime,UserId,PaymentStatusId,ApprovelCharge")] WalkInRequest walkInRequest)
        {
            if (ModelState.IsValid)
            {
                db.WalkInRequests.Add(walkInRequest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ColourId = new SelectList(db.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewBag.DeviceDescriptionId = new SelectList(db.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", walkInRequest.DeviceDescriptionId);
            ViewBag.DeviceProblemId = new SelectList(db.DeviceProblems, "DeviceProblemId", "Description", walkInRequest.DeviceProblemId);
            ViewBag.PaymentStatusId = new SelectList(db.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewBag.StorageId = new SelectList(db.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewBag.WalkInTimesId = new SelectList(db.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        // GET: WalkInRequests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInRequest walkInRequest = await db.WalkInRequests.FindAsync(id);
            if (walkInRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColourId = new SelectList(db.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewBag.DeviceDescriptionId = new SelectList(db.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", walkInRequest.DeviceDescriptionId);
            ViewBag.DeviceProblemId = new SelectList(db.DeviceProblems, "DeviceProblemId", "Description", walkInRequest.DeviceProblemId);
            ViewBag.PaymentStatusId = new SelectList(db.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewBag.StorageId = new SelectList(db.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewBag.WalkInTimesId = new SelectList(db.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        // POST: WalkInRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WalkInRequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,WalkInDate,WalkInTimesId,Price,RequestDateTime,UserId,PaymentStatusId,ApprovelCharge")] WalkInRequest walkInRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walkInRequest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ColourId = new SelectList(db.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewBag.DeviceDescriptionId = new SelectList(db.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", walkInRequest.DeviceDescriptionId);
            ViewBag.DeviceProblemId = new SelectList(db.DeviceProblems, "DeviceProblemId", "Description", walkInRequest.DeviceProblemId);
            ViewBag.PaymentStatusId = new SelectList(db.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewBag.StorageId = new SelectList(db.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewBag.WalkInTimesId = new SelectList(db.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        // GET: WalkInRequests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInRequest walkInRequest = await db.WalkInRequests.FindAsync(id);
            if (walkInRequest == null)
            {
                return HttpNotFound();
            }
            return View(walkInRequest);
        }

        // POST: WalkInRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WalkInRequest walkInRequest = await db.WalkInRequests.FindAsync(id);
            db.WalkInRequests.Remove(walkInRequest);
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
