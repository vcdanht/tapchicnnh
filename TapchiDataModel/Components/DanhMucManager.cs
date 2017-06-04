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
using System.Linq;

namespace Tapchi.Modules.TapchiDataModel.Components
{
    public interface IDanhMucManager
    {
        void CreateItem(DanhMuc t);
        void DeleteItem(int itemId);
        void DeleteItem(DanhMuc t);
        IEnumerable<DanhMuc> GetItems();
        IEnumerable<DanhMuc> GetParentItems();
        IEnumerable<DanhMuc> GetChildItems();
        DanhMuc GetItem(int itemId);
       
        void UpdateItem(DanhMuc t);
    }

    public class DanhMucManager : ServiceLocator<IDanhMucManager, DanhMucManager>, IDanhMucManager
    {
        public void CreateItem(DanhMuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(DanhMuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                rep.Delete(t);
            }
        }

        public IEnumerable<DanhMuc> GetItems()
        {
            IEnumerable<DanhMuc> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                t = rep.Get();               
            }
            return t;
        }

        public IEnumerable<DanhMuc> GetParentItems()
        {
            IEnumerable<DanhMuc> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                t = rep.Find("WHERE ParentID=0");

            }
            return t;
        }

        public IEnumerable<DanhMuc> GetChildItems()
        {
            IEnumerable<DanhMuc> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                t = rep.Find("WHERE ParentID > 0");

            }
            return t;
        }

        public DanhMuc GetItem(int itemId)
        {
            DanhMuc t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                t = rep.GetById(itemId);
            }
            return t;
        }


        public void UpdateItem(DanhMuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DanhMuc>();
                rep.Update(t);
            }
        }

        protected override System.Func<IDanhMucManager> GetFactory()
        {
            return () => new DanhMucManager();
        }
    }
}
