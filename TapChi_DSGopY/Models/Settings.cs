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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TapChi.Modules.TapChi_DSGopY.Models
{
    public class Settings
    {
        public class SettingGopY
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public IEnumerable<SettingGopY> SettingGopYOptions =
            new List<SettingGopY>
            {
            new SettingGopY {Id = 0, Value = "New"},
            new SettingGopY {Id = 1, Value = "List"},

            };
        [DisplayName("Display Type")]
        public int DisplayType { get; set; }
        public string AdminEmail { get; set; }
    }
    
    
}