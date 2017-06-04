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

using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Tapchi.Modules.TapchiDataModel.Models;

namespace Tapchi.Modules.TapchiDataModel.Components
{
    public interface ITheLoaiTinTucManager
    {
        void CreateItem(TheLoaiTinTuc t);
        void DeleteItem(int itemId);
        void DeleteItem(TheLoaiTinTuc t);
        IEnumerable<TheLoaiTinTuc> GetItems();
        TheLoaiTinTuc GetItem(int itemId);
        void UpdateItem(TheLoaiTinTuc t);
    }

    public class TheLoaiTinTucManager : ServiceLocator<ITheLoaiTinTucManager, TheLoaiTinTucManager>, ITheLoaiTinTucManager
    {
        public void CreateItem(TheLoaiTinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TheLoaiTinTuc>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(TheLoaiTinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TheLoaiTinTuc>();
                rep.Delete(t);
            }
        }

        public IEnumerable<TheLoaiTinTuc> GetItems()
        {
            IEnumerable<TheLoaiTinTuc> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TheLoaiTinTuc>();
                t = rep.Get();
                
            }
            return t;
        }

        public TheLoaiTinTuc GetItem(int itemId)
        {
            TheLoaiTinTuc t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TheLoaiTinTuc>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(TheLoaiTinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TheLoaiTinTuc>();
                rep.Update(t);
            }
        }

        protected override System.Func<ITheLoaiTinTucManager> GetFactory()
        {
            return () => new TheLoaiTinTucManager();
        }
    }
}
