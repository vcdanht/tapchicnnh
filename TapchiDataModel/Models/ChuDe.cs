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
using System.ComponentModel.DataAnnotations.Schema;
using Tapchi.Modules.TapchiDataModel.Components;
using System.ComponentModel.DataAnnotations;

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("ChuDe")]
    //setup the primary key for table
    [PrimaryKey("ChuDeID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("ChuDe", CacheItemPriority.Default, 20)]
    public class ChuDe
    {
        public int ChuDeID { get; set; } = -1;
        [Required]
        public string MoTa { get; set; }
        [Required]
        public string Ten { get; set; }
        [Range(0, int.MaxValue)]
        public int ThuTu { get; set; }
        
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
       
        
    }
}
