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
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Tapchi.Modules.TapchiDataModel.Models;

namespace Tapchi.Modules.TapchiDataModel.Components
{
    public interface IDatBaoManager
    {
        void CreateItem(DatBao t);
        void DeleteItem(int itemId);
        void DeleteItem(DatBao t);
        IEnumerable<DatBao> GetItems();
        DatBao GetItem(int itemId);
        void UpdateItem(DatBao t);
    }

    public class DatBaoManager : ServiceLocator<IDatBaoManager, DatBaoManager>, IDatBaoManager
    {
        public void CreateItem(DatBao t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DatBao>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(DatBao t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DatBao>();
                rep.Delete(t);
            }
        }

        public IEnumerable<DatBao> GetItems()
        {
            IEnumerable<DatBao> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DatBao>();
                t = rep.Get();
                
            }
            return t;
        }

        public DatBao GetItem(int itemId)
        {
            DatBao t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DatBao>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(DatBao t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DatBao>();
                rep.Update(t);
            }
        }

        protected override System.Func<IDatBaoManager> GetFactory()
        {
            return () => new DatBaoManager();
        }

       
    }
}
