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
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Tapchi.Modules.Tapchi_QuanLyTacGia.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Tapchi_QuanLyTacGia
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<Tapchi_QuanLyTacGiaInfo> colTapchi_QuanLyTacGias = GetTapchi_QuanLyTacGias(ModuleID);
        //if (colTapchi_QuanLyTacGias.Count != 0)
        //{
        //    strXML += "<Tapchi_QuanLyTacGias>";

        //    foreach (Tapchi_QuanLyTacGiaInfo objTapchi_QuanLyTacGia in colTapchi_QuanLyTacGias)
        //    {
        //        strXML += "<Tapchi_QuanLyTacGia>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objTapchi_QuanLyTacGia.Content) + "</content>";
        //        strXML += "</Tapchi_QuanLyTacGia>";
        //    }
        //    strXML += "</Tapchi_QuanLyTacGias>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlTapchi_QuanLyTacGias = DotNetNuke.Common.Globals.GetContent(Content, "Tapchi_QuanLyTacGias");
        //foreach (XmlNode xmlTapchi_QuanLyTacGia in xmlTapchi_QuanLyTacGias.SelectNodes("Tapchi_QuanLyTacGia"))
        //{
        //    Tapchi_QuanLyTacGiaInfo objTapchi_QuanLyTacGia = new Tapchi_QuanLyTacGiaInfo();
        //    objTapchi_QuanLyTacGia.ModuleId = ModuleID;
        //    objTapchi_QuanLyTacGia.Content = xmlTapchi_QuanLyTacGia.SelectSingleNode("content").InnerText;
        //    objTapchi_QuanLyTacGia.CreatedByUser = UserID;
        //    AddTapchi_QuanLyTacGia(objTapchi_QuanLyTacGia);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<Tapchi_QuanLyTacGiaInfo> colTapchi_QuanLyTacGias = GetTapchi_QuanLyTacGias(ModInfo.ModuleID);

        //foreach (Tapchi_QuanLyTacGiaInfo objTapchi_QuanLyTacGia in colTapchi_QuanLyTacGias)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objTapchi_QuanLyTacGia.Content, objTapchi_QuanLyTacGia.CreatedByUser, objTapchi_QuanLyTacGia.CreatedDate, ModInfo.ModuleID, objTapchi_QuanLyTacGia.ItemId.ToString(), objTapchi_QuanLyTacGia.Content, "ItemId=" + objTapchi_QuanLyTacGia.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
