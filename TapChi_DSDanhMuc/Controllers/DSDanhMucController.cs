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
using TapChi.Modules.TapChi_DSDanhMuc.Components;
using TapChi.Modules.TapChi_DSDanhMuc.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;

namespace TapChi.Modules.TapChi_DSDanhMuc.Controllers
{
    [DnnHandleError]
    public class DSDanhMucController : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var userlist = UserController.GetUsers(PortalSettings.PortalId);
            var users = from user in userlist.Cast<UserInfo>().ToList()
                        select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

            ViewBag.Users = users;

            var item = (itemId == -1)
                 ? new Item { ModuleId = ModuleContext.ModuleId }
                 : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (item.ItemId == -1)
            {
                item.CreatedByUserId = User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastModifiedByUserId = User.UserID;
                item.LastModifiedOnDate = DateTime.UtcNow;

                ItemManager.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
                existingItem.LastModifiedByUserId = User.UserID;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
                existingItem.AssignedUserId = item.AssignedUserId;

                ItemManager.Instance.UpdateItem(existingItem);
            }

            return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index(string id)
        {
            string displayType = ModuleContext.Configuration.ModuleSettings["TapChi_DSDanhMuc_DisplayType"] != null ? ModuleContext.Configuration.ModuleSettings["TapChi_DSDanhMuc_DisplayType"].ToString() : "0";
            if (displayType == "0")
            {
                int intID = 0;
                try
                {
                    intID = Int32.Parse(id);
                }
                catch
                {
                    intID = 0;
                }

                var item = DanhMucManager.Instance.GetItem(intID);

                if (item == null)
                {
                    // Lay bai viet dau tien
                    item = DanhMucManager.Instance.GetItems().Where(d=>d.ParentID>0).OrderByDescending(d => d.DateCreated).Take(1).ToList().First();
                }

                if (item != null)
                {
                    if (item.ParentID == 0)
                    {
                        return View("404", item);
                    }
                    // update view
                    item.View++;
                    DanhMucManager.Instance.UpdateItem(item);
                    // list danh muc cung cap
                    ViewBag.ListDanhMucCungCap = DanhMucManager.Instance.GetChildItems().Where(d => d.ParentID == item.ParentID).ToList();
                    return View("Detail", item);
                }
                else
                {
                    return View("404");
                }
            }
            else
            {
                var items = DanhMucManager.Instance.GetItems().Where(d => d.ParentID > 0).OrderByDescending(m => m.DateCreated).Take(1).ToList();
                if (items != null && items.Count() > 0)
                {
                    ViewBag.FirstItem = items.First();

                }

                // Chuyen muc cha 
                ViewBag.DanhMucCha = DanhMucManager.Instance.GetItem(ViewBag.FirstItem.ParentID);

                // Danh sach chuyen muc cung chuyen muc cha
                items = DanhMucManager.Instance.GetItems().Where(d => d.ParentID == ViewBag.FirstItem.ParentID).OrderBy(d => d.DateCreated).ToList();

                return View(items);
            }
        }

    }
}
