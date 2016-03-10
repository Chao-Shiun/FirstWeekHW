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
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                客戶資料 客戶資料 = db.客戶資料.Find(id);
                客戶資料.已刪除 = true;

                //db.Entry(客戶資料).State = EntityState.Modified;

                foreach (var item in db.客戶聯絡人.Where(x => x.客戶Id == id).ToList())
                {
                    item.已刪除 = true;
                }

                foreach (var item in db.客戶銀行資訊.Where(x => x.客戶Id == id).ToList())
                {
                    item.已刪除 = true;
                }

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
                return RedirectToAction("Index");
            }

            /*客戶資料 客戶資料 = db.客戶資料.Find(id);
            db.客戶資料.Remove(客戶資料);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料
        public ActionResult Index(客戶資料 客戶資料)
        {
            var result = db.客戶資料.ToList().AsQueryable().Where(x => x.已刪除.Equals(false));
            if (!string.IsNullOrWhiteSpace(客戶資料.Email))
                result = result.Where(x => x.Email.Equals(客戶資料.Email));

            if (!string.IsNullOrWhiteSpace(客戶資料.傳真))
                result = result.Where(x => x.傳真.Equals(客戶資料.傳真));

            if (!string.IsNullOrWhiteSpace(客戶資料.地址))
                result = result.Where(x => x.地址.Equals(客戶資料.地址));

            if (!string.IsNullOrWhiteSpace(客戶資料.統一編號))
                result = result.Where(x => x.統一編號.Equals(客戶資料.統一編號));

            if (!string.IsNullOrWhiteSpace(客戶資料.電話))
                result = result.Where(x => x.電話.Equals(客戶資料.電話));
            if (!string.IsNullOrWhiteSpace(客戶資料.客戶名稱))
                result = result.Where(x => x.客戶名稱.Equals(客戶資料.客戶名稱));

            return View(result);
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