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
    public interface ITapChiTacGiaManager
    {
        void CreateItem(TapChiTacGia t);
        void DeleteItem(int itemId);
        void DeleteItem(TapChiTacGia t);
        IEnumerable<TapChiTacGia> GetItems();
        TapChiTacGia GetItem(int itemId);
        void UpdateItem(TapChiTacGia t);
    }

    public class TapChiTacGiaManager : ServiceLocator<ITapChiTacGiaManager, TapChiTacGiaManager>, ITapChiTacGiaManager
    {
        public void CreateItem(TapChiTacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChiTacGia>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(TapChiTacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChiTacGia>();
                rep.Delete(t);
            }
        }

        public IEnumerable<TapChiTacGia> GetItems()
        {
            IEnumerable<TapChiTacGia> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChiTacGia>();
                t = rep.Get();
            }
            return t;
        }

        public TapChiTacGia GetItem(int itemId)
        {
            TapChiTacGia t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChiTacGia>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(TapChiTacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChiTacGia>();
                rep.Update(t);
            }
        }

        protected override System.Func<ITapChiTacGiaManager> GetFactory()
        {
            return () => new TapChiTacGiaManager();
        }
    }
}
