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
using Tapchi.Modules.Tapchi_QuanLyTacGia.Components;
using Tapchi.Modules.Tapchi_QuanLyTacGia.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace Tapchi.Modules.Tapchi_QuanLyTacGia.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class TacGiaController : DnnController
    {

        public ActionResult Delete(int TacGiaID)
        {
            TacGiaManager.Instance.DeleteItem(TacGiaID);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int TacGiaID = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            
            
            var item = (TacGiaID == -1)
                 ? new TacGia { }
                 : TacGiaManager.Instance.GetItem(TacGiaID);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(TacGia item)
        {
            if (ModelState.IsValid)
            {
                if (item.TacGiaID == -1)
                {
                    // add more fields not in database
                    item.UserModified = item.UserCreated = User.Username;
                    item.DateModified = item.DateCreated = DateTime.UtcNow;


                    TacGiaManager.Instance.CreateItem(item);
                }
                else
                {
                    var existingItem = TacGiaManager.Instance.GetItem(item.TacGiaID);

                    existingItem.ButDanh = item.ButDanh;
                    existingItem.Ten = item.Ten;
                    existingItem.DiaChi = item.DiaChi;
                    existingItem.Email = item.Email;
                    existingItem.Phone = item.Phone;
                    existingItem.UserModified = User.Username;
                    existingItem.DateModified = DateTime.UtcNow;

                    TacGiaManager.Instance.UpdateItem(existingItem);
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
            var items = TacGiaManager.Instance.GetItems();
            items.Where(m=>m.ButDanh == "danh").OrderBy(m => m.DateCreated).Select(m=>m.ButDanh).ToList();

            
            return View(items);
        }
    }
}
