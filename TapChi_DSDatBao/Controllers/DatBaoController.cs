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
using Tapchi.Modules.TapChi_DSDatBao.Components;
using Tapchi.Modules.TapChi_DSDatBao.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using Tapchi.Modules.TapchiDataModel.Components;
using Tapchi.Modules.TapchiDataModel.Models;
using DotNetNuke.Services.Mail;
using System.Net;
using System.Configuration;
using reCaptcha;
using Newtonsoft.Json.Linq;

namespace Tapchi.Modules.TapChi_DSDatBao.Controllers
{
    [DnnHandleError]
    public class DatBaoController : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            DatBaoManager.Instance.DeleteItem(itemId);
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
        public ActionResult Index(DatBao item)
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
                if (item.DatBaoId == -1)
                {
                    
                    DatBaoManager.Instance.CreateItem(item);
                    // send email to user and admin.

                    string noidung = "Dear " + item.Ten + "," + Environment.NewLine;
                    noidung += "Cám ơn bạn đã đặt báo tại Tòa soạn của chúng tôi. " + Environment.NewLine;
                    noidung += "Thông tin đặt báo như sau :" + Environment.NewLine;
                    noidung += "Tên: " + item.Ten + Environment.NewLine;
                    noidung += "Địa chỉ: " + item.DiaChi + Environment.NewLine;
                    noidung += "Điện thoại: " + item.DienThoai + Environment.NewLine;
                    noidung += "Email: " + item.Email + Environment.NewLine;
                    noidung += "Kỳ hạn: " + item.KyHan + " thang" + Environment.NewLine;
                    noidung += "Nội dung: " + item.NoiDung + Environment.NewLine;
                    noidung += "Hình thức thanh toán: " + item.HinhThucThanhToan == "TM" ? "Tiền mặt tại toàn soạn" : "Chuyển khoản " + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    noidung += "Trân trọng,";


                    //send mail to user
                    Mail.SendEmail("vovannieu@gmail.com", item.Email, "Dat bao", noidung);

                    // send mail to admin

                    Mail.SendEmail("vovannieu@gmail.com", "vovannieu@gmail.com", "Dat bao", noidung);
                    return View("Thank", item);
                }

                return View("Create", item);


            }
            else
            {
                return View("Create", item);
            }
            //return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var item = new DatBao();
            ViewBag.Recaptcha = ReCaptcha.GetHtml(ConfigurationManager.AppSettings["ReCaptcha:SiteKey"]);
            ViewBag.publicKey = ConfigurationManager.AppSettings["ReCaptcha:SiteKey"];
            return View("Create", item);
        }
    }
}
