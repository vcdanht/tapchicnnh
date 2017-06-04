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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TapChi.Modules.TapChi_DSDanhMuc.Models
{
    public class Settings
    {
        public class SettingType
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public IEnumerable<SettingType> SettingTypeOptions =
            new List<SettingType>
            {
            new SettingType {Id = 0, Value = "Nội dung"},
            new SettingType {Id = 1, Value = "Chuyên mục đã xuất bản"},           
            };

        [DisplayName("Display Type")]
        public int DisplayType { get; set; } = 0;
    }
}