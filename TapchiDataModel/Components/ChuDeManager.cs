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
    public interface IChuDeManager
    {
        void CreateItem(ChuDe t);
        void DeleteItem(int itemId);
        void DeleteItem(ChuDe t);
        IEnumerable<ChuDe> GetItems();
        ChuDe GetItem(int itemId);
        void UpdateItem(ChuDe t);
    }

    public class ChuDeManager : ServiceLocator<IChuDeManager, ChuDeManager>, IChuDeManager
    {
        public void CreateItem(ChuDe t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChuDe>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(ChuDe t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChuDe>();
                rep.Delete(t);
            }
        }

        public IEnumerable<ChuDe> GetItems()
        {
            IEnumerable<ChuDe> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChuDe>();
                t = rep.Get();
                
            }
            return t;
        }

        public ChuDe GetItem(int itemId)
        {
            ChuDe t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChuDe>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(ChuDe t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChuDe>();
                rep.Update(t);
            }
        }

        protected override System.Func<IChuDeManager> GetFactory()
        {
            return () => new ChuDeManager();
        }
    }
}
