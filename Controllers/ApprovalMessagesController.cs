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
    public class ApprovalMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApprovalMessages
        public async Task<ActionResult> Index()
        {
            return View(await db.ApprovalMessages.ToListAsync());
        }

        // GET: ApprovalMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalMessages approvalMessages = await db.ApprovalMessages.FindAsync(id);
            if (approvalMessages == null)
            {
                return HttpNotFound();
            }
            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovalMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ApprovalMessagesId,AMessages")] ApprovalMessages approvalMessages)
        {
            if (ModelState.IsValid)
            {
                db.ApprovalMessages.Add(approvalMessages);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalMessages approvalMessages = await db.ApprovalMessages.FindAsync(id);
            if (approvalMessages == null)
            {
                return HttpNotFound();
            }
            return View(approvalMessages);
        }

        // POST: ApprovalMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApprovalMessagesId,AMessages")] ApprovalMessages approvalMessages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approvalMessages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalMessages approvalMessages = await db.ApprovalMessages.FindAsync(id);
            if (approvalMessages == null)
            {
                return HttpNotFound();
            }
            return View(approvalMessages);
        }

        // POST: ApprovalMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApprovalMessages approvalMessages = await db.ApprovalMessages.FindAsync(id);
            db.ApprovalMessages.Remove(approvalMessages);
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
