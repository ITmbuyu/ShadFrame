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
    public class WalkInPaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WalkInPayments
        public async Task<ActionResult> Index()
        {
            return View(await db.WalkInPayments.ToListAsync());
        }

        // GET: WalkInPayments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInPayments walkInPayments = await db.WalkInPayments.FindAsync(id);
            if (walkInPayments == null)
            {
                return HttpNotFound();
            }
            return View(walkInPayments);
        }

        // GET: WalkInPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkInPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WalkInPaymentsId,paymentmethod,CardNumber,CVVnumber,ExpiryDate,UserId,DateTimeofpayment,TrackingNumberOfRequest,Priceofrepair")] WalkInPayments walkInPayments)
        {
            if (ModelState.IsValid)
            {
                db.WalkInPayments.Add(walkInPayments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(walkInPayments);
        }

        // GET: WalkInPayments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInPayments walkInPayments = await db.WalkInPayments.FindAsync(id);
            if (walkInPayments == null)
            {
                return HttpNotFound();
            }
            return View(walkInPayments);
        }

        // POST: WalkInPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WalkInPaymentsId,paymentmethod,CardNumber,CVVnumber,ExpiryDate,UserId,DateTimeofpayment,TrackingNumberOfRequest,Priceofrepair")] WalkInPayments walkInPayments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walkInPayments).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(walkInPayments);
        }

        // GET: WalkInPayments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkInPayments walkInPayments = await db.WalkInPayments.FindAsync(id);
            if (walkInPayments == null)
            {
                return HttpNotFound();
            }
            return View(walkInPayments);
        }

        // POST: WalkInPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WalkInPayments walkInPayments = await db.WalkInPayments.FindAsync(id);
            db.WalkInPayments.Remove(walkInPayments);
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
