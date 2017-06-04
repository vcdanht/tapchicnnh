/*
' Copyright (c) 2017 Web4U
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Linq;
using System.Web.Mvc;
using Tapchi.Modules.TapchiDataModel;
using Tapchi.Modules.Tapchi_QuanLyTapChi.Components;
using Tapchi.Modules.Tapchi_QuanLyTapChi.Models;
using Tapchi.Modules.TapchiDataModel.Helpers;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace Tapchi.Modules.Tapchi_QuanLyTapChi.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class TapChiController : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            TapChiManager.Instance.DeleteItem(itemId);
            return RedirectToDefaultRoute();
        }

        private void LoadDropDownList(TapChi item)
        {
            // get dropdownlist for danhmuc
            var danhMucList = DanhMucManager.Instance.GetChildItems();

            var danhMucs = (from dm in danhMucList.Cast<DanhMuc>().ToList()
                            select new SelectListItem { Text = dm.Ten, Value = dm.DanhMucID.ToString() }).ToList();

            danhMucs.Insert(0, new SelectListItem { Text = "-- Chọn Danh mục --", Value = "0" });

            ViewBag.ListDanhMuc = danhMucs;

            // get dropdownlist for chude
            var chudeList = ChuDeManager.Instance.GetItems();

            var chudes = (from cd in chudeList.Cast<ChuDe>().ToList()
                          select new SelectListItem { Text = cd.Ten, Value = cd.ChuDeID.ToString() }).ToList();

            chudes.Insert(0, new SelectListItem { Text = "-- Chọn Chủ đề --", Value = "0" });

            ViewBag.ListChuDe = chudes;

            // get dropdownlist for tacgia
            var tacgiaList = TacGiaManager.Instance.GetItems();

            var tacgias = (from tg in tacgiaList.Cast<TacGia>().ToList()
                           select new SelectListItem { Text = tg.Ten, Value = tg.TacGiaID.ToString() }).ToList();

           // tacgias.Insert(0, new SelectListItem { Text = "-- Chọn Tác giả --", Value = "0" });

            ViewBag.ListTacGia = tacgias;


        }
        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (itemId == -1)
                 ? new TapChi { }
                 : TapChiManager.Instance.GetItem(itemId);
            
            LoadDropDownList(item);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(TapChi item)
        {
            if (ModelState.IsValid)
            {
                try {
                    // save file 
                    string path = FileUploadHelper.UploadFile(Request.Files["fileAnhBia"], "tapchi");

                    if (item.TapChiID == -1)
                    {
                        
                        item.UserModified = item.UserCreated = User.Username;
                        item.DateModified = item.DateCreated = DateTime.UtcNow;
                        
                        TapChiManager.Instance.CreateItem(item);
                        InsertTapChiTacGia(item);
                    }
                    else
                    {
                        var existingItem = TapChiManager.Instance.GetItem(item.TapChiID);
                        

                        existingItem.DateModified = DateTime.UtcNow;
                        existingItem.UserModified = User.Username;
                        existingItem.Ten = item.Ten;
                        existingItem.DanhMucID = item.DanhMucID;
                        existingItem.ChuDeID = item.ChuDeID;
                        existingItem.LinkDownload = item.LinkDownload;
                        existingItem.MaSo = item.MaSo;
                        existingItem.NgayDuyet = item.NgayDuyet;
                        existingItem.NgayNhan = item.NgayNhan;
                        existingItem.NgayNhanLai = item.NgayNhanLai;
                        existingItem.ThuTu = item.ThuTu;
                        existingItem.TomTat = item.TomTat;
                        existingItem.Trang = item.Trang;
                        existingItem.TuKhoa = item.TuKhoa;

                        existingItem.AnhBia = item.AnhBia;
                        if (path != "") existingItem.AnhBia = path;

                        TapChiManager.Instance.UpdateItem(existingItem);

                        InsertTapChiTacGia(item);
                    }

                    return RedirectToDefaultRoute();
                }
                catch (Exception ex)
                {
                    // Log
                    ModelState.AddModelError("CustomError", "Đã có lỗi trong quá trình xử lý. Vui lòng liên hệ Admin.");
                    LoadDropDownList(item);
                    return View(item);
                }
                
            } else
            {
                LoadDropDownList(item);
                return View(item);
            }
                
        }

        private void InsertTapChiTacGia(TapChi item)
        {
            // delete old data
            foreach (TapChiTacGia t in TapChiTacGiaManager.Instance.GetItems().Where(x => x.TapChiID == item.TapChiID).ToList())
            {
                TapChiTacGiaManager.Instance.DeleteItem(t);
            }

            // insert new data
            if (item.TacGiasPostBack != null)
            {
                foreach (int tid in item.TacGiasPostBack)
                {
                    TapChiTacGia t = new TapChiTacGia();
                    t.TacGiaID = tid;
                    t.TapChiID = item.TapChiID;
                    t.UserModified = t.UserCreated = User.Username;
                    TapChiTacGiaManager.Instance.CreateItem(t);
                }
            }
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = TapChiManager.Instance.GetItems();

            return View(items);
        }
    }
}
