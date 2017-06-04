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
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("DatBao")]
    //setup the primary key for table
    [PrimaryKey("DatBaoId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("DatBao", CacheItemPriority.Default, 20)]
    
    public class DatBao
    {
        public class KyHanOption
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public IEnumerable<KyHanOption> KyHanOptions =
            new List<KyHanOption>
            {
            new KyHanOption {Id = 3, Value = "3 tháng"},
            new KyHanOption {Id = 4, Value = "4 tháng"},
            new KyHanOption {Id = 5, Value = "5 tháng"},
            new KyHanOption {Id = 5, Value = "12 tháng"}
            };

        public class StatusOption
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public IEnumerable<StatusOption> StatusOptions = new List<StatusOption>
        {
            new StatusOption{Id = 0, Value="Mới"},
            new StatusOption{Id = 1 , Value="Đã thanh toán"},
            new StatusOption{Id = 2 , Value="Đã hoàn thành"}
        };

        
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int DatBaoId { get; set; } = -1;
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        [Required]
        public string Ten { get; set; }


        public int GioiTinh { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string DonViCongtac { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public string DiaChi { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public string DienThoai { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>
        //[Required]
        public int KyHan { get; set; }

       
        public string NoiDung { get; set; }
    
        public string HinhThucThanhToan { get; set; }

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        ///<summary>
        /// The date the object was updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; } = DateTime.UtcNow;

        public int Status { get; set; } = 0;

        //public string USER_CAPTCHA { get; set; }
        //public string USER_CAPTCHA_TOKEN { get; set; }
        public string LastModifiedUser { get; set; }

        [IgnoreColumn]
        public string StatusText 
        {
            get {
                return StatusOptions.Where(m => m.Id == this.Status).Select(m => m.Value).ToList().First();
            }
            set { }
            
        }
        [IgnoreColumn]
        public string KyHanText
        {
            get
            {
                return KyHanOptions.Where(m => m.Id == this.KyHan).Select(m => m.Value).ToList().First();
            }
            set { }

        }
    }
   
}
