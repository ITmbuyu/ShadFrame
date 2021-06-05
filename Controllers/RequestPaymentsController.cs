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
    public class RequestPaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequestPayments
        public async Task<ActionResult> Index()
        {
            return View(await db.requestPayments.ToListAsync());
        }

        // GET: RequestPayments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestPayments requestPayments = await db.requestPayments.FindAsync(id);
            if (requestPayments == null)
            {
                return HttpNotFound();
            }
            return View(requestPayments);
        }

        // GET: RequestPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RequestPaymentsId,paymentmethod,CardNumber,CVVnumber,ExpiryDate,UserId,DateTimeofpayment,TrackingNumberOfRequest,Priceofrepair")] RequestPayments requestPayments)
        {
            if (ModelState.IsValid)
            {
                db.requestPayments.Add(requestPayments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(requestPayments);
        }

        // GET: RequestPayments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestPayments requestPayments = await db.requestPayments.FindAsync(id);
            if (requestPayments == null)
            {
                return HttpNotFound();
            }
            return View(requestPayments);
        }

        // POST: RequestPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RequestPaymentsId,paymentmethod,CardNumber,CVVnumber,ExpiryDate,UserId,DateTimeofpayment,TrackingNumberOfRequest,Priceofrepair")] RequestPayments requestPayments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestPayments).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(requestPayments);
        }

        // GET: RequestPayments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestPayments requestPayments = await db.requestPayments.FindAsync(id);
            if (requestPayments == null)
            {
                return HttpNotFound();
            }
            return View(requestPayments);
        }

        // POST: RequestPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RequestPayments requestPayments = await db.requestPayments.FindAsync(id);
            db.requestPayments.Remove(requestPayments);
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
