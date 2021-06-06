﻿using System;
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
    public class CApprovalMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CApprovalMessages
        public async Task<ActionResult> Index()
        {
            return View(await db.CApprovalMessages.ToListAsync());
        }

        // GET: CApprovalMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CApprovalMessages cApprovalMessages = await db.CApprovalMessages.FindAsync(id);
            if (cApprovalMessages == null)
            {
                return HttpNotFound();
            }
            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CApprovalMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CApprovalMessagesId,CMessages")] CApprovalMessages cApprovalMessages)
        {
            if (ModelState.IsValid)
            {
                db.CApprovalMessages.Add(cApprovalMessages);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CApprovalMessages cApprovalMessages = await db.CApprovalMessages.FindAsync(id);
            if (cApprovalMessages == null)
            {
                return HttpNotFound();
            }
            return View(cApprovalMessages);
        }

        // POST: CApprovalMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CApprovalMessagesId,CMessages")] CApprovalMessages cApprovalMessages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cApprovalMessages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CApprovalMessages cApprovalMessages = await db.CApprovalMessages.FindAsync(id);
            if (cApprovalMessages == null)
            {
                return HttpNotFound();
            }
            return View(cApprovalMessages);
        }

        // POST: CApprovalMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CApprovalMessages cApprovalMessages = await db.CApprovalMessages.FindAsync(id);
            db.CApprovalMessages.Remove(cApprovalMessages);
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
