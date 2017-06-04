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
using Tapchi.Modules.Tapchi_QuanLyDanhMuc.Components;
using Tapchi.Modules.Tapchi_QuanLyDanhMuc.Models;
using Tapchi.Modules.TapchiDataModel.Helpers;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using System.Web;
using System.IO;

namespace Tapchi.Modules.Tapchi_QuanLyDanhMuc.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class DanhMucController : DnnController
    {

        public ActionResult Delete(int DanhMucId)
        {
            DanhMucManager.Instance.DeleteItem(DanhMucId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int DanhMucId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (DanhMucId == -1)
                 ? new DanhMuc { }
                 : DanhMucManager.Instance.GetItem(DanhMucId);


            var danhMucList = DanhMucManager.Instance.GetParentItems();

            var danhMucs = (from dm in danhMucList.Cast<DanhMuc>().ToList()
                           where (dm.DanhMucID != item.DanhMucID)
                          select new SelectListItem { Text = dm.Ten, Value = dm.DanhMucID.ToString() }).ToList();
            danhMucs.Insert(0, new SelectListItem { Text = "-- Chọn danh mục cha --", Value = "0" });

            ViewBag.ListDanhMucCha = danhMucs;

        
            
            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // save file 
                    string path = FileUploadHelper.UploadFile(Request.Files["fileAnhBia"], "danhmuc");

                    if (item.DanhMucID == -1)
                    {
                        item.UserModified = item.UserCreated = User.Username;
                        item.DateModified = item.DateCreated = DateTime.UtcNow;

                        if (path != "") item.AnhBia = path;

                        DanhMucManager.Instance.CreateItem(item);
                    }
                    else
                    {
                        var existingItem = DanhMucManager.Instance.GetItem(item.DanhMucID);
                        existingItem.Ten = item.Ten;
                        existingItem.MoTa = item.MoTa;
                        existingItem.ParentID = item.ParentID;
                        existingItem.ThuTu = item.ThuTu;

                        existingItem.UserModified = User.Username;
                        existingItem.DateModified = DateTime.UtcNow;

                        existingItem.AnhBia = item.AnhBia;
                        if (path != "") existingItem.AnhBia = path;

                        DanhMucManager.Instance.UpdateItem(existingItem);
                    }
                } catch (Exception ex)
                {
                    //Log.ErrorFormat("An error occurred in the Edit Action. Exception: {0}", ex);
                }
                return RedirectToDefaultRoute();
            } else
            {
                return View(item);
            }
        }

       
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = DanhMucManager.Instance.GetItems();
            return View(items);
        }

        
        public ActionResult Detail(int itemID)
        {
            var item = DanhMucManager.Instance.GetItem(itemID);
            return View(item);
        }
    }
}
