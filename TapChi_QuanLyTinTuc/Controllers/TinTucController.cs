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
using Tapchi.Modules.TapchiDataModel.Helpers;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using System.Web;
using System.IO;

namespace Tapchi.Modules.Tapchi_QuanLyTinTuc.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class TinTucController : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            TinTucManager.Instance.DeleteItem(itemId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (itemId == -1)
                 ? new TinTuc { }
                 : TinTucManager.Instance.GetItem(itemId);
            LoadDropDownList(item);
            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(TinTuc item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // save file 
                    string path = FileUploadHelper.UploadFile(Request.Files["fileAnhBia"], "tintuc");

                    if (item.TinTucID == -1)
                    {

                        item.UserModified = item.UserCreated = User.Username;
                        item.DateModified = item.DateCreated = DateTime.UtcNow;

                        TinTucManager.Instance.CreateItem(item);
                        
                    }
                    else
                    {
                        var existingItem = TinTucManager.Instance.GetItem(item.TinTucID);


                        existingItem.DateModified = DateTime.UtcNow;
                        existingItem.UserModified = User.Username;
                        existingItem.TieuDe = item.TieuDe;
                        existingItem.TomTat = item.TomTat;
                        existingItem.TheLoaiID = item.TheLoaiID;
                        existingItem.NoiDung = item.NoiDung;
                        existingItem.Image = item.Image;
                        existingItem.File = item.File;
                        existingItem.HienThi = item.HienThi;
                        existingItem.LuuY = item.LuuY;
                        existingItem.ThuTu = item.ThuTu;

                        existingItem.Tags = item.Tags;
                        existingItem.NguonTin = item.NguonTin;

                        existingItem.Image = item.Image;
                        if (path != "") existingItem.Image = path;

                        TinTucManager.Instance.UpdateItem(existingItem);

                        
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

            }
            else
            {
                LoadDropDownList(item);
                return View(item);
            }
        }

        private void LoadDropDownList(TinTuc item)
        {
            // get dropdownlist for theloai
            var theLoaiList = TheLoaiTinTucManager.Instance.GetItems();

            var theloais = (from tl in theLoaiList.Cast<TheLoaiTinTuc>().ToList()
                            select new SelectListItem { Text = tl.Ten, Value = tl.TheLoaiID.ToString() }).ToList();

            theloais.Insert(0, new SelectListItem { Text = "-- Chọn Thể loại --", Value = "0" });

            ViewBag.ListTheLoai = theloais;
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = TinTucManager.Instance.GetItems();
            return View(items);
        }
    }
}
