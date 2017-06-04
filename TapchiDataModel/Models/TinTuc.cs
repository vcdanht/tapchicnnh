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
    [TableName("TinTuc")]
    //setup the primary key for table
    [PrimaryKey("TinTucID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("TinTuc", CacheItemPriority.Default, 20)]
    public class TinTuc
    {
        public int TinTucID { get; set; } = -1;
        [Required]
        public string TieuDe { get; set; }
        [Required]
        public string TomTat { get; set; }
        [Required]
        public string NoiDung { get; set; }
        public int TheLoaiID { get; set; }
        public int TinNong { get; set; }
        public int HienThi { get; set; }
        public string Image { get; set; } = "";
        public string File { get; set; }
        public string NguonTin { get; set; }
        public string LuuY { get; set; }
        public int View { get; set;  }
        [Range(0, int.MaxValue)]
        public int ThuTu { get; set; }
        public string Tags { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        
        [IgnoreColumn]
        public TheLoaiTinTuc TheLoaiTinTucObj
        {
            get
            {
                return TheLoaiTinTucManager.Instance.GetItem(this.TheLoaiID);
            }
        }
        
    }
}
