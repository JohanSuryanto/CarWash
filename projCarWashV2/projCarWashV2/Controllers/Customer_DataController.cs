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
    public class Customer_DataController : Controller
    {
        private ProjCarWashEntities db = new ProjCarWashEntities();

        // GET: Customer_Data

        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            List<int> dataList = new List<int>();
                foreach (var item in db.Customer_Data)
            {
                //var listCustomer = from trans in db.Transaction_Data
                //                   where trans.ID_Customer == item.ID_Customer
                //                   select trans.ID_Transaction;
                var listCustomer = db.Transaction_Data.Where(s => s.ID_Customer == item.ID_Customer).Select(s => s.ID_Transaction).Count();


                // int dataCusList = listCustomer.Count();
                //dataList.Add(dataCusList);
                dataList.Add(listCustomer);
            }
            var CusList = db.Customer_Data.ToList();
                

            //int i = 0;
            int i = 0;
            string Status, Warna;
            var listStatus = new List<string>();
            var listWarna = new List<string>();
            foreach (var item in dataList)
            {
                if (dataList[i] != 0)
                {
                    if (dataList[i] % 6 != 0)
                    {
                        Status = "Bayar";
                        Warna = "btn btn-primary";
                        listStatus.Add(Status);
                        listWarna.Add(Warna);
                    }
                    else
                    {
                        Status = "Free";
                        Warna = "btn btn-success";
                        listStatus.Add(Status);
                        listWarna.Add(Warna);
                    }
                }
                else
                {
                    Status = "Bayar";
                    Warna = "btn btn-primary";
                    listStatus.Add(Status);
                    listWarna.Add(Warna);
                }
            i++;
            }
            ViewBag.DataListCustomer = dataList;
            ViewBag.ListCustomer = CusList;
            ViewBag.listStatus = listStatus;
            ViewBag.listWarna = listWarna;
            return View();
           // return View(db.Customer_Data.ToList());
        }

        // GET: Customer_Data/Details/5
        public ActionResult Details(int? id)
        {
            List<int> dataList = new List<int>();
            foreach (var item in db.Customer_Data)
            {
                var listCustomer = from trans in db.Transaction_Data
                                   where trans.ID_Customer == item.ID_Customer
                                   select trans.ID_Transaction;


                int dataCusList = listCustomer.Count();
                dataList.Add(dataCusList);
            }


            ViewBag.DataCount = dataList.Count;
            ViewBag.DataListCustomer = dataList;
            ViewBag.ID = id;
            var getData = db.Transaction_Data.Where(s => s.ID_Customer == id);
            ViewBag.getData = getData;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Data customer_Data = db.Customer_Data.Find(id);
            if (customer_Data == null)
            {
                return HttpNotFound();
            }
            return View(customer_Data);
        }

        // GET: Customer_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Customer,Customer_Name,Phone_Customer,Address_Customer")] Customer_Data customer_Data)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Data.Add(customer_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_Data);
        }

        // GET: Customer_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Data customer_Data = db.Customer_Data.Find(id);
            if (customer_Data == null)
            {
                return HttpNotFound();
            }
            return View(customer_Data);
        }

        // POST: Customer_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Customer,Customer_Name,Phone_Customer,Address_Customer")] Customer_Data customer_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_Data);
        }

        // GET: Customer_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Data customer_Data = db.Customer_Data.Find(id);
            if (customer_Data == null)
            {
                return HttpNotFound();
            }
            return View(customer_Data);
        }

        // POST: Customer_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Data customer_Data = db.Customer_Data.Find(id);
            db.Customer_Data.Remove(customer_Data);
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
