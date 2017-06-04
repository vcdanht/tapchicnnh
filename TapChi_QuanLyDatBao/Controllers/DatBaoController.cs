/*
' Copyright (c) 2017 
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
using TapChi.Modules.TapChi_QuanLyDatBao.Components;
using TapChi.Modules.TapChi_QuanLyDatBao.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Models;
using Tapchi.Modules.TapchiDataModel.Components;

namespace TapChi.Modules.TapChi_QuanLyDatBao.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class DatBaoController : DnnController
    {

        public ActionResult Delete(int DatBaoId)
        {
            DatBaoManager.Instance.DeleteItem(DatBaoId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int DatBaoId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);



            var item = (DatBaoId == -1)
                 ? new DatBao { }
                 : DatBaoManager.Instance.GetItem(DatBaoId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(DatBao item)
        {
            if (ModelState.IsValid)
            {


                var existingItem = DatBaoManager.Instance.GetItem(item.DatBaoId);

                existingItem.Status = item.Status;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.LastModifiedUser = User.Username;

                DatBaoManager.Instance.UpdateItem(existingItem);


                return RedirectToDefaultRoute();
            }
            else
            {
                return View(item);
            }
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = DatBaoManager.Instance.GetItems();
            items.OrderBy(m => m.CreatedOnDate).Select(m => m.CreatedOnDate).ToList();
            return View(items);
        }
    }
}
