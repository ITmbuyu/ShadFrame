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
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using System.Net.Mail;

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
                walkInRequest.BrandName = db.DeviceDescriptions.Find(walkInRequest.DeviceDescriptionId).Brand.BrandName;
                walkInRequest.WalkInDate = DateTime.Now;
                walkInRequest.Price = 0;
                walkInRequest.PaymentStatus = db.PaymentStatus.Find(1);
                walkInRequest.UserId = User.Identity.GetUserId();
                walkInRequest.ApprovelCharge = false;
                db.WalkInRequests.Add(walkInRequest);
                db.SaveChanges();

                DeviceStatusWalkIns status = new DeviceStatusWalkIns();
                status.TrackingNumber = "WSTR" + Convert.ToString(walkInRequest.WalkInRequestId);
                status.Brand = walkInRequest.BrandName;
                status.DeviceProblem = db.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description;//request.DeviceProblem.Description;
                status.DeviceName = walkInRequest.DeviceDescription.DeviceName;
                //variable name=  databaseinstance.find(primarykeyofrespectivetable).itemlookingfor
                status.Capacity = db.Storage.Find(walkInRequest.StorageId).StorageCapacity;
                status.Colour = db.Colours.Find(walkInRequest.ColourId).Name;
                status.IMEI = walkInRequest.IMEI;
                status.Price = walkInRequest.Price;
                status.PaymentStatus = db.PaymentStatus.Find(walkInRequest.PaymentStatusId).Status;
                status.WalkInDate = walkInRequest.WalkInDate;
                status.WalkInTime = db.WalkInTimes.Find(walkInRequest.WalkInTimesId).WalkInTime;
                status.WalkInStatus = "Please Drop your Device In for Repair on " + Convert.ToString(status.WalkInDate) + "Between " + Convert.ToString(status.WalkInTime);
                status.RepairStatus = db.RepairStatuses.Find(4);
                status.RequestDateTime = walkInRequest.WalkInDate;
                status.UserId = walkInRequest.UserId;
                status.ApprovalOfCharge = walkInRequest.ApprovelCharge;
                //status.StatusId = 1;
                db.DeviceStatusesWalkIns.Add(status);
                db.SaveChanges();
                WalkInSendEmail(walkInRequest, status);
                return RedirectToAction("Details", new RouteValueDictionary(
                    new { Controller = "WalkInRequests", Action = "Details", Id = walkInRequest.WalkInRequestId }));
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

        //method to send email 
        public void WalkInSendEmail(WalkInRequest walkInRequest, DeviceStatusWalkIns status)
        {
            var user = db.Users.Find(walkInRequest.UserId);
            var email = User.Identity.GetUserName();
            string message =
                $"Hi there, \n\n" +
                $"You have made a WalkIn Booking with Shadrack Phone Repair. Here are the details of the booking: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {walkInRequest.WalkInRequestId} \n" +
                $"Date of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Time of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Here are the details of the Device to be repaired: \n\n" +
                $"Your Device Brand is: {walkInRequest.BrandName} \n" +
                $"Your Device Name is: {walkInRequest.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {db.Storage.Find(walkInRequest.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { db.Colours.Find(walkInRequest.ColourId).Name} \n" +
                $"Device IMEI Number is: {walkInRequest.IMEI} \n" +
                $"Problem with device: {db.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description} \n" +
                $"Price of repair R: {walkInRequest.Price} \n\n" +
                $"Looking foward to seeing you, please check dashboard for status of repair \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{walkInRequest.WalkInRequestId}";
            var body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, recieverMail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
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
