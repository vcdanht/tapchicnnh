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
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System.ComponentModel.DataAnnotations;
using Tapchi.Modules.TapchiDataModel.Components;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("TapChi")]
    //setup the primary key for table
    [PrimaryKey("TapChiID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("TapChi", CacheItemPriority.Default, 20)]
    public class TapChi
    {
        public int TapChiID { get; set; } = -1;
        [Required]
        public string Ten { get; set; }
        public string TuKhoa { get; set; } = "";
        public string Trang { get; set; } = "";
        [Range(0, int.MaxValue)]
        public int ThuTu { get; set; }
        public string MaSo { get; set; } = "";
        [Required]
        public string TomTat { get; set; } = "";
        public string LinkDownload { get; set; } = "";
        public int View { get; set; }
        [Required]
        public int DanhMucID { get; set; }
        [Required]
        public int ChuDeID { get; set; }
        public string AnhBia { get; set; } = "";

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhan { get; set; } = DateTime.Today;
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhanLai { get; set; } = DateTime.Today;
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayDuyet { get; set; } = DateTime.Today;

        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        [IgnoreColumn]
        public int[] TacGias { get; set; }
        [IgnoreColumn]
        public int[] TacGiasPostBack { get; set; }

        [IgnoreColumn]
        public DanhMuc DanhMucObj
        {
            get
            {
                return DanhMucManager.Instance.GetItem(this.DanhMucID);
            }
            set
            {
                // do nothing
            }
        }

        [IgnoreColumn]
        public ChuDe ChuDeObj
        {
            get
            {
                return ChuDeManager.Instance.GetItem(this.ChuDeID);
            }
            set
            {
                // do nothing
            }
        }

        [IgnoreColumn]
        public string DSTacGia
        {
            get
            {
                var tacgias = TapChiTacGiaManager.Instance.GetItems().Where(x => x.TapChiID == this.TapChiID).Select(x=>x.TacGiaObj.Ten).ToList();
                return String.Join(", ", tacgias.ToArray());
            }
            set
            {
                // do nothing
            }
        }

        [IgnoreColumn]
        public TacGia[] ListTacGia
        {
            get
            {
                if (this.TacGias==null)
                {
                    this.LoadTacGias();
                }
                var tacgias = TacGiaManager.Instance.GetItems().Where(t => this.TacGias.Contains(t.TacGiaID)).ToList().ToArray();
                return tacgias;
            }
            set
            {

            }
        }
        public void  LoadTacGias() { 
            this.TacGias = TapChiTacGiaManager.Instance.GetItems().Where(t=> t.TapChiID == this.TapChiID).Select(t=>t.TacGiaID).ToList().ToArray();
            /*this.TacGiasNew = TapChiTacGiaManager.Instance.GetItems().Where(t => t.TapChiID == this.TapChiID).ToList().
Select(x => new SelectListItem { Value = x.TacGiaID.ToString(), Text = x.TacGiaID.ToString() }).ToList();*/
        }
        [IgnoreColumn]
        public string[] ListTuKhoa
        {
            get
            {
                
                return this.TuKhoa.Split(',').ToList().ToArray();
            }
            set
            {

            }
        }

        
    }
}
