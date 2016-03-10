using ClientManagementHomework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClientManagementHomework.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,已刪除")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(客戶聯絡人);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        public ActionResult DeleteAll(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            foreach (var item in db.客戶聯絡人.Where(x => x.已刪除.Equals(false) && x.客戶Id.Equals(id.Value)).ToList())
            {
                item.已刪除 = true;
            }
            db.SaveChanges();
            return RedirectToAction("Details", "客戶資料", new { id = id.Value });
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人.已刪除 = true;
            if (ModelState.IsValid)
            {
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        foreach (var li in item.ValidationErrors)
                        {
                            throw new Exception(li.ErrorMessage);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,已刪除")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var result = db.客戶聯絡人.ToList().AsQueryable().Where(x => x.已刪除.Equals(false));
            if (id == null)
            {
                //var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);
            }
            else
            {
                result = result.Where(x => x.客戶Id == id);
            }
            return View(result.ToList());
        }

        [HttpPost]
        public ActionResult Index(客戶聯絡人 聯絡人)
        {
            var result = db.客戶聯絡人.ToList().AsQueryable().Where(x => x.已刪除.Equals(false));
            if (!string.IsNullOrWhiteSpace(聯絡人.姓名))
                result = result.Where(x => x.姓名.Equals(聯絡人.姓名));
            if (!string.IsNullOrWhiteSpace(聯絡人.職稱))
                result = result.Where(x => x.職稱.Equals(聯絡人.職稱));
            if (!string.IsNullOrWhiteSpace(聯絡人.手機))
                result = result.Where(x => x.手機.Equals(聯絡人.手機));
            if (!string.IsNullOrWhiteSpace(聯絡人.電話))
                result = result.Where(x => x.手機.Equals(聯絡人.電話));
            if (!string.IsNullOrWhiteSpace(聯絡人.Email))
                result = result.Where(x => x.手機.Equals(聯絡人.Email));
            return View(result.ToList());
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