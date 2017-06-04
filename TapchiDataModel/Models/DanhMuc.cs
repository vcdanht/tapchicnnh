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
using System.Collections.Generic;
using Tapchi.Modules.TapchiDataModel.Components;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("DanhMuc")]
    //setup the primary key for table
    [PrimaryKey("DanhMucID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("DanhMuc", CacheItemPriority.Default, 20)]
    public class DanhMuc
    {
        public int DanhMucID { get; set; } = -1;
        [Required]
        public string MoTa { get; set; }
        [Required]
        public string Ten { get; set; }
        public string AnhBia { get; set; } = "";
        public int View { get; set; }
        [Range(0, int.MaxValue)]
        public int ThuTu { get; set; }
        public int ParentID { get; set; } = 0;
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }

       
        
        [IgnoreColumn] 
        public string ParentName
        {
            get
            {
                DanhMuc parent = DanhMucManager.Instance.GetItem(this.ParentID);
                return parent != null ? parent.Ten : "";
            }
            set
            {
                // do nothing
            }
        }

        public TapChi[] ListBaiViet()
        {
            return TapChiManager.Instance.GetItems().Where(t => t.DanhMucID == this.DanhMucID).OrderByDescending(t => t.DateCreated).ToList().ToArray();
        }

        public string GetTrimTen()
        {
            return this.Ten.ToUpper().Replace("SỐ", "");
        }
        
        public string GetTrimMoTa()
        {
            int pos = this.MoTa.IndexOf('/');
            if (pos > 0) return this.MoTa.Substring(0, pos);
            return this.MoTa;
        }
    }
}
