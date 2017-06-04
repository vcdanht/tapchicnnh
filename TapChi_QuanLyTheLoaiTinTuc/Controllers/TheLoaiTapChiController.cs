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

namespace Tapchi.Modules.Tapchi_QuanLyTheLoaiTinTuc.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class TheLoaiTinTucController : DnnController
    {

        public ActionResult Delete(int TheLoaiId)
        {
            TheLoaiTinTucManager.Instance.DeleteItem(TheLoaiId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int TheLoaiId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (TheLoaiId == -1)
                 ? new TheLoaiTinTuc { }
                 : TheLoaiTinTucManager.Instance.GetItem(TheLoaiId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(TheLoaiTinTuc item)
        {
            if (ModelState.IsValid)
            {
                if (item.TheLoaiID == -1)
                {
                    item.UserModified = item.UserCreated = User.Username;
                    item.DateModified = item.DateCreated = DateTime.UtcNow;
                    TheLoaiTinTucManager.Instance.CreateItem(item);
                }
                else
                {
                    var existingItem = TheLoaiTinTucManager.Instance.GetItem(item.TheLoaiID);
                    existingItem.Ten = item.Ten;
                    existingItem.MoTa = item.MoTa;
                    existingItem.ThuTu = item.ThuTu;

                    existingItem.UserModified = User.Username;
                    existingItem.DateModified = DateTime.UtcNow;


                    TheLoaiTinTucManager.Instance.UpdateItem(existingItem);
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
            var items = TheLoaiTinTucManager.Instance.GetItems();
            return View(items);
        }
    }
}
