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

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("TacGia")]
    //setup the primary key for table
    [PrimaryKey("TacGiaID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("TacGia", CacheItemPriority.Default, 20)]
    public class TacGia
    {
        
        public int TacGiaID { get; set; } = -1;
        [Required]
        public string ButDanh { get; set; }
        [Required]
        public string Ten { get; set; }
        public string DiaChi { get; set; } = "";
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string UserCreated { get; set; }
        [Range(0, int.MaxValue)]
        public int ThuTu { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }

        public string GetDisplayString()
        {
            string str = "<b>"+this.Ten+"</b>";
            if (this.DiaChi != "") str += " - " + this.DiaChi;
            if (this.Email != "") str += "; " + this.Email;
            return str;
        }
    }
}
