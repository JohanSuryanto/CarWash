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
    public class Transaction_DataController : Controller
    {
        private ProjCarWashEntities db = new ProjCarWashEntities();

        // GET: Transaction_Data
        [Authorize(Roles ="User")]
        public ActionResult Index()
        {
            //COUNT DATA TRANKSAKSI
            List<int> dataList = new List<int>();
            foreach (var item in db.Transaction_Data)
            {
                var listCustomer = from trans in db.Transaction_Data
                                   where trans.ID_Transaction == item.ID_Transaction
                                   select trans.ID_Transaction;
                int dataCusList = listCustomer.Count();
                dataList.Add(dataCusList);
            }
            ViewBag.DataCount = dataList.Count;

            var transaction_Data = db.Transaction_Data.Include(t => t.Customer_Data).Include(t => t.Price);
            return View(transaction_Data.ToList());
        }

        // GET: Transaction_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Data transaction_Data = db.Transaction_Data.Find(id);
            if (transaction_Data == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Data);
        }
        
        // GET: Transaction_Data/Create
        public ActionResult Create(int id)
        {
            //COUNT DATA TYPE
            //List<int> dataType = new List<int>();
            //foreach (var item in db.Price)
            //{
            //    var listType = from trans in db.Price
            //                   where trans.ID_Type == item.ID_Type
            //                   select trans.ID_Type;
            //    int dataPriceType = listType.Count();
            //    dataType.Add(dataPriceType);
            //}
            //ViewBag.typeCount = dataType.Count;
            //ViewBag.Ukuran = dataType;
            //ViewBag.typeCount = db.Price.Count();
            ViewBag.Ukuran = db.Price;
            var NamaID = db.Customer_Data.Find(id).Customer_Name;
            ViewBag.ID = id;
            ViewBag.NamaID = NamaID;
            //ViewBag.ID_Customer = new SelectList(db.Customer_Data, "ID_Customer", "Customer_Name");
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price");
            return View();
        }

        // POST: Transaction_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Transaction,ID_Customer,ID_Type,Date_Transaction,Total_Price,Number_Of_Vehicles")] Transaction_Data transaction_Data, string ukuran)
        {
            if (ModelState.IsValid)
            {
                transaction_Data.Date_Transaction = DateTime.Today;
                //DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
                //string kecil, string sedang, string besar, string ukuran
                int total = 0;
                int hargacuci;
                ViewBag.dataukuran = db.Price.Find(transaction_Data.ID_Type).Name_Price;
                //foreach (var item in db.Price)
                //{
                    if (ukuran == "Small")
                    {
                        hargacuci = (from getharga in db.Price
                                     where getharga.ID_Type == transaction_Data.ID_Type
                                     select getharga.Small).SingleOrDefault();
                        total += hargacuci;
                    }
                    if (ukuran == "Medium")
                    {
                        hargacuci = (from getharga in db.Price
                                     where getharga.ID_Type == transaction_Data.ID_Type
                                     select getharga.Medium).SingleOrDefault();
                        total += hargacuci;
                    }
                    if (ukuran == "Large")
                    {
                        hargacuci = (from getharga in db.Price
                                     where getharga.ID_Type == transaction_Data.ID_Type
                                     select getharga.Large).SingleOrDefault();
                        total += hargacuci;

                   // }

                    transaction_Data.Total_Price = total;
                    db.Transaction_Data.Add(transaction_Data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
                ViewBag.ID_Customer = new SelectList(db.Customer_Data, "ID_Customer", "Customer_Name", transaction_Data.ID_Customer);
                ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", transaction_Data.ID_Type);
                return View(transaction_Data);
            }
        


        // GET: Transaction_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Data transaction_Data = db.Transaction_Data.Find(id);
            if (transaction_Data == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Customer = new SelectList(db.Customer_Data, "ID_Customer", "Customer_Name", transaction_Data.ID_Customer);
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", transaction_Data.ID_Type);
            return View(transaction_Data);
        }

        // POST: Transaction_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Transaction,ID_Customer,ID_Type,Date_Transaction,Total_Price,Number_Of_Vehicles")] Transaction_Data transaction_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Customer = new SelectList(db.Customer_Data, "ID_Customer", "Customer_Name", transaction_Data.ID_Customer);
            ViewBag.ID_Type = new SelectList(db.Price, "ID_Type", "Name_Price", transaction_Data.ID_Type);
            return View(transaction_Data);
        }

        // GET: Transaction_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Data transaction_Data = db.Transaction_Data.Find(id);
            if (transaction_Data == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Data);
        }

        // POST: Transaction_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction_Data transaction_Data = db.Transaction_Data.Find(id);
            db.Transaction_Data.Remove(transaction_Data);
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
