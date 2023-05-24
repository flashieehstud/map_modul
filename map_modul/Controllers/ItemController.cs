/*
' Copyright (c) 2023 kristof pinter
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using GMKN.Dnn.map_modul.Components;
using GMKN.Dnn.map_modul.Models;
using System;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GMKN.Dnn.map_modul.Controllers
{
    [DnnHandleError]
    public class ItemController : DnnController
    {


        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = ItemManager.Instance.GetItems();
            return View(items);
        }


        [HttpGet]
        public String Get(int Id) 
        {
            var item = new Item();
            using (var be = DataContext.Instance())
            {
                var temp = be.GetRepository<Item>();
                var elem = temp.GetById(Id);
                string mapURL = elem.MapLink;
                return mapURL;
            }

            
            
        }
        [HttpPost]
        public void Post(int  boltId, string name, string cim, int openH, int closeH, string mapLink)
        {
            var newItem = new Item();
            using (var context = DataContext.Instance())
            {
                var thisRepo = context.GetRepository<Item>();
                var thisItem = thisRepo.GetById(boltId);
                newItem.Name = name;
                newItem.cim = cim;
                newItem.openH = openH;
                newItem.closeH = closeH;
                newItem.MapLink = mapLink;


                thisRepo.Update(newItem);

            }

            Item ById(int itemID)
            {
                Item t;
                using (IDataContext ctx = DataContext.Instance())
                {
                    var rep = ctx.GetRepository<Item>();
                    t = rep.GetById(itemID);
                }
                return t;
            }
            

        }
    }
}