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
    public interface ITapChiManager
    {
        void CreateItem(TapChi t);
        void DeleteItem(int itemId);
        void DeleteItem(TapChi t);
        IEnumerable<TapChi> GetItems();
        TapChi GetItem(int itemId);
        void UpdateItem(TapChi t);
    }

    public class TapChiManager : ServiceLocator<ITapChiManager, TapChiManager>, ITapChiManager
    {
        public void CreateItem(TapChi t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChi>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(TapChi t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChi>();
                rep.Delete(t);
            }
        }

        public IEnumerable<TapChi> GetItems()
        {
            IEnumerable<TapChi> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChi>();
                t = rep.Get();
                
            }
            return t;
        }

        public TapChi GetItem(int itemId)
        {
            TapChi t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChi>();
                t = rep.GetById(itemId);
            }
            if (t!=null) t.LoadTacGias();
            return t;
        }

        public void UpdateItem(TapChi t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TapChi>();
                rep.Update(t);
            }
        }

        protected override System.Func<ITapChiManager> GetFactory()
        {
            return () => new TapChiManager();
        }
    }
}
