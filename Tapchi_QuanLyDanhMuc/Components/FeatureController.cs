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

namespace Tapchi.Modules.Tapchi_QuanLyDanhMuc.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Tapchi_QuanLyDanhMuc
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

        //List<Tapchi_QuanLyDanhMucInfo> colTapchi_QuanLyDanhMucs = GetTapchi_QuanLyDanhMucs(ModuleID);
        //if (colTapchi_QuanLyDanhMucs.Count != 0)
        //{
        //    strXML += "<Tapchi_QuanLyDanhMucs>";

        //    foreach (Tapchi_QuanLyDanhMucInfo objTapchi_QuanLyDanhMuc in colTapchi_QuanLyDanhMucs)
        //    {
        //        strXML += "<Tapchi_QuanLyDanhMuc>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objTapchi_QuanLyDanhMuc.Content) + "</content>";
        //        strXML += "</Tapchi_QuanLyDanhMuc>";
        //    }
        //    strXML += "</Tapchi_QuanLyDanhMucs>";
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
        //XmlNode xmlTapchi_QuanLyDanhMucs = DotNetNuke.Common.Globals.GetContent(Content, "Tapchi_QuanLyDanhMucs");
        //foreach (XmlNode xmlTapchi_QuanLyDanhMuc in xmlTapchi_QuanLyDanhMucs.SelectNodes("Tapchi_QuanLyDanhMuc"))
        //{
        //    Tapchi_QuanLyDanhMucInfo objTapchi_QuanLyDanhMuc = new Tapchi_QuanLyDanhMucInfo();
        //    objTapchi_QuanLyDanhMuc.ModuleId = ModuleID;
        //    objTapchi_QuanLyDanhMuc.Content = xmlTapchi_QuanLyDanhMuc.SelectSingleNode("content").InnerText;
        //    objTapchi_QuanLyDanhMuc.CreatedByUser = UserID;
        //    AddTapchi_QuanLyDanhMuc(objTapchi_QuanLyDanhMuc);
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

        //List<Tapchi_QuanLyDanhMucInfo> colTapchi_QuanLyDanhMucs = GetTapchi_QuanLyDanhMucs(ModInfo.ModuleID);

        //foreach (Tapchi_QuanLyDanhMucInfo objTapchi_QuanLyDanhMuc in colTapchi_QuanLyDanhMucs)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objTapchi_QuanLyDanhMuc.Content, objTapchi_QuanLyDanhMuc.CreatedByUser, objTapchi_QuanLyDanhMuc.CreatedDate, ModInfo.ModuleID, objTapchi_QuanLyDanhMuc.ItemId.ToString(), objTapchi_QuanLyDanhMuc.Content, "ItemId=" + objTapchi_QuanLyDanhMuc.ItemId.ToString());
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
