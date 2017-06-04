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

using Tapchi.Modules.TapchiDataModel.Helpers;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using System.Web;
using System.IO;
using DotNetNuke.Services.Mail;
using System.Configuration;
using reCaptcha;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Tapchi.Modules.TapChi_DSGopY.Controllers
{
    [DnnHandleError]
    [AllowAnonymous]
    public class GopYController : DnnController
    {

        public ActionResult Delete(int GopYId)
        {
            GopYManager.Instance.DeleteItem(GopYId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int GopYId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (GopYId == -1)
                 ? new GopY { }
                 : GopYManager.Instance.GetItem(GopYId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Index(GopY item)
        {

            var response = Request["g-recaptcha-response"];
            string secretKey = ConfigurationManager.AppSettings["ReCaptcha:SecretKey"].ToString();
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.RecaptchaLastErrors = status ? "" : "Google reCaptcha validation failed";
            if (ModelState.IsValid && status)
            {
                if (item.GopYId == -1)
                {
                   // item.LastModifiedOnDate = item.LastModifiedOnDate = DateTime.UtcNow;
                   // item.CreatedOnDate = item.CreatedOnDate = DateTime.UtcNow;
                    
                    GopYManager.Instance.CreateItem(item);

                    string noidung = "Dear " + item.Ten + "," + Environment.NewLine;
                    noidung += "Cám ơn bạn đã gop y chúng tôi. " + Environment.NewLine;
                    noidung += "Thông tin đặt báo như sau :" + Environment.NewLine;
                    noidung += "Tên: " + item.Ten + Environment.NewLine;
                    noidung += "Địa chỉ: " + item.DiaChi + Environment.NewLine;
                    noidung += "Điện thoại: " + item.DienThoai + Environment.NewLine;
                    noidung += "Email: " + item.Email + Environment.NewLine;
                    noidung += "Nội dung: " + item.NoiDung + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    noidung += "Trân trọng,";


                    Mail.SendEmail("vovannieu@gmail.com", item.Email, "Gop Y", item.NoiDung);

                    return View("Thank", item);
                }
                return View("Create", item);

            } else
            {
                return View("Create", item);
            }
          
        }

       
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            //var items = GopYManager.Instance.GetItems();

            //ViewBag.DanhMucList = DanhMucManager.Instance.GetItems().ToList();

            var item = new GopY { };

            ViewBag.Recaptcha = ReCaptcha.GetHtml(ConfigurationManager.AppSettings["ReCaptcha:SiteKey"]);
            ViewBag.publicKey = ConfigurationManager.AppSettings["ReCaptcha:SiteKey"];

            return View("Create", item);
        }
    }
}
