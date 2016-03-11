using ClientManagementHomework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClientManagementHomework.Controllers
{
    public class VClientCountsController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: VClientCounts
        public ActionResult Index()
        {
            return View(db.VClientCount.ToList());
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