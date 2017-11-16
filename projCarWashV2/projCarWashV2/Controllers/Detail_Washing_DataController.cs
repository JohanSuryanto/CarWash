using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projCarWashV2;

namespace projCarWashV2.Controllers
{
    public class Detail_Washing_DataController : Controller
    {
        private ProjCarWashEntities db = new ProjCarWashEntities();

        // GET: Detail_Washing_Data
        public ActionResult Index()
        {
            var detail_Washing_Data = db.Detail_Washing_Data.Include(d => d.Transaction_Data).Include(d => d.Price);
            return View(detail_Washing_Data.ToList());
        }

        // GET: Detail_Washing_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Washing_Data detail_Washing_Data = db.Detail_Washing_Data.Find(id);
            if (detail_Washing_Data == null)
            {
                return HttpNotFound();
            }
            return View(detail_Washing_Data);
        }

        // GET: Detail_Washing_Data/Create
        public ActionResult Create()
        {
            ViewBag.ID_Transaction = new SelectList(db.Transaction_Data, "ID_Transaction", "Number_Of_Vehicles");
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price");
            return View();
        }

        // POST: Detail_Washing_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Detail,ID_Transaction,ID_Type")] Detail_Washing_Data detail_Washing_Data)
        {
            if (ModelState.IsValid)
            {
                db.Detail_Washing_Data.Add(detail_Washing_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Transaction = new SelectList(db.Transaction_Data, "ID_Transaction", "Number_Of_Vehicles", detail_Washing_Data.ID_Transaction);
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", detail_Washing_Data.ID_Type);
            return View(detail_Washing_Data);
        }

        // GET: Detail_Washing_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Washing_Data detail_Washing_Data = db.Detail_Washing_Data.Find(id);
            if (detail_Washing_Data == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Transaction = new SelectList(db.Transaction_Data, "ID_Transaction", "Number_Of_Vehicles", detail_Washing_Data.ID_Transaction);
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", detail_Washing_Data.ID_Type);
            return View(detail_Washing_Data);
        }

        // POST: Detail_Washing_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Detail,ID_Transaction,ID_Type")] Detail_Washing_Data detail_Washing_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail_Washing_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Transaction = new SelectList(db.Transaction_Data, "ID_Transaction", "Number_Of_Vehicles", detail_Washing_Data.ID_Transaction);
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", detail_Washing_Data.ID_Type);
            return View(detail_Washing_Data);
        }

        // GET: Detail_Washing_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_Washing_Data detail_Washing_Data = db.Detail_Washing_Data.Find(id);
            if (detail_Washing_Data == null)
            {
                return HttpNotFound();
            }
            return View(detail_Washing_Data);
        }

        // POST: Detail_Washing_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail_Washing_Data detail_Washing_Data = db.Detail_Washing_Data.Find(id);
            db.Detail_Washing_Data.Remove(detail_Washing_Data);
            db.SaveChanges();
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
