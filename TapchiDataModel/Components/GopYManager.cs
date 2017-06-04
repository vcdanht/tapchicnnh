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
    public interface IGopYManager
    {
        void CreateItem(GopY t);
        void DeleteItem(int itemId);
        void DeleteItem(GopY t);
        IEnumerable<GopY> GetItems();
        GopY GetItem(int itemId);
        void UpdateItem(GopY t);
    }

    public class GopYManager : ServiceLocator<IGopYManager, GopYManager>, IGopYManager
    {
        public void CreateItem(GopY t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<GopY>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(GopY t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<GopY>();
                rep.Delete(t);
            }
        }

        public IEnumerable<GopY> GetItems()
        {
            IEnumerable<GopY> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<GopY>();
                t = rep.Get();
                
            }
            return t;
        }

        public GopY GetItem(int itemId)
        {
            GopY t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<GopY>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(GopY t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<GopY>();
                rep.Update(t);
            }
        }

        protected override System.Func<IGopYManager> GetFactory()
        {
            return () => new GopYManager();
        }

       
    }
}
