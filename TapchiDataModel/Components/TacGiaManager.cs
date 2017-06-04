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
    public interface ITacGiaManager
    {
        void CreateItem(TacGia t);
        void DeleteItem(int itemId);
        void DeleteItem(TacGia t);
        IEnumerable<TacGia> GetItems();
        TacGia GetItem(int itemId);
        void UpdateItem(TacGia t);
    }

    public class TacGiaManager : ServiceLocator<ITacGiaManager, TacGiaManager>, ITacGiaManager
    {
        public void CreateItem(TacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TacGia>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(TacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TacGia>();
                rep.Delete(t);
            }
        }

        public IEnumerable<TacGia> GetItems()
        {
            IEnumerable<TacGia> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TacGia>();
                t = rep.Get();
            }
            return t;
        }

        public TacGia GetItem(int itemId)
        {
            TacGia t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TacGia>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(TacGia t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TacGia>();
                rep.Update(t);
            }
        }

        protected override System.Func<ITacGiaManager> GetFactory()
        {
            return () => new TacGiaManager();
        }
    }
}
