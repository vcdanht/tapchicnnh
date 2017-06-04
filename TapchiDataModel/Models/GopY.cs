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

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("GopY")]
    //setup the primary key for table
    [PrimaryKey("GopYId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("GopY", CacheItemPriority.Default, 20)]
    
    public class GopY
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int GopYId { get; set; } = -1;
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        [Required]
        public string Ten { get; set; }

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
        [Required]
        public string TieuDe { get; set; }
        [Required]
        public string NoiDung { get; set; }
    

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        ///<summary>
        /// The date the object was updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; } = DateTime.UtcNow;

        public int Status { get; set; } = 0;
    }
}
