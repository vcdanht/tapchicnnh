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
    public interface ITinTucManager
    {
        void CreateItem(TinTuc t);
        void DeleteItem(int itemId);
        void DeleteItem(TinTuc t);
        IEnumerable<TinTuc> GetItems();
        TinTuc GetItem(int itemId);
        void UpdateItem(TinTuc t);
    }

    public class TinTucManager : ServiceLocator<ITinTucManager, TinTucManager>, ITinTucManager
    {
        public void CreateItem(TinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TinTuc>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(TinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TinTuc>();
                rep.Delete(t);
            }
        }

        public IEnumerable<TinTuc> GetItems()
        {
            IEnumerable<TinTuc> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TinTuc>();
                t = rep.Get();
                
            }
            return t;
        }

        public TinTuc GetItem(int itemId)
        {
            TinTuc t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TinTuc>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(TinTuc t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<TinTuc>();
                rep.Update(t);
            }
        }

        protected override System.Func<ITinTucManager> GetFactory()
        {
            return () => new TinTucManager();
        }
    }
}
