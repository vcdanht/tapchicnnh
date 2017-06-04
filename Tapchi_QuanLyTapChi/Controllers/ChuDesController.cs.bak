using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

using Tapchi.Modules.TapchiDataModel.Models;
using Tapchi.Modules.Tapchi_QuanLyTapChi.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using System.Web.Mvc;

namespace Tapchi.Modules.Tapchi_QuanLyTapChi.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class ChuDesController : DnnController
    {
        private TapchiModulesTapchi_QuanLyTapChiContext db = new TapchiModulesTapchi_QuanLyTapChiContext();
        public ChuDesController() : base()
        {

        }

        // GET: ChuDes
        public ActionResult Index()
        {
            var chuDes = db.ChuDes.Include(c => c.DanhMucObj);
            return View(chuDes.ToList());
        }

        // GET: ChuDes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // GET: ChuDes/Create
        public ActionResult Create()
        {
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "MoTa");
            return View();
        }

        // POST: ChuDes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChuDeID,MoTa,Ten,ThuTu,DanhMucID,UserCreated,DateCreated,UserModified,DateModified,Status")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(chuDe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "MoTa", chuDe.DanhMucID);
            return View(chuDe);
        }

        // GET: ChuDes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "MoTa", chuDe.DanhMucID);
            return View(chuDe);
        }

        // POST: ChuDes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChuDeID,MoTa,Ten,ThuTu,DanhMucID,UserCreated,DateCreated,UserModified,DateModified,Status")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuDe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "MoTa", chuDe.DanhMucID);
            return View(chuDe);
        }

        // GET: ChuDes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDes/Delete/5
        [HttpPost, ActionName("Delete")]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuDe chuDe = db.ChuDes.Find(id);
            db.ChuDes.Remove(chuDe);
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
