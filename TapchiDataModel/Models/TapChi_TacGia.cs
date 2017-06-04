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
using Tapchi.Modules.TapchiDataModel.Components;

namespace Tapchi.Modules.TapchiDataModel.Models
{
    [TableName("TapChi_TacGia")]
    //setup the primary key for table
    [PrimaryKey("TCTGID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("TapChi_TacGia", CacheItemPriority.Default, 20)]
    public class TapChiTacGia
    {
        public int TCTGID { get; set; } = -1;
        public int TapChiID { get; set; }
        public int TacGiaID { get; set; }

        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }

        [IgnoreColumn]
        public TacGia TacGiaObj
        {
            get
            {
                return TacGiaManager.Instance.GetItem(this.TacGiaID);
            }
            set
            {

            }
        }
    }
}
