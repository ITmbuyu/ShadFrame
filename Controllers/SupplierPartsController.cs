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
    public class SupplierPartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupplierParts
        public async Task<ActionResult> Index()
        {
            var supplierParts = db.supplierParts.Include(s => s.Parts).Include(s => s.Supplier);
            return View(await supplierParts.ToListAsync());
        }

        // GET: SupplierParts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierPart supplierPart = await db.supplierParts.FindAsync(id);
            if (supplierPart == null)
            {
                return HttpNotFound();
            }
            return View(supplierPart);
        }

        // GET: SupplierParts/Create
        public ActionResult Create()
        {
            ViewBag.PartsId = new SelectList(db.parts, "PartsId", "Part_Name");
            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "Supplier_Name");
            return View();
        }

        // POST: SupplierParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SupplierPartId,PartsId,SupplierId,PartSupplied_Date,PartSupplied_Quantity")] SupplierPart supplierPart)
        {
            if (ModelState.IsValid)
            {
                db.supplierParts.Add(supplierPart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PartsId = new SelectList(db.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // GET: SupplierParts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierPart supplierPart = await db.supplierParts.FindAsync(id);
            if (supplierPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartsId = new SelectList(db.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // POST: SupplierParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SupplierPartId,PartsId,SupplierId,PartSupplied_Date,PartSupplied_Quantity")] SupplierPart supplierPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierPart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PartsId = new SelectList(db.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewBag.SupplierId = new SelectList(db.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // GET: SupplierParts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierPart supplierPart = await db.supplierParts.FindAsync(id);
            if (supplierPart == null)
            {
                return HttpNotFound();
            }
            return View(supplierPart);
        }

        // POST: SupplierParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SupplierPart supplierPart = await db.supplierParts.FindAsync(id);
            db.supplierParts.Remove(supplierPart);
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
