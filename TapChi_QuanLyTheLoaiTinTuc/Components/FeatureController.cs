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

namespace TapChi.Modules.TapChi_QuanLyTheLoaiTinTuc.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for TapChi_QuanLyTheLoaiTinTuc
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

        //List<TapChi_QuanLyTheLoaiTinTucInfo> colTapChi_QuanLyTheLoaiTinTucs = GetTapChi_QuanLyTheLoaiTinTucs(ModuleID);
        //if (colTapChi_QuanLyTheLoaiTinTucs.Count != 0)
        //{
        //    strXML += "<TapChi_QuanLyTheLoaiTinTucs>";

        //    foreach (TapChi_QuanLyTheLoaiTinTucInfo objTapChi_QuanLyTheLoaiTinTuc in colTapChi_QuanLyTheLoaiTinTucs)
        //    {
        //        strXML += "<TapChi_QuanLyTheLoaiTinTuc>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objTapChi_QuanLyTheLoaiTinTuc.Content) + "</content>";
        //        strXML += "</TapChi_QuanLyTheLoaiTinTuc>";
        //    }
        //    strXML += "</TapChi_QuanLyTheLoaiTinTucs>";
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
        //XmlNode xmlTapChi_QuanLyTheLoaiTinTucs = DotNetNuke.Common.Globals.GetContent(Content, "TapChi_QuanLyTheLoaiTinTucs");
        //foreach (XmlNode xmlTapChi_QuanLyTheLoaiTinTuc in xmlTapChi_QuanLyTheLoaiTinTucs.SelectNodes("TapChi_QuanLyTheLoaiTinTuc"))
        //{
        //    TapChi_QuanLyTheLoaiTinTucInfo objTapChi_QuanLyTheLoaiTinTuc = new TapChi_QuanLyTheLoaiTinTucInfo();
        //    objTapChi_QuanLyTheLoaiTinTuc.ModuleId = ModuleID;
        //    objTapChi_QuanLyTheLoaiTinTuc.Content = xmlTapChi_QuanLyTheLoaiTinTuc.SelectSingleNode("content").InnerText;
        //    objTapChi_QuanLyTheLoaiTinTuc.CreatedByUser = UserID;
        //    AddTapChi_QuanLyTheLoaiTinTuc(objTapChi_QuanLyTheLoaiTinTuc);
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

        //List<TapChi_QuanLyTheLoaiTinTucInfo> colTapChi_QuanLyTheLoaiTinTucs = GetTapChi_QuanLyTheLoaiTinTucs(ModInfo.ModuleID);

        //foreach (TapChi_QuanLyTheLoaiTinTucInfo objTapChi_QuanLyTheLoaiTinTuc in colTapChi_QuanLyTheLoaiTinTucs)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objTapChi_QuanLyTheLoaiTinTuc.Content, objTapChi_QuanLyTheLoaiTinTuc.CreatedByUser, objTapChi_QuanLyTheLoaiTinTuc.CreatedDate, ModInfo.ModuleID, objTapChi_QuanLyTheLoaiTinTuc.ItemId.ToString(), objTapChi_QuanLyTheLoaiTinTuc.Content, "ItemId=" + objTapChi_QuanLyTheLoaiTinTuc.ItemId.ToString());
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
