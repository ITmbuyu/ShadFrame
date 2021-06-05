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
    public class PaymentStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentStatus.ToListAsync());
        }

        // GET: PaymentStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatus paymentStatus = await db.PaymentStatus.FindAsync(id);
            if (paymentStatus == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatus);
        }

        // GET: PaymentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentStatusId,Status")] PaymentStatus paymentStatus)
        {
            if (ModelState.IsValid)
            {
                db.PaymentStatus.Add(paymentStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentStatus);
        }

        // GET: PaymentStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatus paymentStatus = await db.PaymentStatus.FindAsync(id);
            if (paymentStatus == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatus);
        }

        // POST: PaymentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaymentStatusId,Status")] PaymentStatus paymentStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentStatus);
        }

        // GET: PaymentStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentStatus paymentStatus = await db.PaymentStatus.FindAsync(id);
            if (paymentStatus == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatus);
        }

        // POST: PaymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PaymentStatus paymentStatus = await db.PaymentStatus.FindAsync(id);
            db.PaymentStatus.Remove(paymentStatus);
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
