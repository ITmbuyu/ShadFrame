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
    public class PartsCollectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartsCollections
        public async Task<ActionResult> Index()
        {
            return View(await db.PartsCollections.ToListAsync());
        }

        // GET: PartsCollections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsCollection partsCollection = await db.PartsCollections.FindAsync(id);
            if (partsCollection == null)
            {
                return HttpNotFound();
            }
            return View(partsCollection);
        }

        // GET: PartsCollections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartsCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PartsCollectionId,PartName,Quaunity,Price,Supplier,SupplierAddress")] PartsCollection partsCollection)
        {
            if (ModelState.IsValid)
            {
                db.PartsCollections.Add(partsCollection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(partsCollection);
        }

        // GET: PartsCollections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsCollection partsCollection = await db.PartsCollections.FindAsync(id);
            if (partsCollection == null)
            {
                return HttpNotFound();
            }
            return View(partsCollection);
        }

        // POST: PartsCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PartsCollectionId,PartName,Quaunity,Price,Supplier,SupplierAddress")] PartsCollection partsCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partsCollection).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(partsCollection);
        }

        // GET: PartsCollections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsCollection partsCollection = await db.PartsCollections.FindAsync(id);
            if (partsCollection == null)
            {
                return HttpNotFound();
            }
            return View(partsCollection);
        }

        // POST: PartsCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PartsCollection partsCollection = await db.PartsCollections.FindAsync(id);
            db.PartsCollections.Remove(partsCollection);
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
