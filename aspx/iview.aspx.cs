using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using System.IO.Compression;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Threading;

public partial class iview : System.Web.UI.Page
{
    #region Variables
    public IviewData objIview;
    public IviewParams objParams;
    public Custom customObj = Custom.Instance;
    string _xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
    Util.Util util;
    LogFile.Log logobj = new LogFile.Log();
    ASB.WebService webService = new ASB.WebService();
    ASBExt.WebServiceExt objWebServiceExt = new ASBExt.WebServiceExt();
    string gridPageSize = "";
    static JObject jsonForGrid = new JObject();
    string strGlobalVar = string.Empty;
    public string tst_Scripts = string.Empty;
    public string direction = "ltr";
    public string btn_direction = "end";
    public string bread_direction = "start";
    public bool isSqlFld = false;
    public ArrayList arrFillList = new ArrayList();
    public ArrayList arrFillListDataAttr = new ArrayList();
    public bool isSelectWithMultiColumn = false;
    public string isSelectParamsString = string.Empty;
    public string resXhtm;
    public bool HasCKB = false;
    public bool paramsExist;
    public string strFillDepPName = string.Empty;
    string pXml = string.Empty;
    string clientCulture = null;
    public string lblHeading = string.Empty;
    public bool IsParamsVisible = false;
    bool directiview = false;
    bool callParamPlusStructure = false;
    bool isCache = false;
    // create arrays for Header Names and width
    ArrayList headName = new ArrayList();
    ArrayList colWidth = new ArrayList();
    ArrayList colType = new ArrayList();
    ArrayList colApplyComma = new ArrayList();
    ArrayList colHide = new ArrayList();
    ArrayList colFld = new ArrayList();
    ArrayList colDec = new ArrayList();
    ArrayList colHlink = new ArrayList();
    ArrayList colHlinkPop = new ArrayList();
    ArrayList colRefreshParent = new ArrayList();
    IDictionary<string, string> actRefreshParent = new Dictionary<string, string>();
    ArrayList colHlinktype = new ArrayList();
    ArrayList colMap = new ArrayList();
    ArrayList colHAction = new ArrayList();
    ArrayList colHlink_c = new ArrayList();
    ArrayList colHlinktype_c = new ArrayList();
    ArrayList colMap_c = new ArrayList();
    ArrayList colHAction_c = new ArrayList();
    ArrayList colAlign = new ArrayList();
    ArrayList colNoPrint = new ArrayList();

    ArrayList colNoRepeat = new ArrayList();
    ArrayList colZeroOff = new ArrayList();


    //Arrays for toolbar button alignment
    ArrayList arrButtons = new ArrayList();
    ArrayList arrBtnLeftVals = new ArrayList();
    ArrayList arrSortedButtons = new ArrayList();
    ArrayList arrTempBtnLeft = new ArrayList();
    ArrayList pivotGroupHeaderNames = new ArrayList();
    ArrayList pivotStartCol = new ArrayList();
    ArrayList pivotEndCol = new ArrayList();
    ArrayList ivhead = new ArrayList();
    ArrayList actionBtns = new ArrayList();
    ArrayList iviewParams = new ArrayList();
    ArrayList iviewParamValues = new ArrayList();
    ArrayList submerge = new ArrayList();
    ArrayList submergecol = new ArrayList();
    ArrayList showHiddenCols = new ArrayList();
    //Arrays for Iview Download Attachment.
    //ArrayList PathIndexes = new ArrayList();

    IDictionary<string, string> paramss = new Dictionary<string, string>();
    public static StringBuilder paramssBuilder = new StringBuilder();

    int ivAttachRid = -1;
    int ivAttachTransid = -1;
    int ivAttachRowNo = -1;
    int ivAttExt = -1;

    ArrayList FilesIndexes = new ArrayList();
    ArrayList arrHdnColMyViews = new ArrayList();

    public DataTable dtFilterConds = new DataTable();
    public string ColsToFilter = string.Empty;
    public string iviewcap = string.Empty;

    //TreeMethod
    public int root_class_index = -1;
    public int root_account_index = -1;
    public int root_atype_index = -1;
    public int iframe_index = -1;

    public string @params = string.Empty;
    public string iName = string.Empty;
    public string ActBut = string.Empty;
    public string defaultBut = string.Empty;
    //public string TaskBut = string.Empty;
    public string actionButvs = string.Empty;
    public string enableBackForwButton = string.Empty;
    public string noRec = string.Empty;
    public string cac_order = string.Empty;
    public string cac_pivot = string.Empty;
    public string srNoColumnName = string.Empty;
    int totalRows = 0;
    int directDbtotalRows = 0;
    int dataRows = 0;
    public string tid = string.Empty;
    public StringBuilder tskList = new StringBuilder();
    public string AxRole = string.Empty;
    public string proj = string.Empty;
    public string sid = string.Empty;
    public string user = string.Empty;
    public string language = string.Empty;
    public string errLog;
    public int topwidth;
    private string toolBarHtml = string.Empty;
    public dynamic toolbarJSON = new JObject();
    bool buttonsCreated = false;
    int checkcnt = 0;
    string fileName;
    //int tabIndex = 0;
    public bool isCallWS = false;
    string pivothead = string.Empty;
    bool onlyParams = false;
    bool hideChkBox = false;
    bool incrementPivot = false;

    public StringBuilder paramHtml = new StringBuilder();
    public StringBuilder strJsArrays = new StringBuilder();
    public StringBuilder strParamDetails = new StringBuilder();
    public StringBuilder strBreadCrumb = new StringBuilder();
    public string breadCrumb = string.Empty;
    public StringBuilder filterCondDispText = new StringBuilder();
    public StringBuilder filterCondDispFullText = new StringBuilder();

    public static StringBuilder sortingMyView = new StringBuilder();
    public static StringBuilder hiddenColMyView = new StringBuilder();
    public static StringBuilder filterColMyView = new StringBuilder();


    public static StringBuilder sortingMyView1 = new StringBuilder();
    public static StringBuilder hiddenColMyView1 = new StringBuilder();
    public static StringBuilder filterColMyView1 = new StringBuilder();
    public static string paramValueMyView = string.Empty;

    public static ArrayList arrMyViews = new ArrayList();


    public string strBreadCrumbBtns = string.Empty;
    string IsSqlPagination = "false";
    Boolean validateParamOnGo = false;
    int noOfPages = 0;
    int currentPageNo = 0;
    string ivCaption = string.Empty;
    //private string defaultDateStr = "dd/mm/yyyy";
    DataTable navigationInfo = new DataTable();
    private bool IsIviewPop = false;
    private bool AxSplit = false;
    public string hidetoolbar = "false";
    public string hideParameters = "false";

    //Below variables are used for caching the iview pages for sqlpagination
    XmlDocument xmlParamDoc = new XmlDocument();
    bool isParamSame = true;
    bool isPageExist = false;
    public string loadString = string.Empty;
    public int gvWidth = 0;
    public string axp_refresh = "false";
    public double webTime2;
    public static StringBuilder strTimetaken = new StringBuilder();
    int displayRowCnt = 20;
    string Ivkey = string.Empty;
    string IvParamKey = string.Empty;
    public string enableFilter = "false";
    public bool isShowHideColExist = false;
    public string refreshTime = string.Empty;

    string AsbTime = string.Empty;
    public bool isCloudApp = false;
    public string schemaName = string.Empty;

    public bool hasBuildAccess = false;

    ////if iview web service will return row count or not
    public bool getIviewRowCount = false;

    public string axpResp = "false";
    public string langType = "en";
    public string PrintTitle = "";
    public string paramsCache = String.Empty;
    private bool isFromPopup = false;

    public bool globalGetAjaxIviewData = true;
    public bool getAjaxIviewData = true;
    public bool isMobile = false;

    public string redisLoadKey = string.Empty;
    public string redisLoadType = string.Empty;

    public bool requestJSON = true;

    public string notifyTimeout = string.Empty;

    public string iviewButtonStyle = "classic";

    public string inputControlType = "border";

    dynamic flKey = null;

    ExecTrace ObjExecTr = ExecTrace.Instance;
    public string requestProcess_logtime = string.Empty;
    public string serverprocesstime = string.Empty;

    #endregion

    protected override void InitializeCulture()
    {
        if (Session["language"] != null)
        {
            util = new Util.Util();
            string dirLang = string.Empty;
            dirLang = util.SetCulture(Session["language"].ToString().ToUpper());
            if (!string.IsNullOrEmpty(dirLang))
            {
                direction = dirLang.Split('-')[0];
                langType = dirLang.Split('-')[1];
            }
        }
    }
    /// Onload get the construct params if present else getiview data and display.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["hdnbElapsTime"] != null)
        {
            string browserElapsTime = Request.QueryString["hdnbElapsTime"] != null ? Request.QueryString["hdnbElapsTime"] : "0";
            requestProcess_logtime += ObjExecTr.WireElapsTime(browserElapsTime);
        }
        else if (IsPostBack && hdnbElapsTimeGo.Value != "")
        {
            ObjExecTr.SetCurrentTime();
        }
        if (Request.Form["reqProc_logtime"] != null)
            requestProcess_logtime += Request.Form["reqProc_logtime"];
        try
        {
            //ScriptManager.ScriptResourceMapping.AddDefinition("smartviews", new ScriptResourceDefinition
            //{
            //    Path = "~/Js/smartviews"
            //});
            util = new Util.Util();
            util.IsValidSession();
            //util.IsValidAxpertSession();
            ResetSessionTime();
            if (HttpContext.Current.Session["AxPrintTitle"] != null)
                PrintTitle = HttpContext.Current.Session["AxPrintTitle"].ToString();
            if (HttpContext.Current.Session["MobileView"] != null && HttpContext.Current.Session["MobileView"].ToString().ToLower() == "true")
                isMobile = true;
            if (Request.UrlReferrer != null)
            {
                //if (!(Request.UrlReferrer.AbsolutePath.ToLower().Contains("main.aspx") || Request.UrlReferrer.AbsolutePath.ToLower().Contains("iview.aspx") || Request.UrlReferrer.AbsolutePath.ToLower().Contains("ivtoivload.aspx") || Request.UrlReferrer.AbsolutePath.ToLower().Contains("listiview.aspx") || Request.UrlReferrer.AbsolutePath.ToLower().Contains("tstruct.aspx") || Request.UrlReferrer.AbsolutePath.Contains("allocationgrid.aspx")))
                //    Response.Redirect("../CusError/AxCustomError.aspx");
            }
            DateTime asStart = DateTime.Now;
            //HtmlLink Link = FindControl("generic") as HtmlLink;
            //Link.Href = util.toggleTheme();
            if (Session["project"] == null || Session["axApps"] == null || Convert.ToString(Session["project"]) == string.Empty)
            {
                SessExpires();
                return;
            }
            else
            {
                if (util.IsValidQueryString(Request.RawUrl, true) == false)
                {
                    requestProcess_logtime += "Server - " + Constants.INVALIDURL + " ♦ ";
                    HttpContext.Current.Response.Redirect(util.ERRPATH + Constants.INVALIDURL + "*♠*" + requestProcess_logtime);
                }
                if (Session["IsFromChildWindow"] != null && Session["IsFromChildWindow"].ToString() == "true")
                    isFromPopup = true;

                //if (!util.licencedValidSessionCheck())
                //{
                //    HttpContext.Current.Response.Redirect(util.ERRPATH + Constants.SESSIONEXPMSG, false);
                //    return;
                //}
                getIviewRowCount = false; //HttpContext.Current.Session["AxGetIviewRowCount"] != null ? Convert.ToBoolean(HttpContext.Current.Session["AxGetIviewRowCount"]) : false;
                //if (Request.QueryString["tstcaption"] == null)
                //{
                //    Util.Util.DeletedraftRediskeys(Request.QueryString["ivname"]);
                //}

                if (!(string.IsNullOrEmpty(Session["language"].ToString())))
                {
                    language = Session["language"].ToString();
                }
                else
                {
                    language = string.Empty;
                }

                if (HttpContext.Current.Session["dbuser"] != null)
                {
                    schemaName = HttpContext.Current.Session["dbuser"].ToString();
                }

                //redisLoadKey = Request.QueryString["redisLoadKey"];
                if (Request.Form.Count > 0 && Request.Form["redisLoadKey"] != null)
                {
                    redisLoadKey = Request.Form["redisLoadKey"];
                }

                if (!IsPostBack)
                {
                    iName = Request.QueryString["ivname"];

                    logobj.CreateLog("Loading iview.aspx", sid, "openiview-dev-" + iName, "new");
                    
                    requestJSON = GetRequestType();

                    notifyTimeout = util.GetAdvConfigs("notification time interval");

                    if (flKey == null)
                    {
                        flKey = GenerateGlobalSmartViewsKey(iName, Request.QueryString["tstcaption"] != null);
                    }

                    #region New Iview Caching logic
                    if (!requestJSON)
                    {
                        objIview = new IviewData();
                        objParams = new IviewParams();
                    }
                    else
                    {
                        user = Session["user"].ToString();
                        user = util.CheckSpecialChars(user);

                        objIview = GetGlobalSmartViews(iName, flKey);
                        if (objIview == null)
                        {
                            objIview = new IviewData();
                        }
                        if (objParams == null)
                        {
                            objParams = new IviewParams();
                        }
                        //objIview = CheckForIviewData(iName);
                    }

                    #endregion



                    objIview.getIviewRowCount = getIviewRowCount;
                    //objIview.IsParameterExist = false;
                    //objIview.IsPerfXml = false;
                    objIview.requestJSON = requestJSON;
                    objIview.notifyTimeout = notifyTimeout;
                    strTimetaken = new StringBuilder();
                    arrMyViews.Clear();
                    CleardtFilterCond();
                    GetGlobalVariables();
                    if (!IsIviewPop)
                    {
                        if (!AxSplit)
                            util.DeleteTstIvObject(iName);
                        ClearNavigationData();
                        util.RemovelvListPageLoad();
                    }
                    //IncludeCustomLinks();

                    //Call to AxpStructConfig

                    if (util.BreadCrumb)
                    {
                        GetBreadCrumb();
                    }

                    GetAxpStructConfig();

                    try
                    {
                        if (objIview.RetainIviewParams) {
                            loadString = webService.GetIviewNavigationData(iName);
                        }

                        DateTime starttime = DateTime.Now;
                        if (!objIview.requestJSON)
                        {
                            GetIviewStructure(iName);
                        }
                        else
                        {
                            GetIviewStructureNew(iName);
                        }
                        if (objIview.StructureXml != string.Empty && objIview.StructureXml != "false" && objIview.StructureXml != "")
                        {

                            GenericRedisFunction(Title, objIview.IName, objIview.StructureXml, schemaName);

                        }


                        double totTime = DateTime.Now.Subtract(starttime).Milliseconds;

                    }
                    catch (Exception ex)
                    {
                        //Response.Redirect(util.ERRPATH + ex.Message);
                    }

                    IncludeCustomLinksNew(objIview);

                    hdnParamChngd.Value = "false";
                    //Session["paramHtml" + iName] = paramHtml;
                    //Session["iviewJsArrays" + iName] = strJsArrays;
                    cac_order = sid + "order";
                    cac_pivot = sid + iName + "pivot";
                    if ((Session["backForwBtnPressed"] != null && !Convert.ToBoolean(Session["backForwBtnPressed"])) && Request.QueryString["homeicon"] == null)
                    {
                        if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.IndexOf("ivtoivload.aspx") == -1 && Request.RequestType != "POST")
                        {

                            string strUrlParams = hdnparamValues.Value;

                            strUrlParams = strUrlParams.Replace("~", "=");
                            strUrlParams = strUrlParams.Replace("¿", "&");
                            util.UpdateNavigateUrl("ivtoivload.aspx?ivname=" + iName + "&" + strUrlParams);

                        }
                    }
                    //remove key from querystring
                    if (Request.QueryString["homeicon"] != null)
                    {
                        System.Reflection.PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        isreadonly.SetValue(this.Request.QueryString, false, null);
                        this.Request.QueryString.Remove("homeicon");
                    }
                    Session["backForwBtnPressed"] = false;
                    UpdateRecordsPerPage();
                    enableBackForwButton = "<script type=\'text/javascript\' >var axTheme='" + Session["themeColor"].ToString() + "';</script>";
                    //Session["FilteredData"] = null;
                    divFilterCond.InnerHtml = string.Empty;
                    //refreshFilter.Visible = false;
                    //if (objIview.IsFilterEnabled)
                    //    GetMyViews();
                    Ivkey = util.GetIviewId(iName);
                    IvParamKey = Ivkey + "_param";
                    hdnKey.Value = Ivkey;
                    if (Session["tstivobjkey"] != null && Session["tstivobjkey"].ToString() != string.Empty)
                        Session["tstivobjkey"] = Session["tstivobjkey"].ToString() + "," + Ivkey + "," + IvParamKey;
                    else
                        Session["tstivobjkey"] = Ivkey + "," + IvParamKey;

                    Session[Ivkey] = objIview;
                    Session[Ivkey + "_param"] = objParams;
                    //setIviewSessionCacheObject(Ivkey, objIview);
                    arrHdnColMyViews.Clear();
                    showHiddenCols.Clear();

                    hdnToggleDimmer.Value = "false";

                }
                else
                {
                    Ivkey = hdnKey.Value;
                    objIview = (IviewData)Session[Ivkey];
                    objParams = (IviewParams)Session[Ivkey + "_param"];
                    requestJSON = objIview.requestJSON;
                    notifyTimeout = objIview.notifyTimeout;
                    //objIview.getIviewRowCount = getIviewRowCount;
                    //objIview.iviewDataWSRows = iviewDataWSRows;
                    SetGlobalVariables();
                    Session["AxFromHypLink"] = objIview.FromHyperLink;
                    if ((Session["backForwBtnPressed"] != null && !Convert.ToBoolean(Session["backForwBtnPressed"])) && Request.QueryString["homeicon"] == null)
                    {
                        if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.IndexOf("ivtoivload.aspx") == -1 && Request.RequestType != "POST")
                        {
                            string strUrlParams = hdnparamValues.Value;
                            if (strUrlParams != string.Empty)
                            {
                                strUrlParams = strUrlParams.Replace("~", "=");
                                strUrlParams = strUrlParams.Replace("¿", "&");
                                util.UpdateNavigateUrl("ivtoivload.aspx?ivname=" + iName + "&" + strUrlParams);
                            }
                            util.UpdateNavigateUrl(HttpContext.Current.Request.Url.AbsoluteUri);
                        }
                    }

                    CheckCustomIview();

                    if (hdnIvRefresh.Value == "true")
                    {
                        isPageExist = false;
                        hdnIvRefresh.Value = "false";
                    }

                    //In postback event the sub heading will be reconstructed


                    if (objIview.IvCaption != null)
                    {
                        ArrayList arrIvCap = (ArrayList)objIview.IvCaption;
                        ConstructSubHeading(arrIvCap);
                    }
                    if (objIview.CurrentPageNo != null)
                        Session["currentPageNo" + iName] = objIview.CurrentPageNo;
                    if (gridPageSize == "" && objIview.GrdPageSize != null)
                        gridPageSize = objIview.GrdPageSize;

                    if (!string.IsNullOrEmpty(hdnAct.Value))
                    {
                        //ConstructToolbar();
                        hdnAct.Value = string.Empty;
                    }
                    else
                    {
                        //ConstructToolbar();
                        fileName = "openiview-" + iName;
                        logobj.CreateLog(string.Empty, sid, fileName, string.Empty);
                        errLog = logobj.CreateLog("Loading iview.aspx after post back (get and load iview data)", sid, fileName, string.Empty);
                        if (hdnGo.Value == "refreshparams" || hdnGo.Value == "updateCache")
                        {
                            if (iName != "inmemdb")
                            {
                                GetParams();
                            }
                        }
                        else if (hdnGo.Value == "Go" || hdnGo.Value == "clear")
                        {
                            //ShowHideFilterDiv(true);
                        }
                        if (hdnGo.Value == "Go" || hdnGo.Value == "clear" || hdnGo.Value == "TSSave")
                        {
                            logobj.CreateLog("Get and Load Iviewdata", sid, fileName, string.Empty);
                            DateTime asStart2 = DateTime.Now;
                            GetIviewData();
                            webTime2 = DateTime.Now.Subtract(asStart2).TotalMilliseconds;
                            strTimetaken.Append("GetIview-" + webTime2.ToString() + " ");
                            GridView2Wrapper.Visible = true;
                            if (objIview.AxpIsAutoSplit == "true")
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "assocateIframe", "callParentNew('assocateIframe(true)', 'function');", true);
                            dvFilteredRowCount.Visible = false;
                            dtFilterConds.Rows.Clear();
                            Session["dtFilterConds"] = dtFilterConds;
                            divFilterCond.InnerHtml = string.Empty;
                            //refreshFilter.Visible = false;

                        }
                    }

                    string strtemp = hdnparamValues.Value;
                    strtemp = strtemp.Replace("'", "quot;");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(), "ParamValues", "<script>SetParamValues('" + strtemp + "');evalParamExprHandler();AxWaitCursor(true);ShowDimmer(true);</script>", false);

                    //LoadMyViewFromMenu(objIview.MyViewName);

                    hdnToggleDimmer.Value = "false";
                    Session[Ivkey] = objIview;
                    Session[Ivkey + "_param"] = objParams;

                }

                if (objIview.requestJSON && !objIview.isObjFromCache && !objParams.ForceDisableCache)
                {
                    if (flKey == null)
                    {
                        flKey = GenerateGlobalSmartViewsKey(iName, Request.QueryString["tstcaption"] != null);
                    }

                    SetGlobalSmartViews(objIview, iName, flKey);
                }

                setPageDirection();
                IsSqlPagination = IsSqlPagination.ToLower();
                ConstructBreadCrumb();
                if (string.IsNullOrEmpty(paramHtml.ToString()))
                {
                    if (hdnParamHtml.Value != "")
                        paramHtml.Append(hdnParamHtml.Value);
                    else
                        paramHtml.Append(objParams.ParamHtml);
                }
                if (string.IsNullOrEmpty(strJsArrays.ToString()) | strJsArrays.ToString() == "<script type=\"text/javascript\">")
                {
                    strJsArrays.Append(objParams.strJsArrays);
                }
                logobj.CreateLog("End Time : " + DateTime.Now.ToString(), sid, fileName, string.Empty);
                if (objIview.IsDirectDBcall)
                {
                    getAjaxIviewData = false;
                }
                else if (globalGetAjaxIviewData)
                {
                    getAjaxIviewData = true;
                }
                else
                {
                    getAjaxIviewData = false;
                }
                enableBackForwButton = "<script type=\'text/javascript\' > enableBackButton='" + Convert.ToBoolean(Session["enableBackButton"]) + "';" + " enableForwardButton='" + Convert.ToBoolean(Session["enableForwardButton"]) + "'; isSqlPagination='" + IsSqlPagination + "';var axTheme='" + Session["themeColor"].ToString() + "';var paramsExist=" + paramsExist.ToString().ToLower() + ";var isParamVisible='" + IsParamsVisible + "';var isFilterEnabled='" + objParams.IsFilterEnabled.ToString() + "';</script>";
                if (ConfigurationManager.AppSettings["isCloudApp"] != null)
                {
                    isCloudApp = Convert.ToBoolean(ConfigurationManager.AppSettings["isCloudApp"].ToString());
                }

                //iviewButtonStyle = objIview.iviewButtonStyle; // Original code is commented, until old toolbar is enahanced with bootstrap 5. 
                iviewButtonStyle = objIview.iviewButtonStyle == "old" ? "classic" : objIview.iviewButtonStyle;

                inputControlType = objIview.inputControlType;

                string toolbarJsonString = toolbarJSON.ToString().Replace("\r\n", "");

                Page.ClientScript.RegisterStartupScript(GetType(), "set global var in iview", "<script>var isCloudApp = '" + isCloudApp.ToString() + "';var getIviewRowCount = " + getIviewRowCount.ToString().ToLower() + ";var totRowCount = '';</script>");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ivirHeaderData", "var ivirHeaderData = " + jsonForGrid + ";var getAjaxIviewData=" + getAjaxIviewData.ToString().ToLower() + ";var isListView=" + (objIview.purposeString == "" ? "false" : "true") + ";var showParam=" + objParams.showParam.ToString().ToLower() + ";var iviewWrap = " + util.IviewWrap.ToString().ToLower() + ";var isIviewPopup = " + IsIviewPop.ToString().ToLower() + ";var toolbarJSON=JSON.stringify(" + toolbarJsonString + ");var requestJSON = " + objIview.requestJSON.ToString().ToLower() + ";var iviewDataWSRows = " + objIview.iviewDataWSRows.ToString() + ";var isPivotReport = " + objIview.isPivotReport.ToString().ToLower() + ";var redisLoadType = '" + redisLoadType.ToString() + "';var redisLoadKey = '" + redisLoadKey.ToString() + "';var breadCrumbStr = '" + objIview.Menubreadcrumb.ToString() + "';var iviewButtonStyle = '" + iviewButtonStyle.ToString() + "';var inputControlType = '" + inputControlType.ToString() + "';", true);

            }

            ShowHideFilters();

            if (hdnGo.Value == "Go" || hdnGo.Value == "clear")
            {
                webTime2 = DateTime.Now.Subtract(asStart).TotalMilliseconds;
                strTimetaken.Append("PageLoad2-" + webTime2.ToString() + " ");
            }
            else
            {
                webTime2 = DateTime.Now.Subtract(asStart).TotalMilliseconds;
                strTimetaken.Append("PageLoad1-" + webTime2.ToString() + " ");
            }

            if (hdnToggleDimmer.Value.ToLower() == "false")
            {
                hdnToggleDimmer.Value = "true";
                CloseDimmerJS();

            }

            if (Session["build"] != null && Session["build"].ToString() != "")
            {
                hasBuildAccess = System.Web.HttpContext.Current.Session["build"].ToString() == "T";
            }

            if (ConfigurationManager.AppSettings["timetaken"].ToString() == "true")
                lblTime.Text = strTimetaken.ToString();


            printRowsMaxLimitField.Value = Session["AxPrintRowsMaxLimit"].ToString();

            if (hdnGo.Value == "Go" || hdnGo.Value == "clear")
            {
                dvStatictime.Style.Add("display", "block");
                if (refreshTime != "")
                    lblRefresh.Text = "Last Refreshed On :" + refreshTime;
            }
        }
        catch (Exception ex)
        {

        }
        //Page.ClientScript.RegisterStartupScript(GetType(), "axpTstructConfig", "<script>var AxpIsAutoSplit ='" + objIview.AxpIsAutoSplit.ToString().ToLower() + "';var AxpIviewDisableSplit = '" + objIview.AxpIviewDisableSplit.ToString().ToLower() + "';</script>");
        if (objIview != null)
        {
            if (objIview.AxpIsAutoSplit != null)
                hdnAutoSplit.Value = objIview.AxpIsAutoSplit;
            if (objIview.AxpIviewDisableSplit != null)
                hdnDisableSplit.Value = objIview.AxpIviewDisableSplit;
        }
        //Import history modal dialog - for removing breadcrum panel 
        if (Request.QueryString["importhistory"] != null)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ImportHistory", "$('#breadcrumb-panel').remove()", true);
        requestProcess_logtime += ObjExecTr.RequestProcessTime("Response");
        serverprocesstime = ObjExecTr.TotalServerElapsTime();
        if (hdnGo.Value == "Go")
            hdnbElapsTimeGo.Value = serverprocesstime + "♠" + requestProcess_logtime;
    }

    private void GetAxpStructConfig()
    {
        FDW fdwObj = FDW.Instance;
        bool isRedisConnected = fdwObj.IsConnected;
        string axpStructKeyIview = Constants.AXCONFIGIVIEW; //Constants.AXCONFIGURATIONS;       
        string axpConfigTableIview = Constants.AXNODATACONFIGIVIEW; //Constants.AXCONFIGURATIONTABLE;

        string structType = Constants.STRUCTTYPE_IVIEW;
        string configType = Constants.CONFIGTYPE_CONFIGS;

        if (Request.QueryString["tstcaption"] != null)
        {
            axpStructKeyIview = Constants.AXCONFIGTSTRUCT;
            axpConfigTableIview = Constants.AXNODATACONFIGTSTRUCT;

            structType = Constants.STRUCTTYPE_TSTRUCT;
            //configType = Constants.CONFIGTYPE_CONFIGS;
        }

        DBContext objdb = new DBContext();
        DataSet dsConfig = new DataSet();
        DataTable axpConfigStrIview = new DataTable();
        bool isAxpConfig = true;
        string axpConfigTblIview = string.Empty;
        try
        {
            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];

            if (isRedisConnected)
            {
                //axpConfigStrIview = fObj.DataTableFromRedis(util.GetConfigCacheKey(axpStructKeyIview, "", iName, AxRole, "ALL"));

                if (Request.QueryString["tstcaption"] != null)
                    axpConfigStrIview = fObj.DataTableFromRedis(util.GetConfigCacheKey(axpStructKeyIview, iName, "", AxRole, "ALL"));
                else
                    axpConfigStrIview = fObj.DataTableFromRedis(util.GetConfigCacheKey(axpStructKeyIview, "", iName, AxRole, "ALL"));


                if (axpConfigStrIview == null || axpConfigStrIview.Rows.Count == 0)
                    axpConfigTblIview = fObj.StringFromRedis(util.GetNoDataConfigCacheKey(axpConfigTableIview, "", iName, AxRole, "ALL"));
                else
                    axpConfigStrIview.TableName = "Table";
            }
            if (!objIview.requestJSON && (axpConfigTblIview == string.Empty && (axpConfigStrIview == null || axpConfigStrIview.Rows.Count == 0)))
            {
                dsConfig = objdb.GetAxConfigurations(iName, structType, false, configType);

                if (dsConfig.Tables["Table0"] == null || dsConfig.Tables["Table0"].Rows.Count == 0)
                    isAxpConfig = false;
            }

            if ((axpConfigStrIview == null || axpConfigStrIview.Rows.Count == 0) && (isAxpConfig == false || (isAxpConfig && (dsConfig == null || dsConfig.Tables.Count == 0 || dsConfig.Tables["Table0"].Rows.Count == 0))) && axpConfigTblIview == string.Empty && isRedisConnected)
                fdwObj.SaveInRedisServer(util.GetNoDataConfigCacheKey(axpConfigTableIview, "", iName, AxRole, "ALL"), "NoData", axpConfigTableIview, schemaName);


            if (isRedisConnected)
            {
                if (dsConfig.Tables.Count > 0 && dsConfig.Tables["Table0"] != null && dsConfig.Tables["Table0"].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dsConfig.Tables[0];
                    fdwObj.SaveInRedisServerDT(util.GetConfigCacheKey(axpStructKeyIview, "", iName, AxRole, "ALL"), dt, axpStructKeyIview, schemaName);
                    axpConfigStrIview = dt;
                }

            }
            else
                axpConfigStrIview = dsConfig.Tables[0];

            if ((axpConfigStrIview != null) && (axpConfigStrIview.Rows.Count > 0))
            {
                objIview.DsIviewConfig = axpConfigStrIview;
                objIview.GetAxpStructConfig(objIview);
            }
        }
        catch (Exception ex)
        {
            LogFile.Log logObj = new LogFile.Log();
            string sessID = Constants.GeneralLog;
            if (HttpContext.Current.Session != null)
                sessID = HttpContext.Current.Session.SessionID;
            logObj.CreateLog("GetAxpStructConfig -" + ex.Message, sessID, "openiview-dev-" + iName, "");
        }

    }

    private void ResetSessionTime()
    {
        if (Session["AxSessionExtend"] != null && Session["AxSessionExtend"].ToString() == "true")
        {
            HttpContext.Current.Session["LastUpdatedSess"] = DateTime.Now.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "eval(callParent('ResetSession()', 'function'));", true);
        }
    }

    private void ShowHideFilters()
    {
        if (hdnIsParaVisible.Value != string.Empty)
        {
            if (hdnIsParaVisible.Value == "0")
            {


                //myFiltersLi.Attributes.Add("class", "");
                //myFilters.Style.Add("display", "inline-block");
                myFiltersBody.Style.Add("display", "block");



            }
            else
            {


                //myFiltersLi.Attributes.Add("class", "");
                //myFilters.Style.Add("display", "inline-block");
                myFiltersBody.Style.Add("display", "block");
            }
        }

        else
        {




            //myFiltersLi.Attributes.Add("class", "");
            //myFilters.Style.Add("display", "inline-block");
            myFiltersBody.Style.Add("display", "block");
        }
        if (objParams.IsFilterEnabled == false && (objParams.IsParameterExist == false || objParams.NoVisibleParam == true))
        {
            hdnIsParaVisible.Value = "hidden";
            //mainfilter.Style.Add("display", "none");
            //divcontainer.Style.Add("margin-top", "5px");
            //myFilters.Attributes.Add("class", myFilters.Attributes["class"].ToString().Replace("filterBuTTon", "filterBuTTon collapsed"));
            Filterscollapse.Attributes.Add("class", Filterscollapse.Attributes["class"].ToString().Replace("in", ""));

            //myFiltersLi.Attributes.Add("class", "hidden");
            //myFilters.Style.Add("display", "none");
            myFiltersBody.Style.Add("display", "none");
        }
        else
        {
            hdnIsParaVisible.Value = "visible";
        }
        //   myFilters.Style.Add("display", "none");
    }

    private void CheckParamaterDB()
    {
        if (objIview.IsDirectDBcall)
        {
            XmlDocument doc = new XmlDocument();

            if (!string.IsNullOrEmpty(objIview.StructureXml))
            {
                doc.LoadXml(objIview.StructureXml);
                string ivCaption = doc.SelectSingleNode("root").Attributes["caption"].Value;
                ivCaption = ivCaption.Replace("&&", "&");
                lblHeading = ivCaption;
                objIview.IviewCaption = ivCaption;
            }

            if (objParams.IsParameterExist)
            {
                if (iName != "inmemdb")
                {

                    GetParams();
                }
                else
                    tst_Scripts = tst_Scripts + "<script type=\"text/javascript\">var hideParams='true';var proj = '" + proj + "';var user='" + user + "';var AxRole='" + AxRole + "'; var sid='" + sid + "';var iName='" + iName + "'; gl_language='" + HttpContext.Current.Session["language"].ToString() + "'; validateParamOnGo='false'; " + strGlobalVar + "; var axpResp = '" + axpResp + "';</script>";
            }
            else
            {
                tst_Scripts = tst_Scripts + "<script type=\"text/javascript\">var hideParams='true';var proj = '" + proj + "';var user='" + user + "';var AxRole='" + AxRole + "'; var sid='" + sid + "';var iName='" + iName + "'; gl_language='" + HttpContext.Current.Session["language"].ToString() + "'; validateParamOnGo='false'; " + strGlobalVar + "; var axpResp = '" + axpResp + "';</script>";

                CallWebservice("1", "yes");
                //lol1.Style.Add("display", "block");
                iviewFrame.Style.Add("display", "block");
                paramCont.Style.Add("display", "none");
            }
        }
        else
        {
            if (iName != "inmemdb")
            {
                GetParams();
            }
            else
            {
                tst_Scripts = tst_Scripts + "<script type=\"text/javascript\">var hideParams='true';var proj = '" + proj + "';var user='" + user + "';var AxRole='" + AxRole + "'; var sid='" + sid + "';var iName='" + iName + "'; gl_language='" + HttpContext.Current.Session["language"].ToString() + "'; validateParamOnGo='false'; " + strGlobalVar + "; var axpResp = '" + axpResp + "';</script>";
            }
        }
    }

    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new SessionPageStatePersister(Page);
        }
    }

    protected void CloseDimmerJS()
    {
        if ((GridView1.Rows.Count > 0) || (objIview.IViewWhenEmpty != string.Empty) || onlyParams == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "controlDimmer", "closeParentFrame();", true);
        }
    }


    #region DirectDBcall

    ///<summary>
    ///<para>Function to parse the XML in case of MYSQL/MARIADB DB</para>
    ///</summary>
    private void ParseXMLforMySQLMariaDB(DataSet ds, ref bool isDirectDB, ref string structXml, ref bool hasParams, ref string strError)
    {
        int multipleSqlCount = 0;
        try
        {
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                structXml = ds.Tables[0].Rows[0][0].ToString().Trim();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(structXml);

                XmlNode rootNode = xmldoc.SelectSingleNode("/root");
                foreach (XmlNode childNode in rootNode.ChildNodes)
                {
                    if (!hasParams && childNode.Attributes["cat"] != null && childNode.Attributes["cat"].Value.ToLower() == "params")
                        hasParams = true;
                    else if (childNode.Attributes["cat"] != null && childNode.Attributes["cat"].Value.ToLower() == "sql")
                    {
                        multipleSqlCount = multipleSqlCount + 1;
                        if (multipleSqlCount > 1)
                        {
                            strError = "Multiple SQL";
                            break;
                        }
                    }
                    else if (childNode.Attributes["cat"] != null && childNode.Attributes["cat"].Value.ToLower() == "column")
                    {
                        strError = "Non query column";
                        break;
                    }
                    else if (childNode.Attributes["cat"] != null && childNode.Attributes["cat"].Value.ToLower() == "querycol")
                    {
                        if (childNode.SelectSingleNode("a6") != null && childNode.SelectSingleNode("a6").InnerXml != null && childNode.SelectSingleNode("a6").InnerXml != String.Empty)
                        {
                            strError = "Field expression";
                            break;
                        }
                        else if (childNode.SelectSingleNode("a9") != null && childNode.SelectSingleNode("a9").InnerXml != "[Arial,8,clBlack,,False,False,False,False]")
                        {
                            strError = "Column font details";
                            break;
                        }
                        else if (childNode.SelectSingleNode("a12") != null && childNode.SelectSingleNode("a12").InnerXml.ToLower() != "clwindow")
                        {
                            strError = "Font color";
                            break;
                        }
                        else if (childNode.SelectSingleNode("a22") != null && childNode.SelectSingleNode("a22").InnerXml != null && childNode.SelectSingleNode("a22").InnerXml != String.Empty)
                        {
                            strError = "Conditional formatting";
                            break;
                        }
                    }

                    if (childNode.Name.ToLower() == "pivot" || childNode.Name.ToLower() == "pivotcol")
                    {
                        strError = "Pivot";
                        break;
                    }
                }

                if (strError == String.Empty && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[1];
                    if (dt.Columns.Contains("compcaption") && dt.Columns.Contains("comphint"))
                    {
                        string filterExpression;
                        XmlNode compsNode = xmldoc.SelectSingleNode("/root/comps");
                        foreach (XmlNode childNode in compsNode.ChildNodes)
                        {
                            filterExpression = "compname = '" + childNode.Name + "'";
                            DataRow[] dtRows = dt.Select(filterExpression);
                            if (dtRows.Length > 0)
                            {
                                if (childNode.Attributes["caption"] != null)
                                    childNode.Attributes["caption"].Value = dtRows[0]["compcaption"].ToString();
                                if (childNode.Attributes["hint"] != null)
                                    childNode.Attributes["hint"].Value = dtRows[0]["comphint"].ToString();
                            }
                        }
                    }
                    structXml = xmldoc.InnerXml.ToString();
                }

                if (strError != String.Empty)
                {
                    structXml = "false";
                    isDirectDB = false;
                }
                else
                {
                    isDirectDB = true;
                }
            }
        }
        catch (Exception Ex)
        {
            structXml = "false";
            isDirectDB = false;
            strError = "IView XML Parsing Error - " + Ex.Message;
        }
    }

    ///<summary>
    ///<para>Function to get iview structure from either redis or direct db(based on global configuration)</para>
    ///</summary>
    private void GetIviewStructure(string ivname)
    {
        string result = string.Empty;
        //Commented the Memcache object as this was throwing Thread being aborted
        //MemCache obj = new MemCache();
        //bool isDirectDB = false;
        string structxml = string.Empty;
        bool isParamExist = false;
        string errorCond = string.Empty;

        try
        {
            #region New Code to cache Iview structure XML for DirectDB call 
            DataSet ds = new DataSet();
            string ivupdateOn = string.Empty;
            string fdKeyIVIEWSTRUCT = Constants.IVIEWSTRUCT;
            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];

            //Check iview structure xml in cache
            string[] fullRedisData = fObj.StringFromRedis(util.GetRedisServerkey(fdKeyIVIEWSTRUCT, iName)).Split(new[] { "*$*" }, StringSplitOptions.None);
            structxml = fullRedisData[0];

            if (structxml != string.Empty && structxml != "false" && objIview.StructureXml != "")
            {
                GenericRedisFunction(Title, objIview.IName, structxml, schemaName);

            }

            //If xml available, then check the flag in cache that whether iview is suitable for direct db call
            if (fullRedisData.Length == 3)
            {
                isParamExist = Convert.ToBoolean(fullRedisData[1]);
                errorCond = fullRedisData[2];
            }
            else if (structxml != string.Empty)
            {
                directiview = false;
            }

            if (structxml != string.Empty && structxml != "false")
            {
                isCache = true;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(structxml);
                if (xmlDoc.DocumentElement.Attributes["updatedon"] != null)
                {
                    ivupdateOn = xmlDoc.DocumentElement.Attributes["updatedon"].Value;
                }
            }

            bool isStructureUpdated = ivupdateOn != string.Empty && objIview.IsStructureUpdated(ivupdateOn, ivname);

            // If xml not available in cache, check the global direct db call flag.
            //   If global direct db call flag is true
            if (directiview && (structxml == string.Empty || isStructureUpdated))
            {
                DBContext objdb = new DBContext();
                // Call direct db call getstructure for iview xml
                //util.licencedValidSessionCheck();
                ds = objdb.GetIviewStructure(ivname);
                //   If xml is returned then
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    if (Session["axdb"].ToString().ToLower() == "mysql" || Session["axdb"].ToString().ToLower() == "mariadb")
                    {
                        ParseXMLforMySQLMariaDB(ds, ref directiview, ref structxml, ref isParamExist, ref errorCond);
                    }
                    else
                    {
                        structxml = ds.Tables[0].Rows[0][0].ToString();
                        directiview = (structxml == "false") ? false : true;
                        isParamExist = string.IsNullOrEmpty(ds.Tables[0].Rows[0][1].ToString()) ? false : bool.Parse(ds.Tables[0].Rows[0][1].ToString());
                        errorCond = ds.Tables[0].Rows[0][2].ToString();
                    }

                    //Set “directiview” flag is true for that particular iview in cache.
                    string structureDetails = structxml + "*$*" + isParamExist + "*$*" + errorCond;
                    if (directiview)
                    {
                        //dvRefreshParam.Visible = isParamExist;
                        FDW fdwObj1 = FDW.Instance;
                        //  Keep XML in cache.
                        fdwObj1.SaveInRedisServer(util.GetRedisServerkey(fdKeyIVIEWSTRUCT, iName), structureDetails, fdKeyIVIEWSTRUCT, schemaName);
                    }
                }

                isCache = false;
            }
            else if (isStructureUpdated && !directiview)
            {
                if (structxml != string.Empty)
                {
                    //isCache = false;
                    structxml = string.Empty;
                }
            }

            if (fullRedisData.Length == 3 && directiview)
            {
                // Set “directiview” flag is false for that particular iview in cache.
                // If global direct db call is false then
                directiview = (structxml == "false") ? false : true;
            }
            #endregion
            //If directiview is true in cache then

            if (structxml != string.Empty && structxml != "false")
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(structxml);
                XmlNode cNode = default(XmlNode);
                cNode = xmldoc.SelectSingleNode("//iview/b38");
                if (cNode != null)
                {
                    if (cNode.InnerText != null)
                    {
                        objIview.IVType = cNode.InnerText;
                        dvData.Attributes["class"] = "ivType-" + objIview.IVType;
                    }
                    else
                    {
                        objIview.IVType = "Classic";

                    }
                }
                else
                {
                    objIview.IVType = "Classic";
                }

                if (xmldoc.SelectSingleNode("//iview/b39") != null)
                    paramsCache = xmldoc.SelectSingleNode("//iview/b39").InnerText;


            }
            //If directiview is false in cache then
            // If “false” is returned then
            if (!directiview && (structxml == string.Empty || structxml == "false"))
            {
                callParamPlusStructure = true;
            }
            objIview.IsDirectDBcall = directiview;
            objIview.StructureXml = structxml;
            objParams.IsParameterExist = isParamExist;

            strTimetaken.Append("ISStructCached--:" + isCache.ToString() + "--");
            if (isCache)
            {
                logobj.CreateDirectDBLog("openiview-dev-" + ivname, "RedisCachedStructure - GetIviewStructure", "", "IView Name :  " + ivname, "Success --" + ivname
                                                     + Environment.NewLine + "ISCached : " + isCache.ToString() + " - StructureXML : "
                                                     + Environment.NewLine + Environment.NewLine + objIview.StructureXml);
            }
            else if (objIview.IsDirectDBcall)
            {
                logobj.CreateDirectDBLog("openiview-dev- " + ivname, "GetIviewStructure", "", "IView Name :  " + ivname, "Success --" + ivname + "HasParam :"
                                                     + objParams.IsParameterExist + Environment.NewLine + "Condition : " + errorCond + Environment.NewLine + "ISCahed : " + isCache.ToString() + " - StructureXML : "
                                                     + Environment.NewLine + Environment.NewLine + objIview.StructureXml);
            }
        }
        catch (Exception ex)
        {
            string errMsg = ex.Message.Replace("\n", "");
            requestProcess_logtime += "Server - " + errMsg + " ♦ ";
            Response.Redirect(util.ERRPATH + errMsg + "*♠*" + requestProcess_logtime);
            logobj.CreateDirectDBLog("openiview-dev- " + ivname, "GetIviewStructure", errMsg, "IView Name :  " + ivname, "Fail - " + ivname + " - StructureXML");

        }
        if (structxml != string.Empty && structxml != "false" && objIview.StructureXml != "")
        {

            GenericRedisFunction(Title, objIview.IName, structxml, schemaName);

        }
        fileName = "openiview-" + iName;
        errLog = logobj.CreateLog("Loading iview.aspx before post back (get and set parameters)", sid, fileName, "new");
        XmlDocument doc = new XmlDocument();

        callParamAndData(ivname);
    }

    private void callParamAndData(string ivname)
    {
        additionalPageInfo();

        if ((Request.Form.Count > 0 && Request.Form["redisLoadKey"] == null && Request.Form.Keys[0] != "reqProc_logtime") || loadString != string.Empty)
        {
            isCallWS = true;
            logobj.CreateLog("Loading popup iviews", sid, fileName, string.Empty);
            logobj.CreateLog("Get Iview Parameters", sid, fileName, string.Empty);
            SetParamValues();
            //Process parameters
            CheckParamaterDB();
            if (Session["project"] == null)
                return;
            logobj.CreateLog("Get and Load Iviewdata", sid, fileName, string.Empty);
            GetIviewData();
            GridView2Wrapper.Visible = true;

        }
        else if (Request.QueryString["tstcaption"] != null)
        {
            if (!objIview.requestJSON)
            {
                objIview.purposeString = " purpose=\"list\" ";
                objIview.IviewCaption = Request.QueryString["tstcaption"].ToString();
                tst_Scripts += "<script language=javascript> var proj = '" + proj + "';var user='" + user + "';var sid='" + sid + "';var iName='" + iName + "'; var ivna='" + iName + "';var tst ='" + iName + "'; var ivtype='listview';var trace = '" + Session["AxTrace"] + "';var AxRole='" + AxRole + "';var gl_language = '" + language + "';</script>";
                //dvRefreshParam.Visible = false;
                GetIviewData();
            }
            else
            {
                objIview.purposeString = " purpose=\"list\" ";
                objIview.IviewCaption = Request.QueryString["tstcaption"].ToString();
                //dvRefreshParam.Visible = false;

                isCallWS = false;
                logobj.CreateLog("Get ListView Parameters", sid, fileName, string.Empty);
                DateTime asStart1 = DateTime.Now;
                //Process parameters
                CheckParamaterDB();
                onlyParams = true;
                webTime2 = DateTime.Now.Subtract(asStart1).TotalMilliseconds;
                strTimetaken.Append("GetParams-" + webTime2.ToString() + " ");
                if (Session["project"] == null)
                    return;
            }

        }
        else if (iName == "inmemdb")
        {
            axpResp = "true";
            objIview.IviewCaption = "In-Memory DB";
            GetIviewData();
            CheckParamaterDB();
        }
        else
        {
            isCallWS = false;
            logobj.CreateLog("Get Iview Parameters", sid, fileName, string.Empty);
            DateTime asStart1 = DateTime.Now;
            //Process parameters
            CheckParamaterDB();
            onlyParams = true;
            webTime2 = DateTime.Now.Subtract(asStart1).TotalMilliseconds;
            strTimetaken.Append("GetParams-" + webTime2.ToString() + " ");
            if (Session["project"] == null)
                return;
        }
    }

    private void additionalPageInfo()
    {
        gridPageSize = objIview.GrdPageSize;
        if (gridPageSize == "") gridPageSize = "30";
        GridView1.PageSize = Convert.ToInt32(gridPageSize);

        objIview.GrdPageSize = gridPageSize;
        currentPageNo = 1;
        Session["currentPageNo" + iName] = "1";
    }

    private void GetIviewStructureNew(string ivname)
    {
        fileName = "openiview-" + iName;
        errLog = logobj.CreateLog("Loading iview.aspx before post back (get and set parameters)", sid, fileName, "");
        //XmlDocument doc = new XmlDocument();
        callParamAndData(ivname);
    }

    ///<summary>
    ///<para>Function to get iview data if it an direct db call an dtotal records </para>
    ///<para>and  save the values  in object property</para>
    ///</summary>
    private bool GetIviewDataDBCall(string inputXml, string pageNo, string pageSize)
    {
        string sqlQuery = string.Empty;
        DBContext obj = new DBContext();
        DataSet ds = new DataSet();
        try
        {
            sqlQuery = GetSqlFromStructure(objIview.StructureXml);
            if (IsMulSelPrmsSQL(sqlQuery))
                return false;

            if (objParams.IsParameterExist)
                sqlQuery = ReplaceSqlParamByvalues(sqlQuery);

            objIview.SqlQuery = sqlQuery;
            ds = obj.GetIviewDataDB(sqlQuery, pageNo, pageSize, objIview.IsGrandTotal);
            logobj.CreateDirectDBLog("openiview-dev-" + iName, "GetIViewData DirectDB Call - GetIviewDataDBCall", "", iName + "- Sql query "
                 + Environment.NewLine + sqlQuery + Environment.NewLine, "Success --" + iName + " - GetIViewData");
            if (ds.Tables.Count > 1)
            {

                if (currentPageNo == 1)
                {
                    directDbtotalRows = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    objIview.DirectDbtotalRows = directDbtotalRows;
                    objIview.GrandTotalRow.Clear();
                }
            }
            objIview.DsDataSetDB = ds;
            hdnTotalIViewRec.Value = directDbtotalRows.ToString();
        }
        catch (Exception ex)
        {
            string errMsg = ex.Message.Replace("\n", "");

            logobj.CreateDirectDBLog("openiview-dev-" + iName, "GetIViewData DirectDB Call - GetIviewDataDBCall", errMsg, iName + "- Sql query "
                 + Environment.NewLine + sqlQuery + Environment.NewLine, "Fail --" + iName + " - GetIViewData");
            requestProcess_logtime += "Server - " + errMsg + " ♦ ";
            Response.Redirect(util.ERRPATH + errMsg + "*♠*" + requestProcess_logtime);

        }
        return true;
    }

    private bool IsMulSelPrmsSQL(string sqlQuery)
    {
        sqlQuery = sqlQuery.ToLower();
        if (sqlQuery.Contains("axpselectionc") || sqlQuery.Contains("axpselectionn") || sqlQuery.Contains("axpselectiond"))
            return true;
        else
            return false;
    }

    ///<summary>
    ///<para>Function to get sql query from structure xml</para>
    ///</summary>
    private string GetSqlFromStructure(string structureXml)
    {
        StringBuilder result = new StringBuilder();
        string resultStr = String.Empty;
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.LoadXml(structureXml);
            XmlNode xmlrow = doc.SelectSingleNode("//row1/a2");
            foreach (XmlNode nod in xmlrow.ChildNodes)
            {
                result.Append("\n" + nod.InnerText.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        resultStr = SQLRemoveHyphenComments(result.ToString());
        return resultStr;
    }


    public string SQLRemoveHyphenComments(string sql)
    {
        StringBuilder returnSQL = new StringBuilder();
        try
        {
            string[] strArr = sql.Split('\n');
            foreach (string sqlLine in strArr)
            {
                string tempSqlLine = sqlLine;
                if (tempSqlLine != string.Empty)
                {
                    Boolean hyphenExist = tempSqlLine.IndexOf("--") > -1;
                    if (hyphenExist)
                    {
                        char[] quotes = { '\'', '"' };
                        int newCommentLiteral, lastCommentLiteral = 0;
                        while ((newCommentLiteral = tempSqlLine.IndexOf("--", lastCommentLiteral)) != -1)
                        {
                            int countQuotes = tempSqlLine.Substring(lastCommentLiteral, newCommentLiteral - lastCommentLiteral).Split(quotes).Length - 1;
                            if (countQuotes % 2 == 0)
                            {
                                int eol = tempSqlLine.IndexOf("\r\n") + 2;
                                if (eol == 1)
                                    eol = tempSqlLine.Length;
                                tempSqlLine = tempSqlLine.Remove(newCommentLiteral, eol - newCommentLiteral);
                                lastCommentLiteral = newCommentLiteral;
                            }
                            else
                            {
                                int singleQuote = tempSqlLine.IndexOf("'", newCommentLiteral);
                                if (singleQuote == -1)
                                    singleQuote = tempSqlLine.Length;
                                int doubleQuote = tempSqlLine.IndexOf('"', newCommentLiteral);
                                if (doubleQuote == -1)
                                    doubleQuote = tempSqlLine.Length;

                                lastCommentLiteral = Math.Min(singleQuote, doubleQuote) + 1;


                            }
                        }
                        returnSQL.Append(tempSqlLine + " ");
                    }
                    else
                    {
                        returnSQL.Append(tempSqlLine + " ");
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnSQL.ToString();
    }


    ///<summary>
    ///<para>Function parameters and global parameters for input query</para>
    ///</summary>
    private string ReplaceSqlParamByvalues(string sqlQuery, bool isSQL = true)
    {
        //parar values array list was used by referencde hence passing the new araylist by value.. Issue related to appending "to_date(" 
        sqlQuery = ReplaceParamvalues(sqlQuery, new ArrayList(objParams.ParamNames), new ArrayList(objParams.ParamChangedVals), "param", isSQL);
        if (objIview.GolbalVarName != null && objIview.GolbalVarName.Count > 0)
            sqlQuery = ReplaceParamvalues(sqlQuery, objIview.GolbalVarName, objIview.GolbalVarValue, "global", isSQL);

        return sqlQuery;
    }


    ///<summary>
    ///<para>Function replace param with param values for input query</para>
    ///</summary>
    private string ReplaceParamvalues(string sqlQuery, ArrayList paramNames, ArrayList paramValues, string type, bool isSQL = true)
    {
        try
        {
            Util.Util utilGlo = new Util.Util();
            //sqlQuery = sqlQuery.ToLower();
            string dbType = string.Empty;
            string dlmtr = string.Empty;

            if (!string.IsNullOrEmpty(HttpContext.Current.Session["axdb"].ToString()))
                dbType = HttpContext.Current.Session["axdb"].ToString().ToLower();
            for (int i = 0; i < paramNames.Count; i++)
            {
                if (paramNames[i].ToString().ToUpper() != "AXISPOP")
                {
                    if (paramValues[i] != "")
                        paramValues[i] = utilGlo.ReverseCheckSpecialCharsInQuery(paramValues[i].ToString());
                    if ((type == "param") && (dbType.ToLower() == "oracle"))
                    {

                        if (GetParamType(paramNames[i].ToString()) == "Date/Time")
                        {
                            dlmtr = string.Empty;
                            string dateParam = paramValues[i].ToString();

                            if (clientCulture.ToLower() == "en-us")
                            {
                                dateParam = util.GetClientDateString(clientCulture, dateParam);
                                if (isSQL)
                                    paramValues[i] = "to_date('" + dateParam + "','mm/dd/yyyy hh24:mi:ss')";
                                else
                                    paramValues[i] = dateParam;
                            }
                            else
                            {
                                if (isSQL)
                                    paramValues[i] = "to_date('" + dateParam + "','dd/mm/yyyy hh24:mi:ss')";
                                else
                                    paramValues[i] = dateParam;
                            }
                        }
                        else
                        {
                            dlmtr = "'";
                        }
                    }
                    else
                    {
                        dlmtr = "'";
                    }

                    string paramName = ":" + paramNames[i].ToString();
                    string paramnSpace = ":" + paramNames[i] + " ";
                    string paramBrace = ":" + paramNames[i] + ")";
                    string paramColn = ":" + paramNames[i] + ";";
                    string paramBrash = "{" + paramNames[i] + "}";

                    bool isNumericEmptyParam = false;
                    if (type == "param" && GetParamType(paramNames[i].ToString()) == "Numeric")
                    {
                        dlmtr = String.Empty;
                        if (paramValues[i] == "")
                        {
                            isNumericEmptyParam = true;
                            paramValues[i] = 0;
                        }
                    }

                    if (sqlQuery.Contains(paramBrash))
                        sqlQuery = sqlQuery.Replace(paramBrash, paramValues[i].ToString());

                    if (sqlQuery.Contains(paramnSpace))
                        sqlQuery = sqlQuery.Replace(paramName, dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramnSpace.ToLower()))
                        sqlQuery = sqlQuery.Replace(paramName.ToLower(), dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramnSpace.ToUpper()))
                        sqlQuery = sqlQuery.Replace(paramName.ToUpper(), dlmtr + paramValues[i].ToString() + dlmtr);

                    if (sqlQuery.Contains(paramBrace))
                        sqlQuery = sqlQuery.Replace(paramName, dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramBrace.ToLower()))
                        sqlQuery = sqlQuery.Replace(paramName.ToLower(), dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramBrace.ToUpper()))
                        sqlQuery = sqlQuery.Replace(paramName.ToUpper(), dlmtr + paramValues[i].ToString() + dlmtr);


                    else if (sqlQuery.Contains(paramColn))
                        sqlQuery = sqlQuery.Replace(paramName, dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramColn.ToLower()))
                        sqlQuery = sqlQuery.Replace(paramName.ToLower(), dlmtr + paramValues[i].ToString() + dlmtr);

                    else if (sqlQuery.Contains(paramColn.ToUpper()))
                        sqlQuery = sqlQuery.Replace(paramName.ToUpper(), dlmtr + paramValues[i].ToString() + dlmtr);


                    if (sqlQuery.Contains(paramName))
                    {
                        sqlQuery = sqlQuery.Replace(paramName, dlmtr + paramValues[i].ToString() + dlmtr);
                    }
                    else if (sqlQuery.Contains(paramName.ToLower()))
                    {
                        sqlQuery = sqlQuery.Replace(paramName.ToLower(), dlmtr + paramValues[i].ToString() + dlmtr);
                    }
                    else if (sqlQuery.Contains(paramName.ToUpper()))
                    {
                        sqlQuery = sqlQuery.Replace(paramName.ToUpper(), dlmtr + paramValues[i].ToString() + dlmtr);
                    }

                    if (isNumericEmptyParam)
                    {
                        paramValues[i] = "";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return sqlQuery;
    }

    ///<summary>
    ///<para>Function to order grid columns based on the order of arrat colfld array</para>
    ///</summary>
    private void OrderGridColumns()
    {
        try
        {
            if (objIview.ColFld != null && objIview.DsDataSetDB != null)
            {
                DataColumnCollection columns = objIview.DsDataSetDB.Tables[0].Columns;
                for (int i = 0; i <= (objIview.ColFld.Count - 1); i++)
                {
                    string colname = objIview.ColFld[i].ToString();
                    if (columns.Contains(colname))
                        objIview.DsDataSetDB.Tables[0].Columns[colname].SetOrdinal(i);

                }
            }
        }
        catch (Exception ex)
        {
            logobj.CreateLog("ordering grid columns -" + ex.Message + "", sid, "opniview-dev-" + iName, string.Empty);

        }
    }

    ///<summary>
    ///<para>When click on refersh button in parameter window to show the left panel parameters after postback</para>
    ///</summary>
    protected void btnRefreshParams_Click(object sender, System.EventArgs e)
    {

        //leftPanel.Style.Add("display", "block");
        //showFilter.Style.Add("display", "none");
        //hideFilter.Style.Add("display", "block");
    }

    ///<summary>
    ///<para>Method to enable and disable links of next and pevious links for direct DB call data</para>
    ///</summary>
    private void DirectDBEnableDisableLinks(string pageNo)
    {
        bool lastPage = false;
        int recordsperpage = 0;

        if (Convert.ToInt32(objIview.GrdPageSize) > directDbtotalRows)
        {
            recordsperpage = directDbtotalRows;
        }
        else
        {
            recordsperpage = Convert.ToInt32(objIview.GrdPageSize);
        }

        if (recordsperpage == 0)
        {
            lblCurPage.Text = "Rows: " + (((Convert.ToInt32(pageNo) - 1) * Convert.ToInt32(recordsperpage)) + 1).ToString() + "-" + directDbtotalRows + " of ";
        }
        else if ((((Convert.ToInt32(pageNo)) * Convert.ToInt32(recordsperpage))) < directDbtotalRows)
        {

            lblCurPage.Text = "Rows: " + (((Convert.ToInt32(pageNo) - 1) * Convert.ToInt32(recordsperpage)) + 1).ToString() + "-" + (((Convert.ToInt32(pageNo)) * Convert.ToInt32(recordsperpage))).ToString() + " of ";

            if ((((Convert.ToInt32(pageNo)) * Convert.ToInt32(recordsperpage))).ToString() == directDbtotalRows.ToString())
            {
                lastPage = true;
            }
            else
            {
                lastPage = false;
            }
        }
        else
        {
            lblCurPage.Text = "Rows: " + (((Convert.ToInt32(pageNo) - 1) * Convert.ToInt32(recordsperpage)) + 1).ToString() + "-" + directDbtotalRows.ToString() + " of ";

            lastPage = true;

        }
        lblNoOfRecs.Text = directDbtotalRows.ToString();

        if (currentPageNo == 1 && !lastPage)
        {
            lnkPrev.Enabled = false;
            lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left disabled");

            // lnkPrev.CssClass = "pickdis";
            lnkNext.Enabled = true;
            lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right");

            //  lnkNext.CssClass = string.Empty;
        }
        else if (currentPageNo == 1)
        {
            lnkPrev.Enabled = false;
            lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left disabled");

            lnkNext.Enabled = false;
            lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right disabled");


        }
        else if (lastPage)
        {
            lnkPrev.Enabled = true;
            lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left");

            //    lnkPrev.CssClass = string.Empty;
            lnkNext.Enabled = false;
            lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right disabled");

            //   lnkNext.CssClass = "pickdis";
            //dvPages.Visible = true;
            if (IsSqlPagination.ToLower() == "false")
            {
                dvPages.Style.Add("display", "block");
            }

        }
        else
        {
            lnkNext.Enabled = true;
            lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right");

            //     lnkNext.CssClass = string.Empty;
            lnkPrev.Enabled = true;
            lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left");

            //    lnkPrev.CssClass = string.Empty;
        }

        pages.Text = string.Empty;
        //records.Text = objIview.IViewWhenEmpty;
        // lblNoOfRecs.Visible = false;
        lblCurPage.Visible = true;
        pgCap.Visible = false;
        lvPage.Visible = false;

    }


    private void CreateDBHeaderRow(XmlDocument xmlHdDoc)
    {
        XmlNode baseDataNodes = xmlHdDoc.SelectSingleNode("//root/comps");
        baseDataNodes.ParentNode.RemoveChild(baseDataNodes);

        XmlNode baseNode = xmlHdDoc.SelectSingleNode("//root");

        XmlNodeList xmlNodes = baseNode.ChildNodes;

        //Added for rowno column        
        colFld.Add("rowno");
        headName.Add("");
        colWidth.Add("10");
        colType.Add("c");
        //change here to hide first column heading
        colHide.Add("true");
        colDec.Add("0");
        colApplyComma.Add("false");
        colHlink.Add("-");
        colHlinkPop.Add("-");
        colRefreshParent.Add("-");
        colHlinktype.Add("-");
        colMap.Add("-");
        colHAction.Add("-");
        colNoPrint.Add("false");
        submerge.Add("-");
        submergecol.Add("-");
        colAlign.Add(string.Empty);
        colNoRepeat.Add("false");
        colZeroOff.Add("false");

        //Added for rowno column
        colFld.Add("axrowtype");
        headName.Add("axrowtype");
        colWidth.Add("0");
        colType.Add("c");
        colHide.Add("true");
        colDec.Add("0");
        colApplyComma.Add("false");
        colHlink.Add("-");
        colHlinkPop.Add("-");
        colRefreshParent.Add("-");
        colHlinktype.Add("-");
        colMap.Add("-");
        colHAction.Add("-");
        colNoPrint.Add("false");
        submerge.Add("-");
        submergecol.Add("-");
        colAlign.Add(string.Empty);
        colNoRepeat.Add("false");
        colZeroOff.Add("false");

        objIview.SubtTotalonTop.Clear();
        objIview.SubtColName.Clear();
        objIview.SubtCaption.Clear();
        objIview.SubtHeader.Clear();
        objIview.SubtFooter.Clear();
        objIview.SubtOrderNo.Clear();
        objIview.SubtSpaceFooter.Clear();
        objIview.SubtPageBreak.Clear();

        objIview.IsRunningTotal.Clear();
        objIview.IsRunningTotal.Add("False");
        objIview.IsRunningTotal.Add("False");

        objIview.IsSumField.Clear();
        objIview.IsSumField.Add("False");
        objIview.IsSumField.Add("False");
        foreach (XmlNode xmlChildNode in xmlNodes)
        {
            if (xmlChildNode.Attributes["cat"] != null)
            {
                string cat = xmlChildNode.Attributes["cat"].Value;
                if (cat.Equals("querycol"))         //Columns
                {
                    CreateDirectDBFieldArray(xmlChildNode);

                }
                else if (cat.Equals("iview"))
                {
                    foreach (XmlNode xmlsubChildNode in xmlChildNode)
                    {
                        if (xmlsubChildNode.Name == "a11")
                            objIview.IsGrandTotal = Convert.ToBoolean(xmlsubChildNode.InnerText);
                        if (xmlsubChildNode.Name == "a63" && xmlsubChildNode.InnerText != string.Empty)
                            hideChkBox = Convert.ToBoolean(xmlsubChildNode.InnerText);
                        if (xmlsubChildNode.Name == "a51")
                        {
                            string pageSize = xmlsubChildNode.InnerText;
                            if (pageSize != null)
                            {
                                //    //Commented the below code as it was always slicing the data to 20 records
                                //    //if (pageSize == "0")
                                //    //    objIview.IsIviewStagLoad = true;
                                //    //else
                                //    //    objIview.IsIviewStagLoad = false;
                                if (pageSize != "")
                                {
                                    recPerPage.Visible = false;
                                    lbRecPerPage.Visible = false;
                                }
                            }
                        }
                    }
                }

                else if (cat.Equals("subtotals"))
                {
                    CreateSubTotArray(xmlChildNode);

                }
            }

        }

        if (!hideChkBox)
        {
            int colIndx = colFld.IndexOf("rowno");
            colHide[colIndx] = "false";
        }
    }

    ///<summary>
    ///<para>method to Create hyprelinks for direct db </para>
    ///</summary>
    private void CreateDBHyperLinkRow(XmlDocument doc)
    {
        XmlNode baseNode1 = doc.SelectSingleNode("//root");
        XmlNodeList xmlNodes = baseNode1.ChildNodes;
        foreach (XmlNode xmlChildNode in xmlNodes)
        {
            if (xmlChildNode.Attributes["cat"] != null)
            {
                string cat = xmlChildNode.Attributes["cat"].Value;

                if (cat.Equals("hyperlinks"))
                {
                    CreateDBHyperLinkArray(xmlChildNode);
                }
            }
        }

    }

    ///<summary>
    ///<para>Method to craete sub total array from the structure xml </para>
    ///</summary>
    private void CreateSubTotArray(XmlNode xmlChildNode)
    {
        if (xmlChildNode.Attributes["totalontop"] != null)
            objIview.SubtTotalonTop.Add(xmlChildNode.Attributes["totalontop"].Value);
        foreach (XmlNode xmlsubChildNode in xmlChildNode)
        {

            if (xmlsubChildNode.Name == "a1")
                objIview.SubtColName.Add(xmlsubChildNode.InnerText);

            else if (xmlsubChildNode.Name == "a12")
                objIview.SubtCaption.Add(xmlsubChildNode.InnerText);

            else if (xmlsubChildNode.Name == "a4")
                objIview.SubtHeader.Add(xmlsubChildNode.InnerText);

            else if (xmlsubChildNode.Name == "a5")
                objIview.SubtFooter.Add(xmlsubChildNode.InnerText);


            else if (xmlsubChildNode.Name == "a13")
                objIview.SubtOrderNo.Add(xmlsubChildNode.InnerText);


            else if (xmlsubChildNode.Name == "a18")
                objIview.SubtSpaceFooter.Add(xmlsubChildNode.InnerText);


            else if (xmlsubChildNode.Name == "a7")
                objIview.SubtPageBreak.Add(xmlsubChildNode.InnerText);
        }
    }

    ///<summary>
    ///<para>Method to create Header Field array  from the structure xml </para>
    ///</summary>
    private void CreateDirectDBFieldArray(XmlNode baseNode)
    {
        XmlNodeList baseChildNodes = baseNode.ChildNodes;
        foreach (XmlNode childNode in baseChildNodes)
        {
            if (childNode.Name == "a21")
                colHide.Add(childNode.InnerText.ToLower());
            else if (childNode.Name == "a17")
                colWidth.Add(childNode.InnerText);
            else if (childNode.Name == "a5")
                colDec.Add(childNode.InnerText);
            else if (childNode.Name == "a10")
                colApplyComma.Add(childNode.InnerText);
            else if (childNode.Name == "a14")
                colAlign.Add(childNode.InnerText);
            else if (childNode.Name == "a4")
            {
                if (childNode.InnerText == "Numeric")
                    colType.Add("n");
                else if (childNode.InnerText == "Character")
                    colType.Add("c");
                else if (childNode.InnerText == "Date/Time" || childNode.InnerText.ToLower() == "date")
                    colType.Add("d");
            }
            else if (childNode.Name == "a2")
            {
                colFld.Add(childNode.InnerText);
                if (childNode.InnerText.ToLower() == "axp_format")
                {
                    objIview.ColAxp_format = true;
                }
            }
            else if (childNode.Name == "a3")
            {
                if ((childNode.InnerText.Length > 8) && (childNode.InnerText.Substring(0, 8).ToLower() == "noprint_"))
                {
                    childNode.InnerText = childNode.InnerText.Substring(8);
                    colNoPrint.Add("true");
                }
                else
                {
                    colNoPrint.Add("false");
                }
                headName.Add(childNode.InnerText);
            }
            else if (childNode.Name == "a8")
                objIview.IsSumField.Add(childNode.InnerText);

            else if (childNode.Name == "a7")
                objIview.IsRunningTotal.Add(childNode.InnerText);

            else if (childNode.Name == "a61")
            {
                structureMergeAndPivotLogic(childNode);


            }

            if (childNode.Name == "a62")
            {
                structureMergeAndPivotLogic(childNode);

            }

            if (childNode.Name == "a55")
            {
                if (childNode.InnerText == string.Empty)
                    colHAction.Add("-");
                else
                {
                    colHAction.Add(childNode.InnerText);
                    actRefreshParent[childNode.InnerText] = IsRefreshAfterSave(childNode.InnerText, true);
                }
                colHlink.Add("-");
                colHlinkPop.Add("-");
                colRefreshParent.Add("-");
                colHlinktype.Add("-");
                colMap.Add("-");
            }

            if (childNode.Name == "a13")
            {
                colNoRepeat.Add(childNode.InnerText);
            }

            if (childNode.Name == "a16")
            {
                colZeroOff.Add(childNode.InnerText);
            }


        }
    }


    ///<summary>
    ///<para>Method to parse structure xml and add to arry fields </para>
    ///</summary>
    private void CreateDBHyperLinkArray(XmlNode xmlChildNode)
    {
        XmlNodeList hyperChildNodes = xmlChildNode.ChildNodes;

        foreach (XmlNode hyperChildNode in hyperChildNodes)
        {
            string hyperName = string.Empty;
            if (hyperChildNode.Attributes["source"] != null)
                hyperName = hyperChildNode.Attributes["source"].Value;

            int colIndx = colFld.IndexOf(hyperName);
            if (colIndx != -1)
            {
                if (hyperChildNode.Attributes["sname"] != null)
                    colHlink[colIndx] = hyperChildNode.Attributes["sname"].Value;
                if (hyperChildNode.Attributes["pop"] != null)
                    colHlinkPop[colIndx] = hyperChildNode.Attributes["pop"].Value;
                if (hyperChildNode.Attributes["refresh"] != null)
                    colRefreshParent[colIndx] = hyperChildNode.Attributes["refresh"].Value;
                if (hyperChildNode.Attributes["load"] != null)
                {
                    if (hyperChildNode.Attributes["load"].Value == "True")
                        colHlinktype[colIndx] = "load";
                    else
                        colHlinktype[colIndx] = "open";
                }
                if (hyperChildNode.HasChildNodes)
                {

                    string colMapVal = string.Empty;
                    XmlNodeList paramNodes = hyperChildNode.ChildNodes;
                    foreach (XmlNode paramNode in paramNodes)
                    {
                        string mapName = string.Empty,
                            mapValue = string.Empty;

                        if (paramNode.Attributes["n"] != null)
                            mapName = paramNode.Attributes["n"].Value;
                        if (paramNode.Attributes["v"] != null)
                            mapValue = paramNode.Attributes["v"].Value;
                        if (mapName != string.Empty && mapValue != string.Empty)
                        {
                            if (colMapVal == string.Empty)
                                colMapVal = mapName + "=" + mapValue;
                            else
                                colMapVal += "," + mapName + "=" + mapValue;
                        }

                    }
                    if (colMapVal != String.Empty)
                        colMap[colIndx] = colMapVal;
                }
                else
                {
                    string sourceFld = hyperChildNode.Attributes["source"].Value;
                    if (!string.IsNullOrEmpty(sourceFld))
                        colMap[colIndx] = sourceFld + "=:" + sourceFld;
                }
            }
        }
    }


    #endregion DirectDBcall


    public void setPageDirection()
    {

        if (language.ToLower() == "arabic")
        {
            direction = "rtl";
            btn_direction = "start";
            bread_direction = "end";
        }

        if (language.ToLower() == "arabic")
        {
            dvRowsPerPage.Style.Add("float", "left");
            dvRowsPerPage.Style.Add("margin-top", "4px");
            divcontainer.Style.Add("margin-top", "0%");
            leftPanel.Style.Add("margin-top", "1%");

            //dvRefreshParam.Style.Add("float", "left");
            //dvRefreshParam.Style.Add("margin-top", "6px");
            //dvRefreshParam.Style.Add("margin-right", "4px");
        }
        else
        {
            dvRowsPerPage.Style.Add("float", "right");
            dvRowsPerPage.Style.Add("margin-top", "4px");


            // dvRefreshParam.Style.Add("float", "right");
            // dvRefreshParam.Style.Add("margin-top", "6px");
            //dvRefreshParam.Style.Add("margin-right", "4px");
        }
    }

    public void CleardtFilterCond()
    {
        dtFilterConds.Rows.Clear();
        dtFilterConds.Columns.Clear();
        dtFilterConds.Columns.Add("FilterColumn", typeof(string));
        dtFilterConds.Columns.Add("Value", typeof(string));
        Session["dtFilterConds"] = dtFilterConds;

    }

    private void SetParamValues()
    {
        if (Request.Form.Count > 0 && Request.Form["redisLoadKey"] == null)
        {
            string ixml1 = string.Empty;

            for (int i = 0; i < Request.Form.Keys.Count; i++)
            {
                if (Request.Form.Keys[i].ToString() != "pop" && Request.Form.Keys[i].ToString() != "AxHypTstRefresh" && Request.Form.Keys[i].ToString() != "reqProc_logtime")
                {
                    string val = string.Empty;
                    val = Request.Form[i].ToString();
                    //val = val.Replace("quot;", "'");
                    val = util.CheckReverseUrlSpecialChars(val);
                    //changed to ReverseCheckSpecialChars as it was failing in case of &quot; double quotes
                    val = util.ReverseCheckSpecialChars(val);
                    ixml1 += Request.Form.Keys[i].ToString() + "~" + val + "¿";
                }
            }
            hdnparamValues.Value = ixml1;
            Session["paramValues" + iName] = ixml1;
        }
    }

    private void ClearNavigationData()
    {
        Session["iNavigationInfoTable"] = null;
    }

    /// Call to GetParams Web Service
    public void GetParams()
    {
        string ires = string.Empty;
        string istructure = string.Empty;
        string fdKeyIVIEWPARAM = Constants.IVIEWPARAM;
        string fdKeyIVIEWSTRUCT = Constants.IVIEWSTRUCT;
        bool cacheParamsXML = false;
        string ivupdateOn = string.Empty;
        FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
        //check if IView Structure exist in Redis and is Latest

        if (!objIview.isObjFromCache || hdnGo.Value == "updateCache")
        {
            if (callParamPlusStructure && !objIview.requestJSON)
            {
                if (!isCache)
                {
                    string[] fullRedisData = fObj.StringFromRedis(util.GetRedisServerkey(fdKeyIVIEWSTRUCT, iName)).Split(new[] { "*$*" }, StringSplitOptions.None);

                    istructure = fullRedisData[0];

                    if (istructure != string.Empty && istructure != "false")
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(istructure);
                        //istructure = string.Empty;
                        if (xmlDoc.DocumentElement.Attributes["updatedon"] != null)
                        {
                            ivupdateOn = xmlDoc.DocumentElement.Attributes["updatedon"].Value;
                        }


                        if (ivupdateOn != string.Empty && !objIview.IsStructureUpdated(ivupdateOn, iName))
                        {
                            objIview.StructureXml = istructure;
                            callParamPlusStructure = false;
                            isCache = true;
                        }
                    }
                }
                else
                {
                    isCache = false;
                }
            }


            string iXml = string.Empty;
            DateTime asStart = DateTime.Now;
            errLog = logobj.CreateLog("Call to GetParams Web Service", sid, fileName, string.Empty);
            iXml = "<root " + objIview.purposeString + " name =\"" + iName + "\" axpapp = \"" + proj + "\" sessionid = \"" + sid + "\" appsessionkey=\"" + HttpContext.Current.Session["AppSessionKey"].ToString() + "\" username=\"" + HttpContext.Current.Session["username"].ToString() + "\" trace = \"" + errLog + "\" firsttime=\"" + (!objIview.requestJSON ? callParamPlusStructure.ToString().ToLower() : "true") + "\"  >";
            //GetParams input xml will contain the query string values passed by previous iview
            ConstructParamXml();
            iXml += "<params>" + pXml + "</params>";
            iXml += Session["axApps"].ToString() + Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</root>";

            if (hdnGo.Value != "refreshparams" && hdnGo.Value != "updateCache" && (isCache || objIview.requestJSON))
            {
                //Call service     
                if (!objIview.requestJSON)
                {
                    if (Session["IsFromChildWindow"] != null && objParams.ParamXML != string.Empty)//&& Session["IsFromChildWindow"] == "true"
                    {
                        ires = objParams.ParamXML;
                        Session["IsFromChildWindow"] = null;
                        ires = ReturnModified(ires);
                        //objIview.ParamXML = ires;
                        Session["UpdateParamsCollection"] = null;
                    }
                    else
                    {
                        try
                        {
                            if (objIview.IsDirectDBcall)
                            {
                                if (paramsCache == "Session")
                                {
                                    if (HttpContext.Current.Session[iName + "_" + sid] != null)
                                    {
                                        ires = HttpContext.Current.Session[iName + "_" + sid].ToString();
                                    }
                                }
                                else if (paramsCache == "InMemory")
                                {

                                    ires = fObj.StringFromRedis(util.GetRedisServerkey(fdKeyIVIEWPARAM, iName));
                                }

                            }
                            else
                            {
                                if (HttpContext.Current.Session[iName + "_" + sid] != null)
                                {
                                    ires = HttpContext.Current.Session[iName + "_" + sid].ToString();
                                }

                                if (ires == String.Empty)
                                {
                                    ires = fObj.StringFromRedis(util.GetRedisServerkey(fdKeyIVIEWPARAM, iName));
                                }
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            if (!objIview.requestJSON)
            {
                if (ires == string.Empty)
                {
                    //Call “GetParams” web service. -> (Structure xml also will be retuned during first call -> new change)
                    ires = objWebServiceExt.CallGetParamsWS(iName, iXml, objIview);
                    requestProcess_logtime += ires.Split('♠')[0];
                    ires = ires.Split('♠')[1];
                    if (ires != string.Empty && callParamPlusStructure)
                    {
                        string[] splitRes = ires.Split(new[] { "#$#" }, StringSplitOptions.None);
                        if (splitRes.Length == 2)
                        {
                            objParams.ParamXML = ires = splitRes[0];
                            istructure = splitRes[1];
                            if (istructure != string.Empty)
                            {
                                FDW fdwObj = FDW.Instance;
                                //  Keep XML in cache.
                                fdwObj.SaveInRedisServer(util.GetRedisServerkey(fdKeyIVIEWSTRUCT, iName), istructure, fdKeyIVIEWSTRUCT, schemaName);
                                callParamPlusStructure = false;
                                objIview.StructureXml = istructure;
                                isCache = false;
                                logobj.CreateDirectDBLog("openiview-dev-" + iName, "CallGetParams Plus Structure(firsttime=true) - GetParams", "", "IView Name :  " + iName, "Success --" + iName
                                                         + Environment.NewLine + "ISCached : " + isCache.ToString() + Environment.NewLine + " StructureXML : "
                                                         + Environment.NewLine + Environment.NewLine + objIview.StructureXml + Environment.NewLine + Environment.NewLine + " ParamXML :" + ires);
                            }
                        }
                    }
                    cacheParamsXML = true;
                }


                if (!cacheParamsXML)
                {
                    logobj.CreateDirectDBLog("openiview-dev-" + iName, "RedisCachedParams - GetParams", "", "IView Name :  " + iName, "Success --" + iName
                                                             + Environment.NewLine + "ISCached : " + (!cacheParamsXML).ToString() + " - ParamXML : "
                                                             + Environment.NewLine + Environment.NewLine + ires);
                }

                if (isCache)
                {
                    logobj.CreateDirectDBLog("openiview-dev-" + iName, "RedisCachedStructure - GetParams", "", "IView Name :  " + iName, "Success --" + iName
                                                             + Environment.NewLine + "ISCached : " + isCache.ToString() + " - StructureXML : "
                                                             + Environment.NewLine + Environment.NewLine + objIview.StructureXml);
                }

            }
            else
            {
                ires = objWebServiceExt.CallGetParamsWS(iName, iXml, objIview);
                requestProcess_logtime += ires.Split('♠')[0];
                ires = ires.Split('♠')[1];
                if (ires != string.Empty)
                {
                    string[] splitRes = ires.Split(new[] { "#$#" }, StringSplitOptions.None);
                    if (splitRes.Length > 0)
                    {
                        objParams.ParamXML = ires = splitRes[0];
                    }
                    if (splitRes.Length > 1)
                    {
                        objIview.AccessControlXml = splitRes[1];
                    }
                    if (splitRes.Length > 2)
                    {
                        objIview.StructureXml = istructure = splitRes[2];
                    }
                    if (splitRes.Length > 3)
                    {
                        objIview.DsIviewConfig = processXmlConfigAsDt(splitRes[3]);
                    }
                    if (splitRes.Length > 4)
                    {
                        objParams.GlobalVars = splitRes[4];
                    }
                    logobj.CreateDirectDBLog("openiview-dev-" + iName, "Call Params Plus Access Structure Config - GetParams", "",
                        "IView Name :  " + iName, "Success --" + iName + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        (splitRes.Length > 0 ? " ParamXML : " + splitRes[0] + Environment.NewLine + Environment.NewLine : "") +
                        (splitRes.Length > 1 ? " AccessControl : " + splitRes[1] + Environment.NewLine + Environment.NewLine : "") +
                        (splitRes.Length > 2 ? " StructureXML : " + splitRes[2] + Environment.NewLine + Environment.NewLine : "") +
                        (splitRes.Length > 3 ? " Configuration : " + splitRes[3] + Environment.NewLine + Environment.NewLine : "") +
                        (splitRes.Length > 4 ? " GlobalVars : " + splitRes[4] + Environment.NewLine + Environment.NewLine : ""));
                }
            }

            //Session["FilterParamResXML" + iName] = ires;

            DateTime asEnd = DateTime.Now;
            double webTime1 = asStart.Subtract(asStart).TotalMilliseconds;
            double webTime2 = DateTime.Now.Subtract(asEnd).TotalMilliseconds;
            double asbTime = asEnd.Subtract(asStart).TotalMilliseconds;
            AsbTime += "GetParams-" + asbTime.ToString();
            string errMsg = string.Empty;
            errMsg = util.ParseXmlErrorNode(ires);
            if (errMsg != string.Empty)
            {
                if (errMsg == Constants.SESSIONERROR)
                {
                    Session.RemoveAll();
                    Session.Abandon();
                    SessExpires();
                    return;
                }
                else if (errMsg == Constants.SESSIONEXPMSG)
                {
                    SessExpires();
                    return;
                }
                else if (errMsg == Constants.ERAUTHENTICATION)
                {
                    requestProcess_logtime += "Server - " + errMsg + " ♦ ";
                    Response.Redirect(util.ERRPATH + Constants.ERAUTHENTICATION + "*♠*" + requestProcess_logtime);
                }
                else
                {
                    requestProcess_logtime += "Server - " + errMsg + " ♦ ";
                    Response.Redirect(util.ERRPATH + errMsg + "*♠*" + requestProcess_logtime);
                }
            }
            else if (!objIview.requestJSON)
            {
                callParamPlusStructure = false;
                if (objIview.StructureXml != string.Empty)
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(objIview.StructureXml);
                    if (xmldoc.SelectSingleNode("//iview/b39") != null)
                        paramsCache = xmldoc.SelectSingleNode("//iview/b39").InnerText;
                }
                if (ires != "" && cacheParamsXML)
                {
                    try
                    {
                        if (paramsCache == "Session")
                        {
                            HttpContext.Current.Session[iName + "_" + sid] = ires;
                        }
                        else if (paramsCache == "InMemory")
                        {
                            FDW fdwObj = FDW.Instance;
                            fdwObj.SaveInRedisServer(util.GetRedisServerkey(fdKeyIVIEWPARAM, iName), ires, fdKeyIVIEWPARAM, schemaName);
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
            //}
        }
        else
        {
            ires = objParams.ParamXML;
            //Session["FilterParamResXML" + iName] = ires;
        }

        if (objIview.RetainIviewParams)
        {
            loadString = webService.GetIviewNavigationData(iName);
        }

        ConstructParamsHtml(ires);
    }

    private DataTable processXmlConfigAsDt(string configurationXml)
    {
        DataTable returnDt = new DataTable();

        try
        {
            FDW fdwObj = FDW.Instance;
            if (configurationXml != string.Empty)
            {
                logobj.CreateDirectDBLog("openiview-dev-" + iName, "ConfigurationXML", "", "IView Name :  " + iName, "ConfigurationXML : " + Environment.NewLine + Environment.NewLine + configurationXml);

                configurationXml = configurationXml.Replace("<axconfig>", "<dataSet>").Replace("</axconfig>", "</dataSet>").Replace("<row>", "<table0>").Replace("</row>", "</table0>");

                bool isRedisConnected = fdwObj.IsConnected;
                string axpStructKeyIview = Constants.AXCONFIGIVIEW; //Constants.AXCONFIGURATIONS;       
                string axpConfigTableIview = Constants.AXNODATACONFIGIVIEW; //Constants.AXCONFIGURATIONTABLE;

                DataTable axpConfigStrIview = new DataTable();
                bool isAxpConfig = true;
                string axpConfigTblIview = string.Empty;

                DataSet dsConfig = new DataSet();
                StringReader strReader = new StringReader(configurationXml);
                dsConfig.ReadXml(strReader);

                if (dsConfig.Tables["Table0"] == null || dsConfig.Tables["Table0"].Rows.Count == 0)
                {
                    isAxpConfig = false;
                }

                if ((axpConfigStrIview == null || axpConfigStrIview.Rows.Count == 0) && (isAxpConfig == false || (isAxpConfig && (dsConfig == null || dsConfig.Tables.Count == 0 || dsConfig.Tables["Table0"].Rows.Count == 0))) && axpConfigTblIview == string.Empty && isRedisConnected)
                    fdwObj.SaveInRedisServer(util.GetNoDataConfigCacheKey(axpConfigTableIview, "", iName, AxRole, "ALL"), "NoData", axpConfigTableIview, schemaName);


                if (isRedisConnected)
                {
                    if (dsConfig.Tables.Count > 0 && dsConfig.Tables["Table0"] != null && dsConfig.Tables["Table0"].Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        dt = dsConfig.Tables[0];
                        fdwObj.SaveInRedisServerDT(util.GetConfigCacheKey(axpStructKeyIview, "", iName, AxRole, "ALL"), dt, axpStructKeyIview, schemaName);
                        axpConfigStrIview = dt;
                    }

                }
                else
                    axpConfigStrIview = dsConfig.Tables[0];

                if ((axpConfigStrIview != null) && (axpConfigStrIview.Rows.Count > 0))
                {
                    objIview.DsIviewConfig = axpConfigStrIview;
                    returnDt = axpConfigStrIview;
                    objIview.GetAxpStructConfig(objIview);
                }
            }
        }
        catch (Exception ex) { }

        return returnDt;
    }

    private string GetParamsCacheType(string ires)
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ires);
            XmlNode rootNode = xmlDoc.SelectSingleNode("//root");

            if (rootNode != null && rootNode.Attributes["cachetype"] != null)
            {
                paramsCache = rootNode.Attributes["cachetype"].Value.ToString();
            }
            return paramsCache;
        }
        catch (Exception Ex) { }

        return String.Empty;
    }

    private string ReturnModified(string ires)
    {
        XmlDocument xmlDoc = new XmlDocument();
        Dictionary<string, string> DepFields;
        XmlNode responseNode;
        try
        {

            DepFields = (Dictionary<string, string>)Session["UpdateParamsCollection"];
            if (DepFields == null)
                return ires;

            xmlDoc.LoadXml(ires);
            foreach (var depField in DepFields)
            {

                responseNode = xmlDoc.SelectSingleNode("//" + depField.Key.ToString() + "/response");
                if (responseNode != null)
                    responseNode.InnerXml = depField.Value;
                else
                {
                    responseNode = xmlDoc.SelectSingleNode("//" + depField.Key.ToString());
                    XmlElement elem = xmlDoc.CreateElement("response");
                    elem.InnerXml = depField.Value;
                    responseNode.AppendChild(elem);
                }

            }
        }
        catch (Exception exc)
        {
            return ires;
        }
        return xmlDoc.OuterXml.ToString();
    }

    ///Function to get the iview data by calling the service.
    public void GetIviewData()
    {
        if (objIview.IsDirectDBcall)
        {
            getAjaxIviewData = false;
        }
        else if (globalGetAjaxIviewData)
        {
            getAjaxIviewData = true;
        }
        else
        {
            getAjaxIviewData = false;
        }
        // lol1.Style.Add("display", "block");
        iviewFrame.Style.Add("display", "block");
        if (!IsPostBack)
        {
            //ScriptManager.ScriptResourceMapping.AddDefinition("smartviewsbundle", new ScriptResourceDefinition
            //{
            //    Path = "~/Js/smartviews",
            //});
            loadString = loadString.Replace("&grave;", "~");
            string[] loadArr = loadString.Split('&');
            bool loadArrayExist = loadArr.Length > 0;
            if ((Request.Form.Count > 0 && Request.Form["redisLoadKey"] == null))
            {
                string ixml1 = string.Empty;
                int j = 0;
                for (j = 0; j < iviewParams.Count; j++)
                {
                    bool isParamExist = false;
                    for (int i = 0; i < Request.Form.Keys.Count; i++)
                    {
                        if (iviewParams[j].ToString().ToLower() == Request.Form.Keys[i].ToString().ToLower())
                        {
                            if (Request.Form.Keys[i].ToString() != "pop" && Request.Form.Keys[i].ToString() != "AxHypTstRefresh" && Request.Form.Keys[i].ToString() != "reqProc_logtime")
                            {
                                string val = string.Empty;
                                val = Request.Form[i].ToString();
                                //val = val.Replace("quot;", "'");
                                val = util.CheckReverseUrlSpecialChars(val);
                                val = util.ReverseCheckSpecialChars(val);
                                ixml1 += Request.Form.Keys[i].ToString() + "~" + val + "¿";
                            }
                            isParamExist = true;
                            break;
                        }
                    }
                    if (isParamExist)
                        continue;

                    string pVal = string.Empty;
                    pVal = iviewParamValues[j].ToString();
                    pVal = pVal.Replace("quot;", "'");
                    if (iviewParams[j].ToString() != "axp_refresh")
                        ixml1 += iviewParams[j].ToString() + "~" + pVal + "¿";

                }
                hdnparamValues.Value = ixml1;
                Session["paramValues" + iName] = ixml1;

            }
            else if (loadArrayExist)
            {
                string ixml1 = string.Empty;
                int j = -1;
                foreach (string par in iviewParams) {
                    bool isParamExist = false;

                    j++;

                    foreach (string loadStr in loadArr)
                    {
                        string[] keyValArr = loadStr.Split('=');
                        try
                        {
                            string key = keyValArr[0];
                            string value = keyValArr[1].Replace("--.--", "&").Replace("@eq@", "=").Replace("~", "&grave;");

                            if (par.ToLower() == key.ToLower()) {
                                if (loadStr != "pop" && key != "AxHypTstRefresh" && key != "reqProc_logtime")
                                {
                                    string val = string.Empty;
                                    val = value;
                                    //val = val.Replace("quot;", "'");
                                    val = util.CheckReverseUrlSpecialChars(val);
                                    val = util.ReverseCheckSpecialChars(val);
                                    ixml1 += key.ToString() + "~" + val + "¿";
                                }
                                isParamExist = true;
                                break;
                            }
                        }
                        catch (Exception ex) { }
                    }
                    if (isParamExist)
                        continue;

                    string pVal = string.Empty;
                    pVal = iviewParamValues[j].ToString();
                    pVal = pVal.Replace("quot;", "'");
                    if (iviewParams[j].ToString() != "axp_refresh")
                        ixml1 += iviewParams[j].ToString() + "~" + pVal + "¿";
                }
                hdnparamValues.Value = ixml1;
                Session["paramValues" + iName] = ixml1;
            }
        }
        else
        {
            //If the iview is laoded from a drilldown and refreshed through child window, 
            //the parameters were not being saved as param html construction is not handling set param values from request.from,
            //hence storing it in the viewstate and in postback setting the param values from viewstate.
            if (Request.Form.Count > 0 && Request.Form.Keys[0] != "ScriptManager1" && Request.Form["redisLoadKey"] == null)
            {
                if (Session["paramValues" + iName] != null)
                    hdnparamValues.Value = Session["paramValues" + iName].ToString();
            }
            else
            {
                ResetParamsOnSaveCHWindow(true);
                if (!string.IsNullOrEmpty(hdnparamValues.Value))
                    Session["paramValues" + iName] = hdnparamValues.Value;
                //else if (Session["paramValues" + iName] != null)  // commented because it is re loading the previous selected or filled params if not filled any params in this instance
                //    hdnparamValues.Value = Session["paramValues" + iName].ToString();

            }
        }

        if (Session["project"] == null || Convert.ToString(Session["project"]) == string.Empty)
        {
            SessExpires();
        }
        else
        {
            if (hdnGo.Value == "Go")
            {
                currentPageNo = 1;
            }
            else if (isFromPopup && Session["ivPageNum"] != null && Session["ivPageNum"].ToString() != "")
            {
                currentPageNo = Convert.ToInt32(Session["ivPageNum"]);
                Session["ivPageNum"] = null;
            }
            else if (string.IsNullOrEmpty(lvPage.SelectedValue) | hdnGo.Value == "TSSave")
            {
                currentPageNo = 1;
                if (Session["currentPageNo" + iName] != null)
                {
                    currentPageNo = Convert.ToInt32(Session["currentPageNo" + iName]);
                    Session["currentPageNo" + iName] = null;
                }
            }
            else
            {
                currentPageNo = Convert.ToInt32(lvPage.SelectedValue);
                if (Session["currentPageNo" + iName] != null)
                {
                    currentPageNo = Convert.ToInt32(Session["currentPageNo" + iName]);
                    Session["currentPageNo" + iName] = null;
                }
            }

            if (globalGetAjaxIviewData)
                if (!getAjaxIviewData && objIview.IsDirectDBcall && IsMulSelPrmsSQL(GetSqlFromStructure(objIview.StructureXml)))
                {
                    objIview.IsDirectDBcall = false;
                    getAjaxIviewData = true;
                }
            if (hdnGo.Value != "clear")
            {
                if (!getAjaxIviewData)
                    CallWebservice(currentPageNo.ToString(), "yes");
                else
                {
                    GenericRedisFunction2();

                    ConstructParamXml();

                    string idata = string.Empty;

                    if (iName == "inmemdb")
                    {
                        //dvRefreshParam.Visible = false;

                        XmlDocument doc1 = new XmlDocument();
                        doc1 = GetRedisData();
                        idata = doc1.OuterXml;
                    }
                    else
                    {
                        if (redisLoadKey != string.Empty && redisLoadKey != null)
                        {
                            idata = processNotificationLoadData(redisLoadKey, user, schemaName);
                        }

                        string sql = "";
                        string cols = "";
                        string hyp = "";
                        if (idata == string.Empty)
                        {
                            string lvXml = string.Empty;
                            if (Request.QueryString["tstcaption"] != null)
                            {
                                if (hdnLvChangedStructure.Value != "")
                                {
                                    // sql = hdnLvChangedStructure.Value;
                                    if (hdnLvChangedStructure.Value == "main")
                                    {
                                        hdnLvChangedStructure.Value = objIview.StructureXml;
                                    }
                                }
                                else
                                {
                                    cols = hdnLvSelectedCols.Value;
                                    hyp = hdnLvSelectedHyperlink.Value;
                                }
                                lvXml =
                                "<listviewCols>" +
                                    "<selectedCols>" + cols + "</selectedCols>" +
                                    "<selectedHyperlink>" + hyp + "</selectedHyperlink>" +
                                //"<changedLvSQL>" + sql + "</changedLvSQL>"+
                                "</listviewCols>";
                            }
                            idata = objIview.GetData(iName, hdnWebServiceViewName.Value == "" ? 1 : 0, objIview.iviewDataWSRows, pXml, lvXml, objIview.purposeString, hdnLvChangedStructure.Value).ToString();

                            requestProcess_logtime += idata.Split('♠')[0];
                            idata = idata.Split('♠')[1];

                            if (cols != "" && hyp != "")
                            {
                                string[] resultSplitter = idata.Split(new[] { "#$#" }, StringSplitOptions.None);
                                idata = resultSplitter[0];
                                if (resultSplitter.Length > 1)
                                {
                                    try
                                    {
                                        hdnLvChangedStructure.Value = resultSplitter[1];

                                        //hdnLvChangedStructure.Value = util.CheckReverseUrlSpecialChars(hdnLvChangedStructure.Value).Replace("/\"/", "\"");

                                        logobj.CreateDirectDBLog("openiview-dev-" + iName, "Call ListView Cols Plus Structure - GetData", "",
                                            "IView Name :  " + iName, "Success --" + iName + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                                            (resultSplitter.Length > 1 ? " StructureXML : " + resultSplitter[1] + Environment.NewLine + Environment.NewLine : ""));
                                    }
                                    catch (Exception ex) { }
                                }
                            }
                        }
                        try
                        {
                            idata = splitAndParseJsonResponse(idata);
                        }
                        catch (Exception ex) { }

                        if (redisLoadKey == null || redisLoadKey == string.Empty)
                        {
                            hdnWebServiceViewName.Value = "";
                        }
                    }

                    parseError(idata.ToString());

                    try
                    {
                        if (!objIview.requestJSON || iName == "inmemdb")
                        {
                            XmlDocument doc = new XmlDocument();
                            //Session["result" + iName] = idata;
                            doc.LoadXml(idata.ToString());
                            //get action node from structure xml
                            if (!string.IsNullOrEmpty(objIview.StructureXml))
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(objIview.StructureXml);
                                XmlNode structureAction = xmlDoc.SelectSingleNode("//actions");
                                if (structureAction != null)
                                {
                                    XmlNode tempNode = doc.ImportNode(structureAction, true);
                                    doc.DocumentElement.AppendChild(tempNode);
                                }
                            }

                            //get configurations
                            if (objIview.DsIviewConfig != null && (objIview.DsIviewConfig.Rows.Count > 0))
                            {
                                DataSet ds = new DataSet();
                                ds.Merge(objIview.DsIviewConfig.Copy());
                                ds.DataSetName = "configurations";
                                ds.Tables[0].TableName = "config";
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(ds.GetXml());
                                XmlNode tempNode = doc.ImportNode(xmlDoc.DocumentElement, true);
                                doc.DocumentElement.AppendChild(tempNode);
                            }

                            DataTable templateDT = new DataTable();
                            templateDT = getTempleteStringChoices(iName);
                            if (templateDT.Rows.Count > 0)
                            {
                                DataSet ds = new DataSet();
                                ds.Tables.Add(templateDT.Copy());
                                ds.DataSetName = "templetes";
                                ds.Tables[0].TableName = "templete";
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(ds.GetXml());
                                XmlNode tempNode = doc.ImportNode(xmlDoc.DocumentElement, true);
                                doc.DocumentElement.AppendChild(tempNode);
                            }

                            CreateToolbarButtons(doc);
                            GetSubCaptions(doc);
                            if (!objIview.requestJSON)
                            {
                                CreateHeaderRow(doc, "1", "yes");
                            }

                            if (pivotGroupHeaderNames.Count > 0)
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", String.Empty);
                                xmlDoc.PrependChild(xmlDec);
                                XmlElement elemRoot = xmlDoc.CreateElement("PivotAndMerge");
                                XmlElement elem = null;
                                int dataIndex = 0;
                                foreach (string head in pivotGroupHeaderNames)
                                {
                                    dataIndex++;

                                    XmlNode newElem = xmlDoc.CreateNode("element", "header" + dataIndex.ToString(), "");
                                    newElem.InnerText = head;

                                    XmlAttribute sKey = xmlDoc.CreateAttribute("s");
                                    sKey.Value = pivotStartCol[dataIndex - 1].ToString();
                                    XmlAttribute eKey = xmlDoc.CreateAttribute("e");
                                    eKey.Value = pivotEndCol[dataIndex - 1].ToString();

                                    newElem.Attributes.Append(sKey);
                                    newElem.Attributes.Append(eKey);

                                    elemRoot.AppendChild(newElem);
                                }
                                xmlDoc.AppendChild(elemRoot);
                                XmlNode tempNode = doc.ImportNode(xmlDoc.DocumentElement, true);
                                doc.DocumentElement.AppendChild(tempNode);
                            }

                            hdnIViewData.Value = JsonConvert.SerializeXmlNode(doc);
                        }
                        else
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(objIview.StructureXml.ToString());

                            CreateToolbarButtons(doc);
                            GetSubCaptions(doc);
                            //CreateHeaderRow(doc, "1", "yes");

                            hdnIViewData.Value = idata;
                        }
                    }
                    catch (Exception ex)
                    {
                        logobj.CreateLog("Iview Data Parsing Exception: " + ex.Message, sid, "openiview-dev-" + iName, "");
                    }
                    //}
                    GridView1.Visible = false;
                    GridView2Wrapper.Visible = true;
                }
            }


            string strUrlParams = hdnparamValues.Value;

            strUrlParams = strUrlParams.Replace("~", "=");
            strUrlParams = strUrlParams.Replace("¿", "&");
            if (objIview.FromHyperLink != null && objIview.FromHyperLink.ToString().ToUpper() != "TRUE")
                util.UpdateNavigateUrl("ivtoivload.aspx?ivname=" + iName + "&" + strUrlParams);
        }
    }

    private string splitAndParseJsonResponse(string result)
    {
        if (objIview.requestJSON)
        {
            string[] resultSplitter = result.Split(new[] { "#$#" }, StringSplitOptions.None);
            JObject resultJSON = JObject.Parse(resultSplitter[0]);

            JObject resultData = null;

            if (resultJSON["pivot"] != null && resultJSON["pivot"]["pivot"] != null && resultJSON["pivot"]["pivot"].ToString() == "true")
            {
                objIview.isPivotReport = true;
                // objIview.iviewDataWSRows = 0;
            }

            //json response data only
            if (resultJSON["data"] != null)
            {
                resultData = (JObject)resultJSON["data"];
            }
            //if json data contains headrow then add them in object and cache
            if (resultSplitter[0] != string.Empty && resultData != null && (resultData["headrow"] != null))
            {
                try
                {
                    objIview.headerJSON = resultData["headrow"].ToString().Trim();
                }
                catch (Exception ex) { }

                if (objIview.headerJSON == null)
                {
                    objIview.headerJSON = string.Empty;
                }
            }
            else if (resultSplitter[0] != string.Empty && resultData != null && resultData["headrow"] == null && objIview.headerJSON != string.Empty)
            {
                resultData["headrow"] = JObject.Parse(objIview.headerJSON);
            }

            //if json data contains report headers and footers then add them in object and cache
            if (resultSplitter[0] != string.Empty && resultData != null && (resultData["reporthf"] != null))
            {
                try
                {
                    objIview.reportHF = resultData["reporthf"].ToString().Trim();
                }
                catch (Exception ex) { }

                if (objIview.reportHF == null)
                {
                    objIview.reportHF = string.Empty;
                }
            }
            else if (resultSplitter[0] != string.Empty && resultData != null && resultData["reporthf"] == null && objIview.reportHF != string.Empty)
            {
                resultData["reporthf"] = JObject.Parse(objIview.reportHF);
            }

            if (objIview.reportHF != string.Empty)
            {
                try
                {
                    JObject reporthf = JObject.Parse(objIview.reportHF);
                    if (Session["AxShowAppTitle"] != null && Session["AxShowAppTitle"].ToString().ToLower() == "true")
                    {
                        if (Session["AxAppTitle"] != null && Session["AxAppTitle"].ToString() != string.Empty)
                        {
                            reporthf["exportAppTitle"] = Session["AxAppTitle"].ToString();
                        }
                        else if (Session["projTitle"] != null && Session["projTitle"].ToString() != string.Empty)
                        {
                            reporthf["exportAppTitle"] = Session["projTitle"].ToString();
                        }
                    }
                    objIview.reportHF = (resultData["reporthf"] = reporthf).ToString();
                }
                catch (Exception ex) { }
            }


            //if json data contains template then add it to object and cache
            if (resultSplitter.Length > 1)
            {
                try
                {
                    objIview.ivRowTemplate = resultSplitter[1].Trim();//html can also contain ~ symbol
                }
                catch (Exception ex) { }
            }
            if (resultSplitter.Length > 2)
            {
                try
                {
                    objIview.smartviewSettings = resultSplitter[2].Trim();
                }
                catch (Exception ex) { }
            }
            //if row template exist then add it to json in proper heirarchy
            if (objIview.ivRowTemplate != string.Empty)
            {
                try
                {
                    JObject template = JObject.Parse(objIview.ivRowTemplate);
                    if (resultData != null && template != null)
                    {
                        resultData.Add("templetes", template);
                    }
                }
                catch (Exception ex) { }
            }

            if (objIview.smartviewSettings != string.Empty)
            {
                try
                {
                    //string[] smartviewSettingsSplitter = objIview.smartviewSettings.Split('~');
                    //if (smartviewSettingsSplitter.Length == 1)
                    //{
                    //    Array.Resize(ref smartviewSettingsSplitter, smartviewSettingsSplitter.Length + 1);
                    //    smartviewSettingsSplitter[1] = "";
                    //}

                    JObject settings = new JObject();

                    settings.Add("settings", JObject.Parse(objIview.smartviewSettings));
                    //settings.Add("ELEMENTS", smartviewSettingsSplitter[1]);

                    if (resultData != null && objIview.smartviewSettings != "")
                    {
                        resultData.Add("smartview", settings);
                    }
                }
                catch (Exception ex) { }
            }

            if (objIview.DsIviewConfig != null && (objIview.DsIviewConfig.Rows.Count > 0))
            {
                JObject jObj = null;
                jObj = generateConfigurationJson(objIview.DsIviewConfig);
                if (jObj != null)
                {
                    resultData.Add("configurations", jObj);
                }
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(objIview.StructureXml.ToString());
                XmlNode structureAction = doc.SelectSingleNode("//actions");
                if (structureAction != null)
                {
                    resultData.Add("actions", JObject.Parse(JsonConvert.SerializeXmlNode(structureAction))["actions"]);
                }
            }
            catch (Exception ex) { }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(objIview.StructureXml.ToString());
                XmlNode structureScripts = doc.SelectSingleNode("//scripts");
                if (structureScripts != null)
                {
                    resultData.Add("scripts", JObject.Parse(JsonConvert.SerializeXmlNode(structureScripts))["scripts"]);
                }
            }
            catch (Exception ex) { }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(objIview.StructureXml.ToString());
                XmlNode structureAction = doc.SelectSingleNode("//hyperlinks");
                if (structureAction != null)
                {
                    resultData.Add("hyperlinks", JObject.Parse(JsonConvert.SerializeXmlNode(structureAction))["hyperlinks"]);
                }
            }
            catch (Exception ex) { }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(objIview.StructureXml.ToString());
                XmlNode structureAction = doc.SelectSingleNode("//comps");
                if (structureAction != null)
                {
                    resultData.Add("comps", JObject.Parse(JsonConvert.SerializeXmlNode(structureAction))["comps"]);
                }
            }
            catch (Exception ex) { }

            result = resultJSON.ToString();
            //caching row tempate and configuration logic
        }
        return result;
    }

    private void parseError(string data)
    {
        string errMsg = string.Empty;
        string returnString = string.Empty;
        if (!objIview.requestJSON || data.StartsWith(Constants.ERROR))
        {
            returnString = util.ParseXmlErrorNode(data);
        }
        else
        {
            returnString = util.ParseJSonErrorNode(data, false);
        }
        errMsg = returnString;
        if (errMsg != string.Empty)
        {
            if (errMsg == Constants.SESSIONERROR)
            {
                Session.RemoveAll();
                Session.Abandon();
                SessExpires();
            }
            else if (errMsg == Constants.SESSIONEXPMSG)
            {
                SessExpires();
            }
            else if (errMsg == Constants.ERAUTHENTICATION)
            {
                requestProcess_logtime += "Server - " + errMsg + " ♦ ";
                Response.Redirect(util.ERRPATH + Constants.ERAUTHENTICATION + "*♠*" + requestProcess_logtime);
            }
            else
            {
                errMsg = errMsg.Replace("\n", string.Empty);
                requestProcess_logtime += "Server - " + errMsg + " ♦ ";
                Response.Redirect(util.ERRPATH + errMsg + "*♠*" + requestProcess_logtime, false);
            }
        }
    }

    ///Function to call the webservice
    public void CallWebservice(string pageNo, string firstTime)
    {
        if (firstTime == "yes" && pageNo == "1")
        {
            resetIViewWithoutRowCount();
        }
        string iXml = string.Empty;
        errLog = logobj.CreateLog("Call to GetIView Web Service for page no " + pageNo, sid, fileName, string.Empty);

        if (Session != null)
        {
            if (Session["iv_noofpages"] != null)
            {
                totalRows = Convert.ToInt32(Session["iv_noofpages"].ToString());
            }
            if (!String.IsNullOrEmpty(objIview.DirectDbtotalRows.ToString()) && objIview.DirectDbtotalRows != 0)
            {
                directDbtotalRows = Convert.ToInt32(objIview.DirectDbtotalRows.ToString());
            }
        }

        if (hdnparamValues.Value != objIview.paramCacheString)
        {
            resetIViewWithoutRowCount();
        }

        if (objIview.iviewDataWSRows < Convert.ToInt32(gridPageSize))
        {
            objIview.iviewDataWSRows = Convert.ToInt32(gridPageSize);
        }
        else if (gridPageSize != "" && Convert.ToInt32(gridPageSize) == 0)
        {
            objIview.iviewDataWSRows = 0;
            //objIview.getIviewRowCount = true;
        }

        bool cacheIviewInDT = (!objIview.getIviewRowCount && !objIview.IsDirectDBcall && !objIview.lastPageCached && (objIview.newPagesArray.IndexOf(currentPageNo) == objIview.newPagesArray.Count - 1) || objIview.newPagesArray.IndexOf(currentPageNo) < 0) && (currentPageNo * Convert.ToInt32(gridPageSize) != objIview.realRowCount);

        int wsCallPageNumber = 0;
        if (objIview.getIviewRowCount || objIview.IsDirectDBcall)
        {
            wsCallPageNumber = Convert.ToInt32(pageNo);
        }
        else if (cacheIviewInDT)
        {
            //wsCallPageNumber = Convert.ToInt32(Math.Ceiling((currentPageNo + 1) / Math.Ceiling(Convert.ToDouble(objIview.iviewDataWSRows / Convert.ToDouble(gridPageSize)))));
            // getIviewRowCount = objIview
            wsCallPageNumber = ++objIview.cachedPage;
        }
        //gridPageSize = "1000";
        if (IsSqlPagination == "true" && pageNo != "1")
        {
            iXml = "<root " + objIview.purposeString + " name ='" + iName + "' axpapp = '" + proj + "' sessionid = '" + sid + "' appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "' trace = '" + errLog + "' pageno='" + wsCallPageNumber.ToString() + "' pagesize='" + (objIview.getIviewRowCount || objIview.IsDirectDBcall ? gridPageSize : objIview.iviewDataWSRows.ToString()) + "' firsttime='" + firstTime + "' sqlpagination='" + IsSqlPagination.ToLower() + "' getrowcount='" + objIview.getIviewRowCount.ToString().ToLower() + "' gettotalrows='false' smartview='true'><params> ";
        }
        else
        {
            iXml = "<root " + objIview.purposeString + " name ='" + iName + "' axpapp = '" + proj + "' sessionid = '" + sid + "' appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "' trace = '" + errLog + "' pageno='" + wsCallPageNumber.ToString() + "' pagesize='" + (objIview.getIviewRowCount || objIview.IsDirectDBcall ? gridPageSize : objIview.iviewDataWSRows.ToString()) + "' firsttime='" + firstTime + "' sqlpagination='" + IsSqlPagination.ToLower() + "' getrowcount='" + objIview.getIviewRowCount.ToString().ToLower() + "' gettotalrows='false' smartview='true'><params> ";
        }
        ConstructParamXml();
        iXml = iXml + pXml + "</params>";
        objParams.IviewParamString = pXml;
        iXml += Session["axApps"].ToString() + Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</root>";
        // iview caching : below line of code checks , selected parameter/(s) is(are) cached or not.
        // if not cached it generats .xml file for selected parameter and save at defined location.
        // if parameter/(s) is(are) already cached and they are not same as the one constructed, delete the folder and save the new param file in the directory.

        if (IsSqlPagination == "true" && objParams.ParamsExist)
        {

        }
        else
        {
            xmlParamDoc.LoadXml("<root>" + pXml + "</root>");
        }

        //Pivot arrays not included in this screen.
        logobj.CreateLog("Call to GetIView Web Service for page no " + pageNo, sid, fileName, string.Empty);
        logobj.CreateLog("Start Time " + DateTime.Now.ToString(), sid, fileName, string.Empty);
        logobj.CreateLog(string.Empty, sid, fileName, string.Empty);

        string ires = string.Empty;

        string errMsg = string.Empty;

        // iview caching : below line of code checks , iview page is cached or not.
        // if not cached it generats .xml file for iview and save at defined location.
        // if iview is already cached it does not make any web service call.


        if (objIview.IsPerfXml)
            isPageExist = false;


        XmlDocument xmlDoc = new XmlDocument();
        if (objIview.IsDirectDBcall)
        {
            xmlDoc = GetResultToXmlDoc(objIview.StructureXml, pageNo);
            CreateHeaderRow(xmlDoc, pageNo, firstTime);
        }

        if ((IsSqlPagination == "true" && !isPageExist) || !(IsSqlPagination == "true"))
        {
            DateTime asStart = DateTime.Now;
            if (objIview.IsDirectDBcall)
            {
                //util.licencedValidSessionCheck();
                logobj.CreateLog("called from directdb", sid, fileName, string.Empty);
                if (objIview.IVType == "Interactive")
                    gridPageSize = "0";
                // Call direct db call to get iview data.
                bool dbRes = GetIviewDataDBCall(iXml, pageNo, gridPageSize);//Checking whether iview params are multi select
                if (dbRes)
                {
                    if (objIview.DsDataSetDB != null)
                    {
                        totalRows = objIview.DsDataSetDB.Tables[0].Rows.Count;
                        if (currentPageNo == 1)
                        {
                            directDbtotalRows = Convert.ToInt32(objIview.DsDataSetDB.Tables[1].Rows[0][0]);
                            objIview.DirectDbtotalRows = directDbtotalRows;
                            objIview.GrandTotalRow.Clear();
                        }
                    }
                    Session["iv_noofpages"] = pageNo;

                }
                else
                {
                    objIview.IsDirectDBcall = false;
                    if (objIview.getIviewRowCount || cacheIviewInDT || Convert.ToInt32(gridPageSize) == 0)
                    {
                        // Call getiview web service

                        ires = objWebServiceExt.CallGetIViewWS(iName, iXml, objIview.StructureXml, objIview);
                        requestProcess_logtime += ires.Split('♠')[0];
                        ires = ires.Split('♠')[1];
                        if (ires == "")
                        {
                            logobj.CreateLog(String.Format("{ 0:dMyyyy HHmmss}", DateTime.Now) + Environment.NewLine + "CallGetIViewWS-" + ires + "-InputXMl-" + iXml, Session["nsessionid"].ToString(), "openiview-dev-" + iName, "", "true");
                        }
                    }
                    else
                    {
                        //util.licencedValidSessionCheck();
                        ires = objIview.iRes;
                    }

                    ParseIVResult(ires);

                }
            }
            else
            {
                if (objIview.getIviewRowCount || cacheIviewInDT || Convert.ToInt32(gridPageSize) == 0)
                {
                    // Call getiview web service -> (pass iview structure xml available in cache to this service -> new change)
                    ires = objWebServiceExt.CallGetIViewWS(iName, iXml, objIview.StructureXml, objIview);
                    requestProcess_logtime += ires.Split('♠')[0];
                    ires = ires.Split('♠')[1];
                    if (ires == "")
                    {
                        logobj.CreateLog(String.Format("{ 0:dMyyyy HHmmss}", DateTime.Now) + Environment.NewLine + "CallGetIViewWS-" + ires + "-InputXMl-" + iXml, Session["nsessionid"].ToString(), "openiview-dev-" + iName, "", "true");
                    }
                }
                else
                {
                    //util.licencedValidSessionCheck();
                    ires = objIview.iRes;
                }

                ParseIVResult(ires);
            }

            DateTime asEnd = DateTime.Now;
            double webTime1 = asStart.Subtract(asStart).TotalMilliseconds;
            double webTime2 = DateTime.Now.Subtract(asEnd).TotalMilliseconds;
            double asbTime = asEnd.Subtract(asStart).TotalMilliseconds;
            AsbTime += "GetIview-" + asbTime.ToString();
            errMsg = util.ParseXmlErrorNode(ires);
            objIview.CurrentPageNo = pageNo;
            objIview.iRes = ires;
        }

        if (errMsg != string.Empty)
        {
            if (errMsg == Constants.SESSIONERROR)
            {
                Session.RemoveAll();
                Session.Abandon();
                SessExpires();
            }
            else
            {
                errMsg = errMsg.Replace("\n", string.Empty);
                requestProcess_logtime += "Server - " + errMsg + " ♦ ";
                Response.Redirect(util.ERRPATH + errMsg + "*♠*" + requestProcess_logtime, false);
            }
        }
        else
        {
            logobj.CreateLog("Setting Iview components", sid, fileName, string.Empty);



            if (!objIview.IsDirectDBcall)
                xmlDoc = GetResultToXmlDoc(ires, pageNo);

            if (defaultBut == string.Empty || actionBtns.Count == 0)
            {
                defaultBut = string.Empty;
                actionBtns.Clear();
                CreateToolbarButtons(xmlDoc);
                GetSubCaptions(xmlDoc);
            }

            objIview.IvCaption = ivhead;

            XmlNodeList rowDataExist = default(XmlNodeList);
            XmlDocument xmlDocpv = new XmlDocument();

            if (ires == string.Empty)
            {
                ires = xmlDoc.InnerXml;
            }

            try
            {
                xmlDocpv.LoadXml(ires);
            }
            catch (Exception ex)
            {
                requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
                Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
            }


            rowDataExist = xmlDocpv.SelectNodes("//rowdata");
            if (rowDataExist.Count > 0)
            {
                hdnIsPerfXml.Value = "true";
                objIview.IsPerfXml = true;

            }


            if (!objIview.IsDirectDBcall)
                CreateHeaderRow(xmlDoc, pageNo, firstTime);



            //Pivot Header Definition Starts

            //ires = Session["result" + iName].ToString();

            XmlNodeList productNodespv = default(XmlNodeList);
            XmlNodeList baseDataNodespv = default(XmlNodeList);


            productNodespv = xmlDocpv.SelectNodes("//headrow");
            XmlNode hdRowNode = xmlDocpv.SelectSingleNode("//headrow");
            //Complete header xml..
            string hdRowXml = string.Empty;
            if (hdRowNode != null)
                hdRowXml = hdRowNode.OuterXml;

            foreach (XmlNode productNodepv in productNodespv)
            {
                baseDataNodespv = productNodepv.ChildNodes;
                foreach (XmlNode baseDataNodepv in baseDataNodespv)
                {
                    if (baseDataNodepv.Name == "pivotghead")
                    {
                        pivothead = baseDataNodepv.InnerXml;
                        XmlNodeList finalNodelist = default(XmlNodeList);
                        foreach (XmlNode base2node in baseDataNodepv)
                        {
                            finalNodelist = base2node.ChildNodes;
                            foreach (XmlNode finalNode in finalNodelist)
                            {
                                if (finalNode.Name == "sn")
                                {
                                    pivotStartCol.Add(finalNode.InnerText);
                                }
                                else if (finalNode.Name == "ghead")
                                {
                                    pivotGroupHeaderNames.Add(finalNode.InnerText);
                                }
                                else if (finalNode.Name == "en")
                                {
                                    pivotEndCol.Add(finalNode.InnerText);
                                }
                            }
                        }
                    }
                }
            }

            objIview.PivotMergeHeaders = pivotGroupHeaderNames;
            objIview.PivotStartCol = pivotStartCol;
            objIview.PivotEndCol = pivotEndCol;

            if (cac_pivot == null)
            {
                cac_pivot = sid + iName + "pivot";
            }


            Cache.Insert(cac_pivot, pivothead, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            //remove all other nodes other than data and call binddata
            XmlNode rnode = xmlDoc.SelectSingleNode("//headrow/pivotghead");
            if (rnode != null)
                rnode.ParentNode.RemoveChild(rnode);

            XmlNode cNode = xmlDoc.SelectSingleNode("//comps");
            string cNodeXml = cNode.OuterXml;


            if (objIview.IsPerfXml)
            {
                XmlNode cheadrow = xmlDoc.SelectSingleNode("//headrow");
                cheadrow.ParentNode.RemoveChild(cheadrow);
            }

            //Prepares header for printing filtered records.
            Session["res"] = cNodeXml + hdRowXml;
            cNode.ParentNode.RemoveChild(cNode);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);

            try
            {
                xmlDoc.WriteTo(xw);
            }
            catch (Exception ex)
            {
                requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
                Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
            }


            string nXml = null;
            if (objIview.IsDirectDBcall && objIview.DsDataSetDB != null && objIview.DsDataSetDB.Tables.Count > 0)
            {
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(objIview.DsDataSetDB.Tables[0].Copy());
                dsTemp.Tables[0].TableName = "row";
                nXml = dsTemp.GetXml();
                nXml = nXml.Replace(">\r\n    <", "><").Replace(">\r\n  <", "><");
                dsTemp = null;
                rXml.Value = nXml;
            }
            else
                nXml = sw.ToString();

            try
            {
                //Custom Iview data call before BindDataGrid()
                Custom custObj = Custom.Instance;
                nXml = custObj.AxBeforeIViewBindDataGrid(nXml, objIview.IName);
            }
            catch (Exception ex)
            {
                logobj.CreateLog("Custom Iview data call before BindDataGrid " + ex.Message, sid, "openiview-dev-" + iName, string.Empty);
            }

            // assign XML Val to input textbox

            objIview.IViewWhenEmpty = objIview.GetParamValue(hdnparamValues.Value, "axp_whenempty");
            if (objIview.IViewWhenEmpty == string.Empty)
                objIview.IViewWhenEmpty = lblNodataServer.Text;// Constants.REC_NOT_FOUND;


            rXml.Value = nXml;
            rXml.Value = rXml.Value.Replace("\"", "'");
            if (nXml == "<?xml version=\"1.0\" encoding=\"utf-8\"?><data></data>" || nXml == "<data></data>" || (objIview.IsPerfXml && totalRows == 0))
            {

                if (objIview.IsPerfXml)
                {
                    nXml = nXml.Replace("<data perfxml=\"true\">", "");
                    nXml = nXml.Replace("<data>", "");
                    nXml = nXml.Replace("</data>", "");
                }

                objIview.ResultXml = string.Empty;
                //records.Text = objIview.IViewWhenEmpty;
                hdnNoOfRecords.Value = string.Empty;
                pages.Text = string.Empty;
                BindDataGrid(nXml, totalRows, pageNo);//calling BindDataGrid(..) here to clear the grid as there is no data
            }
            else
            {
                //to handle scenario where the first page do not have all column data. 
                //we add the dummy headrow as row and then in binddatagrid remove the first row. 
                // TODO: the below string manipulation need to be relooked and see any other elegant solution possible.
                //  nXml = util.RemoveAppSessKeyAtt(nXml, "appsessionkey");// in concurrent user support added appsessionkey again its removing from the result.
                if (objIview.IsPerfXml)
                {
                    nXml = nXml.Replace("<data perfxml=\"true\">", "");
                    nXml = nXml.Replace("<data>", "");
                    nXml = nXml.Replace("</data>", "");
                }
                else
                {
                    if (nXml.IndexOf("headrow") != -1)
                    {
                        nXml = nXml.Replace("headrow", "row");
                        string tmpString = nXml.Substring(0, nXml.IndexOf("<row"));
                        string tmpString1 = nXml.Substring(nXml.IndexOf("<row"));
                        string tmpString2 = tmpString1.Substring(tmpString1.IndexOf(">") + 1);
                        nXml = tmpString + "<row>" + tmpString2;
                    }
                }
                objIview.ResultXml = nXml;
                objIview.TotalRows = totalRows;
                objIview.DirectDbtotalRows = directDbtotalRows;
                BindDataGrid(nXml, totalRows, pageNo);
                if (IsSqlPagination != "true")
                    lvPage.SelectedValue = pageNo;


            }


            generateJsonForGrid();

        }

    }

    public void initMergeAndPivot(String baseDataNodeName)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(objIview.StructureXml);
            //XmlNode a61a62Parent = doc.SelectSingleNode("//" + baseDataNodeName + "[@cat='querycol']");
            XmlNode a61a62Parent = doc.SelectSingleNode("//" + baseDataNodeName + "[@cat='querycol']");
            if (a61a62Parent == null)
            {
                if (baseDataNodeName != "axp__font" && baseDataNodeName != "axrowtype")
                {
                    submerge.Add("-");
                    submergecol.Add("-");
                }
            }
            else
            {
                XmlNode a61 = a61a62Parent.SelectSingleNode("//" + a61a62Parent.Name + "/a61");
                XmlNode a62 = a61a62Parent.SelectSingleNode("//" + a61a62Parent.Name + "/a62");
                if (a61 != null && a62 != null)
                {
                    structureMergeAndPivotLogic(a61);
                    structureMergeAndPivotLogic(a62);
                }
                else
                {
                    submerge.Add("-");
                    submergecol.Add("-");
                }
            }
        }
        catch (Exception ex) { }
    }

    public void structureMergeAndPivotLogic(XmlNode childNode)
    {
        switch (childNode.Name)
        {
            case "a61":

                if (childNode.InnerText == string.Empty)
                    submergecol.Add("-");
                else
                    submergecol.Add(childNode.InnerText);

                if (childNode.InnerText == "0")
                {
                    pivotStartCol.Add(submergecol.Count);
                }
                else
                {
                    if (submergecol[(submergecol.Count - 1)].ToString() != submergecol[submergecol.Count - 2].ToString())
                    {
                        int nodeData = -1;
                        try
                        {
                            nodeData = Convert.ToInt32(childNode.InnerText);
                        }
                        catch (Exception ex)
                        {
                            nodeData = Convert.ToInt32(pivotEndCol[pivotEndCol.Count - 1]);
                        }


                        if (nodeData <= Convert.ToInt32(pivotStartCol[pivotStartCol.Count - 1]))
                        {
                            incrementPivot = true;
                            pivotStartCol.Add(nodeData + 2);
                        }
                        else
                        {
                            pivotStartCol.Add(nodeData);
                        }
                    }
                }
                break;

            case "a62":
                int increment = 0;
                if (incrementPivot)
                {
                    increment = 2;
                    incrementPivot = false;
                }
                if (childNode.InnerText == string.Empty)
                    submerge.Add("-");
                else
                    submerge.Add(childNode.InnerText);

                if (childNode.InnerText == string.Empty)
                {
                    pivotGroupHeaderNames.Add("");
                    pivotEndCol.Add(submergecol.Count + 1 + increment);
                }
                else
                {
                    if (submerge[(submerge.Count - 1)].ToString() != submerge[submerge.Count - 2].ToString())
                    {
                        pivotGroupHeaderNames.Add(childNode.InnerText);
                        //pivotEndCol.Add(submerge.Count + 1 + increment);
                        pivotEndCol.Add(Convert.ToInt32(pivotStartCol[pivotEndCol.Count]) + 1);
                    }
                    else
                    {
                        pivotEndCol[pivotEndCol.Count - 1] = Convert.ToInt32(pivotEndCol[pivotEndCol.Count - 1]) + 1;
                    }
                }
                break;
            default:
                break;
        }
    }

    private void generateJsonForGrid()
    {
        if (colHide[0].ToString() == "false")
            HasCKB = true;

        jsonForGrid.RemoveAll();

        ArrayList smIvColType = new ArrayList(colType);
        ArrayList smIvHeadName = new ArrayList(headName);
        ArrayList smIvColFld = new ArrayList(colFld);
        ArrayList smIvColHide = new ArrayList(colHide);

        int fontColIndex = colFld.IndexOf("axp__font");

        if (fontColIndex >= 0)
        {
            smIvColType.RemoveAt(fontColIndex);
            smIvHeadName.RemoveAt(fontColIndex);
            smIvColFld.RemoveAt(fontColIndex);
            smIvColHide.RemoveAt(fontColIndex);
        }


        //string JsonString = JsonConvert.SerializeObject(ds1, Newtonsoft.Json.Formatting.Indented);
        jsonForGrid.Add("ColumnType", JsonConvert.SerializeObject(smIvColType, Newtonsoft.Json.Formatting.Indented));
        jsonForGrid.Add("HeaderText", JsonConvert.SerializeObject(smIvHeadName, Newtonsoft.Json.Formatting.Indented));
        jsonForGrid.Add("FieldName", JsonConvert.SerializeObject(smIvColFld, Newtonsoft.Json.Formatting.Indented));
        jsonForGrid.Add("HideColumn", JsonConvert.SerializeObject(smIvColHide, Newtonsoft.Json.Formatting.Indented));

        jsonForGrid.Add("HasCKB", JsonConvert.SerializeObject(HasCKB, Newtonsoft.Json.Formatting.Indented));


        string JsonString = JsonConvert.SerializeObject(jsonForGrid, Newtonsoft.Json.Formatting.Indented);
        //XmlDocument xml = JsonConvert.DeserializeXmlNode(JsonString);
        JsonString = JsonString.Replace("\\r\\n", "");
        jsonForGrid = JObject.Parse(JsonString);
        jsonForGrid["customObjIV"] = JsonConvert.SerializeObject(objIview.customBtnIV);
    }

    private void resetIViewWithoutRowCount()
    {
        if (objIview != null)
        {
            objIview.realRowCount = 0;
            objIview.lastPageCached = false;
            objIview.newPagesArray = new ArrayList();
            objIview.realPageSize = new List<int>();
            objIview.pageSizeWithGTandST = new ArrayList();
            objIview.dsIvPages = new DataSet();
            objIview.cachedPage = 0;
            objIview.paramCacheString = "";
        }
    }

    [WebMethod]
    public static object GetIViewData(string ivKey, int pageno = 0, int recsPerPage = 0, string paramX = "", string lvXml = "", string lvStructure = "")
    {
        string result = string.Empty, status = string.Empty;
        IviewData objIview = (IviewData)HttpContext.Current.Session[ivKey];
        //IviewParams objParams = (IviewParams)HttpContext.Current.Session[ivKey + "_param"];
        if (objIview == null)
            return new { status = "failure", result = Constants.ERAUTHENTICATION };
        string iVName = ivKey.Split('_')[0];

        var ds = objIview.GetData(iVName, pageno, recsPerPage, paramX, lvXml, objIview.purposeString, lvStructure);
        if (ds != null)
        {
            ds = ds.ToString().Split('♠')[1];

            string[] resultSplitter = ds.ToString().Split(new[] { "#$#" }, StringSplitOptions.None);
            ds = resultSplitter[0];
        }
        XmlDocument doc = new XmlDocument();
        try
        {
            if (!objIview.requestJSON)
            {
                doc.LoadXml(ds.ToString());
                var json = JsonConvert.SerializeXmlNode(doc);
                return new { status = "success", result = json };
            }
            else
            {
                return new { status = "success", result = ds.ToString() };
            }
        }
        catch (Exception ex)
        {
            return new { status = "failure", result = Constants.CUSTOMERROR };
        }
    }

    private void ParseIVResult(string ires)
    {
        if (ires.StartsWith("<error>"))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "IViewError", "<script>ShowDimmer(true);showAlertDialog('error','" + ires.Substring(7).Replace("'", "\"") + "');</script>");
        }

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(ires);
        XmlNode cNode = default(XmlNode);
        cNode = xmldoc.SelectSingleNode("//headrow");
        if (cNode != null)
        {
            string ivtype = "";
            if (cNode.Attributes["vtype"] != null)
            {
                ivtype = cNode.Attributes["vtype"].Value.ToString();
                if (ivtype == "i")
                {
                    objIview.IVType = "Interactive";
                }
                else
                {
                    objIview.IVType = "Classic";
                }
            }
            else
            {
                objIview.IVType = "Classic";
            }
        }
        else
        {
            objIview.IVType = "Classic";
        }
    }

    private void ClearHeaderArray()
    {
        paramxml.Value = pXml;
        headName.Clear();
        colWidth.Clear();
        colType.Clear();
        colHide.Clear();

        colFld.Clear();
        colDec.Clear();
        colApplyComma.Clear();
        colHlink.Clear();
        colHlinktype.Clear();
        colMap.Clear();
        colHAction.Clear();

        colAlign.Clear();
        colHlinkPop.Clear();
        colRefreshParent.Clear();
        colNoPrint.Clear();

        colNoRepeat.Clear();
        colZeroOff.Clear();
        submergecol.Clear();
        submerge.Clear();
        Session["sOrder"] = string.Empty;
        Session["sColumn"] = string.Empty;
        Session["fCol"] = string.Empty;
        Session["fColVal"] = string.Empty;
    }

    private XmlDocument GetResultToXmlDoc(string ires, string pageNo)
    {
        string loadXml = string.Empty;
        XmlDocument xmlDoc = new XmlDocument();
        string xmlFilePath = util.ScriptsPath + "axpert\\" + sid + "\\" + iName + "\\" + iName + "_" + pageNo + ".xml";
        try
        {
            isPageExist = false;
            // iview caching - if the cached file is not there create the folder and save .              
            if (IsSqlPagination == "true" && isPageExist)
            {
                fileName = "openiview-" + iName;
                logobj.CreateLog("load Iview from cache page no " + pageNo, sid, fileName, string.Empty);
                logobj.CreateLog("Start Time " + DateTime.Now.ToString(), sid, fileName, string.Empty);
                logobj.CreateLog(string.Empty, sid, fileName, string.Empty);
                XDocument document = XDocument.Load(xmlFilePath);
                ires = _xmlString + document.ToString();
                xmlDoc.LoadXml(ires);
                string Jsonstring = JsonConvert.SerializeXmlNode(xmlDoc);
            }
            else if (!(IsSqlPagination == "true") || isPageExist == false)
            {
                xmlDoc.LoadXml(ires);
            }
        }
        catch (Exception ex)
        {
            requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
            Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
        }

        ////////////////+++++Temporary fix for serial no until dll is fixed
        XmlNodeList productNodes = default(XmlNodeList);

        productNodes = xmlDoc.SelectNodes(".//row");
        foreach (XmlNode productNode in productNodes)
        {

            if (productNode.SelectSingleNode(".//column1") != null && (productNode.SelectSingleNode(".//column1").InnerText.ToLower() == "sr. no." || productNode.SelectSingleNode(".//column1").InnerText.ToLower() == "sr.no."))
            {

                productNode.SelectSingleNode(".//column1").InnerText = ((Convert.ToInt32(productNode.SelectSingleNode(".//rowno").InnerText) + (Convert.ToInt32(pageNo) * Convert.ToInt32(objIview.GrdPageSize))) - Convert.ToInt32(objIview.GrdPageSize)).ToString();
            }

        }
        ////////////////-----Temporary fix for serial no until dll is fixed

        //Session["result" + iName] = ires;
        return xmlDoc;
    }

    private void GetSubCaptions(XmlDocument xmlDoc)
    {
        XmlNodeList compNodes = default(XmlNodeList);
        XmlNodeList cbaseDataNodes = default(XmlNodeList);
        if (objIview.IsDirectDBcall)
        {
            compNodes = xmlDoc.SelectNodes("//root/comps");
        }
        else
        {
            compNodes = xmlDoc.SelectNodes("//comps");

        }
        ivhead.Clear();
        foreach (XmlNode compNode in compNodes)
        {
            cbaseDataNodes = compNode.ChildNodes;
            int compNodeCnt = 0;
            int toolbarBtnCnt = 0;
            toolbarBtnCnt = cbaseDataNodes.Count - 1;

            if (compNode.Name == "X__Head")
            {
                ivCaption = compNode.Attributes["caption"].ToString();
                ivCaption = ivCaption.Replace("&&", "&");
                lblHeading = ivCaption;
                objIview.IviewCaption = ivCaption;
            }


            for (compNodeCnt = 0; compNodeCnt <= toolbarBtnCnt; compNodeCnt++)
            {
                if (cbaseDataNodes[compNodeCnt].Name.Substring(0, 3) == "lbl")
                {
                    string ivHeading = string.Empty;
                    if (cbaseDataNodes[compNodeCnt].Attributes["hint"] != null && cbaseDataNodes[compNodeCnt].Attributes["hint"].Value != "")
                    {
                        ivHeading = cbaseDataNodes[compNodeCnt].Attributes["hint"].Value;
                    }
                    else if (cbaseDataNodes[compNodeCnt].Attributes["caption"] != null && cbaseDataNodes[compNodeCnt].Attributes["caption"].Value != "")
                    {
                        ivHeading = cbaseDataNodes[compNodeCnt].Attributes["caption"].Value;
                    }
                    ivHeading = ivHeading.Replace("&&", "&");
                    ivhead.Add(ivHeading);
                }
            }
        }
        if (ivhead.Count > 0)
        {
            ConstructSubHeading(ivhead);
        }
    }

    private void ConstructSubHeading(ArrayList ivhead)
    {
        int iv = 0;
        ivCap1.Controls.Clear();
        for (iv = 0; iv <= ivhead.Count - 1; iv++)
        {
            string subHeading = string.Empty;
            subHeading = ivhead[iv].ToString();
            if (subHeading.IndexOf(":") > -1)
            {
                subHeading = ReplaceSqlParamByvalues(subHeading, false);
            }
            subHeading = subHeading.Replace("&&", "&");
            HtmlGenericControl i = new HtmlGenericControl("i");
            i.Attributes.Add("class", "glyphicon glyphicon-chevron-right subb-heading icon-arrows-right");
            Label lbl = new Label();
            lbl.Text = subHeading;
            lbl.CssClass = "IVcapTxt";
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("runat", "server");
            div.Controls.Add(i);
            div.Controls.Add(lbl);
            ivCap1.Controls.Add(div);
        }
        if (ivCap1.Controls.Count > 0 && objIview.IVType != "Interactive")
            ivCap1.Visible = true;
        else
            ivCap1.Visible = false;
    }

    private DataSet GetStaggeredTables(DataSet ds)
    {
        int totalRowCount = ds.Tables[0].Rows.Count;

        List<DataTable> stagTables = SplitTable(ds.Tables[0], displayRowCnt);
        for (int i = 0; i < stagTables.Count; i++)
        {
            DataTable dtTemp = stagTables[i].Copy();
            if (dtTemp.Rows.Count == 1)
            {
                if (dtTemp.Rows[0]["axrowtype"].Equals("gtot"))
                {
                    stagTables[i - 1].Merge(dtTemp);
                    stagTables[i - 1].AcceptChanges();
                    displayRowCnt = stagTables[i - 1].Rows.Count;
                    stagTables.RemoveAt(i);
                }
            }
        }

        objIview.StagTables = stagTables;
        DataSet dsNew = new DataSet();
        DataTable dt = ds.Tables[0].Rows.Cast<System.Data.DataRow>().Take(displayRowCnt).CopyToDataTable();
        dsNew.Tables.Add(dt);
        hdnStagTableNo.Value = "1";
        return dsNew;

    }

    private static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
    {
        List<DataTable> tables = new List<DataTable>();
        int i = 0;
        int j = 1;
        int rowCnt = 0;
        DataTable newDt = originalTable.Clone();
        newDt.TableName = "Table_" + j;
        newDt.Clear();

        foreach (DataRow row in originalTable.Rows)
        {
            DataRow newRow = newDt.NewRow();
            newRow.ItemArray = row.ItemArray;
            newDt.Rows.Add(newRow);
            i++;
            rowCnt++;
            if (i == batchSize)
            {
                tables.Add(newDt);
                j++;
                newDt = originalTable.Clone();
                newDt.TableName = "Table_" + j;
                newDt.Clear();
                i = 0;
            }
            if (rowCnt == originalTable.Rows.Count && newDt.Rows.Count > 0)
            {
                tables.Add(newDt);
            }
        }
        return tables;
    }


    ///Bind the iview data to the gridview control.
    private void BindDataGrid(string a, int totRows, string pageNo)
    {
        hdnTotalRec.Value = totRows.ToString();
        GridView1.Columns.Clear();
        GridView1.DataSource = null;
        GridView1.DataBind();
        DataSet ds = new DataSet();
        DataSet dsFullData = new DataSet();
        int dataSetPage = 0;
        gvWidth = 0;
        objIview.paramCacheString = hdnparamValues.Value;
        if (!objIview.getIviewRowCount && !objIview.IsDirectDBcall && currentPageNo > 0)
        {
            dataSetPage = currentPageNo - 1;
        }
        try
        {
            //Process data to display.
            if (objIview.IsDirectDBcall)
            {
                hdnIsDirectDB.Value = "true";
                OrderGridColumns();
                ds = objIview.ApplySubTotal(objIview.DsDataSetDB, false, Convert.ToInt32(gridPageSize));
                dsFullData = ds;
            }
            else
            {
                hdnIsDirectDB.Value = "false";
                StringReader sr = new StringReader(a);
                dsFullData.ReadXml(sr);
                dsFullData.Tables[0].Rows.RemoveAt(0);
                //older iview WS
                if (objIview.getIviewRowCount)
                {
                    ds = dsFullData;
                }
                //new iview WS without total rows
                else if (!objIview.lastPageCached && ((objIview.newPagesArray.IndexOf(currentPageNo) == objIview.newPagesArray.Count - 1) || objIview.newPagesArray.IndexOf(currentPageNo) < 0) && ((currentPageNo * Convert.ToInt32(gridPageSize) != objIview.realRowCount) || Convert.ToInt32(gridPageSize) == 0) && dsFullData.Tables[0].Rows.Count > 0)
                {
                    int rnos = 0;
                    int realPS = 0;
                    int virtualPS = 0;
                    int startIndex = 0;
                    var tempPageNo = 0;

                    if (objIview.newPagesArray.Count == 0)
                    {
                        objIview.dsIvPages = dsFullData.Clone();
                        objIview.dsIvPages.Tables[0].TableName = "page1";
                    }
                    else
                    {
                        var pageIndex = objIview.newPagesArray.IndexOf(currentPageNo);
                        if (pageIndex >= 0)
                        {

                            realPS = objIview.realPageSize[pageIndex];
                            virtualPS = Convert.ToInt32(objIview.pageSizeWithGTandST[pageIndex]);
                            //startIndex = 0;

                        }
                        tempPageNo = currentPageNo - 1;
                        //rnos = objIview.realRowCount;

                    }


                    foreach (DataRow dr1 in dsFullData.Tables[0].Rows)
                    {

                        if (objIview.IsPerfXml)
                        {
                            realPS++;
                            virtualPS++;
                        }
                        else if (dsFullData.Tables[0].Rows[rnos][1].ToString() == "")
                        {

                            realPS++;
                            virtualPS++;
                        }
                        else
                        {
                            virtualPS++;
                        }

                        //to add new dataTable page
                        if (((realPS > Convert.ToInt32(gridPageSize) || (realPS > Convert.ToInt32(gridPageSize) - 1 && (!objIview.IsPerfXml && dr1[1].ToString() == "subhead"))) && Convert.ToInt32(gridPageSize) != 0) || ((realPS == 1 || virtualPS == 1) && objIview.dsIvPages.Tables.IndexOf("page" + (tempPageNo + 1)) < 0))
                        {
                            if (realPS != 1 && virtualPS != 1)
                            {
                                tempPageNo++;
                            }


                            DataTable dummtDT = objIview.dsIvPages.Tables[0].Clone();
                            dummtDT.TableName = "page" + (tempPageNo + 1);
                            if (objIview.dsIvPages.Tables[dummtDT.TableName] == null)
                            {
                                objIview.dsIvPages.Tables.Add(dummtDT);
                            }

                            if (realPS != 1 && virtualPS != 1)
                            {
                                if (objIview.IsPerfXml || dsFullData.Tables[0].Rows[rnos][1].ToString() == "")
                                {
                                    realPS = 1;
                                }
                                else
                                {
                                    realPS = 0;
                                }

                                virtualPS = 1;
                            }
                        }

                        //to add entry in arraylist
                        if (objIview.newPagesArray.IndexOf(tempPageNo + 1) < 0)
                        {
                            objIview.newPagesArray.Add(0);
                            objIview.realPageSize.Add(0);
                            objIview.pageSizeWithGTandST.Add(0);
                        }
                        objIview.newPagesArray[tempPageNo] = tempPageNo + 1;
                        objIview.realPageSize[tempPageNo] = realPS;
                        objIview.pageSizeWithGTandST[tempPageNo] = virtualPS;

                        objIview.dsIvPages.Tables[tempPageNo].ImportRow(dr1);




                        rnos++;
                    }

                    objIview.realRowCount = objIview.realPageSize.Sum();
                    if (objIview.iviewDataWSRows == 0)
                    {
                        objIview.iviewDataWSRows = objIview.realRowCount;
                        objIview.GrdPageSize = objIview.realRowCount.ToString();
                        objIview.lastPageCached = true;
                    }
                    if (objIview.realRowCount % objIview.iviewDataWSRows != 0)
                    {
                        objIview.lastPageCached = true;
                    }
                    totRows = objIview.realRowCount;


                    ds = objIview.dsIvPages;
                    dsFullData = ds;
                }
                else if (dsFullData.Tables[0].Rows.Count == 0 && !objIview.lastPageCached)
                {

                    objIview.lastPageCached = true;
                    totRows = objIview.realRowCount;
                    lnkNext.Enabled = false;
                    if (currentPageNo == 1)
                    {
                        ds = dsFullData;
                    }
                    else
                    {
                        --dataSetPage;
                        --currentPageNo;
                        pageNo = currentPageNo.ToString();



                        ds = objIview.dsIvPages;
                        dsFullData = ds;
                    }
                }
                else
                {
                    totRows = objIview.realRowCount;
                    ds = objIview.dsIvPages;
                    dsFullData = ds;
                }

            }

            if (objIview.IsPerfXml)
            {
                DataColumnCollection columns = ds.Tables[dataSetPage].Columns;

                //remove column in new perf xml
                if (columns.Contains("axrnum"))
                {
                    ds.Tables[dataSetPage].Columns.Remove("axrnum");
                }

                // added column for adding check box
                if (colFld.IndexOf("rowno") > -1)
                {
                    if (ds.Tables[dataSetPage].Columns.IndexOf("rowno") < 0)
                    {
                        ds.Tables[dataSetPage].Columns.Add("rowno").SetOrdinal(0);
                    }
                    GetSerialNoForPerfXml(ds.Tables[dataSetPage], "rowno");
                }

                if (headName.IndexOf("Sr. No.") > -1)
                {
                    GetSerialNoForPerfXml(ds.Tables[dataSetPage], objIview.SrNoColumName);
                }


            }

        }
        catch (Exception ex)
        {
            requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
            Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
        }

        //see line 1244 for details


        ////If stag load is true
        //if (objIview.IsIviewStagLoad)
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        dvStagLoad.Style.Add("display", "block");
        //        ds = GetStaggeredTables(ds);
        //    }
        //    else
        //    {
        //        dvStagLoad.Style.Add("display", "none");
        //    }
        //}
        //else
        //{
        //    dvStagLoad.Style.Add("display", "none");
        //}

        // Important : the datasource store in session as datatable. for paging and sorting

        // IMP : Create a new dataset - use clone - which create new structure then change
        //       Column datatype to int, double,string and date - which is needed for Sorting
        int n = 0;
        n = 0;
        DataSet ds1 = new DataSet();

        ds1 = ds.Clone();
        foreach (DataColumn dc1 in ds1.Tables[0].Columns)
        {
            if (colType[n].ToString() == "n")
            {
                dc1.DataType = typeof(string);
            }
            else if (colType[n].ToString() == "d")
            {
                dc1.DataType = typeof(string);
            }
            else
            {
                try
                {
                    dc1.DataType = typeof(string);
                }
                catch (Exception ex)
                {
                }
            }
            n = n + 1;
        }
        int rno = 0;
        rno = 0;

        string[] noRepatstr = new string[colNoRepeat.Count];
        foreach (DataRow dr1 in ds.Tables[dataSetPage].Rows)
        {
            // Before import ds to ds1 change the row value from str to date while datacol type is date
            // rno for find row no and id for col ... make new date then attach to dr1 -datarow then import 
            int id = 0;
            for (id = 0; id <= colType.Count - 1; id++)
            {
                if (id > ds.Tables[dataSetPage].Columns.Count - 1)
                    continue;

                if (colType[id].ToString() == "d")
                {
                    string actDt = null;
                    actDt = ds.Tables[dataSetPage].Rows[rno][id].ToString();

                    string newDt = string.Empty;


                    if (string.IsNullOrEmpty(actDt) | actDt == "Grand Total")
                    {
                        newDt = string.Empty;
                    }
                    else
                    {
                        string[] tempdt = null;
                        tempdt = actDt.Split('/');


                        if (tempdt.Length == 3)
                        {
                            string dd = null;
                            string MM = null;
                            string yyyy = null;

                            dd = tempdt[0].ToString();
                            if (int.Parse(dd) > 0 & int.Parse(dd) <= 31)
                            {
                                if ((dd.Length == 1))
                                {
                                    dd = "0" + dd;
                                }
                            }
                            else
                            {
                                dd = "01";
                            }

                            MM = tempdt[1].ToString();
                            if (int.Parse(MM) > 0 & int.Parse(MM) <= 12)
                            {
                                if (MM.Length == 1)
                                {
                                    MM = "0" + dd;
                                }
                            }
                            else
                            {
                                MM = "01";
                            }
                            string[] year = null;
                            year = tempdt[2].ToString().Split(' ');
                            yyyy = year[0];
                            if (yyyy.Length == 2)
                            {
                                yyyy = "1900";
                            }


                            //Dim newDt As Date
                            newDt = new DateTime(int.Parse(yyyy), int.Parse(MM), int.Parse(dd)).ToString();
                            newDt = actDt;

                            dr1[id] = newDt;
                            if (dr1[id].ToString() == "01/01/01 12:00:00 AM")
                            {
                                dr1[id] = null;
                            }
                            newDt = string.Empty;
                        }
                        else
                        {
                            dr1[id] = tempdt[0].ToString();
                        }
                    }

                }
                else if (colType[id].ToString() == "n")
                {
                    string nVal = null;
                    nVal = ds.Tables[dataSetPage].Rows[rno][id].ToString();

                    if (string.IsNullOrEmpty(nVal))
                    {
                        if (ds.Tables[dataSetPage].Rows[rno][1].ToString() == "subhead" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "stot" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "gtot" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "emptyRow")
                        {
                            dr1[id] = DBNull.Value;
                        }
                        else
                        {
                            if (objIview.IsDirectDBcall)
                            {
                                if (colZeroOff[id].ToString().ToLower() == "true")
                                {
                                    dr1[id] = DBNull.Value;
                                }
                                else
                                    dr1[id] = 0;
                            }
                            else
                                //TODO: handling zero off
                                dr1[id] = "";
                        }
                    }
                    else
                    {
                        try
                        {//if db column type is string & user selected iview column properties datatype as numeric then convert the string to int(ex. "0000" to 0) for checking zero off option
                         //if (int.Parse(nVal) == 0)
                            if (Convert.ToInt64(nVal) == 0)
                                nVal = "0";
                        }
                        catch (Exception ex)
                        {

                        }
                        if (objIview.IsDirectDBcall)
                        {
                            if (colZeroOff[id].ToString().ToLower() == "true" && nVal == "0")
                            {
                                dr1[id] = DBNull.Value;
                            }
                            else
                                dr1[id] = nVal;
                        }
                        else
                        {
                            try
                            {
                                if (objIview.IsPerfXml && Convert.ToInt32(colDec[id]) > 0)
                                {
                                    dr1[id] = string.Format("{0:n" + colDec[id] + "}", Convert.ToDouble(nVal.ToString()));
                                }
                                else
                                {
                                    dr1[id] = nVal;
                                }
                            }
                            catch (Exception ex)
                            {
                                dr1[id] = nVal;
                            }
                        }
                    }
                }
                else if (colType[id].ToString() == "c")
                {
                    string nVal = null;
                    nVal = ds.Tables[dataSetPage].Rows[rno][id].ToString();
                    if (!string.IsNullOrEmpty(nVal))
                    {
                        int startSpace = nVal.Length - (nVal.TrimStart().Length);
                        int endSpace = nVal.Length - (nVal.TrimEnd().Length);
                        nVal = nVal.TrimStart();
                        nVal = nVal.TrimEnd();
                        string startSpaceText = string.Empty;
                        string endSpaceText = string.Empty;
                        if (startSpace != 0)
                        {
                            for (int i = 0; i < startSpace; i++)
                                startSpaceText += "&nbsp;";
                        }
                        if (endSpace != 0)
                        {
                            for (int i = 0; i < endSpace; i++)
                                endSpaceText += "&nbsp;";
                        }
                        nVal = startSpaceText + nVal + endSpaceText;
                        dr1[id] = nVal;
                    }
                    else
                    {
                        if (ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"] != null && ds.Tables[dataSetPage].Rows[rno][ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"].Ordinal] != null && (ds.Tables[dataSetPage].Rows[rno][ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"].Ordinal].ToString() == "subhead" || ds.Tables[dataSetPage].Rows[rno][ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"].Ordinal].ToString() == "stot" || ds.Tables[dataSetPage].Rows[rno][ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"].Ordinal].ToString() == "gtot" || ds.Tables[dataSetPage].Rows[rno][ds.Tables[dataSetPage].Rows[rno].Table.Columns["AXROWTYPE"].Ordinal].ToString() == "emptyRow"))
                        {
                            dr1[id] = DBNull.Value;
                        }
                        else if (ds.Tables[dataSetPage].Rows[rno][1].ToString() == "subhead" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "stot" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "gtot" || ds.Tables[dataSetPage].Rows[rno][1].ToString() == "emptyRow")
                        {
                            dr1[id] = DBNull.Value;
                        }
                        else
                        {
                            if (dr1[id].GetType() != typeof(DBNull))
                                dr1[id] = "";
                        }
                    }
                }

                if (objIview.IsDirectDBcall)
                {
                    if (colNoRepeat[id].ToString().ToLower() == "true")
                    {
                        if (ds.Tables[dataSetPage].Rows[rno][1].ToString() != "subhead" && ds.Tables[dataSetPage].Rows[rno][1].ToString() != "stot" && ds.Tables[dataSetPage].Rows[rno][1].ToString() != "gtot" && ds.Tables[dataSetPage].Rows[rno][1].ToString() != "emptyRow")
                        {
                            if (noRepatstr[id] == dr1[id].ToString())
                            {
                                noRepatstr[id] = dr1[id].ToString();
                                dr1[id] = DBNull.Value;
                            }
                            else
                            {
                                noRepatstr[id] = dr1[id].ToString();
                                dr1[id] = dr1[id];
                            }
                        }
                    }
                }
            }
            ds1.Tables[dataSetPage].ImportRow(dr1);
            rno = rno + 1;
        }


        //If stag load is true
        if (objIview.IsIviewStagLoad)
        {
            if (ds1.Tables[dataSetPage].Rows.Count > 0)
            {
                dvStagLoad.Style.Add("display", "block");
                ds1 = GetStaggeredTables(ds1);
            }
            else
            {
                dvStagLoad.Style.Add("display", "none");
            }
        }
        else
        {
            dvStagLoad.Style.Add("display", "none");
        }
        //End 


        //Session["cac_iviewData"] = dsFullData.Tables[dataSetPage];
        objIview.DtCurrentdata = dsFullData.Tables[dataSetPage];
        if (cac_order == null)
        {
            cac_order = sid + "order";
        }
        Cache.Insert(cac_order, ds1.Tables[0], null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);

        if (ds1.Tables.Count > 0)
        {
            foreach (DataColumn dc in ds1.Tables[dataSetPage].Columns)
            {
                BoundField bfield = new BoundField();
                //'initialiae the data field value
                bfield.DataField = dc.ColumnName;
                //'initialise the header text value
                bfield.HeaderText = dc.ColumnName;
                bfield.HtmlEncode = false;
                //' add newly created columns to gridview
                GridView1.Columns.Add(bfield);
                //For setting grid Header height
                GridView1.HeaderStyle.Height = 25;
            }
        }

        //The below line will check for pagesize is defined as '0' in axpert then all the data will be sent in single page.
        //Hence assigning totalrows as gridPageSize.
        if (IsSqlPagination == "true" && gridPageSize == "0")
            gridPageSize = totalRows.ToString();

        if ((gridPageSize == "" | string.IsNullOrEmpty(gridPageSize)) || gridPageSize == "0")
        {
            gridPageSize = objIview.GrdPageSize;
        }

        try
        {
            GridView1.PageSize = Convert.ToInt32(gridPageSize);
        }
        catch (Exception ex)
        {
            if (gridPageSize == "0")
            {
                GridView1.PageSize = totRows;
            }
            else
            {
                GridView1.PageSize = 10;
            }
        }


        GridView1.DataSource = ds1.Tables[dataSetPage];

        //string mailreult = string.Empty;
        //StringBuilder inputXml = new StringBuilder();
        //inputXml.Append("<root sname ='" + objIview.IName + "' dsign='f' direct='true' transid='" + objIview.IName + "' filename='sendingmail' ordno='1'  axpapp = '" + proj + "' sessionid = '" + sid + "' stype='Iview'  trace='"+ errLog +"' recordid='0'>");
        //inputXml.Append("<sendmail><mailfrom>mohsin@agile-labs.com</mailfrom><mailto>abhinav@agile-labs.com</mailto><cc>ashwini@agile-labs.com</cc><subject>Hi</subject><body>Iview test</body>");
        //inputXml.Append("<attach></attach><axpattach></axpattach><msoutlook>false</msoutlook><pruntime>false</pruntime></sendmail></root>");
        //mailreult = objwebservice.CallAxpSendMailWS(objIview.IName, inputXml.ToString());
        ClearChartColumns();

        // to change the header Name and set the column width
        int idx = 0;

        for (idx = 0; idx <= headName.Count - 1; idx++)
        {
            if (idx > GridView1.Columns.Count - 1)
                continue;
            if (colWidth[idx].ToString() == "-1")
            {
                colWidth[idx] = "0";
            }
            GridView1.Columns[idx].HeaderText = headName[idx].ToString().Replace("~", "<br/>");
            if (colHide[idx].ToString() == "false")
            {
                //For Sorting set sortexp to newly set column heading
                GridView1.Columns[idx].SortExpression = colFld[idx].ToString();
                // For set width of the Column
                GridView1.Columns[idx].ItemStyle.Width = Convert.ToInt32(colWidth[idx].ToString());
                GridView1.Columns[idx].HeaderStyle.Width = Convert.ToInt32(colWidth[idx].ToString());
                gvWidth = gvWidth + Convert.ToInt32(colWidth[idx].ToString());
                if (headName[idx].ToString() != string.Empty)
                    AddChartColumns(headName[idx].ToString(), idx, colType[idx].ToString());
            }
        }


        DateTime dataBindStart = DateTime.Now;
        GridView1.DataBind();
        strTimetaken.Append("GridView DataBind-" + DateTime.Now.Subtract(dataBindStart).TotalMilliseconds.ToString() + " ");

        if (ConfigurationManager.AppSettings["timetaken"].ToString() == "true")
            lblTime.Text = strTimetaken.ToString();

        GridView1.Columns[1].ItemStyle.Width = Convert.ToInt32(0);

        if (ds.Tables[dataSetPage].Columns.IndexOf("axp__font") >= 0)
        {
            GridView1.Columns[ds.Tables[dataSetPage].Columns.IndexOf("axp__font")].Visible = false;
        }


        //for condition formating
        string str = string.Empty;
        int colIndx = 0;

        if (ds1.Tables[dataSetPage].Columns.Contains("axp__font"))
        {
            bool fontInfoAvlble = ds1.Tables[dataSetPage].Columns[2].ToString() == "axp__font";
            for (int j = 0; j < ds1.Tables[dataSetPage].Rows.Count; j++)
            {
                str = ds1.Tables[dataSetPage].Rows[j][2].ToString();
                if (fontInfoAvlble && str.Length > 1)
                {
                    string[] axpFont_Col = str.Split('~');
                    for (int k = 0; k < axpFont_Col.Length; k++)
                    {
                        string[] axpFont = axpFont_Col[k].Split(',');
                        for (int i = 0; i < ds1.Tables[dataSetPage].Columns.Count; i++)
                        {
                            if (ds1.Tables[dataSetPage].Columns[i].ToString() == axpFont[0])
                            {
                                colIndx = i;
                                break;
                            }
                        }
                        GridView1.Rows[j].Cells[colIndx].Font.Name = axpFont[1];
                        GridView1.Rows[j].Cells[colIndx].Font.Size = Convert.ToInt32(axpFont[2]);
                        GridView1.Rows[j].Cells[colIndx].Font.Bold = axpFont[3] == "t" ? true : false;
                        GridView1.Rows[j].Cells[colIndx].Font.Italic = axpFont[4] == "t" ? true : false;
                        GridView1.Rows[j].Cells[colIndx].Font.Underline = axpFont[5] == "t" ? true : false;
                        GridView1.Rows[j].Cells[colIndx].Font.Strikeout = axpFont[6] == "t" ? true : false;
                        if (axpFont[7].Length > 0)
                            GridView1.Rows[j].Cells[colIndx].ForeColor = System.Drawing.Color.FromName(axpFont[7].Substring(2));
                    }
                }
            }
        }


        if (!objIview.IsPerfXml)
            GridView1.Columns[1].Visible = false;
        double pg = Convert.ToInt32(totRows) / Convert.ToInt32(GridView1.PageSize);
        int pg1 = Convert.ToInt32(Math.Floor(pg));
        if ((totRows % GridView1.PageSize) > 0)
        {
            pg1 += 1;
        }

        // add and remove a hidden buttons after no records string
        string norecordsClass = "norecords";


        if (totRows > 0)
        {
            //remove a hidden buttons after no records class
            //searchBar.Attributes.Add("class", String.Join(" ", searchBar
            //          .Attributes["class"]
            //          .Split(' ')
            //          .Except(new string[] { "", norecordsClass })
            //          .ToArray()
            //  ));

            noRecccord.Style.Add("display", "none");
            unhidedvRowsPerPage();
            divcontainer.Style.Remove("height");
            if (dataRows > 0)
                records.Text = "Total no of records: " + dataRows;
            pages.Text = " of " + pg1;
            pgCap.Visible = true;
            lvPage.Visible = true;
            Session["ivPageNum"] = currentPageNo.ToString();
            if (IsSqlPagination == "true")
            {

                objIview.CurrentPageNo = currentPageNo.ToString();
                lnkPrev.Enabled = false;
                lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left disabled");
                //dvSqlPages.Visible = true;
                dvSqlPages.Style.Add("display", "block");
                //dvPages.Visible = false;
                dvPages.Style.Add("display", "none");
            }
            else
            {
                //dvSqlPages.Visible = false;
                dvSqlPages.Style.Add("display", "none");
                //dvPages.Visible = true;
                dvPages.Style.Add("display", "block");
            }

        }
        else
        {
            // add a hidden buttons after no records class
            //searchBar.Attributes.Add("class", String.Join(" ", searchBar
            //           .Attributes["class"]
            //           .Split(' ')
            //           .Except(new string[] { "", norecordsClass })
            //           .Concat(new string[] { norecordsClass })
            //           .ToArray()
            //   ));

            noRecccord.Style.Add("display", "table-cell");

            dvRowsPerPage.Style.Add("display", "none");

            if (objIview.IsDirectDBcall)
            {
                DirectDBEnableDisableLinks(pageNo);
                dvPages.Style.Add("display", "block");
                dvSqlPages.Style.Add("display", "none");

                return;
            }
            else
            {
                hdnNoOfRecords.Value = string.Empty;
                //dvPages.Visible = true;
                dvPages.Style.Add("display", "block");
                pages.Text = string.Empty;
                //  records.Text = objIview.IViewWhenEmpty;
                //dvSqlPages.Visible = false;
                dvSqlPages.Style.Add("display", "none");
                GridView1.Columns.Clear();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            records.Text = "";
        }

        int pgno = 0;
        lvPage.Items.Clear();
        for (pgno = 1; pgno <= pg1; pgno++)
        {
            lvPage.Items.Add(pgno.ToString());
        }
        if (IsSqlPagination == "true")
        {
            noOfPages = pg1;


            int recordsperpage = 0;

            if (Convert.ToInt32(objIview.GrdPageSize) > totRows)
            {
                recordsperpage = totRows;
            }
            else
            {
                recordsperpage = Convert.ToInt32(objIview.GrdPageSize);
            }


            //decimal recordsperpage = 0;

            //if (noOfPages > 0)
            //{
            //    recordsperpage = Math.Ceiling(Convert.ToDecimal(totRows) / noOfPages);
            //}

            if (recordsperpage == 0)
            {
                lblCurPage.Text = "Rows: 1-" + totRows.ToString();
            }
            else if ((((Convert.ToInt32(pageNo)) * Convert.ToInt32(recordsperpage))) < totRows)
            {

                lblCurPage.Text = "Rows: " + (((Convert.ToInt32(pageNo) - 1) * Convert.ToInt32(recordsperpage)) + 1).ToString() + "-" + (((Convert.ToInt32(pageNo)) * Convert.ToInt32(recordsperpage))).ToString();
            }
            else
            {
                lblCurPage.Text = "Rows: " + (((Convert.ToInt32(pageNo) - 1) * Convert.ToInt32(recordsperpage)) + 1).ToString() + "-" + totRows.ToString();
            }

            if ((objIview.getIviewRowCount || objIview.IsDirectDBcall) || (!objIview.getIviewRowCount && !objIview.IsDirectDBcall && objIview.lastPageCached))
                lblNoOfRecs.Text = " of " + totRows.ToString();
            else
                lblNoOfRecs.Text = " of <a  href=\"javascript:void(0)\" onclick=\"getIviewRecordCount();\" id=\"getIviewRecordCountVal\" title=\"\" class=\"ms-1\"><span class=\"material-icons material-icons-style material-icons-3 position-absolute\">help_outline</span></a>";
            //   lblNoOfRecs.Text = "Total no of rows: " + totRows;
            //   lblCurPage.Text = " Page No (" + pageNo + ") of " + noOfPages;



            if (currentPageNo == 1)
            {
                lnkPrev.Enabled = false;
                lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left disabled");
                //   lnkPrev.CssClass = "pickdis";
            }
            else
            {
                lnkPrev.Enabled = true;
                lnkPrev.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-left");

                //   lnkPrev.CssClass = string.Empty;
            }

            if (currentPageNo == noOfPages && ((objIview.getIviewRowCount || objIview.IsDirectDBcall) || (!objIview.getIviewRowCount && !objIview.IsDirectDBcall && objIview.lastPageCached)))
            {
                lnkNext.Enabled = false;
                lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right disabled");
                //   lnkNext.CssClass = "pickdis";
            }
            else
            {
                lnkNext.Enabled = true;
                lnkNext.Attributes.Add("class", "glyphicon glyphicon-chevron-left icon-arrows-right");

                //     lnkNext.CssClass = string.Empty;
            }

            if (objIview.IsDirectDBcall)
            {
                hdnTotalIViewRec.Value = directDbtotalRows.ToString();
                DirectDBEnableDisableLinks(pageNo);
            }
            else
            {
                hdnTotalIViewRec.Value = totalRows.ToString();
            }

            if (objIview.IsIviewStagLoad)
            {
                int rowCount = ds.Tables[dataSetPage].Rows.Count;
                if (rowCount == 0 || totRows == 0)
                {
                    dvStagLoad.Attributes.CssStyle.Add("display", "none");
                }
                else
                {
                    if (ds.Tables[dataSetPage].Rows[rowCount - 1][1].ToString().Contains("gtot"))
                        rowCount = rowCount - 1;

                    lblCurPage.Text = "";
                    lblNoOfRecs.Text = "Total no of Rows :  " + rowCount + " of " + totRows;
                    if (!objIview.IsDirectDBcall)
                        hdnTotalIViewRec.Value = totRows.ToString();
                    if (rowCount == totRows && totalRows >= 20)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableStagLoad", "DisableStagLoad();", true);
                    }
                    else if (dataRows == totRows && dataRows < 20)
                    {
                        dvStagLoad.Attributes.CssStyle.Add("display", "none");

                    }
                    lnkPrev.Visible = false;
                    lnkNext.Visible = false;
                }
            }
        }

        if (navigationInfo.Rows.Count > 0)
            Session["iNavigationInfoTable"] = navigationInfo;

        logobj.CreateLog("Binding data to grid completed", sid, fileName, string.Empty);
        GridView1.Width = gvWidth;
        objIview.GridWidth = gvWidth;

        if (currentPageNo == 1 && !lnkNext.Enabled && !lnkNext.Enabled)
        {
            //dvSqlPages.Visible = false;
            //dvSqlPages.Style.Add("display", "none");
            nextPrevBtns.Style.Add("display", "none");
        }
        else
        {

        }


        // ConstructFilterDiv(false);
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "dvToolBarFix", "dvToolBarFix();", true);
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string GetJsonForivirGrid(string ivKey)
    {
        IviewData objIview = (IviewData)HttpContext.Current.Session[ivKey];
        if (objIview != null)
        {

            jsonForGrid["customObjIV"] = JsonConvert.SerializeObject(objIview.customBtnIV);
            return jsonForGrid.ToString();
        }
        else
            return "";
    }

    ///Row data bound function of gridview where check box is bounded as first column if required.
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //System.Data.DataRowView drv = null;
        string sstr = null;
        string fstr = string.Empty;
        string navigateTo = string.Empty;
        bool bFoundTotal = false;
        bool chkBox = false;
        int strtIndx = 0;
        bool isSpecialRow = false; //Special row is true if the row is a subhead/subtot/granttot row
                                   //drv = (System.Data.DataRowView)e.Row.DataItem;

        DataTable rowDt = objIview.DtCurrentdata.Clone();
        for (int j = 1; j < rowDt.Columns.Count; j++)
        {
            //if (colType[j].ToString() == "d")
            rowDt.Columns[j].DataType = typeof(string);
        }
        DataRow dr = null;


        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (string.IsNullOrEmpty(e.Row.Cells[0].Text) || e.Row.Cells[0].Text == " " || e.Row.Cells[0].Text == "&nbsp;")
            {
                e.Row.Cells[0].Text = "<input name='chkall' id='chkall' type=checkbox />";
                chkBox = true;
            }
            //	Iterate through the header row.
            for (int cellIndex = 0; cellIndex < e.Row.Cells.Count; cellIndex++)
            {   //	Pass through all the cells. 
                //	If the Cell matches the key words add current index to respective arrays.

                if (e.Row.Cells[cellIndex].Text.Equals("recordid"))
                    ivAttachRid = cellIndex;
                else if (e.Row.Cells[cellIndex].Text.Equals("transid"))
                    ivAttachTransid = cellIndex;
                else if (e.Row.Cells[cellIndex].Text.Equals("attachfieldname"))
                    ivAttachRowNo = cellIndex;
                else if (e.Row.Cells[cellIndex].Text.Equals("axp_gridattach"))
                    ivAttExt = cellIndex;
                //gridattachext_lr
                else if (e.Row.Cells[cellIndex].Text.Contains("axp_attachfilename"))
                {
                    FilesIndexes.Add(cellIndex);
                    colAlign[cellIndex] = "Center";
                    e.Row.Cells[cellIndex].Text = e.Row.Cells[cellIndex].Text.Replace("axp_attachfilename", "");

                }
                //TreeMethod
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("root_class"))
                {
                    root_class_index = cellIndex;
                }
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("account name"))
                {
                    root_account_index = cellIndex;
                }
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("particulars"))
                {
                    root_account_index = cellIndex;
                }
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("+/-"))
                {
                    root_account_index = cellIndex;
                }
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("root_type"))
                {
                    root_atype_index = cellIndex;
                }
                else if (e.Row.Cells[cellIndex].Text.ToLower().Equals("link url"))
                {
                    // This code will behave differently with new UI Split
                    //iframe_index = cellIndex;
                    //Session["iframe_index"] = iframe_index;
                    //iframe_index = Convert.ToInt32(Session["iframe_index"]);

                }


                e.Row.Cells[cellIndex].ID = colFld[cellIndex].ToString();
                e.Row.Cells[cellIndex].Attributes.Add("data-data", colFld[cellIndex].ToString());
                e.Row.Cells[cellIndex].Attributes.Add("data-name", colFld[cellIndex].ToString());

            }





        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.DataItem != null)
            {
                // first change  col 1 to check box
                string catName = e.Row.RowIndex.ToString();
                // for change the content to component like check box or input box
                //to Remove checkbox from first column
                checkcnt = checkcnt + 1;
                e.Row.Cells[0].Text = "<input  name='chkItem' type=checkbox value=" + checkcnt + ">";
                //	Check each row cell with the file indexes 

                int idx = 0;
                for (idx = 0; idx <= colHide.Count - 1; idx++)
                {
                    if (idx > e.Row.Cells.Count - 1)
                        continue;
                    //js not implemented
                    if (arrHdnColMyViews.IndexOf(colFld[idx]) != -1)
                    {
                        GridView1.HeaderRow.Cells[idx].Visible = false;
                        e.Row.Cells[idx].Visible = false;
                    }


                    if (e.Row.Cells[idx].Text.Contains("~"))
                        e.Row.Cells[idx].Text = e.Row.Cells[idx].Text.Replace("~", "<br/>");

                    if ((!string.IsNullOrEmpty(util.IviewWrap)) && (util.IviewWrap.ToLower() == "true"))
                        e.Row.Cells[idx].Attributes.Add("style", "word-break: break-word;");
                    else
                        e.Row.Cells[idx].Attributes.Add("style", "white-space: nowrap;");




                    string nVal = null;
                    nVal = e.Row.Cells[idx].Text.ToString();



                    if (e.Row.Cells[idx].Text != "&nbsp;" && idx != 0)
                    {
                        if (e.Row.Cells[idx].Text.IndexOf("&nbsp;") != -1)
                            nVal = nVal.Replace("&nbsp;", " ");
                        if (!(nVal.StartsWith("<") && nVal.EndsWith(">")) && !(nVal.Contains("<") && (nVal.Contains("</") || nVal.Contains("/>"))))
                            e.Row.Cells[idx].Text = Server.HtmlEncode(nVal);
                    }


                    if (colType[idx].ToString() == "c")
                    {
                        if (nVal.StartsWith(" "))
                        {
                            nVal = nVal.Trim();
                            e.Row.Cells[idx].Text = nVal;
                        }

                    }
                    //else if (colType[idx].ToString() == "n" && colDec[idx].ToString() == "0" && objIview.IVType != "Interactive")
                    //{
                    //    if (language.ToLower() == "arabic")
                    //        e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Left;
                    //    else
                    //        e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    else if (colType[idx].ToString() == "n")
                    {

                        //format numeric with decimal pts
                        //change here
                        //colApplyComma only for directDB so only else condition in js
                        if (!string.IsNullOrEmpty(e.Row.Cells[idx].Text.ToString()) && e.Row.Cells[idx].Text.ToString() != "&nbsp;" && colApplyComma[idx].ToString().ToLower() == "true")
                        {
                            //e.Row.Cells[idx].Text = string.Format(string.Empty, Convert.ToDouble(drv[idx].ToString()));

                            if (e.Row.Cells[idx].Text.ToString().StartsWith("("))
                            {
                                e.Row.Cells[idx].Text = e.Row.Cells[idx].Text.ToString();
                            }
                            else
                            {
                                if (e.Row.Cells[idx].Text.ToString() != String.Empty && e.Row.Cells[idx].Text.ToString() != "&nbsp;" && ParseNumeric(e.Row.Cells[idx].Text.ToString()))
                                {
                                    e.Row.Cells[idx].Text = "0";
                                    objIview.DtCurrentdata.Rows[e.Row.RowIndex][idx] = "0";
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(colDec[idx].ToString()))//&& colApplyComma[idx].ToString().ToLower() == "true"
                                    {
                                        e.Row.Cells[idx].Text = string.Format("{0:n" + colDec[idx] + "}", Convert.ToDouble(e.Row.Cells[idx].Text.ToString()));//System.Globalization.CultureInfo.CreateSpecificCulture("hi-IN"), 
                                        ((DataRowView)e.Row.DataItem).Row[idx] = e.Row.Cells[idx].Text;
                                    }
                                    else
                                    {
                                        e.Row.Cells[idx].Text = string.Format(string.Empty, "");
                                    }
                                }
                            }
                        }
                        else
                        {
                            //ParseNumeric is working as isInValidNumber
                            //"(" this if condition is not required
                            if (e.Row.Cells[idx].Text.ToString().StartsWith("("))
                            {
                                e.Row.Cells[idx].Text = objIview.DtCurrentdata.Rows[e.Row.RowIndex][idx].ToString();
                            }
                            else if (e.Row.Cells[idx].Text.ToString() != String.Empty && e.Row.Cells[idx].Text.ToString() != "&nbsp;" && ParseNumeric(e.Row.Cells[idx].Text.ToString()))
                            {
                                e.Row.Cells[idx].Text = "0";
                                objIview.DtCurrentdata.Rows[e.Row.RowIndex][idx] = 0;
                            }
                        }
                        // for check date datatype
                    }
                    else if (colType[idx].ToString() == "d")
                    {
                        // for date datatype change format to dd/mm/yyyy
                        string tdt = null;
                        if (!string.IsNullOrEmpty(e.Row.Cells[idx].Text.ToString()) && e.Row.Cells[idx].Text.ToString() != "&nbsp;")
                        {
                            tdt = e.Row.Cells[idx].Text.ToString();
                            //in directdb call date/time column will return with time by default as 00:00:00 by default so applting following workaround
                            if (objIview.IsDirectDBcall)
                            {
                                try
                                {
                                    var splitDate = tdt.Split(' ');
                                    if (splitDate.Length == 2 && splitDate[1] == "00:00:00")
                                    {
                                        tdt = splitDate[0];
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //exception happened so in "tdt" there will be no change
                                }
                            }
                            if (objIview.IsPerfXml)
                            {
                                tdt.Split('T')[0].ToString();
                                if (tdt.Contains('T') && tdt.Contains('-'))
                                {
                                    string[] date = tdt.Split('T');
                                    string[] dateformat = date[0].Split('-');

                                    e.Row.Cells[idx].Text = dateformat[2] + "/" + dateformat[1] + "/" + dateformat[0];
                                }
                                else
                                {
                                    e.Row.Cells[idx].Text = util.GetClientDateString(clientCulture, tdt, objIview.IsDirectDBcall || objIview.IsPerfXml);
                                    objIview.DtCurrentdata.Rows[e.Row.RowIndex][idx] = e.Row.Cells[idx].Text;
                                }
                            }
                            else
                            {
                                e.Row.Cells[idx].Text = util.GetClientDateString(clientCulture, tdt, objIview.IsDirectDBcall || objIview.IsPerfXml);
                                objIview.DtCurrentdata.Rows[e.Row.RowIndex][idx] = e.Row.Cells[idx].Text;
                            }

                        }
                        else
                        {
                            e.Row.Cells[idx].Text = " ";
                        }
                        //skipped in js
                        if (objIview.IVType != "Interactive")
                            e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Center;
                    }


                    if (colAlign[idx].ToString() != string.Empty)
                    {
                        string alignStr = colAlign[idx].ToString();
                        if (alignStr == "Center")
                        {
                            e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Center;
                        }
                        else
                        {
                            if (language.ToLower() == "arabic")
                            {
                                if (alignStr == "Right")
                                    e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Left;
                                else if (alignStr == "Left")
                                    e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Right;
                            }
                            else
                            {
                                if (alignStr == "Right")
                                    e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Right;
                                else if (alignStr == "Left")
                                    e.Row.Cells[idx].HorizontalAlign = HorizontalAlign.Left;

                            }
                        }
                    }

                    if (e.Row.Cells[1].Text.Contains("stot") | e.Row.Cells[1].Text.Contains("subhead") | e.Row.Cells[1].Text.Contains("gtot"))
                    {
                        isSpecialRow = true;
                        if (e.Row.Cells[1].Text.Contains("stot"))
                        {
                            e.Row.Font.Bold = true;
                            //e.Row.CssClass = "fontBlue";
                            for (int i = 0; i < GridView1.Columns.Count; i++)
                            {
                                e.Row.Cells[i].CssClass = "fontBlue";
                            }
                            e.Row.Cells[0].Text = " ";
                            e.Row.Cells[idx].Font.Bold = true;
                        }
                        else if (e.Row.Cells[1].Text.Contains("subhead"))
                        {
                            e.Row.Font.Bold = true;
                            //e.Row.CssClass = "fontBlack";
                            for (int i = 0; i < GridView1.Columns.Count; i++)
                            {
                                e.Row.Cells[i].CssClass = "fontBlack";
                            }
                            e.Row.Cells[0].Text = " ";
                            e.Row.Cells[idx].Font.Bold = true;
                        }
                        else
                        {
                            e.Row.Font.Bold = true;
                            //e.Row.CssClass = "fontGreen";
                            for (int i = 0; i < GridView1.Columns.Count; i++)
                            {
                                e.Row.Cells[i].CssClass = "fontGreen";
                            }
                            e.Row.Cells[0].Text = " ";
                        }
                    }

                    //Code to handle empty value for hyperlink column
                    if (string.IsNullOrEmpty(nVal) || nVal == "&nbsp;")
                    {
                        e.Row.Cells[idx].Text = " ";
                    }

                    if ((colFld[idx].ToString() == "column1" || colType[idx].ToString() == "n") && e.Row.Cells[idx].Text != "&nbsp;" && e.Row.Cells[idx].Text != " " && e.Row.Cells[idx].Text != string.Empty)
                    {
                        e.Row.Cells[idx].Attributes.Add("data-order", e.Row.Cells[idx].Text);
                    }

                }
                if (!hideChkBox)
                    strtIndx = 1;
                else
                    strtIndx = 0;
                //Displaying hyperlinks 
                dr = rowDt.NewRow();
                for (int j = 1; j < e.Row.Cells.Count; j++)
                {
                    dr[j] = e.Row.Cells[j].Text;
                }
                rowDt.Rows.Add(dr);
                try
                {
                    if (!isSpecialRow)
                    {
                        dr = objIview.GetHyperLinks(dr, catName, objIview, e.Row.RowIndex, objIview.DtCurrentdata);

                        for (int i = strtIndx; i < dr.ItemArray.Length; i++)
                        {
                            e.Row.Cells[i].Text = dr[i].ToString();
                        }

                        if (FilesIndexes.Count > 0)
                        {
                            btnDownloadAll.Enabled = true;
                            btnDownloadAll.Visible = true;
                            for (int fileIndex = 0; fileIndex < FilesIndexes.Count; fileIndex++)
                            {
                                string filName = e.Row.Cells[int.Parse(FilesIndexes[fileIndex].ToString())].Text;

                                if (!string.IsNullOrEmpty(e.Row.Cells[int.Parse(FilesIndexes[fileIndex].ToString())].Text) && e.Row.Cells[int.Parse(FilesIndexes[fileIndex].ToString())].Text != "&nbsp;")
                                {
                                    e.Row.Cells[int.Parse(FilesIndexes[fileIndex].ToString())].Text = "<a class=\"downloadLink" + e.Row.RowIndex + "\" href=\"javascript:SetFileToDownload('" + Session["project"].ToString() + "','" + e.Row.Cells[ivAttachTransid].Text + "','" + e.Row.Cells[ivAttExt].Text + "','" + filName + "');\">" + " <img src=\"../AxpImages/Downloads-icon.png\" alt=\"Download\"/>" + "</a>";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    requestProcess_logtime += "Server -Error occured while Setting IView hyperlinks ♦ ";
                    Response.Redirect(util.ERRPATH + "Error occured while Setting IView hyperlinks" + "*♠*" + requestProcess_logtime);
                }

                //TreeMethod
                if (root_class_index > 0)
                    e.Row.Attributes.Add("class", e.Row.Cells[root_class_index].Text);

                if (root_class_index > 0 && root_atype_index > 0 && root_account_index > 0 && e.Row.Cells[root_atype_index].Text.ToLower() == "group")
                {
                    //  int count = e.Row.Cells[root_atype_index].Text.Where(x => x == "&nbsp;").Count();
                    int count = e.Row.Cells[root_account_index].Text.Replace("&nbsp;", "").Length;

                    e.Row.Cells[root_account_index].Text = e.Row.Cells[root_account_index].Text.Substring(0, e.Row.Cells[root_account_index].Text.Length - count) + "<span class='icon-arrows-plus' style='font-size: 12px;'>" + e.Row.Cells[root_account_index].Text.Replace("&nbsp;", "") + "</span> ";
                }



                //Setting the Column formatting 
                try
                {
                    if (objIview.ColAxp_format)
                    {
                        string colFormatVal = e.Row.Cells[objIview.DtCurrentdata.DataSet.Tables[0].Columns.IndexOf("axp__font")].Text.ToString();
                        objIview.GetIviewColFontStyle(objIview, colFormatVal);

                        for (int fIndx = 0; fIndx < objIview.FormatCols.Count; fIndx++)
                        {
                            int fldIndx = objIview.ColFld.IndexOf(objIview.FormatCols[fIndx].ToString());
                            if (fldIndx != -1)
                            {
                                ArrayList fontStyles = objIview.SetIviewColFontStyle(e.Row.RowIndex, objIview, fIndx);

                                if (fontStyles.Count > 0 && fontStyles.Count <= 4)
                                {
                                    if (fontStyles[0].ToString() != string.Empty)
                                    {
                                        e.Row.Cells[fldIndx].Font.Name = fontStyles[0].ToString();
                                    }
                                    if (fontStyles[1].ToString() != string.Empty)
                                        e.Row.Cells[fldIndx].Font.Size = Convert.ToInt16(fontStyles[1]);
                                    if (fontStyles[2].ToString() != string.Empty)
                                    {
                                        string fontWt = fontStyles[2].ToString();
                                        if (fontWt.ToLower().Contains("bold"))
                                            e.Row.Cells[fldIndx].Font.Bold = true;
                                        if (fontWt.ToLower().Contains("italic"))
                                            e.Row.Cells[fldIndx].Font.Italic = true;
                                    }
                                    if (fontStyles[3].ToString() != string.Empty)
                                        e.Row.Cells[fldIndx].ForeColor = System.Drawing.Color.FromName(fontStyles[3].ToString());

                                }
                            }
                        }
                        for (int k = strtIndx; k < e.Row.Cells.Count; k++)
                        {
                            if (colHide[k].ToString() != "true")
                            {
                                e.Row.Cells[k].Text = dr[colFld[k].ToString()].ToString();
                            }
                        }
                    }

                }

                catch (Exception Ex)
                {
                    requestProcess_logtime += "Server -Error occured in formatting the IView column ♦ ";
                    Response.Redirect(util.ERRPATH + "Error occured in formatting the IView column" + "*♠*" + requestProcess_logtime);
                }
            }
        }

        //for NOWRAP in IE
        int m = 0;
        string sh = string.Empty;
        for (m = 0; m <= e.Row.Cells.Count - 1; m++)
        {
            if (m == 1)
            {
                if (e.Row.Cells[1].Text.Contains("subhead"))
                {
                    sh = "shead";
                }
            }

            if (sh == "shead")
            {
                e.Row.Font.Bold = true;
                //e.Row.CssClass = "fontBlack";
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    e.Row.Cells[i].CssClass = "fontBlack";
                }
                e.Row.Cells[0].Text = " ";
                e.Row.Cells[1].Font.Bold = true;
            }
            //e.Row.Attributes.Add("class", String.Join(" ", e.Row
            //           .Attributes["class"]
            //           .Split(' ')
            //           .Except(new string[] { "", "specialRow" })
            //           .Concat(new string[] { "specialRow" })
            //           .ToArray()
            //   ));

            if (e.Row.Cells[m].Text.Contains("stot") | e.Row.Cells[m].Text.Contains("subhead") | e.Row.Cells[m].Text.Contains("gtot"))
            {

                e.Row.CssClass = String.Join(" ", e.Row.CssClass.Split(' ')
                    .Except(new string[] { "", "specialRow" })
                    .Concat(new string[] { "specialRow" })
                    .ToArray()
            );



                //if (e.Row.Cells[m].Text.Contains("stot"))
                //{
                //    e.Row.Font.Bold = true;
                //    //e.Row.CssClass = "fontBlue";
                //    for (int i = 0; i < GridView1.Columns.Count; i++)
                //    {
                //        e.Row.Cells[i].CssClass = "fontBlue";
                //    }
                //    e.Row.Cells[0].Text = " ";
                //    e.Row.Cells[m].Font.Bold = true;
                //}

                //else if (e.Row.Cells[m].Text.Contains("subhead"))
                //{
                //    e.Row.Font.Bold = true;
                //    //e.Row.CssClass = "fontBlack";
                //    for (int i = 0; i < GridView1.Columns.Count; i++)
                //    {
                //        e.Row.Cells[i].CssClass = "fontBlack";
                //    }
                //    e.Row.Cells[0].Text = " ";
                //    e.Row.Cells[m].Font.Bold = true;
                //}
                //else
                //{
                //    e.Row.Font.Bold = true;
                //    //e.Row.CssClass = "fontGreen";
                //    for (int i = 0; i < GridView1.Columns.Count; i++)
                //    {
                //        e.Row.Cells[i].CssClass = "fontGreen";
                //    }
                //    e.Row.Cells[0].Text = " ";
                //}
            }

        }

        //Pivot Header Add
        if ((pivotGroupHeaderNames.Count == 0) | (pivotGroupHeaderNames.Count == 1))
        {
            pivotheadcreate();
        }

        SortedList creatCels = new SortedList();
        int inc = 0;
        string val = null;
        int colSpan = 0;
        int multiheadValidator = 0;
        for (inc = 0; inc <= pivotGroupHeaderNames.Count - 1; inc++)
        {
            colSpan = Convert.ToInt32(pivotEndCol[inc].ToString()) - Convert.ToInt32(pivotStartCol[inc].ToString());
            val = pivotGroupHeaderNames[inc].ToString() + "¿" + colSpan + "¿" + 1;
            creatCels.Add(inc, val);
            if (!String.IsNullOrEmpty(pivotGroupHeaderNames[inc].ToString()))
            {
                multiheadValidator++;
            }
        }
        if (creatCels.Count > 0 && multiheadValidator > 0)
        {
            GetMyMultiHeader(e, creatCels);
        }


        //not implemented in js
        //logic to move grand total form sr.no column to next column
        for (int indx = 0; indx < GridView1.Columns.Count; indx++)
        {
            if (e.Row.Cells[indx].Text == "Grand Total")
            {
                for (int vindx = indx + 1; vindx < colHide.Count; vindx++)
                {
                    if ((colHide[vindx].ToString() == "false") && (colFld[indx].ToString() == objIview.SrNoColumName))
                    {
                        if (colHide[indx].ToString() == "false")
                        {
                            e.Row.Cells[vindx].Text = "Grand Total";
                            e.Row.Cells[indx].Text = " ";
                            bFoundTotal = true;
                            break;
                        }
                    }
                }
                if (bFoundTotal) break;

            }
        }
        //not implemented in js
        //logic to make serial no column special cell empty
        if (e.Row.Cells[1].Text.Contains("stot") | e.Row.Cells[1].Text.Contains("subhead") | e.Row.Cells[1].Text.Contains("gtot"))
        {
            if (headName.IndexOf("Sr. No.") > -1 || headName.IndexOf("Sr.No.") > -1)
            {
                e.Row.Cells[(colFld.IndexOf(objIview.SrNoColumName))].Text = string.Empty;
            }



        }
    }

    public bool ParseNumeric(string str)
    {
        Int32 intValue;
        Int64 bigintValue;
        Double doubleValue;
        Decimal decimalValue;
        DateTime dateValue;

        if (Int32.TryParse(str, out intValue))
            return false;
        else if (Int64.TryParse(str, out bigintValue))
            return false;
        else if (Double.TryParse(str, out doubleValue))
            return false;
        else if (Decimal.TryParse(str, out decimalValue))
            return false;
        else if (DateTime.TryParse(str, out dateValue))
            return true;
        else return true;

    }

    ///Function for handling multiple header in the gridview.
    public void GetMyMultiHeader(System.Web.UI.WebControls.GridViewRowEventArgs e, SortedList GetCels)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = default(GridViewRow);
            row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
            IDictionaryEnumerator enumCels = null;
            enumCels = GetCels.GetEnumerator();

            //if (colHide[0].ToString() == "false")
            {
                //add one cell for check box. 
                row.Cells.Add(GetCell(1, 1, "&nbsp;"));
            }

            while (enumCels.MoveNext())
            {
                string[] cont = null;
                cont = enumCels.Value.ToString().Split(Convert.ToChar("¿"));
                cont[0] = cont[0].ToString() == string.Empty ? "&nbsp;" : cont[0];
                row.Cells.Add(GetCell(Convert.ToInt16(cont[2].ToString()), Convert.ToInt16(cont[1].ToString()), cont[0].ToString()));
            }
            e.Row.Parent.Controls.AddAt(0, row);
        }

    }

    /// Function to load the items into the drop down box which is a parameter to the iview.
    public void ComboFill(XmlNode baseDataNode, string fldName = "")
    {
        foreach (XmlNode rowdNode in baseDataNode.ChildNodes)
        {
            if (rowdNode.ChildNodes[0] != null)
            {
                if (rowdNode.ChildNodes[0].InnerText != "*")
                {
                    string ddlValue = util.CheckSpecialChars(rowdNode.ChildNodes[0].InnerText);

                    ddlValue = Regex.Replace(ddlValue, "&apos;", "&#39;");
                    ddlValue = Regex.Replace(ddlValue, ";bkslh", "&#92;");
                    arrFillList.Add(ddlValue);
                }
            }

            //if (isSelectWithMultiColumn)
            if(rowdNode.ChildNodes.Count > 1)
            {
                string arrFillListDataAttrStr = string.Empty;
                int ind = -1;
                foreach (XmlNode col in rowdNode.ChildNodes)
                {
                    ind++;
                    if (col.InnerText != "*")
                    {
                        string ddlValue = util.CheckSpecialChars(col.InnerText);

                        ddlValue = Regex.Replace(ddlValue, "&apos;", "&#39;");
                        //arrFillList.Add(ddlValue);
                        arrFillListDataAttrStr += " data-optionsss" + (ind == 0 ? fldName : col.Name) + "=\"" + ddlValue + "\" "+ (ind == 0 || col.Attributes["dt"] == null ? "" : " data-dtypeee" + (ind == 0 ? fldName : col.Name) + "=\"" + (col.Attributes["dt"].Value) + "\" ") + " ";
                    }
                }
                arrFillListDataAttr.Add(arrFillListDataAttrStr);
            }
            else
            {
                arrFillListDataAttr.Add(string.Empty);
            }
        }
    }

    ///Function to construct the parameter xml on which the iview is dependent.
    protected void ConstructParamXml()
    {
        string str = string.Empty;
        if (objIview.IsDirectDBcall && hdnparamValues.Value == string.Empty && objParams.ParamNames.Count > 0)
        {
            ConstructHdnParamValues();
        }
        ResetParamsOnSaveCHWindow(false);
        str = hdnparamValues.Value;
        string[] strp = util.AxSplit1(str, "¿");
        int i = 0;
        param.Value = string.Empty;
        for (i = 0; i <= strp.Length - 1; i++)
        {
            if (!string.IsNullOrEmpty(strp[i]))
            {
                string[] arrparam = strp[i].ToString().Split('~');
                string pName = util.CheckSpecialChars(arrparam[0].ToString());
                string pValue = util.CheckSpecialChars(arrparam[1].ToString());
                pValue = Regex.Replace(pValue, ";bkslh", "&#92;");
                if (pValue.Contains("&amp;grave;") == true)
                {
                    pValue = pValue.Replace("&amp;grave;", "~");
                }
                pXml = pXml + "<" + pName + ">";
                pXml = pXml + pValue;
                pXml = pXml + "</" + pName + ">";

                if (pName == "mrefresh")
                {
                    if (pValue != "")
                        refreshTime = pValue;
                }

                UpdateParamValues(pName, pValue);
                if (objParams.ParamCaption.Count > 0 && objParams.ParamCaption.ToString() != "")
                {
                    paramss[objParams.ParamCaption[i].ToString()] = pValue;
                }

                pValue = pValue.Replace("~", "&grave;");
                if (!string.IsNullOrEmpty(param.Value))
                {
                    param.Value = param.Value + "~" + pName + "♠" + pValue;
                }
                else
                {
                    param.Value = pName + "♠" + pValue;
                }
            }
        }
        //write code to display the param selected values in the label
        int iCount = 0;
        if (objParams.ParamCaption.Count > 0 && objParams.ParamCaption.ToString() != "")
        {
            paramssBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> entry in paramss)
            {

                if (!string.IsNullOrEmpty(entry.Key) && !string.IsNullOrEmpty(entry.Value))
                {
                    iCount++;

                    paramssBuilder.Append("<tr><td><b>" + entry.Key + "</b> </td><td>: " + entry.Value + "</td></tr>");
                }
            }



            string paramValuesShown = string.Empty;
            paramValuesShown = paramssBuilder.ToString();

            paramValuesShown = "<span class=\"filtertooltip\" style='text-decoration: none;'>" + iCount + "<span class=\"tooltiptext\"><table>" + paramValuesShown + "</table></span></span>";
            //FilterValues.InnerHtml = paramValuesShown.ToString();

        }
    }

    private void ResetParamsOnSaveCHWindow(bool delFromSession)
    {
        if (Session["IsFromChildWindow"] != null)//&& Session["IsFromChildWindow"] == "true"
        {

            if (Request.QueryString["ivname"] != null)
                iName = Request.QueryString["ivname"];
            if (Session["paramValues" + iName] != null)
            {
                hdnparamValues.Value = Session["paramValues" + iName].ToString();
                hdnSelParamsAftrChWin.Value = Session["paramValues" + iName].ToString();
            }
            if (delFromSession)
                Session["IsFromChildWindow"] = null;
        }
    }

    private void ConstructHdnParamValues()
    {
        StringBuilder pValue = new StringBuilder();
        int i = 0;
        for (i = 0; i < objParams.ParamNames.Count; i++)
        {
            pValue.Append(objParams.ParamNames[i] + "~" + objParams.ParamChangedVals[i] + "¿");
        }
        hdnparamValues.Value = pValue.ToString();
    }

    private void UpdateParamValues(string pName, string pValue)
    {
        int idx = -1;
        idx = objParams.ParamNames.IndexOf(pName);
        if (idx == -1)
        {
            objParams.ParamNames.Add(pName);
            objParams.ParamValsOnLoad.Add(pValue);
            objParams.ParamChangedVals.Add(pValue);
        }
        else
        {
            objParams.ParamChangedVals[idx] = pValue;
        }
    }

    //Function to return cells. params: Row span, Col span, Label value
    private TableCell GetCell(int r, int c, string v)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.RowSpan = r;
        cell.ColumnSpan = c;
        cell.Controls.Add(new LiteralControl(v));
        //cell.CssClass = "Gridviewph";
        if (c > 1)
        {
            //   cell.Style.Add("border-bottom", "1px solid #CCCCCC !important");
        }
        cell.HorizontalAlign = HorizontalAlign.Center;
        return cell;
    }

    ///Function for sorting in gridview.
    protected void GridView1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        DataTable dtorders = new DataTable();
        dtorders = (DataTable)Cache.Get(cac_order);
        if (objIview.SortDir.ToString() == "ASC")
        {
            dtorders.DefaultView.Sort = e.SortExpression + " " + "DESC";
            objIview.SortDir = "DESC";

        }
        else
        {
            dtorders.DefaultView.Sort = e.SortExpression + " " + "ASC";
            objIview.SortDir = "ASC";
        }

        GridView1.DataSource = dtorders.DefaultView;
        Cache.Insert(cac_order, dtorders, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
        GridView1.DataBind();
        GridView1.Columns[1].Visible = false;
    }

    /// function to handle pivot heading , i.e. single heading for more than one column.
    private void pivotheadcreate()
    {
        //Pivot Header Definition Starts
        string ires = null;
        if (Cache.Get(cac_pivot) != null)
        {
            ires = Cache.Get(cac_pivot).ToString();
            ires = "<headrow><pivotghead>" + ires + "</pivotghead></headrow>";
            XmlDocument xmlDocpv = new XmlDocument();
            XmlNodeList productNodespv = default(XmlNodeList);
            XmlNodeList baseDataNodespv = default(XmlNodeList);

            try
            {
                xmlDocpv.LoadXml(ires);
            }
            catch (Exception ex)
            {
                requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
                Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
            }


            productNodespv = xmlDocpv.SelectNodes("//headrow");
            pivotGroupHeaderNames.Clear();
            pivotStartCol.Clear();
            pivotEndCol.Clear();

            foreach (XmlNode productNodepv in productNodespv)
            {
                baseDataNodespv = productNodepv.ChildNodes;
                foreach (XmlNode baseDataNodepv in baseDataNodespv)
                {
                    if (baseDataNodepv.Name == "pivotghead")
                    {
                        XmlNodeList finalNodelist = default(XmlNodeList);
                        foreach (XmlNode base2node in baseDataNodepv)
                        {
                            finalNodelist = base2node.ChildNodes;
                            foreach (XmlNode finalNode in finalNodelist)
                            {
                                if (finalNode.Name == "sn")
                                {
                                    pivotStartCol.Add(finalNode.InnerText);
                                }
                                else if (finalNode.Name == "ghead")
                                {
                                    pivotGroupHeaderNames.Add(finalNode.InnerText);
                                }
                                else if (finalNode.Name == "en")
                                {
                                    pivotEndCol.Add(finalNode.InnerText);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    /// Calling a function to get iview data  on change of the page no. from the dropdown.
    /// its nothing but handling pagination on change of dropdown box.
    protected void lvPage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ClearNavigationData();
        paramxml.Value = string.Empty;
        string pgNo = lvPage.SelectedValue;
        Session["currentPageNo" + iName] = pgNo;
        CallWebservice(pgNo, "no");
    }

    protected void button2_Click(object sender, System.EventArgs e)
    {
        pgCap.Visible = false;
        //records.Text = string.Empty;
        hdnNoOfRecords.Value = string.Empty;
        pages.Text = string.Empty;
        lvPage.Items.Clear();
        lvPage.Visible = false;
        hdnparamValues.Value = string.Empty;
        GridView1.Columns.Clear();
        GridView1.DataSource = null;
        GridView1.DataBind();
        ivCap1.InnerHtml = string.Empty;
        ivCap1.Visible = false;
        GridView2Wrapper.Visible = false;
        resetIViewWithoutRowCount();
    }

    private LinkButton GetButton(string action, string iviewName, string confirm, string allRows, string btnImageId, string caption, bool isFileUpload = false)
    {
        actionButvs = actionButvs + action + '~' + iviewName + '~' + confirm + '~' + allRows + '~' + btnImageId + '~' + caption + '^';
        LinkButton b = new LinkButton();
        b.CssClass = "action handCur l2";
        b.ID = "btn_" + action;
        b.CommandName = "ID";
        b.ToolTip = caption;
        b.CommandArgument = "btn_" + action.ToString();
        //b.Command += new CommandEventHandler(this.LinkButton_Click);
        //if (objIview.ActBtnNavigation != null && objIview.ActBtnNavigation.ContainsKey(action))
        //    b.OnClientClick = "return ActButtonClick('" + b.ClientID + "','" + confirm + "','" + allRows + "','" + objIview.ActBtnNavigation[action] + "')";
        //else
        if (!isFileUpload)
        {
            b.OnClientClick = "return ActButtonClick('" + b.ClientID + "','" + confirm + "','" + allRows + "')";
        }
        else
        {
            b.OnClientClick = "javascript:callFileUploadAction('" + action + "','" + iviewName + "','" + confirm + "','" + allRows + "');";
        }
        b.Text = b.ToolTip;
        //if (btnImageId == string.Empty)
        //    b.ImageUrl = "../AxpImages/icons/16x16/action.png";
        //else
        //    b.ImageUrl = "../AxpImages/" + btnImageId;

        return b;
    }

    //private void ConstructToolbar()
    //{
    //    logobj.CreateLog("Setting Iview components", sid, fileName, string.Empty);
    //    XmlDocument xmlDocs = new XmlDocument();
    //    try
    //    {
    //        xmlDocs.LoadXml(Session["result" + iName].ToString());
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Redirect(util.ERRPATH + ex.Message);
    //    }
    //    defaultBut = string.Empty;
    //    CreateToolbarButtons(xmlDocs);
    //}

    private void UpdateHdrFtrInObj(XmlNode hdrFtrNode)
    {
        XmlNodeList chNodes = hdrFtrNode.ChildNodes;
        string font = string.Empty;
        if (objIview.ReportHdrs == null)
        {
            objIview.ReportHdrs = new ArrayList();
            objIview.ReportHdrStyles = new ArrayList();
            objIview.ReportFtrs = new ArrayList();
            objIview.ReportFtrStyles = new ArrayList();
        }

        foreach (XmlNode chNode in chNodes)
        {
            if (chNode.Attributes["font"] != null)
                font = chNode.Attributes["font"].Value;
            else
                font = string.Empty;
            if (hdrFtrNode.Name == "header")
            {
                objIview.ReportHdrs.Add(ReplaceSqlParamByvalues(chNode.InnerText, false));
                objIview.ReportHdrStyles.Add(font);
            }
            else
            {
                objIview.ReportFtrs.Add(chNode.InnerText);
                objIview.ReportFtrStyles.Add(font);
            }
        }
    }

    private void CreateToolbarButtons(XmlDocument xmlDoc)
    {
        dynamic toolbarData = new JObject();
        XmlNodeList compNodes = default(XmlNodeList);
        XmlNodeList cbaseDataNodes = default(XmlNodeList);
        string Lsttask = null;
        string action = null;
        string tskCap = null;
        //ArrayList arrDDButtons = new ArrayList();
        ArrayList arrDDBtntype = new ArrayList();
        CreateButtonPos(xmlDoc);

        if (buttonsCreated == false)
        {
            if (objIview.IsDirectDBcall)
            {
                compNodes = xmlDoc.SelectNodes("//root/comps");

                XmlNode task = xmlDoc.SelectSingleNode("//root/comps/btn6");
                if (task != null)
                {
                    XmlElement newNodesaveas = xmlDoc.CreateElement("pop8");
                    newNodesaveas.SetAttribute("caption", "Save as");
                    newNodesaveas.SetAttribute("task", "save as");
                    newNodesaveas.SetAttribute("action", "");
                    task.AppendChild(newNodesaveas);

                    XmlElement newNodexl = xmlDoc.CreateElement("pop9");
                    newNodexl.SetAttribute("caption", "To XL");
                    newNodexl.SetAttribute("task", "to xl");
                    newNodexl.SetAttribute("action", "");
                    task.AppendChild(newNodexl);
                }

            }
            else
            {
                compNodes = xmlDoc.SelectNodes("//comps");
            }



            tskList.Length = 0;
            objIview.ReportHdrs.Clear();
            objIview.ReportHdrStyles.Clear();

            foreach (XmlNode compNode in compNodes)
            {

                if (compNode.Attributes["dwbtb"] != null && compNode.Attributes["dwbtb"].Value.ToString().ToLower() == "true")
                {
                    string structName = string.Empty;
                    if (objIview.IsDirectDBcall && xmlDoc.SelectNodes("//root/iview/a3")[0].InnerText != null)
                    {
                        structName = xmlDoc.SelectNodes("//root/iview/a3")[0].InnerText.ToString();
                    }
                    toolbarJSON = CreateDWBToolbarButtons(compNode, structName);
                }
                else
                {
                    cbaseDataNodes = compNode.ChildNodes;
                    int cnt = 0;
                    int compNodeCnt = 0;
                    int toolbarBtnCnt = 0;
                    toolbarBtnCnt = cbaseDataNodes.Count - 1;
                    for (compNodeCnt = 0; compNodeCnt <= toolbarBtnCnt; compNodeCnt++)
                    {
                        if (cbaseDataNodes[compNodeCnt].Name == "header" || cbaseDataNodes[compNodeCnt].Name == "footer")
                        {
                            //if (arrDDButtons.Count > 0 && compNodeCnt == toolbarBtnCnt)
                            //{
                            //    //arrButtons.Add(strDDButtons.ToString());
                            //    ConstructDDbtns(arrDDButtons, arrDDBtntype);
                            //    arrDDButtons = new ArrayList();
                            //}
                            UpdateHdrFtrInObj(cbaseDataNodes[compNodeCnt]);

                            if (cbaseDataNodes[compNodeCnt].Name == "footer")
                                foreach (XmlElement item in cbaseDataNodes[compNodeCnt])
                                    if (!string.IsNullOrEmpty(objIview.IviewFooter))
                                        objIview.IviewFooter += "|" + item.InnerText;
                                    else
                                        objIview.IviewFooter = item.InnerText;

                            continue;
                        }

                        if (cbaseDataNodes[compNodeCnt].Name.Length >= 6)
                        {
                            if (cbaseDataNodes[compNodeCnt].Name.Substring(0, 7) == "x__head")
                            {
                                ivCaption = cbaseDataNodes[compNodeCnt].Attributes["caption"].Value;
                                ivCaption = ivCaption.Replace("&&", "&");
                            }
                        }

                        string tlhw = string.Empty;
                        string actionn = string.Empty;
                        string taskk = string.Empty;
                        if (cbaseDataNodes[compNodeCnt].Attributes["tlhw"] != null)
                        {
                            tlhw = cbaseDataNodes[compNodeCnt].Attributes["tlhw"].Value;
                            if (cbaseDataNodes[compNodeCnt].Attributes["action"] != null)
                                actionn = cbaseDataNodes[compNodeCnt].Attributes["action"].Value;
                            if (cbaseDataNodes[compNodeCnt].Attributes["task"] != null)
                                taskk = cbaseDataNodes[compNodeCnt].Attributes["task"].Value;
                        }

                        if (cbaseDataNodes[compNodeCnt].Name.Substring(0, 3) == "btn")
                        {
                            string[] arrLeft = null;
                            //If there is a button with empty task and empty action no need to add button

                            if (!(string.IsNullOrEmpty(taskk)) && taskk == "printersetting")
                            {
                                continue;
                            }
                            if (!(string.IsNullOrEmpty(tlhw)) && (!(string.IsNullOrEmpty(actionn)) || !(string.IsNullOrEmpty(taskk))))
                            {
                                arrLeft = tlhw.Split(',');
                                if (arrLeft.Length > 0)
                                {
                                    if (arrTempBtnLeft.IndexOf(arrLeft[1].ToString()) != -1)
                                        arrLeft[1] = Convert.ToString(Convert.ToInt32(arrLeft[1], 10) + 1);
                                    arrTempBtnLeft.Add(arrLeft[1]);
                                }
                            }
                            //addding buttons to dropdown in Iview
                            //string btndd = string.Empty;
                            //if (cbaseDataNodes[compNodeCnt].Attributes["dropdown"] != null)
                            //{
                            //    btndd = cbaseDataNodes[compNodeCnt].Attributes["dropdown"].Value;
                            //    dvActions.Style.Add("display", "block");
                            //}

                            //string isDDParent = string.Empty;
                            //if (cbaseDataNodes[compNodeCnt].Attributes["parentnode"] != null)
                            //    isDDParent = cbaseDataNodes[compNodeCnt].Attributes["parentnode"].Value;

                            //if (isDDParent == string.Empty && arrDDButtons.Count > 0)
                            //{
                            //    ConstructDDbtns(arrDDButtons, arrDDBtntype);
                            //    //arrButtons.Add(strDDButtons.ToString());
                            //    arrDDButtons = new ArrayList();
                            //}

                            string task = string.Empty;
                            if (cbaseDataNodes[compNodeCnt].Attributes["task"] != null)
                            {
                                task = cbaseDataNodes[compNodeCnt].Attributes["task"].Value;
                            }

                            JObject toolbarJO = new JObject();
                            toolbarJO.Add("isRoot", false);
                            if (task != "tasks")
                            {
                                toolbarJO.Add("structure", iName);
                            }

                            JObject taskJO = null;

                            string caption = string.Empty;

                            string hint = string.Empty;
                            if (cbaseDataNodes[compNodeCnt].Attributes["hint"] != null)
                            {
                                hint = cbaseDataNodes[compNodeCnt].Attributes["hint"].Value;
                            }
                            string sname = string.Empty;
                            if (cbaseDataNodes[compNodeCnt].Attributes["sname"] != null && cbaseDataNodes[compNodeCnt].Attributes["sname"].Value != "")
                            {
                                sname = cbaseDataNodes[compNodeCnt].Attributes["sname"].Value;
                            }
                            else if (objIview.IsDirectDBcall && xmlDoc.SelectNodes("//root/iview/a3")[0].InnerText != null)
                            {
                                sname = xmlDoc.SelectNodes("//root/iview/a3")[0].InnerText.ToString();
                            }
                            objIview.AssociatedTStruct = sname;

                            string actionVal = string.Empty;
                            if (cbaseDataNodes[compNodeCnt].Attributes["action"] != null)
                            {
                                actionVal = cbaseDataNodes[compNodeCnt].Attributes["action"].Value;
                            }
                            string fileUpload = string.Empty;
                            if (cbaseDataNodes[compNodeCnt].Attributes["fileupload"] != null)
                            {
                                fileUpload = cbaseDataNodes[compNodeCnt].Attributes["fileupload"].Value;
                                if (task != "tasks")
                                {
                                    toolbarJO.Add("fileUpload", fileUpload);//y
                                }
                            }
                            string confirm = null;
                            XmlNode cnf = cbaseDataNodes[compNodeCnt].Attributes["desc"];
                            if (cnf == null)
                            {
                                confirm = string.Empty;
                            }
                            else
                            {
                                confirm = cnf.Value;
                            }
                            if (iName == "inmemdb")
                            {
                                confirm = "Are you sure you want to delete the selected key(s)?";
                            }
                            if (task != "tasks")
                            {
                                toolbarJO.Add("confirm", confirm);
                            }
                            string appl = null;
                            XmlNode ap = cbaseDataNodes[compNodeCnt].Attributes["apply"];
                            if (ap == null)
                            {
                                appl = string.Empty;
                            }
                            else
                            {
                                appl = ap.Value;
                            }
                            if (task != "tasks")
                            {
                                toolbarJO.Add("allRows", appl);
                            }
                            if (task == "refresh")
                            {
                                arrButtons.Add(string.Empty);
                                //Currently not available for this version

                            }
                            else if (task == "view")
                            {
                                arrButtons.Add(string.Empty);
                                //Currently not available for this version
                            }
                            else if (task == "print")
                            {
                                //<p><span><img id="new" onclick="parent.LoadIframe('tstructdesign.aspx?transid=purrq')" src="../axpimages/toolicons/edit2.png" border="0" alt="Design Mode" title="design" class="handCur"></span></p>
                                arrButtons.Add("<li class='liPrint'><a class='print' title='Print' href=\"javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",'true');\" >" + hint + "</a></li>");
                                //JObject toolbarJO = new JObject();
                                //toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                                //toolbarJO.Add("hint", hint);
                                //toolbarJO.Add("structure", iName);
                                toolbarJO.Add("href", "javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",'true');");
                                //toolbarJSON[task] = toolbarJO;
                            }
                            else if (task == "preview")
                            {
                                arrButtons.Add(string.Empty);
                                //Currently not available for this version
                            }
                            else if (task == "analyze")
                            {
                                arrButtons.Add(string.Empty);
                            }
                            else if (task == "delete")
                            {
                                //Below line is to avoid creating the delete button if the associated tstruct is not given for the iview
                                string deleteStructureName = string.Empty;
                                if (sname == string.Empty)
                                    deleteStructureName = iName;
                                else
                                    deleteStructureName = sname;
                                arrButtons.Add("<li class='liDelete'><a class='delete' title='" + hint + "' href=\"javascript:callDelete('" + deleteStructureName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");\">" + hint + "</a></li>");
                                //toolbarJSON[task] = JObject.Parse(@"{left: '" + arrTempBtnLeft[arrTempBtnLeft.Count - 1] + "', hint: '" + hint + "', structure: '" + deleteStructureName + "'}");
                                //JObject toolbarJO = new JObject();
                                //toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                                //toolbarJO.Add("hint", hint);
                                toolbarJO["structure"] = deleteStructureName;
                                toolbarJO.Add("href", "javascript:callDelete('" + deleteStructureName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                //toolbarJSON[task] = toolbarJO;
                                //caption = "Remove";
                                caption = hint;
                            }
                            else if (task == "new")
                            {
                                string newStructureName = string.Empty;
                                if (sname == string.Empty)
                                    newStructureName = iName;
                                else
                                    newStructureName = sname;
                                arrButtons.Add("<li class='liNew'><a class='add' title='" + hint + "' href=\"javascript:callOpenAction('opentstruct','" + newStructureName + "');\">" + hint + "</a></li>");
                                //toolbarJSON[task] = JObject.Parse(@"{left: '" + arrTempBtnLeft[arrTempBtnLeft.Count - 1] + "', hint: '" + hint + "', structure: '" + newStructureName + "'}");
                                //JObject toolbarJO = new JObject();
                                //toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                                //toolbarJO.Add("hint", hint);
                                toolbarJO["structure"] = newStructureName;
                                toolbarJO.Add("href", "javascript:callOpenAction('opentstruct','" + newStructureName + "');");
                                //toolbarJSON[task] = toolbarJO;
                            }
                            else if (task == "pdf")
                            {
                                arrButtons.Add("<li class='liPdf'><a class='pdf' title='PDF' href=\"javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");\">" + hint + "</a></li>");
                                //toolbarJSON[task] = JObject.Parse(@"{left: '" + arrTempBtnLeft[arrTempBtnLeft.Count - 1] + "', hint: '" + hint + "', structure: '" + iName + "'}");
                                //JObject toolbarJO = new JObject();
                                //toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                                //toolbarJO.Add("hint", hint);
                                //toolbarJO.Add("structure", iName);
                                toolbarJO.Add("href", "javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                //toolbarJSON[task] = toolbarJO;
                            }
                            else if (task == "tasks")
                            {

                                //toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                                //toolbarJO.Add("hint", hint);
                                //toolbarJO.Add("structure", iName);
                                //TaskBut = "a";

                                XmlNodeList taskListNodes = default(XmlNodeList);
                                taskListNodes = cbaseDataNodes[compNodeCnt].ChildNodes;
                                if (taskListNodes.Count > 0)
                                {
                                    toolbarJO["isRoot"] = true;
                                    toolbarJO.Add("href", "javascript:void(0);");
                                    Custom custObj = Custom.Instance;
                                    try
                                    {
                                        hint = custObj.AxBeforeAddTaskTitle(hint);
                                    }
                                    catch (Exception ex)
                                    {
                                        hint = "Tasks";
                                    }
                                    arrButtons.Add(string.Empty);

                                    string tasksUlWrapperStart = "<li class='dropdown'><a href='javascript:void(0)' id='tasks' class='dropdown-toggle' data-toggle='dropdown' data-hover='dropdown' title='Tasks' data-close-others='true'>" + "Tasks" + "&nbsp;<span class='caret'></span></a><ul class='dropdown-menu'>";

                                    tskList.Append(tasksUlWrapperStart);
                                    int leftCounter = -1000;
                                    foreach (XmlNode taskItem in taskListNodes)
                                    {
                                        Lsttask = taskItem.Attributes["task"].Value;
                                        tskCap = taskItem.Attributes["caption"].Value;
                                        action = taskItem.Attributes["action"].Value;
                                        Lsttask = Lsttask.ToLower();
                                        if (!string.IsNullOrEmpty(Lsttask) & string.IsNullOrEmpty(action))
                                        {
                                            taskJO = new JObject();
                                            if (Lsttask == "attach")
                                            {
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:AttachFiles();'><a class='TaskItems' href=\"javascript:void(0)\" id='attach' title=" + tskCap + " >" + tskCap + "</a></li>");
                                                taskJO.Add("href", "javascript:void(0);");
                                                taskJO.Add("onclick", "javascript:AttachFiles();");
                                            }
                                            else if (Lsttask == "email")
                                            {
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:openEMail(\"" + tid + "\",\"tstruct\",\"0\");'><a class='TaskItems' href=\"javascript:void(0)\" id='email' title=" + tskCap + " >" + tskCap + "</a></li>");
                                                taskJO.Add("href", "javascript:void(0);");
                                                taskJO.Add("onclick", "javascript:openEMail('" + tid + "','tstruct','0');");
                                            }
                                            else if (Lsttask == "print")
                                            {
                                                //Currently not available for this version
                                            }
                                            else if (Lsttask == "pdf")
                                            {
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:toPDF(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'><a class='TaskItems' href=\"javascript:void(0)\" id='pdf' title=" + tskCap + " >" + tskCap + "</a></li>");
                                                taskJO.Add("href", "javascript:void(0);");
                                                taskJO.Add("onclick", "javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                            }
                                            else if (Lsttask == "save as")
                                            {
                                                //to display PDF and HTML options in Save as dropdown
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:toPDF(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'><a class='TaskItems' href=\"javascript:void(0)\" id='pdf' title='PDF' >PDF</a></li>");
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:toHTML(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ",true);'><a class='TaskItems' href=\"javascript:void(0)\" id='HTML' title='Print' >Print</a></li>");

                                                //tskList.Append("<li  class='liTaskItems' onclick='javascript:CallSaveAs(\"" + iName + "\","+(objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"")+");window.close();'><a class='TaskItems' href=\"javascript:void(0)\" id='saveas' title=" + tskCap + " >" + tskCap + "</a></li>");
                                                taskJO.Add("href", "javascript:void(0);");
                                                taskJO.Add("onclick", JObject.Parse("{\"PDF\": \"javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");\", \"Print\": \"javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",true);\", \"HTML\": \"javascript:SetDatatableExport('html');\", \"JSON\": \"javascript:SetDatatableExport('json');\", \"Copy\": \"javascript:SetDatatableExport('copy');\"}"));
                                            }
                                            else if (Lsttask == "preview")
                                            {
                                                //Currently not available for this version
                                            }
                                            else if (Lsttask == "to xl")
                                            {
                                                tskList.Append("<li  class='liTaskItems' onclick='javascript:toExcelWeb(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'><a class='TaskItems' href=\"javascript:void(0)\" id='excel' title='Excel'>Excel</a></li>");
                                                taskJO.Add("href", "javascript:void(0);");
                                                taskJO.Add("onclick", "javascript:toExcelWeb('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                                tskCap = "Excel";
                                            }
                                            else if (Lsttask == "params")
                                            {
                                            }

                                            taskJO.Add("isRoot", false);
                                            taskJO.Add("task", Lsttask);
                                            taskJO.Add("caption", tskCap);
                                            //taskJO.Add("action", action);
                                            taskJO.Add("isAction", false);
                                            taskJO.Add("structure", iName);
                                            taskJO.Add("key", Lsttask);
                                            taskJO.Add("left", (leftCounter++).ToString());
                                            toolbarJO.Add(Lsttask, taskJO);
                                        }
                                    }
                                    if (tskList.ToString() == tasksUlWrapperStart)
                                    {
                                        tskList.Clear();
                                    }
                                    else
                                    {
                                        tskList.Append("</ul></li>");
                                    }
                                }
                                else
                                {
                                    arrButtons.Add(string.Empty);
                                }

                                arrButtons[(arrButtons.Count) - 1] += (tskList).ToString();
                                //Session["tskList" + iName] = tskList;

                                //toolbarJSON[task] = toolbarJO;
                            }
                            else if (task == "find")
                            {
                                arrButtons.Add(string.Empty);
                                defaultBut = defaultBut + string.Empty;
                            }
                            else if (task == "save as")
                            {
                                //arrButtons.Add("<li class='liSaveAs'><a class='saveas' href='javascript:CallSaveAs(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");window.close();'>" + hint + "</a></li>");
                                //toolbarJO.Add("href", "javascript:CallSaveAs('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");window.close();");

                                //to display PDF and HTML options in Save as dropdown
                                tskList.Append("<li  class='liSaveAs' onclick='javascript:toPDF(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'><a class='SaveAs' href=\"javascript:void(0)\" id='pdf2' title='PDF' >PDF</a></li>");
                                tskList.Append("<li  class='liSaveAs' onclick='javascript:toHTML(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ",true);'><a class='SaveAs' href=\"javascript:void(0)\" id='HTML2' title='Print' >Print</a></li>");
                                toolbarJO.Add("href", "javascript:void(0);");
                                toolbarJO.Add("onclick", JObject.Parse("{\"PDF\": \"javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");\", \"Print\": \"javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",true);\", \"HTML\": \"javascript:SetDatatableExport('html');\", \"JSON\": \"javascript:SetDatatableExport('json');\", \"Copy\": \"javascript:SetDatatableExport('copy');\"}"));
                            }
                            else if (task == "to xl")
                            {
                                arrButtons.Add("<li class='liToExcel'><a class='toexcel' title='Save as Excel' href='javascript:toExcelWeb(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'>" + hint + "</a></li>");
                                toolbarJO.Add("href", "javascript:toExcelWeb('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                            }
                            else if (task == string.Empty && actionVal != string.Empty)
                            {
                                string imgName = string.Empty;
                                if (cbaseDataNodes[compNodeCnt].Attributes["caption"] != null)
                                {
                                    caption = cbaseDataNodes[compNodeCnt].Attributes["caption"].Value;
                                }

                                string btnImage = string.Empty;
                                if (cbaseDataNodes[compNodeCnt].Attributes["img"] != null)
                                {
                                    imgName = cbaseDataNodes[compNodeCnt].Attributes["img"].Value;
                                    btnImage = imgName.ToString();
                                }

                                if (!util.IsImageAvailable(btnImage))
                                    btnImage = "";
                                else
                                {
                                    btnImage = btnImage.Substring(0, btnImage.IndexOf(".") + 1) + "png";
                                }


                                if (actionVal != string.Empty)
                                {
                                    toolbarJO.Add("isAction", true);
                                    if (string.IsNullOrEmpty(cbaseDataNodes[compNodeCnt].Attributes["caption"].Value) && cbaseDataNodes[compNodeCnt].Attributes["hint"].Value == "New")
                                    {
                                        arrButtons.Add(string.Empty);
                                        //actionBtns.Add("<li><a class='action arrButtonsAction' title='New'>" + GetButton(actionVal, iName, confirm, appl, btnImage, "New") + "</a></li>");
                                        actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, "New"));
                                        toolbarJO.Add("href", "javascript:void(0);");
                                        toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        // dvActionBtns.Controls.Add(GetButton(actionVal, iName, confirm, appl, "New"));

                                    }
                                    else if (fileUpload == "y")
                                    {
                                        //arrButtons.Add("<input type=hidden id=cb_sactbu name=cb_sactbu/><li><a class='action arrButtonsAction' href=\"javascript:callFileUploadAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\">" + (hint != string.Empty ? hint : caption) + "</a></li>");

                                        actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, (hint != string.Empty ? hint : caption), true));

                                        toolbarJO.Add("href", "javascript:void(0);");
                                        toolbarJO.Add("onclick", "javascript:callFileUploadAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');");
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(caption) & !string.IsNullOrEmpty(imgName))
                                        {
                                            //Display Image with caption as hint.
                                            // arrButtons.Add("<li><a href=\"javascript:callAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\" class=handCur><img src=\"../AxpImages/" + btnImage + "\" border=0 alt='" + hint + "' title='" + hint + "' ></a></li>&nbsp;");
                                            arrButtons.Add(string.Empty);
                                            actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, caption));
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        }
                                        else if (!string.IsNullOrEmpty(imgName) & string.IsNullOrEmpty(caption))
                                        {
                                            //Display only image
                                            //arrButtons.Add("<li><a href=\"javascript:callAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\" class=handCur><img src=\"../AxpImages/" + btnImage + "\" border=0 alt='" + hint + "' title='" + hint + "'></a></li>&nbsp;");
                                            arrButtons.Add(string.Empty);
                                            actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, (hint != string.Empty ? hint : caption)));
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        }
                                        else if (!string.IsNullOrEmpty(caption) & string.IsNullOrEmpty(imgName))
                                        {
                                            //Display button with Caption
                                            //arrButtons.Add("<input type=button onclick=\"javascript:callAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\" value=\"" + caption + "\" />&nbsp;");
                                            arrButtons.Add(string.Empty);
                                            actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, caption));
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        }
                                        else if (string.IsNullOrEmpty(caption) & string.IsNullOrEmpty(imgName))
                                        {
                                            // arrButtons.Add("<input type=button onclick=\"javascript:callAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\" value=\"" + caption + "\" />&nbsp;");
                                            arrButtons.Add(string.Empty);
                                            actionBtns.Add(GetButton(actionVal, iName, confirm, appl, btnImage, (hint != string.Empty ? hint : caption)));
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        }

                                    }
                                }
                                else
                                {
                                    toolbarJO.Add("isAction", false);
                                }

                                if (!string.IsNullOrEmpty(task))
                                {
                                    arrButtons.Add(string.Empty);
                                }
                                else if (string.IsNullOrEmpty(task) & string.IsNullOrEmpty(actionVal))
                                {
                                    arrBtnLeftVals.Add(string.Empty);

                                }
                            }
                            else
                            {
                                //If there is a button with empty task and empty action no need to add button
                            }
                            //JObject toolbarJO = new JObject();
                            if (toolbarJO != null)
                            {
                                if (task != "tasks")
                                {
                                    toolbarJO.Add("hint", hint);
                                    toolbarJO.Add("caption", caption);
                                }
                                else
                                {
                                    toolbarJO["isRoot"] = true;
                                    toolbarJO.Add("groupName", "Options");
                                }
                                //toolbarJO.Add("structure", iName);
                                //if (taskJO != null) {
                                //    toolbarJO.Add(Lsttask, taskJO);
                                //    taskJO = null;
                                //}
                            if (arrTempBtnLeft.Count == 0)
                            {
                                toolbarJO.Add("left", "0");
                            }
                            else
                            {
                                toolbarJO.Add("left", arrTempBtnLeft[arrTempBtnLeft.Count - 1].ToString());
                            }
                                string keyName = task != string.Empty ? task : actionVal;
                                toolbarJO["key"] = keyName;
                                toolbarJSON[keyName] = toolbarJO;
                            }
                            //Condition to add dropdown buttons
                            //if (btndd == "true" || isDDParent != "")
                            //{
                            //    if (task != "")
                            //    {
                            //        arrDDButtons.Add(arrButtons[arrButtons.Count - 1].ToString());
                            //        arrDDBtntype.Add("t");
                            //        arrButtons.RemoveAt(arrButtons.Count - 1);
                            //    }
                            //    else if (action != "")
                            //    {
                            //        arrDDBtntype.Add("a");
                            //        arrDDButtons.Add("<li><a class=\"action\" href=\"javascript:callAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');\"><span>" + actionVal + "</span>&nbsp;</a></span></li>");
                            //        actionBtns.RemoveAt(actionBtns.Count - 1);
                            //    }
                            //}

                            //if (arrDDButtons.Count > 0 && compNodeCnt == toolbarBtnCnt)
                            //{

                            //    ConstructDDbtns(arrDDButtons, arrDDBtntype);
                            //    arrDDButtons = new ArrayList();
                            //}
                        }
                    }//end of for
                }
            }
            //if (objIview.purposeString == "") { 
            AlignToolbarBtns();
            //}
        }

        if (string.IsNullOrEmpty(lblHeading) & !string.IsNullOrEmpty(ivCaption))
        {
            lblHeading = ivCaption;
        }
        else
        {

        }

        buttonsCreated = true;


        ConstructActionBtns();
    }

    private JObject CreateDWBToolbarButtons(XmlNode compNode, string sname)
    {
        XmlNodeList cbaseDataNodes = default(XmlNodeList);
        JObject mainToolbarJO = new JObject();
        //JObject toolbarJO = new JObject();

        cbaseDataNodes = compNode.ChildNodes;
        foreach (XmlNode cbaseDataNode in cbaseDataNodes)
        {
            if (cbaseDataNode.Name.Length >= 6)
            {
                if (cbaseDataNode.Name.Substring(0, 7) == "x__head")
                {
                    ivCaption = cbaseDataNode.Attributes["caption"].Value;
                    ivCaption = ivCaption.Replace("&&", "&");
                }
            }
            string action = string.Empty;
            string task = string.Empty;
            string visible = "true";
            string script = string.Empty;
            string caption = string.Empty;
            string key = string.Empty;
            // string sname = string.Empty;
            string actionVal = string.Empty;
            string fileUpload = string.Empty;
            dynamic icon;
            //string iconClass = string.Empty;
            //string image = string.Empty;
            string confirm = null;
            bool isroot = false;
            JObject taskJO = null;
            JObject toolbarJO = new JObject();
            if (cbaseDataNode.Name != "icon")
            {
                if (cbaseDataNode.Attributes["task"] != null)
                {
                    task = cbaseDataNode.Attributes["task"].Value.ToLower();
                }
                if (cbaseDataNode.Attributes["visible"] != null)
                {
                    visible = cbaseDataNode.Attributes["visible"].Value.ToLower();
                }
                if (!(string.IsNullOrEmpty(task)) && task == "printersetting")
                {
                    continue;
                }
                if (visible == "false") {
                    continue;
                }
                if (cbaseDataNode.Attributes["folder"] != null)
                {
                    isroot = cbaseDataNode.Attributes["folder"].Value.ToLower() == "true" ? true : false;
                }
                if (cbaseDataNode.Attributes["key"] != null)
                {
                    key = cbaseDataNode.Attributes["key"].Value;
                }
                if (cbaseDataNode.Attributes["caption"] != null)
                {
                    caption = cbaseDataNode.Attributes["caption"].Value;
                }
                if (cbaseDataNode.Attributes["action"] != null)
                {
                    actionVal = cbaseDataNode.Attributes["action"].Value;
                }
                if (cbaseDataNode.Attributes["fileupload"] != null)
                {
                    fileUpload = cbaseDataNode.Attributes["fileupload"].Value;
                    if (task != "tasks")
                    {
                        toolbarJO.Add("fileUpload", fileUpload);//y
                    }
                }
                if (cbaseDataNode.Attributes["img"] != null && cbaseDataNode.Attributes["img"].Value != "" && util.IsImageAvailable(cbaseDataNode.Attributes["img"].Value, "icon"))
                {
                    icon = cbaseDataNode.Attributes["img"].Value;
                }
                else if (cbaseDataNode.SelectSingleNode("icon") != null)
                {
                    icon = new JObject();
                    XmlNode iconNode = cbaseDataNode.SelectSingleNode("icon");
                    if (iconNode.SelectSingleNode("text") != null && iconNode.SelectSingleNode("addClass") != null)
                    {
                        icon["text"] = iconNode.SelectSingleNode("text").InnerText;
                        icon["addClass"] = iconNode.SelectSingleNode("addClass").InnerText;
                    }
                }
                else
                {
                    icon = string.Empty;
                }
                if (cbaseDataNode.Attributes["sname"] != null && cbaseDataNode.Attributes["sname"].Value != "")
                {
                    sname = cbaseDataNode.Attributes["sname"].Value;
                }
                objIview.AssociatedTStruct = sname;
                if (task != "tasks")
                {
                    toolbarJO.Add("structure", iName);
                }
                XmlNode cnf = cbaseDataNode.Attributes["desc"];
                if (cnf == null)
                {
                    confirm = string.Empty;
                }
                else
                {
                    confirm = cnf.Value;
                }
                if (iName == "inmemdb")
                {
                    confirm = "Are you sure you want to delete the selected key(s)?";
                }
                if (task != "tasks")
                {
                    toolbarJO.Add("confirm", confirm);
                }
                string appl = null;
                XmlNode ap = cbaseDataNode.Attributes["apply"];
                if (ap == null)
                {
                    appl = string.Empty;
                }
                else
                {
                    appl = ap.Value;
                }
                if (task != "tasks")
                {
                    toolbarJO.Add("allRows", appl);
                }
                if (isroot)
                {
                    JObject childJO = null;
                    childJO = CreateDWBToolbarButtons(cbaseDataNode, sname);
                    toolbarJO.Merge(childJO, new JsonMergeSettings
                    {
                        // union array values together to avoid duplicates
                        MergeArrayHandling = MergeArrayHandling.Union
                    });
                    //toolbarJO.Add("groupName", caption);
                }
                else
                {
                    switch (task)
                    {

                        case "refresh":
                            {
                                //Currently not available for this version
                                break;
                            }
                        case "view":
                            {
                                //Currently not available for this version
                                break;
                            }
                        case "print":
                            {

                                toolbarJO.Add("href", "javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",'true');");
                                break;
                            }
                        case "preview":
                            {
                                break;
                            }
                        case "analyze":
                            {
                                break;
                            }
                        case "delete":
                            {
                                //Below line is to avoid creating the delete button if the associated tstruct is not given for the iview
                                string deleteStructureName = string.Empty;
                                if (sname == string.Empty)
                                    deleteStructureName = iName;
                                else
                                    deleteStructureName = sname;
                                toolbarJO["structure"] = deleteStructureName;
                                toolbarJO.Add("href", "javascript:callDelete('" + deleteStructureName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");

                                break;
                            }
                        case "new":
                            {
                                string newStructureName = string.Empty;
                                if (sname == string.Empty)
                                    newStructureName = iName;
                                else
                                    newStructureName = sname;
                                toolbarJO["structure"] = newStructureName;
                                toolbarJO.Add("href", "javascript:callOpenAction('opentstruct','" + newStructureName + "');");
                                break;
                            }
                        case "pdf":
                            {
                                toolbarJO.Add("href", "javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                break;
                            }

                        case "find":
                            {
                                break;
                            }
                        case "save as":
                            {
                                toolbarJO.Add("href", "javascript:void(0);");
                                toolbarJO.Add("onclick", JObject.Parse("{\"PDF\": \"javascript:toPDF('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");\", \"Print\": \"javascript:toHTML('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ",true);\"}"));
                                break;
                            }
                        case "to xl":
                            {
                                toolbarJO.Add("href", "javascript:toExcelWeb('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
                                break;
                            }
                        case "tasks":
                            {
                                isroot = true;
                                JObject childJO = null;
                                childJO = CreateDWBToolbarButtons(cbaseDataNode, sname);
                                toolbarJO.Merge(childJO, new JsonMergeSettings
                                {
                                    // union array values together to avoid duplicates
                                    MergeArrayHandling = MergeArrayHandling.Union
                                });
                                //childJO.Add("groupName", caption);
                                break;
                            }
                        case "":
                            {
                                if (actionVal != string.Empty)
                                {
                                    //toolbarJO.Add("href", "javascript:void(0);");
                                    //toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");



                                    if (actionVal != string.Empty)
                                    {
                                        toolbarJO.Add("isAction", true);
                                        if (string.IsNullOrEmpty(cbaseDataNode.Attributes["caption"].Value) && cbaseDataNode.Attributes["hint"].Value == "New")
                                        {
                                            arrButtons.Add(string.Empty);
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");

                                        }
                                        else if (fileUpload == "y")
                                        {

                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "javascript:callFileUploadAction('" + actionVal + "','" + iName + "','" + confirm + "','" + appl + "');");
                                        }
                                        else
                                        {
                                            toolbarJO.Add("href", "javascript:void(0);");
                                            toolbarJO.Add("onclick", "return ActButtonClick('btn_" + actionVal + "','" + confirm + "','" + appl + "');");
                                        }
                                    }
                                    else
                                    {
                                        toolbarJO.Add("isAction", false);
                                    }

                                    if (!string.IsNullOrEmpty(task))
                                    {
                                        arrButtons.Add(string.Empty);
                                    }
                                    else if (string.IsNullOrEmpty(task) & string.IsNullOrEmpty(actionVal))
                                    {
                                        arrBtnLeftVals.Add(string.Empty);

                                    }
                                }
                                else
                                {
                                    //If there is a button with empty task and empty action no need to add button
                                }
                                break;
                            }
                    }
                }

                if (toolbarJO != null)
                {
                    //if (task != "tasks")
                    //{
                    //    toolbarJO.Add("hint", caption);
                    //    toolbarJO.Add("caption", caption);
                    //}
                    //else
                    //{
                    //    toolbarJO["isRoot"] = true;
                    //    toolbarJO.Add("groupName", "Options");
                    //}

                    if (task != "tasks")
                    {
                        toolbarJO.Add("groupName", caption);
                    }
                    else
                    {
                        toolbarJO.Add("groupName", "Options");
                    }

                    toolbarJO.Add("hint", caption);
                    toolbarJO.Add("caption", caption);
                    //string keyName = task != string.Empty ? task : actionVal;
                    if (key == "")
                    {
                        key = task != string.Empty ? task : actionVal;
                    }
                    toolbarJO["key"] = key;
                    toolbarJO.Add("icon", icon);
                    toolbarJO.Add("isRoot", isroot);
                    mainToolbarJO[key] = toolbarJO;
                }

            }
        }
        //end of for
        buttonsCreated = true;
        // return toolbarJO;
        return mainToolbarJO;
    }
    private void ConstructActionBtns()
    {
        string groupButtons = "";
        objIview.customBtnIV.Clear();
        if (objIview.IsDirectDBcall && !objParams.IsParameterExist)
        {
            groupButtons = util.GetCustomsGroupButtons(iName, "iview");// this service call will happen only on direct DB=true & params not exist 
        }
        else if (ViewState["ivGroupBtns"] != null)
        {
            groupButtons = ViewState["ivGroupBtns"].ToString();
        }
        if (actionBtns.Count > 0)
        {
            if (groupButtons != "")
            {
                try
                {
                    ArrayList tempChecker = actionBtns;
                    String[] btnGroups = groupButtons.Split('~');
                    for (int i = 0; i < btnGroups.Length; i++)
                    {
                        //HtmlGenericControl parentLi = new HtmlGenericControl("li");
                        //parentLi.Attributes.Add("class", "gropuedBtn");
                        //parentLi.InnerText = "Options";
                        //HtmlGenericControl div = new HtmlGenericControl("div");
                        //HtmlGenericControl buttonhtml = new HtmlGenericControl("button");
                        //HtmlGenericControl dropul = new HtmlGenericControl("ul");
                        //dropul.Attributes.Add("id", "uldropelements");
                        //dropul.Attributes.Add("class", "dropdown-menu");

                        string[] seperateButton = (btnGroups[i].Split('-')[1]).ToString().Split(',');

                        JObject actionButtonJO = new JObject();

                        for (int j = 0; j < seperateButton.Length; j++)
                        {

                            for (int k = 0; k < actionBtns.Count; k++)
                            {
                                if (((System.Web.UI.Control)(actionBtns[k])).ClientID.Equals("btn_" + seperateButton[j]))
                                {
                                    //LinkButton btn = (LinkButton)actionBtns[k];
                                    //Label lbl = new Label();
                                    //HtmlGenericControl li = new HtmlGenericControl("li");
                                    //li.Attributes.Add("class", "actionWrapper");

                                    //li.Controls.Add(btn);
                                    //dropul.Controls.Add(li);
                                    tempChecker.RemoveAt(k);
                                }

                                if (toolbarJSON[seperateButton[j]] != null && toolbarJSON[seperateButton[j]]["isRoot"] == false)
                                {
                                    actionButtonJO.Add(seperateButton[j], toolbarJSON[seperateButton[j]]);
                                    toolbarJSON.Property(seperateButton[j]).Remove();
                                }
                            }

                        }

                        //buttonhtml.Attributes.Add("class", "btn actionsBtn dropdown-toggle");
                        //buttonhtml.Attributes.Add("type", "button");
                        //buttonhtml.Attributes.Add("data-toggle", "dropdown");

                        string btnGroupCaption = btnGroups[i].Split('-')[0].ToString();
                        //if (btnGroupCaption != "")
                        //    buttonhtml.InnerHtml = btnGroupCaption + " <span class=\"icon-arrows-down\"></span>";
                        //else
                        //    buttonhtml.InnerHtml = "Options <span class=\"icon-arrows-down\"></span>";

                        actionButtonJO.Add("isRoot", true);
                        actionButtonJO.Add("groupName", btnGroupCaption);
                        actionButtonJO["key"] = "customGroup" + (i + 1);
                        toolbarJSON.Add("customGroup" + (i + 1), actionButtonJO);

                        //div.Attributes.Add("class", "dropdown");
                        //div.Controls.Add(buttonhtml);
                        //div.Controls.Add(dropul);
                        //parentLi.Controls.Add(div);
                        //iconsUl.Controls.Add(parentLi);
                    }


                    foreach (LinkButton item in tempChecker)
                    {
                        if (item.Text != "")
                        {
                            //LinkButton btn = (LinkButton)item;
                            //Label lbl = new Label();

                            //HtmlGenericControl li = new HtmlGenericControl("li");
                            //li.Attributes.Add("class", "actionWrapper");
                            //btn.CssClass = "action singleaction handCur l2";

                            //li.Controls.Add(btn);

                            //iconsUl.Controls.Add(li);
                        }

                    }
                }
                catch (Exception ex)
                {
                    logobj.CreateLog("Iview - Grouped Button -\r\nValue: " + groupButtons + "\r\nException: " + ex.Message + "", HttpContext.Current.Session["nsessionid"].ToString(), "openiview-dev-" + iName, string.Empty);
                }
            }
            else
            {
                for (int i = 0; i < actionBtns.Count; i++)
                {
                    //LinkButton btn = (LinkButton)actionBtns[i];
                    //Label lbl = new Label();

                    //HtmlGenericControl li = new HtmlGenericControl("li");
                    //li.Attributes.Add("class", "actionWrapper");
                    //btn.CssClass = "action singleaction handCur l2";

                    //li.Controls.Add(btn);
                    //iconsUl.Controls.Add(li);

                }
            }
        }
        objIview.ToolBarBtn = actionButvs;
        //string toolbarJsonString = toolbarJSON.ToString();
    }

    //private void ConstructDDbtns(ArrayList strBtnHtml, ArrayList arrDDBtntype)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    for (int i = 0; i < strBtnHtml.Count; i++)
    //    {
    //        string type = arrDDBtntype[i].ToString();
    //        if (type == "t")
    //            sb.Append(strBtnHtml[i].ToString());
    //        else
    //            sb.Append(strBtnHtml[i].ToString());

    //    }
    //    ddActionBtns.InnerHtml = sb.ToString();
    //}

    private void CreateHeaderRow(XmlDocument xmlDoc, string pageNo, string firsttime)
    {

        if (hdnGo.Value == "refreshparams")
            return;

        if (firsttime.ToLower() == "yes")
        {
            if ((objIview.IsDirectDBcall))
            {

                ClearHeaderArray();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(objIview.StructureXml);
                CreateDBHeaderRow(doc);
                CreateDBHyperLinkRow(doc);
            }

            else
            {

                ClearHeaderArray();
                hideChkBox = true;
                XmlNodeList productNodes = default(XmlNodeList);
                XmlNodeList baseDataNodes = default(XmlNodeList);
                productNodes = xmlDoc.SelectNodes("//headrow");
                foreach (XmlNode productNode in productNodes)
                {
                    if (!getAjaxIviewData)
                    {
                        if (pageNo == "1")
                        {
                            XmlNode tnode = productNode.Attributes["totalrows"];
                            XmlNode dnode = productNode.Attributes["datarows"];
                            if (dnode == null)
                            {
                                dataRows = 0;
                            }
                            else
                            {
                                dataRows = Convert.ToInt32(dnode.Value);
                            }
                            Session["iv_datarows"] = dataRows;
                            if (tnode == null)
                            {
                                totalRows = 0;
                            }
                            else
                            {

                                if (IsSqlPagination == "true")
                                {
                                    totalRows = Convert.ToInt32(tnode.Value);
                                }
                                else
                                {
                                    totalRows = dataRows;
                                }
                            }




                            //If the webservice returns the pagesize, then overrite the pagesize else use from web.config
                            XmlNode pageSize = productNode.Attributes["pagesize"];
                            if (pageSize != null)
                            {
                                //Commented the below code as it was always slicing the data to 20 records
                                //if (pageSize.Value == "0")
                                //    objIview.IsIviewStagLoad = true;
                                //else
                                //    objIview.IsIviewStagLoad = false;

                                gridPageSize = pageSize.Value;
                                if (!objIview.getIviewRowCount && !objIview.IsDirectDBcall)
                                {
                                    //if(gridPageSize == "0")
                                    //{
                                    //    gridPageSize = objIview.GrdPageSize;
                                    //}
                                    objIview.iviewDataWSRows = Convert.ToInt32(gridPageSize);
                                }
                                objIview.GrdPageSize = gridPageSize;
                                if (pageSize.Value != "")
                                {
                                    recPerPage.Visible = false;
                                    lbRecPerPage.Visible = false;
                                }
                            }
                            else
                            {
                                //if (totalRows < 30)
                                //    dvRowsPerPage.Style.Add("display", "none");
                                //else
                                //    dvRowsPerPage.Style.Add("display", "block");
                            }
                            if (totalRows == 0 && pageSize == null)
                            {
                                //dvRowsPerPage.Style.Add("display", "none");
                            }

                            Session["iv_noofpages"] = totalRows;

                        }
                        else
                        {
                            totalRows = Convert.ToInt32(Session["iv_noofpages"].ToString());
                            dataRows = Convert.ToInt32(Session["iv_datarows"].ToString());
                        }
                        if (totalRows == 0)
                        {
                            lvPage.Visible = false;
                            pgCap.Visible = false;
                        }
                        else
                        {
                            lvPage.Visible = true;
                            pgCap.Visible = true;
                        }
                    }
                    baseDataNodes = productNode.ChildNodes;
                    foreach (XmlNode baseDataNode in baseDataNodes)
                    {
                        if (objIview.IsPerfXml)
                        {
                            if (!((baseDataNode.Name == "pivotghead") || (baseDataNode.Name == "axrowtype") || (baseDataNode.Name == "axp__font")))
                            {
                                colFld.Add(baseDataNode.Name);

                                if (baseDataNode.Name == "rowno")
                                {
                                    //chnage here to add "-"
                                    headName.Add(string.Empty);
                                    colWidth.Add("10");
                                    colType.Add("c");
                                    //change here to hide first column heading
                                    colHide.Add(baseDataNode.Attributes["hide"].Value);
                                    if (baseDataNode.Attributes["hide"].Value == "false")
                                        hideChkBox = false;
                                    colDec.Add("0");
                                    colApplyComma.Add("false");
                                    colHlink.Add("-");
                                    colHlinkPop.Add("-");
                                    colRefreshParent.Add("-");
                                    colHlinktype.Add("-");
                                    colMap.Add("-");
                                    colHAction.Add("-");
                                    colAlign.Add(string.Empty);
                                    colNoPrint.Add("false");
                                    colNoRepeat.Add("false");
                                    colZeroOff.Add("false");
                                }
                                else
                                {
                                    CreateFieldArray(baseDataNode);
                                }
                                XmlNode pivotNode = baseDataNodes.Cast<XmlNode>().Where(item => item.Name == "pivotghead").ToList().FirstOrDefault();
                                if (pivotNode == null || pivotNode.OuterXml == "<pivotghead />")
                                {
                                    initMergeAndPivot(baseDataNode.Name);
                                }
                            }
                        }
                        else
                        {
                            if (baseDataNode.Name != "pivotghead")
                            {
                                colFld.Add(baseDataNode.Name);
                            }
                            if (baseDataNode.Name == "rowno")
                            {
                                //chnage here to add "-"
                                headName.Add(string.Empty);
                                colWidth.Add("10");
                                colType.Add("c");
                                //change here to hide first column heading                                
                                colHide.Add(baseDataNode.Attributes["hide"].Value);
                                if (baseDataNode.Attributes["hide"].Value == "false")
                                    hideChkBox = false;
                                colDec.Add("0");
                                colApplyComma.Add("false");
                                colHlink.Add("-");
                                colHlinkPop.Add("-");
                                colRefreshParent.Add("-");
                                colHlinktype.Add("-");
                                colMap.Add("-");
                                colHAction.Add("-");
                                colAlign.Add(string.Empty);
                                colNoPrint.Add("false");
                                colNoRepeat.Add("false");
                                colZeroOff.Add("false");
                            }
                            else if (baseDataNode.Name == "axrowtype")
                            {
                                headName.Add(string.Empty);
                                colWidth.Add("0");
                                colType.Add("c");
                                //change here to hide first column heading
                                colHide.Add("false");
                                colDec.Add("0");
                                colApplyComma.Add("false");
                                colHlink.Add("-");
                                colHlinkPop.Add("-");
                                colRefreshParent.Add("-");
                                colHlinktype.Add("-");
                                colMap.Add("-");
                                colHAction.Add("-");
                                colAlign.Add(string.Empty);
                                colNoPrint.Add("false");
                                colNoRepeat.Add("false");
                                colZeroOff.Add("false");
                            }
                            else
                            {
                                CreateFieldArray(baseDataNode);
                            }
                            XmlNode pivotNode = baseDataNodes.Cast<XmlNode>().Where(item => item.Name == "pivotghead").ToList().FirstOrDefault();
                            if (baseDataNode.Name != "pivotghead" && pivotNode == null || pivotNode.OuterXml == "<pivotghead />")
                            {
                                initMergeAndPivot(baseDataNode.Name);
                            }
                        }
                        if (!getAjaxIviewData)
                        {
                            baseDataNode.RemoveAll();
                        }
                    }
                }
            }
            objIview.ColFld = colFld;
            objIview.HeadName = headName;
            objIview.ColWidth = colWidth;
            objIview.ColType = colType;
            objIview.ColHide = colHide;
            objIview.ColDec = colDec;
            objIview.ColApplyComma = colApplyComma;
            objIview.ColHlink = colHlink;
            objIview.ColHlinkPop = colHlinkPop;
            objIview.ColRefreshPrent = colRefreshParent;
            objIview.ActRefreshParent = actRefreshParent;
            objIview.ColHlinktype = colHlinktype;
            objIview.ColMap = colMap;
            objIview.ColHAction = colHAction;
            objIview.ColAlign = colAlign;
            objIview.ColNoPrint = colNoPrint;
            objIview.ColNoRepeat = colNoRepeat;
            objIview.ColZeroOff = colZeroOff;

        }
        else
        {
            //clear the headrow attributes
            XmlNodeList productNodes = default(XmlNodeList);
            XmlNodeList baseDataNodes = default(XmlNodeList);
            productNodes = xmlDoc.SelectNodes("//headrow");
            foreach (XmlNode productNode in productNodes)
            {
                baseDataNodes = productNode.ChildNodes;
                foreach (XmlNode baseDataNode in baseDataNodes)
                {
                    baseDataNode.RemoveAll();
                }
            }
        }
    }

    private void CreateFieldArray(XmlNode baseDataNode)
    {

        if ((baseDataNode.InnerText.Length > 8) && (baseDataNode.InnerText.Substring(0, 8).ToLower() == "noprint_"))
        {
            baseDataNode.InnerText = baseDataNode.InnerText.Substring(8);
            colNoPrint.Add("true");
        }
        else
        {
            colNoPrint.Add("false");
        }

        if (baseDataNode.Name != "pivotghead")
        {
            colApplyComma.Add("false");
            if (baseDataNode.InnerText.ToLower() == "axp_slno" || baseDataNode.InnerText.ToLower() == "sr. no." || baseDataNode.InnerText.ToLower() == "sr.no.")
            {
                headName.Add("Sr. No.");
                objIview.SrNoColumName = colFld[colFld.Count - 1].ToString();
            }
            else
            {
                headName.Add(baseDataNode.InnerText);
            }

            if (baseDataNode.Attributes["width"] != null)
            {
                colWidth.Add((int.Parse(baseDataNode.Attributes["width"].Value) + 50).ToString());
            }
            else
                colWidth.Add(string.Empty);
            if (baseDataNode.Attributes["type"] != null)
                colType.Add(baseDataNode.Attributes["type"].Value);
            else
                colType.Add(string.Empty);
            if (baseDataNode.Attributes["hide"] != null)
                colHide.Add(baseDataNode.Attributes["hide"].Value);
            else
                colHide.Add(string.Empty);


            //colRefreshParent.Add(IsRefreshAfterSave(baseDataNode.InnerText));
            colRefreshParent.Add(IsRefreshAfterSave(baseDataNode.Name));


            if (baseDataNode.Attributes["dec"] != null)
                colDec.Add(baseDataNode.Attributes["dec"].Value);
            else
                colDec.Add(string.Empty);
            if (baseDataNode.Attributes["align"] != null)
                colAlign.Add(baseDataNode.Attributes["align"].Value);
            else
                colAlign.Add(string.Empty);

            XmlNode nodepop = baseDataNode.Attributes["pop"];
            if (nodepop == null)
            {
                colHlinkPop.Add("-");
            }
            else
            {
                colHlinkPop.Add(nodepop.Value);
            }

            XmlNode node = baseDataNode.Attributes["hlink"];
            if (node == null)
            {
                colHlink.Add("-");
            }
            else
            {
                colHlink.Add(node.Value);
            }

            XmlNode nodehlt = baseDataNode.Attributes["hltype"];
            if (nodehlt == null)
            {
                colHlinktype.Add("-");
            }
            else
            {
                colHlinktype.Add(nodehlt.Value);
            }
            XmlNode node1 = baseDataNode.Attributes["map"];
            if (node1 == null)
            {
                colMap.Add("-");
            }
            else
            {
                colMap.Add(node1.Value);
            }

            XmlNode nodeha = baseDataNode.Attributes["hlaction"];
            if (nodeha == null)
            {
                colHAction.Add("-");
            }
            else
            {
                colHAction.Add(nodeha.Value);
                actRefreshParent[nodeha.Value] = IsRefreshAfterSave(nodeha.Value, true);
            }

        }
    }

    private string IsRefreshAfterSave(string ColumnName, bool isActionHyperlink = false)
    {
        string result = "false";
        XmlDocument xmlDoc = new XmlDocument();
        if (!string.IsNullOrEmpty(objIview.StructureXml) && ColumnName != string.Empty)
        {
            if (!isActionHyperlink)
            {
                xmlDoc.LoadXml(objIview.StructureXml);
                XmlNode hyperLinks = xmlDoc.SelectSingleNode("//hyperlinks");
                if (hyperLinks != null)
                    foreach (XmlNode node in hyperLinks)
                    {


                        if (node.Attributes["source"] != null && node.Attributes["source"].Value.ToLower() == ColumnName.ToLower() && node.Attributes["refresh"] != null)
                        {
                            result = node.Attributes["refresh"].Value.ToLower();
                            break;
                        }
                    }
            }
            else
            {
                try
                {
                    xmlDoc.LoadXml(objIview.StructureXml);
                    XmlNode thisRefresh = xmlDoc.SelectSingleNode("//actions/" + ColumnName + "/r1/param1/Refresh");
                    if (thisRefresh != null)
                    {
                        result = thisRefresh.InnerText.ToLower();
                    }
                }
                catch (Exception ex) { }
            }
        }
        return result;
    }

    private void AlignToolbarBtns()
    {
        if (IsPostBack && getAjaxIviewData)
            defaultBut = string.Empty;
        int tempLftCnt = 0;
        int BtnLftCnt = 0;
        int i = 0;

        for (i = 0; i <= arrButtons.Count; i++)
        {
            arrSortedButtons.Add(string.Empty);
        }
        bool IsBtnCnt = false;

        if (objIview.purposeString == "")
        {

            for (BtnLftCnt = 0; BtnLftCnt < arrBtnLeftVals.Count; BtnLftCnt++)
            {
                for (tempLftCnt = 0; tempLftCnt < arrTempBtnLeft.Count; tempLftCnt++)
                {
                    if (arrBtnLeftVals[BtnLftCnt].ToString() == arrTempBtnLeft[tempLftCnt].ToString())
                    {
                        if (arrTempBtnLeft.Count != arrButtons.Count)
                        {
                            IsBtnCnt = true;
                        }
                        else
                        {
                            arrSortedButtons[BtnLftCnt] = arrButtons[tempLftCnt];
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            arrSortedButtons = arrButtons;
        }

        int j = 0;
        if (IsBtnCnt == true)
        {
            for (j = 0; j <= arrButtons.Count - 1; j++)
            {
                defaultBut += arrButtons[j].ToString();
            }
        }

        for (j = 0; j <= arrSortedButtons.Count - 1; j++)
        {
            if (!string.IsNullOrEmpty(arrSortedButtons[j].ToString()))
            {
                defaultBut += arrSortedButtons[j].ToString();
            }
        }
        if (iName == "inmemdb")
        {
            defaultBut += "<li  class='actionWrapper' onclick='window.location.href = window.location.href;'><a class='action singleaction' href=\"javascript:void(0)\" id='inMemRefresh' title='Reload' >Reload</a></li>";
            /*  "find": {
                "isRoot": false,
                "structure": "jkjk",
                "confirm": "",
                "allRows": "",
                "left": "480",
                "hint": "Find",
                "caption": ""
              }*/

            JObject redisReload = new JObject();
            redisReload.Add("isRoot", false);
            redisReload.Add("structure", iName);
            redisReload.Add("confirm", "");
            redisReload.Add("allRows", "");
            redisReload.Add("left", "");
            redisReload.Add("hint", "Reload");
            redisReload.Add("caption", "Reload");
            redisReload.Add("href", "javascript:void(0);");
            redisReload.Add("onclick", "window.location.href = window.location.href;");
            redisReload["key"] = "redisReload";
            toolbarJSON["redisReload"] = redisReload;
        }


        if (Request.QueryString["tstcaption"] != null && Session["AxpExcelExport"] != null && Session["AxpExcelExport"].ToString() == "true")
        {
            defaultBut += "<li class='liToExcel'><a class='toexcel' title='Save as Excel' href='javascript:toExcelWeb(\"" + iName + "\"," + (objIview.purposeString == "" ? "\"Iview\"" : "\"lview\"") + ");'>Save as Excel</a></li>";
            JObject axpExcelExport = new JObject();
            axpExcelExport.Add("isRoot", false);
            axpExcelExport.Add("structure", iName);
            axpExcelExport.Add("confirm", "");
            axpExcelExport.Add("allRows", "");
            axpExcelExport.Add("left", "");
            axpExcelExport.Add("hint", "Save as Excel");
            axpExcelExport.Add("caption", "Save as Excel");
            axpExcelExport.Add("href", "javascript:toExcelWeb('" + iName + "'," + (objIview.purposeString == "" ? "'Iview'" : "'lview'") + ");");
            axpExcelExport.Add("onclick", "");
            axpExcelExport["key"] = "axpExcelExport";
            toolbarJSON["axpExcelExport"] = axpExcelExport;
        }

        objIview.ToolbarHtml = defaultBut;

        ShowHideFilters();

        //var sb = new StringBuilder();
        //myFilters.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
        //var sb2 = new StringBuilder();
        //dvSelectedFilters.RenderControl(new HtmlTextWriter(new StringWriter(sb2)));

        //string s = sb.ToString();
        //s = s + sb2.ToString();
        //iconsUl.InnerHtml = 
        //    "<li id='myFiltersLi' class='" + myFiltersLi.Attributes["class"].ToString() + "'>" + s + "</li>" +

        //    //           "<li id='ivInSearch' style='width: 62px;'>" +
        //    //            "<div class=\"searchBox\">" +
        //    //  "<div class=\"searchBoxChildContainer\">" +
        //    //      "<span class=\"icon\"><i class=\"fa fa-search\"></i></span>" +
        //    //      "<input type=\"search\" id=\"ivInSearchInput\" placeholder=\"Search...\" />" +
        //    //      "<span id=\"ivirMoreButton\" class=\"icon2\" onclick=\"ivirMoreFilters(true);\" tabindex=\"0\"><i class=\"fa fa-caret-down\"></i></span>" +
        //    //  "</div>" +
        //    //"</div>" +
        //    //           "</li>" +

        //    //"<li id='advFilterWrapper'></li>" +
        //    //"<li id='filterColumnSelect' class='d-none'></li>" +
        //    //"<li class='searchColWrapper'></li>" +

        //    "<li id='filterWrapper'></li>" +
        //    "<li id='ivirCustomActionButtons'></li>" +
        //    //"<li id='customActionBtn'></li>" +
        //    //"<li></li>" +
        //    defaultBut +
        //    "";
    }

    private void CreateButtonPos(XmlDocument xmldoc)
    {
        XmlNodeList compNodes = default(XmlNodeList);
        XmlNodeList cbaseDataNodes = default(XmlNodeList);

        if (objIview.IsDirectDBcall)
            compNodes = xmldoc.SelectNodes("//root/comps");
        else
            compNodes = xmldoc.SelectNodes("//data/comps");

        foreach (XmlNode compNode in compNodes)
        {
            cbaseDataNodes = compNode.ChildNodes;
            int cnt1 = 0;
            int compNodeCnt = 0;
            int ToolbarBtnCnt = 0;
            string[] arrLeft = null;
            ToolbarBtnCnt = cbaseDataNodes.Count - 1;
            for (compNodeCnt = ToolbarBtnCnt; compNodeCnt >= 0; compNodeCnt += -1)
            {
                if (cbaseDataNodes[compNodeCnt].Name.Substring(0, 3) == "btn")
                {
                    string tlhw = string.Empty;
                    string actionn = string.Empty;
                    string taskk = string.Empty;
                    if (cbaseDataNodes[compNodeCnt].Attributes["tlhw"] != null)
                    {
                        tlhw = cbaseDataNodes[compNodeCnt].Attributes["tlhw"].Value;
                        if (cbaseDataNodes[compNodeCnt].Attributes["action"] != null)
                            actionn = cbaseDataNodes[compNodeCnt].Attributes["action"].Value;
                        if (cbaseDataNodes[compNodeCnt].Attributes["task"] != null)
                            taskk = cbaseDataNodes[compNodeCnt].Attributes["task"].Value;
                    }
                    //If there is a button with empty task and empty action no need to add button
                    if (!(string.IsNullOrEmpty(tlhw)) && (!(string.IsNullOrEmpty(actionn)) || !(string.IsNullOrEmpty(taskk))) && taskk != "printersetting")
                    {
                        arrLeft = tlhw.Split(',');
                        if (arrLeft.Length > 0)
                        {
                            arrBtnLeftVals.Add(arrLeft[1]);
                        }
                    }
                }

            }
        }
        arrBtnLeftVals.Sort(new Util.CustomComparer());
    }

    public void MessageBox(string Msg)
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "myrest", "<script>showAlertDialog('info','" + Msg + "');</script>");
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        if (hdnIsPostBack.Value != "false")
            ActionClick(((LinkButton)sender).ID);
    }

    private string GetRowXmlFromDS(DataRow dr)
    {
        StringBuilder rowXml = new StringBuilder();
        DataSet ds = new DataSet();

        ds.Tables.Add(dr.Table.Clone());
        ds.Tables[0].ImportRow(dr);
        ds.Tables[0].TableName = "row";
        //Not using DataTable.WriteXml as empty columns were escaped by the method, hence looping through all the nodes.
        rowXml.Append("<row>");
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            string colName = ds.Tables[0].Columns[i].ColumnName;
            string colVal = dr[colName].ToString().Replace("&nbsp;", " ");
            colVal = util.CheckSpecialChars(colVal);
            rowXml.Append("<" + colName + ">" + colVal + "</" + colName + ">");
        }
        rowXml.Append("</row>");
        return rowXml.ToString();
    }

    private void ActionClick(string btnId, bool isScript = false)
    {
        btnId = btnId.ToString();
        string actName = btnId.Substring(4);
        XmlDocument xmlDoc = new XmlDocument();
        bool xmlEmpty = false;
        try
        {
            if (objIview.IsPerfXml)
            {
                string oldformatXml = util.ConvertPerfXmlToXml(objIview.iRes, objIview);
                xmlDoc.LoadXml(oldformatXml);
            }
            else
            {
                if (objIview.ResultXml != "")
                    xmlDoc.LoadXml(objIview.ResultXml);
                else
                    return;
            }

        }
        catch (Exception ex)
        {
            // Response.Redirect(util.ERRPATH + ex.Message);
            xmlEmpty = true;
        }
        string xml = string.Empty;

        if (!xmlEmpty)
        {
            string[] rowArys = hdnSRows.Value.Split('♣');

            for (int i = 0; i < rowArys.Length - 1; i++)
            {
                int row = Convert.ToInt32(rowArys[i].ToString());
                if (objIview.IsDirectDBcall)
                    xml = xml + GetRowXmlFromDS(objIview.DsDataSetDB.Tables[0].Rows[row - 1]);
                else
                    xml = xml + xmlDoc.SelectNodes("//row")[row].OuterXml;
            }
        }
        string iXml = string.Empty;
        string actFileName = "Action-" + actName + "-" + iName;
        errLog = logobj.CreateLog("Call to RemoteDoAction Web Service", sid, actFileName, string.Empty);

        iXml = "<root " + objIview.purposeString + " axpapp =\"" + proj + "\" trace =\"" + errLog + "\" sessionid =\"" + sid + "\" appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "' stype=\"iviews\" sname=\"" + iName + "\" actname=\"" + actName + "\" ><params>";
        ConstructParamXml();
        iXml = iXml + pXml + "</params><varlist>" + xml + "</varlist>";
        iXml += Session["axApps"].ToString() + Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</root>";
        string ires = string.Empty;
        Session["currentPageNo" + iName] = objIview.CurrentPageNo;
        //Call service
        if (iXml != string.Empty)
            iXml = iXml.Replace("<root", "<root scriptpath='" + ConfigurationManager.AppSettings["ScriptsPath"].ToString() + "'");

        if (isScript)
            ires = objWebServiceExt.callRemoteDoScriptWS(iName, iXml, ires, objIview.WebServiceTimeout);
        else
            ires = objWebServiceExt.CallRemoteDoActionWS(iName, iXml, ires, objIview.WebServiceTimeout);

        if (ires != null)
            ires = ires.Split('♠')[1];
        ires = ires.Replace("'", ";quot");
        ires = ires.Replace("\\", ";bkslh");
        ires = ires.Replace("\n", "<br>");
        if (navigationInfo.Rows.Count > 0)
            Session["iNavigationInfoTable"] = navigationInfo;
        if (objIview.ActBtnNavigation != null && objIview.ActBtnNavigation.ContainsKey(actName))
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(), "myActionTest", "<script>CallAssignLoadVals('" + ires + "', \"Iview\",'" + actName + "','" + objIview.ActBtnNavigation[actName].ToLower() + "');</script>", false);
        else
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(), "myActionTest", "<script>CallAssignLoadVals('" + ires + "', \"Iview\",'" + actName + "');</script>", false);
        //CallWebservice(currentPageNo.ToString(), "yes");
    }

    private void GetGlobalVariables()
    {
        if (Application["ValidateIviewParamOnGo"] != null)
            validateParamOnGo = Convert.ToBoolean(Application["ValidateIviewParamOnGo"].ToString());
        else
            validateParamOnGo = false;

        //iName = Request.QueryString["ivname"];

        if (!string.IsNullOrEmpty(iName))
        {
            if (iName.Contains(":"))
            {
                string viewName = iName.Substring(iName.LastIndexOf(':') + 1);
                iName = iName.Substring(0, iName.LastIndexOf(":"));
                objIview.MyViewName = viewName;
            }

        }
        iName = util.CheckSpecialChars(iName);
        if (iName == null || iName == string.Empty)
        {
            if (objIview.Ivname != null && Convert.ToString(objIview.Ivname) != string.Empty)
            {
                iName = objIview.Ivname.ToString();
            }
            else if (Request.Form["ivname"] != null)
            {
                iName = Request.Form["ivname"].ToString();
            }
        }

        if (!util.IsValidIvName(iName))
            Response.Redirect(Constants.PARAMERR);

        if (iName != null)
        {
            objIview.IName = iName;
            objIview.Ivname = iName;
        }
        else
        {
            iName = objIview.IName.ToString();
        }

        objIview.IName = iName;
        Session["iName"] = iName;
        if (Request.QueryString["ivname"] != null && Request.QueryString["ivname"] != string.Empty)
        {
            tid = Request.QueryString["ivname"].ToString();
        }
        tid = util.CheckSpecialChars(tid);
        objIview.Tid = tid;
        AxRole = Session["AxRole"].ToString();
        AxRole = util.CheckSpecialChars(AxRole);
        proj = Session["project"].ToString();
        proj = util.CheckSpecialChars(proj);
        sid = Session["nsessionid"].ToString();
        sid = util.CheckSpecialChars(sid);
        user = Session["user"].ToString();
        user = util.CheckSpecialChars(user);


        if (Session["ClientLocale"] != null)
            clientCulture = Convert.ToString(Session["ClientLocale"]);


        if (string.IsNullOrEmpty(clientCulture))
            clientCulture = "en-gb";
        //CheckDetailView(iName, tid);

        string replaceWith = "\\";
        strGlobalVar = util.GetGlobalVarString().Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        CreateGlobalVarArray(strGlobalVar);

        if (Session["AxDbPagination"] != null)
            IsSqlPagination = Session["AxDbPagination"].ToString().ToLower();
        //if IView is opened as popup, the hyperlinks in the popup will not support navigation
        if (Session["AxIsPop"] != null)
        {
            if (Convert.ToString(Session["AxIsPop"]) == "IviewPop")
            {
                IsIviewPop = true;
                Session["AxIsPop"] = string.Empty;
            }
        }

        if (Session["AxSplit"] != null && Session["AxSplit"].ToString() == "true")
        {
            AxSplit = true;
            Session.Remove("AxSplit");
        }
        if (Request.QueryString["AxSplit"] != null && Request.QueryString["AxSplit"] == "true")
        {
            AxSplit = true;
        }

        if (Session["AxFromHypLink"] != null)
            objIview.FromHyperLink = Session["AxFromHypLink"].ToString();
        CheckCustomIview();

        //Direct DB is disabled from 10.7
        // if (Session["AxEnableDirectDB"] != null)
        //     directiview = Convert.ToBoolean(Session["AxEnableDirectDB"].ToString());

        if (HttpContext.Current.Session["dbuser"] != null)
            schemaName = HttpContext.Current.Session["dbuser"].ToString();

        if (iName == "inmemdb")
        {
            directiview = false;
        }
    }



    private void CreateGlobalVarArray(string strGlobalVar)
    {
        string globalVar = strGlobalVar;
        if (globalVar != string.Empty)
        {
            string[] globalVarArr = new string[globalVar.Split(';').Length];
            globalVarArr = globalVar.Split(';');
            foreach (var glvar in globalVarArr)
            {
                if (glvar != string.Empty || (glvar != " ") || (glvar != null))
                {
                    if (glvar.Length > 0 && glvar.Contains('='))
                    {
                        string glvarNameval = glvar.Split('=')[1].Replace('"', ' ').Trim();

                        if (objIview.GolbalVarName != null && objIview.GolbalVarValue != null)
                        {
                            objIview.GolbalVarName.Add(glvarNameval.Split('~')[0]);
                            objIview.GolbalVarValue.Add(glvarNameval.Split('~')[1]);
                        }
                    }
                }
            }
        }

    }


    private void CheckCustomIview()
    {
        if (Session["AxCustomIviews"] != null)
        {
            //the value can be ivname:t,ivname:p,ivname:*
            string customIviews = Session["AxCustomIviews"].ToString();
            if (customIviews != string.Empty)
            {
                string[] arrCusIv = customIviews.Split(',');
                for (int i = 0; i < arrCusIv.Length; i++)
                {
                    int idx = arrCusIv[i].ToString().IndexOf(":");
                    if (idx != -1)
                    {
                        if (arrCusIv[i].ToString().Substring(0, idx) == iName)
                        {
                            string str = arrCusIv[i].ToString().Substring(idx + 1);
                            str = str.Trim().ToLower();
                            if (str == "t")
                                hidetoolbar = "true";
                            else if (str == "p")
                                hideParameters = "true";
                            else if (str == "*")
                            {
                                hideParameters = "true";
                                hidetoolbar = "true";
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    private void SetGlobalVariables()
    {
        if (objIview.IName != null)
            iName = objIview.IName.ToString();
        else
            iName = string.Empty;

        if (objIview.Tid != null)
            tid = objIview.Tid.ToString();
        else
            tid = string.Empty;

        //if (Session["tskList" + iName] != null)
        //    tskList = (StringBuilder)Session["tskList" + iName];



        AxRole = Session["AxRole"].ToString();
        AxRole = util.CheckSpecialChars(AxRole);
        proj = Session["project"].ToString();
        proj = util.CheckSpecialChars(proj);
        sid = Session["nsessionid"].ToString();
        sid = util.CheckSpecialChars(sid);
        user = Session["user"].ToString();
        user = util.CheckSpecialChars(user);

        cac_order = sid + "order";
        cac_pivot = sid + iName + "pivot";

        if (clientCulture == null)
        {
            clientCulture = Convert.ToString(Session["ClientLocale"]);
            if (string.IsNullOrEmpty(clientCulture))
                clientCulture = "en-gb";
        }

        if (objIview.IviewCaption != null)
            lblHeading = objIview.IviewCaption.ToString();

        if (objIview.ToolbarHtml != null)
            defaultBut = objIview.ToolbarHtml;

        if (objIview.ToolBarBtn != null && hdnAct.Value == string.Empty)
        {
            //if (dvActionBtns.Controls.Count <= 1)
            //{
            //    dvActionBtns.Controls.Clear();
            //    string actViewstate = objIview.ToolBarBtn.ToString();
            //    string[] actStr = actViewstate.Split('^');
            //    for (int i = 0; i < actStr.Length - 1; i++)
            //    {
            //        string[] actPara = actStr[i].Split('~');
            //        actionBtns.Add(GetButton(actPara[0].ToString(), actPara[1].ToString(), actPara[2].ToString(), actPara[3].ToString(), actPara[4].ToString(), actPara[5].ToString()));
            //    }
            //}
            ConstructActionBtns();
        }
        if (Session["AxDbPagination"] != null)
            IsSqlPagination = Session["AxDbPagination"].ToString().ToLower();
        if (objIview.ColFld != null)
            colFld = (ArrayList)objIview.ColFld;
        if (objIview.HeadName != null)
            headName = (ArrayList)objIview.HeadName;
        if (objIview.ColWidth != null)
            colWidth = (ArrayList)objIview.ColWidth;
        if (objIview.ColType != null)
            colType = (ArrayList)objIview.ColType;
        if (objIview.ColHide != null)
            colHide = (ArrayList)objIview.ColHide;
        if (objIview.ColDec != null)
            colDec = (ArrayList)objIview.ColDec;
        if (objIview.ColApplyComma != null)
            colApplyComma = (ArrayList)objIview.ColApplyComma;
        if (objIview.ColHlink != null)
            colHlink = (ArrayList)objIview.ColHlink;
        if (objIview.ColHlinkPop != null)
            colHlinkPop = (ArrayList)objIview.ColHlinkPop;
        if (objIview.ColRefreshPrent != null)
            actRefreshParent = (IDictionary<string, string>)objIview.ActRefreshParent;
        if (objIview.ColHlinktype != null)
            colHlinktype = (ArrayList)objIview.ColHlinktype;
        if (objIview.ColMap != null)
            colMap = (ArrayList)objIview.ColMap;
        if (objIview.ColHAction != null)
            colHAction = (ArrayList)objIview.ColHAction;
        if (objIview.ColAlign != null)
            colAlign = (ArrayList)objIview.ColAlign;
        if (objIview.ColNoPrint != null)
            colNoPrint = (ArrayList)objIview.ColNoPrint;

        if (objIview.ColNoRepeat != null)
            colNoRepeat = (ArrayList)objIview.ColNoRepeat;
        if (objIview.ColZeroOff != null)
            colZeroOff = (ArrayList)objIview.ColZeroOff;

        if (objIview.ShowHiddengridCols != null)
            showHiddenCols = (ArrayList)objIview.ShowHiddengridCols;
        if (objIview.ShowHideCols != null)
            arrHdnColMyViews = (ArrayList)objIview.ShowHideCols;
        if (objIview.ColsToFilter != string.Empty)
            ColsToFilter = objIview.ColsToFilter;
    }

    private void CheckDetailView(string iName, string tid)
    {
        string strCust = Application["CustomisedIviews"].ToString();
        string[] custArr = strCust.Split(',');
        for (int i = 0; i < custArr.Length; i++)
        {
            if (custArr[i].ToString() == iName)
            {
                Response.Redirect("DetailView.aspx?ivname=" + iName + "&transid=" + tid);
                break; // TODO: might not be correct. Was : Exit For
            }
            i = i + 1;
        }
    }

    private void GetBreadCrumb()
    {
        try
        {
            objIview.Menubreadcrumb = string.Empty;
            //string strv = Session["MenuData"].ToString();
            string strv = string.Empty;
            try
            {
                string fdKeyMenuData = Constants.REDISMENUDATA;
                string schemaName = string.Empty;
                if (HttpContext.Current.Session["dbuser"] != null)
                    schemaName = HttpContext.Current.Session["dbuser"].ToString();
                FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
                if (fObj != null)
                    strv = fObj.StringFromRedis(util.GetRedisServerkey(fdKeyMenuData, "Menu"), schemaName);
            }
            catch (Exception) { }

            if (strv == string.Empty && Session["MenuData"] != null)
                strv = Session["MenuData"].ToString();
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.LoadXml(strv);
            string code = (Request.QueryString["tstcaption"] != null ? "tstruct.aspx?transid=" + iName : "iview.aspx?ivname=" + iName);
            XmlNode node = null;
            XmlElement basicDataRoot = xmlDoc1.DocumentElement;
            if (basicDataRoot.SelectSingleNode("descendant::child[@target='" + code + "']") != null)
            {
                node = basicDataRoot.SelectSingleNode("descendant::child[@target='" + code + "']");
            }
            else if (basicDataRoot.SelectSingleNode("descendant::parent[@target='" + code + "']") != null)
            {
                node = basicDataRoot.SelectSingleNode("descendant::parent[@target='" + code + "']");
            }

            if (node != null)
            {
                string s = node.Attributes["name"].Value;
                string s1 = string.Empty;
                XmlNode parnode = default(XmlNode);
                if (node.ParentNode != null)
                {
                    parnode = node.ParentNode;
                    while (parnode.Name != "root")
                    {
                        s1 = parnode.Attributes["name"].Value + " / " + s1;
                        parnode = parnode.ParentNode;
                    }
                }

                objIview.Menubreadcrumb = s1;
            }
            else
            {
                objIview.Menubreadcrumb = string.Empty;

            }
        }
        catch (Exception)
        {
            SessExpires();
            return;
        }
    }

    private void ConstructBreadCrumb()
    {
        string direction1 = "start";
        if (language.ToLower() == "arabic")
            direction1 = "end";
        if (language.ToLower() == "arabic")
            strBreadCrumbBtns = "<div id='backforwrdbuttons' class='d-none d-flex backbutton " + direction1 + " '><span class='navLeft icon-arrows-left-double-32 handCur' onclick='javascript:BackForwardButtonClicked(\"back\");' id='" + "goback" + "' title=\"Click here to go back\" ></span></div>";
        else
            strBreadCrumbBtns = "<div id='backforwrdbuttons' class='d-none d-flex backbutton " + direction1 + " '><span class='navLeft icon-arrows-left-double-32 handCur' onclick='javascript:BackForwardButtonClicked(\"back\");' id='" + "goback" + "' title=\"Click here to go back\" ></span></div>";
        //if (util.BreadCrumb && objIview.Menubreadcrumb.ToString() == string.Empty)
        //    strBreadCrumb.Append("<div class='icon-services bcrumb h3 " + direction1 + " '>" + objIview.Menubreadcrumb.ToString() + objIview.IviewCaption.ToString() + "</div>");
        //else if (util.BreadCrumb && objIview.Menubreadcrumb.ToString() != string.Empty)
        //    strBreadCrumb.Append("<div class='icon-services " + direction1 + "  bcrumb pd5'><h3>" + objIview.IviewCaption.ToString() + "</h3><span>" + objIview.Menubreadcrumb.ToString() + "</span></div>");
        //else

        if (!(string.IsNullOrEmpty(objIview.IviewCaption.ToString())))
        {
            breadCrumb = objIview.IviewCaption.ToString();
        }
        else
        {
            breadCrumb = string.Empty;
        }

        //if (util.BreadCrumb && !string.IsNullOrEmpty(objIview.Menubreadcrumb))
        //{
        //    strBreadCrumb.Append("<div class='icon-services " + direction1 + " bcrumb'><span class=\"tstivCaption\">" + breadCrumb + "</span><span class=\"menuBreadCrumb\"><span class=\"breadCrumbCaption\">" + objIview.Menubreadcrumb.ToString() + "</span>" + objIview.IviewCaption.ToString() + "</span></div>");
        //}
        //else
        //{
        //strBreadCrumb.Append("<div class='icon-services " + direction1 + " bcrumb'><span class=\"tstivCaption tstivtitle\">" + breadCrumb + "</span></div>");
        strBreadCrumb.Append("<h1 class=\"text-dark fw-bolder my-1 fs-2 page-caption\">" + breadCrumb + "</h1>");
        //}
    }

    private void ConstructParamsHtml(string result)
    {
        result = _xmlString + result;
        logobj.CreateLog("Loading and setting parameters components", sid, fileName, string.Empty);
        string parameterName = string.Empty;
        string paramCaption = string.Empty;
        string paramType = string.Empty;
        string paramHidden = string.Empty;
        string paramMOE = string.Empty;
        string paramValue = string.Empty;
        string paramSql = string.Empty;
        string paramDepStr = string.Empty;
        string columnDepStr = string.Empty;
        Boolean unHideParams = false;
        string expr = string.Empty;
        bool exprSuggestion = false;
        string vExpr = string.Empty;
        string decPts = string.Empty;
        int tabIndex = 1;
        //objIview.NoVisibleParam = true;
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList productNodes = default(XmlNodeList);
        XmlNodeList baseDataNodes = default(XmlNodeList);
        int iCnt = 0;
        int fldNo = 0;
        int dpCnt = 0;
        bool paramsBound = true;

        try
        {
            xmlDoc.LoadXml(result);
        }
        catch (XmlException ex)
        {
            requestProcess_logtime += "Server - " + ex.Message + " ♦ ";
            Response.Redirect(util.ERRPATH + ex.Message + "*♠*" + requestProcess_logtime);
        }

        if (xmlDoc.DocumentElement.Attributes["cvalue"] != null)
        {
            string cvalue = xmlDoc.DocumentElement.Attributes["cvalue"].Value;
            if (cvalue != "")
                ViewState["ivGroupBtns"] = cvalue;
            else
                ViewState["ivGroupBtns"] = null;
        }

        if (!objIview.isObjFromCache)
        {

            productNodes = xmlDoc.SelectNodes("//root");


            if (productNodes[0].Attributes["showparams"] != null && productNodes[0].Attributes["showparams"].Value != string.Empty)
                objParams.showParam = Convert.ToBoolean(productNodes[0].Attributes["showparams"].Value);
            if (productNodes[0].ChildNodes.Count > 0)
            {
                //ShowHideFilterDiv(objIview.showParam);
                paramsExist = true;
                objParams.ParamsExist = true;
                GridView2Wrapper.Visible = false;
            }
            else
            {
                paramsExist = false;
                objParams.ParamsExist = false;
                iviewFrame.Style.Add("display", "block");
                paramCont.Style.Add("display", "none");
                GridView2Wrapper.Visible = true;
            }
            strJsArrays.Append("<script type='text/javascript'>");

            ivCaption = xmlDoc.SelectSingleNode("root").Attributes["caption"].Value;
            ivCaption = ivCaption.Replace("&&", "&");
            lblHeading = ivCaption;
            if (Request.QueryString["tstcaption"] == null)
            {
                objIview.IviewCaption = ivCaption;
            }
            string dynamicFilterString = string.Empty;
            foreach (XmlNode productNode in productNodes)
            {
                baseDataNodes = productNode.ChildNodes;
                paramHtml.Append("<table id=\"ivParamTable\" class=\"table table-borderless gy-0\"><tr>");

                foreach (XmlNode baseDataNode in baseDataNodes)
                {
                    exprSuggestion = false;
                    if (baseDataNode.Attributes["cat"].Value == "params")
                    {
                        paramValue = string.Empty;
                        if (baseDataNode.Attributes["value"] != null)
                            paramValue = baseDataNode.Attributes["value"].Value;

                        iviewParamValues.Add(paramValue);

                        foreach (XmlNode tstNode in baseDataNode)
                        {
                            if (tstNode.Name == "a0")
                            {
                                parameterName = tstNode.InnerText;
                                iviewParams.Add(parameterName);
                                UpdateParamValues(parameterName, paramValue);
                                if (parameterName != "" && parameterName == "axpResp")
                                {
                                    axpResp = paramValue == "true" || paramValue == "false" ? paramValue : "true";
                                }
                            }
                            else if (tstNode.Name == "a2")
                            {
                                paramCaption = tstNode.InnerText;
                                strParamDetails.Append(paramCaption + ",");
                                if (paramCaption.ToLower() == "axp_refresh")
                                    objParams.Axp_refresh = "true";

                                objParams.ParamCaption.Add(paramCaption);
                            }
                            else if (tstNode.Name == "a4")
                            {
                                paramType = tstNode.InnerText;
                            }
                            else if (tstNode.Name == "a5")
                            {
                                if (!string.IsNullOrEmpty(paramType) && paramType.ToLower() == "numeric")
                                {
                                    decPts = tstNode.InnerText;
                                }
                            }
                            else if (tstNode.Name == "a6")
                            {
                                expr = tstNode.InnerText;

                                if (expr.ToLower().IndexOf("date()") > -1)
                                {
                                    objParams.ForceDisableCache = true;
                                }

                                try
                                {
                                    exprSuggestion = Convert.ToBoolean(tstNode.Attributes["sugg"].Value);
                                }
                                catch (Exception ex) { }
                            }
                            else if (tstNode.Name == "a10")
                            {
                                vExpr = tstNode.InnerText;
                            }
                            else if (tstNode.Name == "a21")
                            {
                                paramHidden = tstNode.InnerText;
                                strParamDetails.Append(paramHidden + "~");
                                if (paramHidden == "true")
                                {
                                    objParams.ParamCaption.RemoveAt(objParams.ParamCaption.Count - 1);
                                    objParams.ParamCaption.Add("");
                                }
                                if (paramHidden != "true" && objParams.NoVisibleParam == true)
                                {
                                    objParams.NoVisibleParam = false;
                                }
                            }
                            else if (tstNode.Name == "a13")
                            {
                                paramMOE = tstNode.InnerText;
                            }
                            else if (tstNode.Name == "a56")
                            {
                                //pvalue = tstNode.InnerText;
                            }
                            else if (tstNode.Name == "a11")
                            {
                                paramSql = tstNode.InnerText;
                            }
                            else if (tstNode.Name == "a15")
                            {
                                foreach (XmlNode selNode in tstNode)
                                {
                                    if (selNode.Name == "s")
                                    {
                                        paramDepStr = selNode.InnerText.ToString();

                                        if (paramDepStr != string.Empty)
                                        {
                                            objParams.ForceDisableCache = true;
                                        }
                                    }
                                }
                                //if (paramDepStr == string.Empty) {
                                    try
                                    {
                                        isSelectWithMultiColumn = baseDataNode["response"].ChildNodes[0].ChildNodes.Count > 1;



                                        ArrayList parList = new ArrayList();

                                        int ind = -1;
                                        foreach (XmlNode node in baseDataNode["response"].ChildNodes[0].ChildNodes)
                                        {
                                            ind++;
                                            if (ind > 0)
                                            {
                                                parList.Add(node.Name);
                                            }
                                        }

                                        columnDepStr = String.Join(",", parList.ToArray());

                                        //if (columnDepStr != string.Empty)
                                        //{
                                        //    objIview.ForceDisableCache = true;
                                        //}
                                    }
                                    catch (Exception ex) { }

                                    //if (isSelectWithMultiColumn) {
                                    isSelectParamsString = util.getSqlParameters(paramSql);
                                    //}

                                    if (isSelectParamsString != string.Empty)
                                    {
                                        objParams.ForceDisableCache = true;
                                    }
                                //}
                            }
                            else if (tstNode.Name.ToLower() == "a16")
                                foreach (XmlNode node in tstNode)
                                {
                                    string dfTemp = string.Empty;
                                    for (int i = 0; i < node.Attributes.Count; i++)
                                        dfTemp += node.Attributes[i].Value + "~";

                                    if (dfTemp.EndsWith("~"))
                                        dfTemp = dfTemp.Substring(0, dfTemp.Length - 1);

                                    dfTemp += "|";
                                    dynamicFilterString += dfTemp;

                                }
                            else if (tstNode.Name == "response")
                            {
                                ComboFill(tstNode, parameterName);
                                isSqlFld = true;
                            }

                        }
                        objParams.ParamNameType.Add(parameterName + "♣" + paramType);
                    }

                    if (paramType == "Date/Time" && clientCulture.ToLower() == "en-us")
                    {
                        paramValue = util.GetClientDateString(clientCulture, paramValue);

                        if (paramMOE.ToLower() == "select" && arrFillList.Count > 0)
                        {
                            for (int y = 0; y <= arrFillList.Count - 1; y++) {
                                arrFillList[y] = util.GetClientDateString(clientCulture, arrFillList[y].ToString());
                                //arrFillListDataAttr
                            }
                        }
                    }

                    //construction of parameters.
                    paramValue = util.CheckSpecialChars(paramValue);
                    strJsArrays.Append("parentArr[" + fldNo + "]='" + parameterName + "';typeArr[" + fldNo + "]='" + paramMOE + "';paramType[" + fldNo + "]='" + paramType + "';depArr[" + fldNo + "]='" + paramDepStr + "';hiddenArr[" + fldNo + "]='" + paramHidden + "';Expressions[" + fldNo + "]='" + expr.Replace("'", "\\'") + "';exprSuggestions[" + fldNo + "]=" + exprSuggestion.ToString().ToLower() + ";pCurArr[" + fldNo + "]= '" + paramValue + "';vExpressions[" + fldNo + "]='" + vExpr + "';sqlParamsArr[" + fldNo + "]='" + isSelectParamsString + "';columnDepArr[" + fldNo + "]='" + columnDepStr + "'; ");
                    paramHidden = paramHidden.ToLower();
                    if (paramHidden == "false")
                    {
                        objParams.ArrParamType.Add(paramType);
                        objParams.IsParameterExist = true;
                        IsParamsVisible = true;
                        if (paramsBound && paramValue == string.Empty)
                        {
                            if (paramMOE.ToLower() == "select")
                            {
                                if (arrFillList.Count > 0 && arrFillList[0].ToString() != string.Empty)
                                    paramsBound = true;
                                else
                                    paramsBound = false;
                            }
                            else
                                paramsBound = false;
                        }

                        //tabIndex = tabIndex + 1;
                        unHideParams = true;
                        string CallValidateExpr = string.Empty;
                        string onlyTime = String.Empty;
                        if (parameterName.StartsWith("axptm_") || parameterName.StartsWith("axpdbtm_"))
                        {
                            onlyTime = " onlyTime ";
                        }

                        string acceptNumericCorrection = "valdDecPts(this," + decPts + ");";
                        string hideMobKeyBoard = (isMobile ? " onFocus=\"blur();\" " : "");
                        if (!string.IsNullOrEmpty(vExpr))
                        {
                            if (paramMOE.ToLower() == "accept")
                            {
                                if (paramType == "Date/Time")
                                    CallValidateExpr = "onChange=\"ValidateVexpr('" + parameterName + "','" + vExpr + "');FillDependents('" + parameterName + "');\" ";
                                else
                                    CallValidateExpr = "onBlur=\""+(paramType.ToLower() == "numeric" ? acceptNumericCorrection : "")+"FillDependents('" + parameterName + "');ValidateVexpr('" + parameterName + "','" + vExpr + "');\" ";

                            }
                            else if ((paramMOE.ToLower() == "select") | (paramMOE.ToLower() == "pick list"))
                            {
                                CallValidateExpr = "onChange=\"FillDependents('" + parameterName + "');ValidateVexpr('" + parameterName + "','" + vExpr + "');\" ";
                            }
                        }
                        else
                        {
                            if (paramMOE.ToLower() == "accept")
                            {
                                CallValidateExpr = "onBlur=\""+(paramType.ToLower() == "numeric" ? acceptNumericCorrection : "")+"FillDependents('" + parameterName + "');\" ";
                            }
                            else if ((paramMOE.ToLower() == "select") | (paramMOE.ToLower() == "pick list"))
                            {
                                CallValidateExpr = "onChange=\"FillDependents('" + parameterName + "');\" ";
                            }
                        }



                        if ((paramMOE.ToLower() == "accept") & (paramType == "Date/Time") & (!string.IsNullOrEmpty(expr)))
                        {
                            if (expr.ToLower() != "date()")
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='date form-control' data-input onfocus=\"ExprHandler(this.name,this.value, true);" + (isMobile ? "blur();" : "") + "\"><span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>calendar_today</span></span></div></div></td>");
                                
                            }
                            else
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='date form-control'" + CallValidateExpr + "" + hideMobKeyBoard + " data-input><span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>calendar_today</span></span></div></div></td>");

                            }
                        }
                        else if ((paramMOE.ToLower() == "accept") & (paramType == "Date/Time") & (string.IsNullOrEmpty(expr)))
                        {
                            if (paramDepStr != string.Empty)
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='date form-control'" + CallValidateExpr + "" + hideMobKeyBoard + " data-input><span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>calendar_today</span></span></div></div></td>");

                            }
                            else
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='date form-control'" + CallValidateExpr + "" + hideMobKeyBoard + " data-input><span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>calendar_today</span></span></div></div></td>");

                            }
                        }
                        else if ((paramMOE.ToLower() == "accept") & (!string.IsNullOrEmpty(expr)))
                        {
                            if (paramType.ToLower() == "numeric")
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='" + onlyTime + "form-control ' onfocus=\"ExprHandler(this.name,this.value, true);" + (isMobile ? "blur();" : "") + "\" " + CallValidateExpr + " " + (onlyTime != string.Empty ? "data-input" : "") + ">" + (onlyTime != string.Empty ? "<span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>schedule</span></span>" : "") + "</div></div></td>");
                            }
                            else
                            {
                                paramHtml.Append("<td><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='" + onlyTime + "form-control ' onfocus=\"ExprHandler(this.name,this.value, true);" + (isMobile ? "blur();" : "") + "\" " + CallValidateExpr + " " + (onlyTime != string.Empty ? "data-input" : "") + ">" + (onlyTime != string.Empty ? "<span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>schedule</span></span>" : "") + "</div></div></td>");
                            }

                        }
                        else if ((paramMOE.ToLower() == "accept"))
                        {
                            if (paramType.ToLower() == "numeric")
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='" + onlyTime + "form-control ' " + CallValidateExpr + " " + (onlyTime != string.Empty ? "data-input" : "") + ">" + (onlyTime != string.Empty ? "<span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>schedule</span></span>" : "") + "</div></div></td>");
                            }
                            else
                            {
                                paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group paramtd2'><input type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='" + onlyTime + " form-control '" + CallValidateExpr + " " + (onlyTime != string.Empty ? "data-input" : "") + ">" + (onlyTime != string.Empty ? "<span class='input-group-text' data-toggle><span class='material-icons material-icons-style cursor-pointer fs-4'>schedule</span></span>" : "") + "</div></div></td>");
                            }

                        }
                        else if ((paramMOE.ToLower() == "pick list"))
                        {
                            
                            if (dynamicFilterString.EndsWith("|"))
                                dynamicFilterString = dynamicFilterString.Substring(0, dynamicFilterString.Length - 1);
                            
                            paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group pick-list paramtd2'><select type='text' id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "' class='form-select trySelectPl' " + CallValidateExpr + "></select></div></td>");
                            paramHtml.Append("<script>var dfval" + parameterName + "= '" + dynamicFilterString + "' </script>");
                            dynamicFilterString = string.Empty;
                            arrFillList.Clear();
                            arrFillListDataAttr.Clear();
                            isSelectWithMultiColumn = false;
                            isSelectParamsString = string.Empty;
                        }
                        else if ((paramMOE.ToLower() == "select") & isSqlFld == true)
                        {
                            paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "<span class=\"required ivparamselect\"></span></label><div class='input-group paramtd2'><select id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' class='form-select trySelect'  onmouseover=\"showHideTooltip(this.id);\"  " + CallValidateExpr + ">");

                            int i = 0;
                            if (arrFillList.Count == 0)
                            {
                                paramHtml.Append("<option selected>" + Constants.EMPTYOPTION + "</option>");
                            }
                            for (i = 0; i <= arrFillList.Count - 1; i++)
                            {
                                if (arrFillList[i].ToString() == paramValue)
                                {
                                    paramHtml.Append("<option selected value=\"" + arrFillList[i].ToString() + "\" "+ arrFillListDataAttr[i] + " >" + arrFillList[i].ToString() + "</option>");
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        paramHtml.Append("<option value=\"\" " + arrFillListDataAttr[i] + " >" + Constants.EMPTYOPTION + "</option>");
                                        paramHtml.Append("<option value=\"" + arrFillList[i].ToString() + "\" " + arrFillListDataAttr[i] + " >" + arrFillList[i].ToString() + "</option>");
                                        strFillDepPName = strFillDepPName + parameterName + "¿";
                                    }
                                    else
                                    {
                                        paramHtml.Append("<option value=\"" + arrFillList[i].ToString() + "\" " + arrFillListDataAttr[i] + " >" + arrFillList[i].ToString() + "</option>");
                                    }
                                }
                            }
                            paramHtml.Append("</select></div></div></td>");
                            arrFillList.Clear();
                            arrFillListDataAttr.Clear();
                            isSelectWithMultiColumn = false;
                            isSelectParamsString = string.Empty;
                            isSqlFld = false;
                        }
                        else if (paramMOE.ToLower() == "select" & isSqlFld == false)
                        {
                            paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "<span class=\"required ivparamselect\"></span></label><div class='input-group paramtd2'><select id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' class='form-select trySelect' " + CallValidateExpr + " ></select></div></div></td>");
                        }
                        else if (((paramMOE.ToLower() == "multi select")))
                        {
                            paramHtml.Append("<td class='d-block d-sm-table-cell col-12 col-sm-4'><div class='agform '><label for='" + parameterName + "' class='form-label col-form-label paramtd1 cap '>" + paramCaption + "</label><div class='input-group multi-select paramtd2'>");

                            if (!objIview.requestJSON)
                            {

                                paramHtml.Append("<div style=\"\"  name=\"" + parameterName + "\" data-caption=\"" + paramCaption + "\"  class=\"spnSelectAll\"><input type='checkbox' id='"
                                        + parameterName + "' data-caption=\"" + paramCaption + "\" onclick=\"GetAllChecked(this);\" class=\"chkAllList chkSelectAll\" "
                                        + string.Empty + "/>Select All</div><div id=\"" + parameterName + "\" class=\"paramtd2 chkListBdr\">");

                                int i = 0;
                                for (i = 0; i <= arrFillList.Count - 1; i++)
                                {

                                    if (arrFillList[i].ToString() == paramValue)
                                    {
                                        paramHtml.Append("<span><input type=\"checkbox\" onclick=\"UncheckChkAll(this);\" checked='true' id=\"" + parameterName + "\" data-caption=\"" + paramCaption + "\" class=\" chkAllList chkShwSel\" value=\"" + arrFillList[i].ToString() + "\"/>" + arrFillList[i].ToString() + "</span><br />");

                                    }
                                    else
                                    {
                                        paramHtml.Append("<span><input type=\"checkbox\" id=\"" + parameterName + "\" data-caption=\"" + paramCaption + "\" class=\" chkAllList chkShwSel\" onclick=\"UncheckChkAll(this);\" value=\"" + arrFillList[i].ToString() + "\"/>" + arrFillList[i].ToString() + "</span><br />");

                                    }

                                }
                                paramHtml.Append("</div>");

                            }
                            else
                            {
                                string separator = "&grave;";
                                paramHtml.Append("<select class=\"form-select trySelectMs\" multiple=\"multiple\" name=\"" + parameterName + "\" id='" + parameterName + "' data-caption=\"" + paramCaption + "\" data-valuelist=\"" + string.Join(separator.ToString(), arrFillList.ToArray().Where(x => !string.IsNullOrEmpty(x.ToString())).ToArray()) + "\"  data-selectedlist=\"" + paramValue + "\"  data-separator=\"" + separator.ToString() + "\" /></select>");
                                //paramHtml.Append("<div class=\"input-group-hide multiChkSpan gridstackCalcChecklist\" ><label class=\"input-group-addon d-none\" ><input type=\"checkbox\" class=\"tokenSelectAll\" onclick=\"checkAllCheckBoxTokens(this);\" />Select All</label><div class=\"autoinput-parent\"><input name=\"" + parameterName + "\" id='" + parameterName + "' data-caption=\"" + paramCaption + "\" type=\"text\" class=\"multiFldChk   form-control\"" + " data-type=\"checkbox\" data-valuelist=\"" + string.Join(separator.ToString(), arrFillList.ToArray().Where(x => !string.IsNullOrEmpty(x.ToString())).ToArray()) + "\"  data-selectedlist=\"" + paramValue + "\"  data-separator=\"" + separator.ToString() + "\" />");
                                //paramHtml.Append("<div class=\"edit\"><i class=\"glyphicon glyphicon-chevron-down autoClickddl\" title=\"select\" data-clk=\"" + parameterName + "-tokenfield\"></i></div>");
                                //paramHtml.Append("</div></div>");
                            }
                            paramHtml.Append("</div></div></td>");
                            arrFillList.Clear();
                            arrFillListDataAttr.Clear();
                            isSelectWithMultiColumn = false;
                            isSelectParamsString = string.Empty;
                            isSqlFld = false;
                        }


                        iCnt = iCnt + 1;
                        if (CallValidateExpr != string.Empty && paramDepStr != string.Empty)
                        {
                            strJsArrays.Append("depParamArr[" + dpCnt + "]='" + parameterName + "';");
                            dpCnt++;
                        }
                        CallValidateExpr = string.Empty;

                    }
                    else
                    {
                        objParams.ArrParamType.Add(paramType);
                        if (!string.IsNullOrEmpty(paramValue))
                        {
                            paramHtml.Append("<input type=hidden id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value='" + paramValue + "'/>");
                        }
                        else
                        {
                            paramHtml.Append("<input type=hidden id='" + parameterName + "' name='" + parameterName + "' data-caption='" + paramCaption + "' value=''/>");
                        }
                        arrFillList.Clear();
                        arrFillListDataAttr.Clear();
                        isSelectWithMultiColumn = false;
                        isSelectParamsString = string.Empty;

                    }
                    fldNo = fldNo + 1;
                    paramDepStr = string.Empty;
                    columnDepStr = string.Empty;
                    if (iCnt == 3)
                    {
                        iCnt = 0;
                        paramHtml.Append("</tr><tr>");
                    }

                }
            }
            paramHtml.Append("</div></tr></table>");

            strJsArrays.Append("</script>");

            objParams.ParamHtml = paramHtml;
            objParams.strJsArrays = strJsArrays.ToString();
            objParams.iviewParams = iviewParams;
            objParams.iviewParamValues = iviewParamValues;
            objParams.axpResp = axpResp;
            objParams.paramsBound = paramsBound;
        }
        else
        {
            paramHtml = objParams.ParamHtml != null ? objParams.ParamHtml : new StringBuilder();
            strJsArrays.Append(objParams.strJsArrays);
            iviewParams = objParams.iviewParams;
            iviewParamValues = objParams.iviewParamValues;
            axpResp = objParams.axpResp;
            axp_refresh = objParams.Axp_refresh;
            unHideParams = IsParamsVisible = objParams.IsParameterExist;
            paramsBound = objParams.paramsBound;
        }
        //button1.TabIndex = Convert.ToInt16(tabIndex + 1);
        if (!objIview.requestJSON)
        {
            Session["paramDetails"] = strParamDetails.ToString();
        }
        //Session["FillDepPName"] = strFillDepPName;

        //dvRefreshParam.Visible = IsParamsVisible;

        if (objParams.ParamsExist == false || redisLoadKey != string.Empty)
        {
            GetIviewData();
        }
        else if (unHideParams == false && isCallWS == false)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "myrest", "<script type=\"text/javascript\">document.getElementById('button1').click();</script>");
            iviewFrame.Style.Add("display", "block");
            paramCont.Style.Add("display", "none");
        }

        JObject resultData = new JObject();
        if (objIview.DsIviewConfig != null && (objIview.DsIviewConfig.Rows.Count > 0))
        {

            JObject jObj = null;
            jObj = generateConfigurationJson(objIview.DsIviewConfig);
            if (jObj != null)
            {
                resultData.Add("configurations", jObj);
            }
        }
        tst_Scripts = tst_Scripts + "<script type=\"text/javascript\">var hideParams='" + hideParameters + "';var proj = '" + proj + "';var user='" + user + "';var AxRole='" + AxRole + "'; var sid='" + sid + "';var iName='" + iName + "';var dynamicFilterString =''; gl_language='" + language + "'; validateParamOnGo=" + validateParamOnGo.ToString().ToLower() + "; " + strGlobalVar + "var axpResp='" + axpResp + "';var axp_refresh = '" + objParams.Axp_refresh + "';var globalIvConfigurations = " + resultData.ToString(Newtonsoft.Json.Formatting.None) + ";</script>";
        logobj.CreateLog("Loading and setting parameters components completed", sid, fileName, string.Empty);
        if (paramsBound == true && unHideParams == true && isCallWS == false)
        {
            unhidedvRowsPerPage();
            if (objIview.IsDirectDBcall)
            {
                GridView2Wrapper.Visible = true;
                string a = string.Empty;
                if (hdnGo.Value == "refreshparams")
                    BindDataGrid(a, GridView1.PageSize, objIview.CurrentPageNo);
                else
                    CallWebservice("1", "yes");

            }
            else if (redisLoadKey == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "FillDependentsStartupPlus", "<script type=\"text/javascript\">AxWaitCursor(true);ShowDimmer(true);GetUserLocale(); FillDependentsStartup(true);</script>");
            }
            //ShowHideFilterDiv(false);
        }
        else
        {
            if (objParams.ParamsExist)
            {
                dvRowsPerPage.Style.Add("display", "none");
            }
            else
            {
                unhidedvRowsPerPage();
            }
            if (redisLoadKey == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "FillDependentsStartup", "<script type=\"text/javascript\">FillDependentsStartup(false);</script>");
            }
        }
    }

    private string GetParamType(string paramName)
    {
        foreach (string strParam in objParams.ParamNameType)
        {
            string[] arrParam = strParam.Split('♣');
            if (arrParam.Length == 2 && arrParam[0].ToString().ToLower() == paramName.ToLower())
                return arrParam[1].ToString();
        }
        return string.Empty;
    }

    private void ShowHideFilterDiv(bool showParam)
    {
        if (showParam)
        {
            hdnShowParams.Value = "true";
            paramCont.Style.Add("display", "block");

            //myFilters.Attributes.Add("class", myFilters.Attributes["class"].ToString().Replace("collapsed", ""));
            Filterscollapse.Attributes.Add("class", Filterscollapse.Attributes["class"].ToString().Replace("collapse", "collapse in"));
        }
        else
        {
            hdnShowParams.Value = "false";
            hideParameters = "true";
            paramCont.Style.Add("display", "none");

            //myFilters.Attributes.Add("class", myFilters.Attributes["class"].ToString().Replace("filterBuTTon", "filterBuTTon collapsed"));
            //  myFilters.Attributes.Add("aria-expanded", myFilters.Attributes["aria-expanded"].ToString().Replace("true", "false"));
            Filterscollapse.Attributes.Add("class", Filterscollapse.Attributes["class"].ToString().Replace("in", ""));
        }

    }

    #region "Function for Load the Recent Activities"
    private void LoadActivities()
    {
        divCustomAct.Visible = true;
        string sqlQuery = string.Empty;
        string result = string.Empty;
        string errorLog = logobj.CreateLog("GetLoginActivity.", Session["nsessionid"].ToString(), "openiview-dev-" + iName, "");
        string query = "<sqlresultset axpapp='" + Session["project"].ToString() + "' sessionid='" + Session["nsessionid"].ToString() + "' trace='" + errorLog + "' appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "' ><sql>";
        sqlQuery = "select username as Users,case when convert(varchar(10),CALLEDON,101) = convert(varchar(10),getdate(),101) then substring(convert(varchar(30),CALLEDON,100),12,30) else convert(varchar(30),CALLEDON,100) end calledon ,IP from ( Select a.username, CALLEDON, ip,structname ,row_number() over ( order by calledon desc ) as axrnum from axaudit a, axpertlog b Where a.sessionid= b.sessionid and a.username not like 'portal%' and structname is not null and structname = '" + iName + "') dual where axrnum < 11 order by axrnum";
        sqlQuery = util.CheckSpecialChars(sqlQuery);
        query += sqlQuery + " </sql>" + Session["axApps"].ToString() + Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</sqlresultset>";

        //Call service 
        result = objWebServiceExt.CallGetChoiceWS(iName, query);

        if (result == string.Empty || (result.StartsWith("<error>")) || (result.Contains("error")))
        {
            Server.Transfer("err.aspx?errmsg=" + result);
        }
        else
        {
            DataSet ds = new DataSet();
            System.IO.StringReader sr = new System.IO.StringReader(result);
            ds.ReadXml(sr);

            BindData(ds);
        }
    }

    private void BindData(DataSet dst)
    {
        if (dst.Tables["row"] != null)
        {
            if (dst.Tables["row"].Rows.Count > 0)
            {
                grvActivities.DataSource = dst.Tables["row"];
                grvActivities.DataBind();
            }
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Users");
            dt.Columns.Add("Date/Time");
            dt.Columns.Add("IP");
            dt.Columns.Add(string.Empty);
            dt.Rows.Add(new object[] { "", "" });
            grvActivities.Height = 20;
            grvActivities.DataSource = dt;
            grvActivities.DataBind();
        }
    }

    protected void grvActivities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[2].Width = 200;
        e.Row.Cells[1].Width = 150;
        e.Row.Cells[0].Width = 200;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Text = "Date/Time";
            e.Row.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "*")
                e.Row.Cells[2].Text = string.Empty;

            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    #endregion

    private void SessExpires()
    {
        string url = Convert.ToString(HttpContext.Current.Application["SessExpiryPath"]);
        Response.Write("<script>" + Constants.vbCrLf);
        Response.Write("parent.parent.location.href='" + url + "';");
        Response.Write(Constants.vbCrLf + "</script>");
    }

    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        ClearNavigationData();
        currentPageNo = Convert.ToInt32(objIview.CurrentPageNo);
        currentPageNo = currentPageNo - 1;

        CallWebservice(currentPageNo.ToString(), string.Empty);
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "prev page click", "ShowDimmer(false);", true);
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        ClearNavigationData();
        currentPageNo = Convert.ToInt32(objIview.CurrentPageNo);
        currentPageNo = currentPageNo + 1;

        CallWebservice(currentPageNo.ToString(), string.Empty);
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "next page click", "ShowDimmer(false);", true);
    }

    #region Charts

    private void ClearChartColumns()
    {
        //clear the chart columns and add one empty item
        ddlChartCol1.Items.Clear();
        ddlChartCol2.Items.Clear();
        ddlChartCol1.Items.Add(string.Empty);
        ddlChartCol2.Items.Add(string.Empty);
    }

    private void AddChartColumns(string columnName, int index, string type)
    {
        System.Web.UI.WebControls.ListItem lst = new System.Web.UI.WebControls.ListItem();
        lst.Text = columnName;
        lst.Value = index.ToString();
        ddlChartCol1.Items.Add(lst);
        if (type == "n")
            ddlChartCol2.Items.Add(lst);
    }

    protected void btnGetChart_Click(object sender, EventArgs e)
    {
        if (ddlChartCol1.SelectedValue != string.Empty && ddlChartCol2.SelectedValue != string.Empty)
        {
            try
            {
                PrepareChart(rbtnChartType.SelectedValue);
                divcontainer.Style.Add("width", "50%");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {

            string chartScript = "<script type='text/javascript'>ShowCharts('IView','show');</script>";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(), "myChart", chartScript, false);


        }
    }

    private void PrepareChart(string type)
    {
        StringBuilder strChart = new StringBuilder();
        strChart.Append("<script type='text/javascript'>");

        DataTable dt = new DataTable();
        //dt = (DataTable)Session["FilteredData"];
        //cac_iviewData is removed from bind data since this old iview PrepareChart functionality is removed
        if (dt == null) dt = (DataTable)Session["cac_iviewData"];
        if (dt == null) return;
        string col1 = string.Empty; string col2 = string.Empty;
        string colData = string.Empty;


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["axrowtype"].ToString() != "subhead" && dt.Rows[i]["axrowtype"].ToString() != "stot")
            {
                col2 = dt.Rows[i][Convert.ToInt32(ddlChartCol2.SelectedValue)].ToString().Replace(",", string.Empty);
                if (col2 == "") col2 = "0";

                if (colData == string.Empty)
                    colData = "['" + dt.Rows[i][Convert.ToInt32(ddlChartCol1.SelectedValue)].ToString() + "', " + col2 + "]";
                else
                    colData += ",['" + dt.Rows[i][Convert.ToInt32(ddlChartCol1.SelectedValue)].ToString() + "', " + col2 + "]";
            }
        }

        string chWidth = "550";
        string chHeight = "200";
        if (hdnChartSize.Value == "full")
        {
            chWidth = "800";
            chHeight = "300";
        }

        if (type == "line")
            strChart.Append(GetLineChart(colData, chWidth, chHeight));
        else if (type == "bar")
            strChart.Append(GetBarChart(colData, chWidth, chHeight));
        else if (type == "pie")
            strChart.Append(GetPieChart(colData, chWidth, chHeight));

        strChart.Append("</script>");
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(), "myChart", strChart.ToString(), false);
    }


    private string GetLineChart(string data, string width, string height)
    {
        StringBuilder strChart = new StringBuilder();
        strChart.Append("google.setOnLoadCallback(drawChart);");
        strChart.Append("function drawChart() {var data = google.visualization.arrayToDataTable([");
        strChart.Append("['" + ddlChartCol1.SelectedItem.Text + "', '" + ddlChartCol2.SelectedItem.Text + "'],");
        strChart.Append(data);
        strChart.Append("]);");
        strChart.Append("data = google.visualization.data.group(data,[0],[{'column': 1, 'aggregation': google.visualization.data.sum, 'type': 'number'}]);");
        strChart.Append("new google.visualization.LineChart(document.getElementById('chart_div'))");
        strChart.Append(".draw(data, {title: '" + objIview.IviewCaption.ToString() + "',width: " + width + ",height:" + height + ",fontName:'Segoe UI',fontSize:10});}");
        strChart.Append("drawChart();ShowCharts('IView','show');");
        return strChart.ToString();
    }

    private string GetBarChart(string data, string width, string height)
    {
        StringBuilder strChart = new StringBuilder();
        strChart.Append("google.setOnLoadCallback(drawChart);function drawChart() {");
        strChart.Append("var data = google.visualization.arrayToDataTable([");
        strChart.Append("['" + ddlChartCol1.SelectedItem.Text + "', '" + ddlChartCol2.SelectedItem.Text + "'],");
        strChart.Append(data);
        strChart.Append("]);");
        strChart.Append("data = google.visualization.data.group(data,[0],[{'column': 1, 'aggregation': google.visualization.data.sum, 'type': 'number'}]);");
        strChart.Append("new google.visualization.BarChart(document.getElementById('chart_div'))");
        strChart.Append(".draw(data, {title: '" + objIview.IviewCaption.ToString() + "',width: " + width + ",height:" + height + ",fontName:'Segoe UI',fontSize:10});}");
        strChart.Append("drawChart();ShowCharts('IView','show');");
        return strChart.ToString();
    }

    private string GetPieChart(string data, string width, string height)
    {
        StringBuilder strChart = new StringBuilder();
        strChart.Append("google.setOnLoadCallback(drawChart);");
        strChart.Append("function drawChart() {var data = google.visualization.arrayToDataTable([");
        strChart.Append("['" + ddlChartCol1.SelectedItem.Text + "', '" + ddlChartCol2.SelectedItem.Text + "'],");
        strChart.Append(data);
        strChart.Append("]);");
        strChart.Append("data = google.visualization.data.group(data,[0],[{'column': 1, 'aggregation': google.visualization.data.sum, 'type': 'number'}]);");
        strChart.Append("new google.visualization.PieChart(document.getElementById('chart_div'))");
        strChart.Append(".draw(data, {title: '" + objIview.IviewCaption.ToString() + "',width: " + width + ",height:" + height + ",chartArea: {'width': '80%', 'height': '80%'},fontName:'Segoe UI',fontSize:10});}");
        //strChart.Append(".draw(data, {title: '" + objIview.IviewCaption.ToString() + "',chartArea: {'width': '100%', 'height': '80%'},width: " + width + ",height:" + height + ",fontName:'Segoe UI',fontSize:10});}");
        strChart.Append("drawChart();ShowCharts('IView','show');");

        return strChart.ToString();
    }

    #endregion

    // iview caching : below function is check for opened iview exists or not.
    private bool IsIviewCacheFileExist(string curPageNo)
    {
        string xmlFilePath = util.ScriptsPath + "axpert\\" + sid + "\\" + iName + "\\" + iName + "_" + curPageNo + ".xml";

        if (File.Exists(xmlFilePath) && !objIview.IsDirectDBcall)
            isPageExist = true;
        else
            isPageExist = false;

        return isPageExist;
    }

    // iview caching : below function is check for select parameter exist or not.
    private bool IsParamFileExist(string sId, string iName)
    {
        string xmlParamFilePath = util.ScriptsPath + "axpert\\" + sid + "\\" + iName + "\\" + iName + "_param.xml";

        return false;
    }


    private void CreateCacheDir()
    {
        string cachePath = util.ScriptsPath + "axpert\\" + sid + "\\" + iName + "\\";
        try
        {
            DirectoryInfo di = new DirectoryInfo(cachePath);
            if (!di.Exists)
                di.Create();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region IView Filter

    //To create Filter on IView Data

    //sorting
    protected void btnSortGrid_Click(object sender, EventArgs e)
    {

    }

    //hidecolumns
    protected void btnHideColumn_Click(object sender, System.EventArgs e)
    {

    }

    //filter
    protected void btnFilterGrid_Click(object sender, EventArgs e)
    {

    }

    public DataTable GetFilterSerialNo(DataTable dt)
    {
        if (!string.IsNullOrEmpty(objIview.SrNoColumName))
        {
            srNoColumnName = objIview.SrNoColumName;
            if (dt.Columns.Contains(srNoColumnName))
            {
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    string valsrNoColumn = dt.Rows[count][srNoColumnName].ToString();

                    if ((!string.IsNullOrEmpty(valsrNoColumn) && (!valsrNoColumn.Equals("Grand Total"))))

                        dt.Rows[count][srNoColumnName] = count + 1;
                }
            }
        }
        return dt;
    }


    public DataTable GetSerialNoForPerfXml(DataTable dt, string columnName)
    {
        if (!string.IsNullOrEmpty(columnName))
        {
            srNoColumnName = columnName;
            if (dt.Columns.Contains(srNoColumnName))
            {
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    dt.Rows[count][srNoColumnName] = count + 1;

                }
            }
        }
        return dt;
    }

    private void BindTableToGrid(DataTable dt, string calledFrom)
    {
        if (objIview.IsIviewStagLoad)
        {
            DataSet ds = new DataSet();
            DataTable dtTemp = new DataTable();
            dtTemp = dt.Copy();
            ds.Tables.Add(dtTemp);
            ds = GetStaggeredTables(ds);
            GridView1.DataSource = ds.Tables[0];
        }
        else
        {
            GridView1.DataSource = dt;
        }

        objIview.DtCurrentdata = dt;


        GridView1.DataBind();
        if (objIview.IsIviewStagLoad)
        {
            if (calledFrom != "sort")
            {
                int rowCount = dt.Rows.Count;
                int totStagRows = GridView1.Rows.Count;
                if (dt.Rows[rowCount - 1][1].ToString().Contains("gtot"))
                {
                    rowCount = rowCount - 1;
                    totStagRows = totStagRows - 1;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableStagLoad", "DisableStagLoad();", true);
                }

                hdnTotalIViewRec.Value = dt.Rows.Count.ToString();
                lblFilteredRowCount.Text = lblTotalNo.Text + totStagRows + " of " + rowCount;
            }
            lnkPrev.Visible = false;
            lnkNext.Visible = false;
        }
        else
        {
            lblFilteredRowCount.Text = lblTotalNo.Text + dt.Rows.Count.ToString();
        }
    }


    //clear
    protected void RecordsPerPage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ClearNavigationData();
        resetIViewWithoutRowCount();
        paramxml.Value = string.Empty;
        gridPageSize = recPerPage.SelectedItem.Value.ToString();
        objIview.GrdPageSize = gridPageSize;
        currentPageNo = 1;
        Session["currentPageNo" + iName] = 1;
        if (recPerPage.Visible == true)
            CallWebservice("1", "yes");
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "record per page", "ShowDimmer(false);", true);
    }
    protected void btnClearFilter_Clicked(object sender, System.EventArgs e)
    {

        pXml = ""; string pName = "";
        for (int i = 0; i < objParams.ParamNames.Count; i++)
        {
            pName = objParams.ParamNames[i].ToString();
            pXml = pXml + "<" + pName + ">";
            pXml = pXml + objParams.ParamValsOnLoad[i].ToString();
            pXml = pXml + "</" + pName + ">";
        }

    }
    private void UpdateRecordsPerPage()
    {
        int recIdx = recPerPage.Items.IndexOf(new System.Web.UI.WebControls.ListItem(gridPageSize));
        if (recIdx == -1)
        {
            //List<int> list = new List<int> { 50, 100, 200, 500, 1000 };
            List<int> list = new List<int> { 50, 100, 200, 500 };
            int ivPageSize = Convert.ToInt32(gridPageSize);
            int closest = list.OrderBy(item => Math.Abs(ivPageSize - item)).First();
            if (closest > ivPageSize && list.IndexOf(closest) > 0)
                recIdx = list.IndexOf(closest) - 1;
            else if (closest > ivPageSize && list.IndexOf(closest) == 0)
                recIdx = 0;
            else
                recIdx = list.IndexOf(closest) + 1;
            recPerPage.Items.Insert(recIdx, new System.Web.UI.WebControls.ListItem(gridPageSize));
            recPerPage.SelectedIndex = recIdx;
        }
        else
        {
            recPerPage.SelectedIndex = recIdx;
        }
    }

    public bool setIviewSessionCacheObject(String ivKey, IviewData ivD)
    {
        List<String> sessionsIviewStore = new List<String>();
        if (HttpContext.Current.Session["sessionsIviewStore"] != null)
        {
            sessionsIviewStore = (List<String>)HttpContext.Current.Session["sessionsIviewStore"];
        }
        try
        {
            string ivNameFromIvKey = ivKey.Split('_')[0];
            if (iName == ivNameFromIvKey)
            {
                int i = 0;
                foreach (string key in sessionsIviewStore)
                {
                    var sessionKeyIviewName = key.Split('_')[0];
                    if (sessionKeyIviewName == ivNameFromIvKey)
                    {
                        Session[key] = null;
                        sessionsIviewStore.RemoveAt(i);
                        break;
                    }
                    i++;
                }
            }
            sessionsIviewStore.Add(ivKey);
            HttpContext.Current.Session["sessionsIviewStore"] = sessionsIviewStore;
            HttpContext.Current.Session[ivKey] = ivD;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    //myviews
    //get my views

    #endregion
    private void IncludeCustomLinks()
    {
        string projName = HttpContext.Current.Session["Project"].ToString();
        Custom customObj = Custom.Instance;
        for (int i = 0; i < customObj.jsIviewFiles.Count; i++)
        {
            string[] jsFileStr = customObj.jsIviewFiles[i].ToString().Split('¿');
            string iviewName = jsFileStr[0].ToString().ToLower();
            string fileName = jsFileStr[1].ToString();
            if (iName.ToLower() == iviewName)
            {
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                string path = "../" + projName + "/" + fileName;
                js.Attributes["src"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }

        for (int j = 0; j < customObj.jsIviewGlobalFiles.Count; j++)
        {
            HtmlGenericControl js = new HtmlGenericControl("script");
            js.Attributes["type"] = "text/javascript";
            string path = "../" + projName + "/" + customObj.jsIviewGlobalFiles[j].ToString();
            js.Attributes["src"] = path;
            ScriptManager1.Controls.Add(js);
        }

        for (int i = 0; i < customObj.cssIviewFiles.Count; i++)
        {
            string[] jsFileStr = customObj.cssIviewFiles[i].ToString().Split('¿');
            string iviewName = jsFileStr[0].ToString().ToLower();
            string fileName = jsFileStr[1].ToString();
            if (iName.ToLower() == iviewName)
            {
                HtmlGenericControl js = new HtmlGenericControl("link");
                js.Attributes["type"] = "text/css";
                js.Attributes["rel"] = "stylesheet";
                string path = "../" + projName + "/" + fileName;
                js.Attributes["href"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }

        for (int i = 0; i < customObj.cssIviewGlobalFiles.Count; i++)
        {
            HtmlGenericControl js = new HtmlGenericControl("link");
            js.Attributes["type"] = "text/css";
            js.Attributes["rel"] = "stylesheet";
            string path = "../" + projName + "/" + customObj.cssIviewGlobalFiles[i].ToString();
            js.Attributes["href"] = path;
            ScriptManager1.Controls.Add(js);
        }
    }

    private void IncludeCustomLinksNew(IviewData objIview)
    {
        string projName = HttpContext.Current.Session["Project"].ToString();
        if (objIview.axpCustomJs != string.Empty && objIview.axpCustomJs.ToLower() == "single")
        {
            FileInfo filtcustom = new FileInfo(HttpContext.Current.Server.MapPath("~/" + projName + "/report/js/" + iName + ".js"));
            if (filtcustom.Exists)
            {
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                string path = "../" + projName + "/report/js/" + iName + ".js";
                js.Attributes["src"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }
        else if (objIview.axpCustomJs != string.Empty && objIview.axpCustomJs.ToLower() == "all")
        {
            FileInfo filcustom = new FileInfo(HttpContext.Current.Server.MapPath("~/" + projName + "/report/js/custom.js"));
            if (filcustom.Exists)
            {
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                string path = "../" + projName + "/report/js/custom.js";
                js.Attributes["src"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }

        if (objIview.axpCustomCss != string.Empty && objIview.axpCustomCss.ToLower() == "single")
        {
            FileInfo filtcsscustom = new FileInfo(HttpContext.Current.Server.MapPath("~/" + projName + "/report/css/" + iName + ".css"));
            if (filtcsscustom.Exists)
            {
                HtmlGenericControl js = new HtmlGenericControl("link");
                js.Attributes["type"] = "text/css";
                js.Attributes["rel"] = "stylesheet";
                string path = "../" + projName + "/report/css/" + iName + ".css";
                js.Attributes["href"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }
        else if (objIview.axpCustomCss != string.Empty && objIview.axpCustomCss.ToLower() == "all")
        {
            FileInfo filcsscustom = new FileInfo(HttpContext.Current.Server.MapPath("~/" + projName + "/report/css/custom.css"));
            if (filcsscustom.Exists)
            {
                HtmlGenericControl js = new HtmlGenericControl("link");
                js.Attributes["type"] = "text/css";
                js.Attributes["rel"] = "stylesheet";
                string path = "../" + projName + "/report/css/custom.css";
                js.Attributes["href"] = path;
                ScriptManager1.Controls.Add(js);
            }
        }

        if (objIview.axpCustomJs == string.Empty && objIview.axpCustomCss == string.Empty)
            IncludeCustomLinks();
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (Session["AxMergeRowIviews"] != null)
        {
            string mergeRowIviews = string.Empty;
            mergeRowIviews = Session["AxMergeRowIviews"].ToString();
            Boolean rowMerge = false;
            int mergeColumns = 0;
            if (!string.IsNullOrEmpty(mergeRowIviews))
            {
                string[] mIviews = mergeRowIviews.Split(',');
                for (int i = 0; i < mIviews.Length; i++)
                {
                    string mIview = mIviews[i].Substring(0, mIviews[i].IndexOf(':'));
                    if (iName == mIview)
                    {
                        rowMerge = true;
                        mergeColumns = Convert.ToInt32(mIviews[i].Substring(mIviews[i].IndexOf(':') + 1));
                        mergeColumns = mergeColumns + 1;
                        break;
                    }
                }
            }
            if (rowMerge)
            {
                ArrayList cellsWithValues = new ArrayList();
                for (int i = GridView1.Rows.Count - 1; i > 0; i--)
                {
                    GridViewRow row = GridView1.Rows[i];

                    if (i == GridView1.Rows.Count - 1)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            int sl;
                            if (!string.IsNullOrEmpty(row.Cells[c].Text) && !StringExtensions.IsNullOrWhiteSpace(row.Cells[c].Text))
                            {
                                if (c != 0 && int.TryParse(row.Cells[c].Text, out sl) != true)
                                    cellsWithValues.Add(c);
                            }
                        }
                    }
                    GridViewRow previousRow = GridView1.Rows[i - 1];
                    bool firstElement = false;
                    for (int n = 0; n < cellsWithValues.Count; n++)
                    {
                        string rowText = row.Cells[int.Parse(cellsWithValues[n].ToString())].Text;
                        string prevRowText = previousRow.Cells[int.Parse(cellsWithValues[n].ToString())].Text;
                        if (rowText.Equals(prevRowText) && rowText == prevRowText)
                        {
                            if (n == 0)
                                firstElement = true;

                            if (n == (cellsWithValues.Count - 1))
                                break;

                            string rowTextNext = row.Cells[int.Parse(cellsWithValues[n + 1].ToString())].Text;
                            string prevRowTextNext = previousRow.Cells[int.Parse(cellsWithValues[n + 1].ToString())].Text;

                            if (n == 0)
                                if (rowTextNext != prevRowTextNext && !rowTextNext.Equals(prevRowTextNext))
                                    break;

                            if (firstElement == true)
                            {
                                if (previousRow.Cells[int.Parse(cellsWithValues[n].ToString())].RowSpan == 0)
                                {
                                    if (row.Cells[int.Parse(cellsWithValues[n].ToString())].RowSpan == 0)
                                        previousRow.Cells[int.Parse(cellsWithValues[n].ToString())].RowSpan += 2;
                                    else
                                        previousRow.Cells[int.Parse(cellsWithValues[n].ToString())].RowSpan = row.Cells[int.Parse(cellsWithValues[n].ToString())].RowSpan + 1;

                                    row.Cells[int.Parse(cellsWithValues[n].ToString())].Visible = false;
                                    previousRow.Cells[int.Parse(cellsWithValues[n].ToString())].Style.Add("vertical-align", "middle");
                                }
                            }
                        }
                        else if (n == 0)
                            break;
                    }
                }
            }
        }
    }

    // Code to hide unhide row per page div 
    private void unhidedvRowsPerPage()
    {
        //if (objIview.IVType != "Interactive")
        //    dvRowsPerPage.Style.Add("display", "block");
        //else
        //    dvRowsPerPage.Style.Add("display", "none");
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string GetIviewPickListData(string iviewName, string pageNo, string pageSize, string fieldName, string fieldValue, string depParamVal)
    {
        Util.Util utilGlo = new Util.Util();
        string pickDepParams = string.Empty;
        try
        {
            if (depParamVal != "")
            {
                string[] pdParamStr = depParamVal.Split('¿');
                for (int i = 0; i < pdParamStr.Count(); i++)
                {
                    string pdNameVal = pdParamStr[i];
                    if (pdNameVal != "")
                    {
                        string[] pdNames = pdNameVal.Split('~');
                        pickDepParams = pickDepParams + "<" + pdNames[0] + ">";
                        pickDepParams = pickDepParams + utilGlo.CheckSpecialChars(pdNames[1]);
                        pickDepParams = pickDepParams + "</" + pdNames[0] + ">";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //TODO Exception
        }
        fieldValue = utilGlo.CheckSpecialChars(fieldValue);
        string iXml = string.Empty;
        string filename = "iviewpicklist-" + iviewName;
        LogFile.Log logobj = new LogFile.Log();
        ASBExt.WebServiceExt asbExt = new ASBExt.WebServiceExt();
        string errlog = logobj.CreateLog("", HttpContext.Current.Session["nsessionid"].ToString(), filename, "");
        iXml = iXml + "<sqlresultset axpapp=\"" + HttpContext.Current.Session["project"] + "\" value=\"" + fieldValue + "\" sessionid= \"" + HttpContext.Current.Session["nsessionid"] + "\" pname =\"" + fieldName + "\" trace=\"" + errlog + "\" user=\"" + HttpContext.Current.Session["user"] + "\" ivname=\"" + iviewName + "\" pageno =\"" + pageNo + "\" pagesize=\"" + pageSize + "\" appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "'>";
        if (pickDepParams != string.Empty)
            iXml = iXml + "<varlist>" + pickDepParams + "</varlist>";
        iXml = iXml + HttpContext.Current.Session["axApps"].ToString() + HttpContext.Current.Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString();
        iXml = iXml + "</sqlresultset>";

        string result = asbExt.CallGetParamChoicesWS(iviewName, iXml);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(result);

        string json = JsonConvert.SerializeXmlNode(doc);

        return json;
    }
    [WebMethod]
    public static string SaveJsonInDB(string jsonString, bool isListView)
    {
        string result = String.Empty;
        string sql = String.Empty;
        ASBCustom.CustomWebservice objCWbSer = new ASBCustom.CustomWebservice();
        string fileName = "openiview-dev---";
        if (HttpContext.Current.Session["nsessionid"] == null)
            return Constants.ERAUTHENTICATION;
        string sid = HttpContext.Current.Session["nsessionid"].ToString();
        LogFile.Log logobj = new LogFile.Log();

        string fdSettingsKey = Constants.RedisOldIviewSettings;
        if (isListView)
        {
            fdSettingsKey = Constants.RedisOldListviewSettings;
        }

        try
        {
            sql = Constants.MYSQL_QUERY_IVIR_SAVE_JSON;
            if (!string.IsNullOrEmpty(sql))
            {
                sql = sql.Replace("$USERID$", HttpContext.Current.Session["user"].ToString());
                sql = sql.Replace("$VALUE$", jsonString.Replace("&", "&amp;"));
            }
            result = objCWbSer.GetChoices("", sql);
        }
        catch (Exception ex)
        {
            logobj.CreateLog("Smartviews Save Exeception - " + ex.Message, sid, fileName, string.Empty);
        }

        if (result == "done")
        {
            try
            {
                Util.Util util = new Util.Util();
                string user = HttpContext.Current.Session["user"].ToString();
                FDW fdwObj = FDW.Instance;
                fdwObj.SaveInRedisServer(util.GetRedisServerkey(fdSettingsKey, "", user), jsonString, fdSettingsKey, HttpContext.Current.Session["dbuser"].ToString());
            }
            catch (Exception ex) { }
        }

        return result;
    }
    [WebMethod]
    public static object GetJsonFromDB(bool isListView)
    {
        string sqlResult = String.Empty;
        string result = string.Empty, status = string.Empty;
        ASBCustom.CustomWebservice objCWbSer = new ASBCustom.CustomWebservice();
        string fileName = "openiview-dev---";
        if (HttpContext.Current.Session["nsessionid"] == null)
            return new { result = Constants.ERAUTHENTICATION, status = "failure" };
        string sid = HttpContext.Current.Session["nsessionid"].ToString();
        LogFile.Log logobj = new LogFile.Log();
        string sql = string.Empty;

        string fdSettingsKey = Constants.RedisOldIviewSettings;
        if (isListView)
        {
            fdSettingsKey = Constants.RedisOldListviewSettings;
        }

        try
        {
            Util.Util util = new Util.Util();

            string user = HttpContext.Current.Session["user"].ToString();

            try
            {

                FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
                if (fObj == null)
                {
                    fObj = new FDR();
                    HttpContext.Current.Session["FDR"] = fObj;
                }

                result = fObj.StringFromRedis(util.GetRedisServerkey(fdSettingsKey, "", user));
            }
            catch (Exception ex) { }

            if (result != string.Empty)
            {
                status = "success";
            }
            else
            {
                util.CheckUserSettings();
                sql = Constants.MYSQL_QUERY_IVIR_GET_JSON;
                if (!string.IsNullOrEmpty(sql))
                {
                    sql = sql.Replace("$USERID$", HttpContext.Current.Session["user"].ToString());
                }
                sqlResult = objCWbSer.GetChoices("", sql);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sqlResult);
                XmlNodeList xml = doc.SelectNodes("//row//IR_CONFIG | //row//ir_config");
                if (xml.Count != 0)
                {
                    result = xml[0].InnerText;
                    status = "success";
                    try
                    {
                        FDW fdwObj = FDW.Instance;
                        fdwObj.SaveInRedisServer(util.GetRedisServerkey(fdSettingsKey, "", user), result, fdSettingsKey, HttpContext.Current.Session["dbuser"].ToString());
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    status = "failure";
                }
                //return json;
            }
        }
        catch (Exception ex)
        {
            logobj.CreateLog("Smartviews Load Exception - " + ex.Message, sid, fileName, string.Empty);
            status = "failure";
        }
        return new { result = result, status = status };
    }

    public static string ConvertBytesToMegabytes(double size)
    {
        double sizeMB = Convert.ToDouble(size / 1024f / 1024f);
        sizeMB = Math.Round(sizeMB);
        return sizeMB.ToString();

        //if (memoryText == "used_memory")
        //    lblMemoryAllocated.Text = memoryText + " : " + sizeMB.ToString() + " MB";
        //else
        //    lblMemorydetails.Text = memoryText + " : " + sizeMB.ToString() + " MB";
    }

    [WebMethod]
    public static string MemoryDetails()
    {
        List<Dictionary<string, object>> allSeries = new List<Dictionary<string, object>>();
        string memokey = string.Empty;
        string value = string.Empty;
        string newvalue = string.Empty;
        string resultset = string.Empty;
        ArrayList redsMemDetails = new ArrayList();
        ArrayList chartdetails = new ArrayList();
        try
        {
            FDR fdrObj = (FDR)HttpContext.Current.Session["FDR"];
            chartdetails = (ArrayList)fdrObj.GetMemoryDetails();
            if (chartdetails.Count > 0)
            {
                foreach (string arr2 in chartdetails)
                {
                    Dictionary<string, object> aSeries = new Dictionary<string, object>();
                    value = arr2.Split(':')[1];
                    aSeries["name"] = arr2.Split(':')[0];
                    newvalue = ConvertBytesToMegabytes(Convert.ToDouble(value));

                    aSeries["y"] = Convert.ToInt32(newvalue);
                    allSeries.Add(aSeries);
                }
                string pirrst = JsonConvert.SerializeObject(allSeries);
                resultset += pirrst.Replace(":[", ":").Replace("]}", "}");
            }
            return resultset;
        }
        catch (Exception ex)
        {
            //LogFile.Log logObj = new LogFile.Log();
            //logObj.CreateLog("FastDataUtility page(MemoryDetails), Message:" + ex.Message, "", "RedisServer", "new");
            return "failure";
        }
    }

    [WebMethod]
    public static object ActionBtnClick(string iName, string ivkey, string iXml, string actName, bool isScript = false)
    {
        var objIview = (IviewData)HttpContext.Current.Session[ivkey];
        if (objIview == null)
            return new { result = Constants.ERAUTHENTICATION };
        string filename = "Action-" + iName;
        LogFile.Log logobj = new LogFile.Log();
        //ASBExt.WebServiceExt asbExt = new ASBExt.WebServiceExt();
        string errlog = logobj.CreateLog("", HttpContext.Current.Session["nsessionid"].ToString(), filename, "");
        iXml = iXml.Replace("♦♦trace♦♦", errlog);
        iXml += HttpContext.Current.Session["axApps"].ToString() + HttpContext.Current.Application["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</root>";
        //Call service
        ASBExt.WebServiceExt objWebServiceExt = new ASBExt.WebServiceExt();
        string ires = string.Empty;

        if (iName == "inmemdb")
        {
            string delKeyResp = DeleteRedisKeys(iXml, HttpContext.Current.Session["dbuser"].ToString());
            return new { result = delKeyResp };
        }
        if (iXml != string.Empty)
            iXml = iXml.Replace("<root", "<root scriptpath='" + ConfigurationManager.AppSettings["ScriptsPath"].ToString() + "'");

        if (isScript)
            ires = objWebServiceExt.callRemoteDoScriptWS(iName, iXml, ires, objIview.WebServiceTimeout);
        else
            ires = objWebServiceExt.CallRemoteDoActionWS(iName, iXml, ires, objIview.WebServiceTimeout);

        if (ires != null)
            ires = ires.Split('♠')[1];
        ires = ires.Replace("'", ";quot");
        ires = ires.Replace("\\", ";bkslh");
        ires = ires.Replace("\n", "<br>");
        string result = "success";
        if (ires == string.Empty)
            result = "failure";
        if (objIview.ActBtnNavigation != null && objIview.ActBtnNavigation.ContainsKey(actName))
            return new { result = result, actResponse = ires, ActBtnNavigation = objIview.ActBtnNavigation[actName].ToLower() };
        else
            return new { result = result, actResponse = ires };

    }

    [WebMethod]
    public static string GetTstructFieldsForListView(string iName)
    {
        ASB.WebService asbWebService = new ASB.WebService();
        return asbWebService.GetTstructFieldsForListView(iName);
    }

    //modifaction done after redis logic changed
    //souvik
    public static string DeleteRedisKeys(string xml, string schemaName)
    {
        LogFile.Log logobj = new LogFile.Log();
        string selectedKeys = string.Empty;
        ArrayList redisvalues = new ArrayList();
        string pgKey = Constants.AXPAGETITLE;
        FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
        Util.Util util = new Util.Util();
        redisvalues = (ArrayList)fObj.ObjectJsonFromRedis(util.GetRedisServerkey(pgKey, ""), schemaName);
        var node = "";
        //string pgKey = Constants.AXPAGETITLE;
        //string
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            ArrayList formList = new ArrayList();
            bool delRecords = false;
            var items = "";
            string tname = "";
            //var item = "";
            //select redis keys by seperated by &
            foreach (XmlNode childNode in doc.SelectNodes("//root"))
            {
                foreach (XmlNode chdNode in doc.SelectNodes("//row"))
                {
                    node = chdNode.SelectSingleNode("TNAME").InnerText;
                    var keys = chdNode.SelectSingleNode("KEYS").InnerText;
                    selectedKeys += keys + "&";
                    // node += node + "#";

                    formList.Add(node);


                }
            }
            if (selectedKeys != string.Empty)
            {
                selectedKeys = selectedKeys.Substring(0, selectedKeys.Length - 1);
                FDW objFdw = FDW.Instance;
                string proj = string.Empty;
                //if (HttpContext.Current.Session["dbuser"] != null)
                //    proj = HttpContext.Current.Session["dbuser"].ToString();

                delRecords = objFdw.DeleteAllKeys(selectedKeys, schemaName);

            }
            if (delRecords == true && redisvalues.Count > 0)
            {
                ArrayList redisvaluesTemp = new ArrayList(redisvalues);
                foreach (var item in redisvalues)
                {
                    var id = item.ToString().Split('♠')[2];
                    tname = id.ToString();
                    foreach (var item1 in formList)
                    {
                        if (tname.IndexOf(item1.ToString()) != -1)
                        {
                            redisvaluesTemp.Remove(item);
                            break;

                            //return "success";
                        }

                    }

                }
                FDW fdwObj = FDW.Instance;
                //  Util.Util util = new Util.Util();
                fdwObj.SaveInRedisServer(util.GetRedisServerkey(pgKey, ""), redisvaluesTemp, Constants.AXPAGETITLE);
                return "success";
            }
            else return "failure";
        }
        //else
        //return "failure";

        catch (Exception ex)
        {
            logobj.CreateLog("Iview - DeleteRedisKeys -" + ex.Message + "", HttpContext.Current.Session["nsessionid"].ToString(), "openiview-dev---", string.Empty);
        }
        return "success";
    }

    // generic method for converting string to xmldocument
    //souvik
    private static XmlDocument GetElement(string xml)
    {
        XmlDocument doc1 = new XmlDocument();
        doc1.LoadXml(xml);
        return doc1;
    }


    public void GenericRedisFunction(string Title, string objIName, string structure, string schemaName)
    {

        FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
        XmlDocument xmldoc1 = new XmlDocument();
        xmldoc1.LoadXml(structure);
        XmlNode cNode = default(XmlNode);
        cNode = xmldoc1.SelectSingleNode("//iview/a2");
        string pgKey = Constants.AXPAGETITLE;
        ArrayList redisvalues = new ArrayList();
        FDW fdwObj = FDW.Instance;
        Util.Util util = new Util.Util();
        var redisvalues1 = fObj.ObjectJsonFromRedis(util.GetRedisServerkey(pgKey, ""), schemaName);
        if (redisvalues1 == null)
            redisvalues.Add(Title + "♠" + cNode.InnerText + "♠" + objIName);
        else
        {
            redisvalues = (ArrayList)redisvalues1;
            string newValue = Title + "♠" + cNode.InnerText + "♠" + objIName;
            if (!redisvalues.Contains(newValue))

                redisvalues.Add(newValue);

        }


        fdwObj.SaveInRedisServer(util.GetRedisServerkey(pgKey, objIName), redisvalues, Constants.AXPAGETITLE, HttpContext.Current.Session["dbuser"].ToString());
    }

    public void GenericRedisFunction2()
    {
        string pgKey = Constants.AXPAGETITLE;
        ArrayList redisvalues = new ArrayList();
        // List<string> redisvalues = new List<string>();
        FDW fdwObj = FDW.Instance;
        FDR fObj = (FDR)HttpContext.Current.Session["FDR"];

        var redisvalues1 = fObj.ObjectJsonFromRedis(util.GetRedisServerkey(pgKey, ""));
        if (redisvalues1 == null)
            redisvalues.Add(Title + "♠" + objIview.IviewCaption + "♠" + objIview.IName);
        else
        {
            redisvalues = (ArrayList)redisvalues1;
            //var i = 0;
            //foreach (var i in redisvalues)
            //{
            //var tstivname = i.ToString().Split('♠')[1];

            string newValue = Title + "♠" + objIview.IviewCaption + "♠" + objIview.IName;
            if (Request.QueryString["tstcaption"] == null)
            {
                if (!redisvalues.Contains(newValue))
                    //  if (redisvalues.IndexOf(newValue) > -1)

                    redisvalues.Add(newValue);
                //}
            }
        }

        fdwObj.SaveInRedisServer(util.GetRedisServerkey(pgKey, objIview.IName), redisvalues, Constants.AXPAGETITLE, schemaName);
    }

    //get redis data logic changed
    //no webservice used
    //souvik
    public XmlDocument GetRedisData()
    {
        XmlDocument doc1 = GetElement(Constants.REDISXML);
        XmlDocument doc2 = GetElement("<row TNAME =\"\" FTYPE=\"\" CAPTION=\"\" KEYSIZE=\"\" TOTALKEYS=\"\" KEYS=\"\"/>");
        XmlNode node = doc2;
        XmlNode root = doc1.DocumentElement;
        LogFile.Log logobj = new LogFile.Log();
        try
        {
            ArrayList formList = new ArrayList();
            ArrayList redisvalues = new ArrayList();
            string pgKey = Constants.AXPAGETITLE;
            FDR fdrObj = (FDR)HttpContext.Current.Session["FDR"];
            FDW fdwObj = FDW.Instance;
            bool isRedisConnected = fdwObj.IsConnected;
            if (isRedisConnected)
            {
                redisvalues = (ArrayList)fdrObj.ObjectJsonFromRedis(util.GetRedisServerkey(pgKey, ""), schemaName);
                ArrayList redisvaluesGeneral = fdrObj.GetPrefixedKeys("General", true);
                ArrayList redisKeys = new ArrayList();

                ArrayList addedKeys = new ArrayList();
                //redisvalues = (ArrayList)fdrObj.ObjectJsonFromRedis(util.GetRedisServerkey(pgKey, ""), schemaName);
                XmlElement elem = doc1.CreateElement("rowdata");
                root.InsertAfter(elem, root.LastChild);
                XmlNode rowDataNode = doc1.SelectSingleNode("//rowdata");
                StringBuilder aaa = new StringBuilder();
                aaa.Append("<row FTYPE=\"\" TNAME=\"\" CAPTION=\"\" KEYSIZE=\"\" TOTALKEYS=\"\" KEYS=\"\" /> ");
                elem.InnerText = aaa.ToString();
                foreach (var item in redisvalues)
                {
                    try
                    {
                        var type = item.ToString().Split('♠')[0];
                        var tstivname = item.ToString().Split('♠')[1];
                        var id = item.ToString().Split('♠')[2];
                        string tname = id.ToString();
                        redisKeys = fdrObj.GetPrefixedKeys(tname, true);
                        string keysData = String.Join("&amp;", (string[])redisKeys.ToArray(Type.GetType("System.String")));
                        if (redisKeys.Count > 0)
                        {
                            aaa.AppendLine(string.Format("<row FTYPE=\"{0}\" TNAME=\"{1}\"  CAPTION=\"{2}\" KEYSIZE=\"{3}\" TOTALKEYS=\"{4}\" KEYS=\"{5}\" /> ", WebUtility.HtmlEncode(type), WebUtility.HtmlEncode(tname), WebUtility.HtmlEncode(tstivname), "", redisKeys.Count, keysData));
                            elem.InnerXml = aaa.ToString();
                        }
                    }
                    catch (Exception ex) { }
                }
                //foreach (var generalitems in redisvaluesGeneral)
                //{
                //var splitter = generalitems.ToString().Split('-')[2];
                //string keysData = String.Join("&amp;", (string[])redisvaluesGeneral.ToArray(Type.GetType("System.String")));
                //aaa.AppendLine(string.Format("<row FTYPE=\"{0}\" TNAME=\"{1}\"  CAPTION=\"{2}\" KEYSIZE=\"{3}\" TOTALKEYS=\"{4}\" KEYS=\"{5}\" /> ","General", "General","General", "",1, keysData));
                //elem.InnerXml = aaa.ToString();
                //}
                if (redisvaluesGeneral.Count > 0)
                {
                    string keysData1 = String.Join("&amp;", (string[])redisvaluesGeneral.ToArray(Type.GetType("System.String")));
                    aaa.AppendLine(string.Format("<row FTYPE=\"{0}\" TNAME=\"{1}\"  CAPTION=\"{2}\" KEYSIZE=\"{3}\" TOTALKEYS=\"{4}\" KEYS=\"{5}\" /> ", "General", "General", "General", "", redisvaluesGeneral.Count, keysData1));
                }
                elem.InnerXml = aaa.ToString();
            }


        }
        catch (Exception ex)
        {
            logobj.CreateLog("Iview - GetRedisKeys -" + ex.Message + "", HttpContext.Current.Session["nsessionid"].ToString(), "openiview-dev---", string.Empty);
        }
        return doc1;
    }

    public DataTable getTempleteStringChoices(string iName)
    {
        string result = string.Empty;
        DataTable templateDT = new DataTable();
        string sqlQuery = string.Empty;

        string fdSettingsKey = Constants.RedisOldIviewTemplates;
        if (objIview.purposeString != "")
        {
            fdSettingsKey = Constants.RedisOldListviewTemplates;
        }

        try
        {

            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
            if (fObj == null)
            {
                fObj = new FDR();
                HttpContext.Current.Session["FDR"] = fObj;
            }

            result = fObj.StringFromRedis(util.GetRedisServerkey(fdSettingsKey, iName, user));
        }
        catch (Exception ex) { }

        if (result == string.Empty)
        {

            string errorLog = logobj.CreateLog("GetIviewTemplete.", Session["nsessionid"].ToString(), "GetIviewTemplete-" + iName + string.Empty, "new");

            string query = "<sqlresultset axpapp='" + Session["project"].ToString() + "' sessionid='" + Session["nsessionid"].ToString() + "' trace='" + errorLog + "' appsessionkey='" + HttpContext.Current.Session["AppSessionKey"].ToString() + "' username='" + HttpContext.Current.Session["username"].ToString() + "' ><sql>";
            sqlQuery = Constants.GET_IV_TEMPLETE.Replace(Constants.VAR_IVNAME, iName);
            sqlQuery = util.CheckSpecialChars(sqlQuery);
            query += sqlQuery + " </sql>" + Session["axApps"].ToString() + Application
                ["axProps"].ToString() + HttpContext.Current.Session["axGlobalVars"].ToString() + HttpContext.Current.Session["axUserVars"].ToString() + "</sqlresultset>";

            try
            {
                result = objWebServiceExt.CallGetChoiceWS(iName, query);
            }
            catch (Exception ex) { }
        }

        try
        {
            if (result != string.Empty || (!result.StartsWith("<error>")) || (result.Contains("error")))
            {
                DataSet ds = new DataSet();
                System.IO.StringReader sr = new System.IO.StringReader(result);
                ds.ReadXml(sr);

                if ((ds.Tables.Count > 0) && (ds.Tables["row"].Rows.Count > 0))
                {
                    templateDT = ds.Tables["row"];
                }
            }
        }
        catch (Exception ex) { }

        try
        {
            FDW fdwObj = FDW.Instance;
            fdwObj.SaveInRedisServer(util.GetRedisServerkey(fdSettingsKey, iName, user), result, fdSettingsKey, HttpContext.Current.Session["dbuser"].ToString());
        }
        catch (Exception ex) { }

        return templateDT;
    }


    public bool GetRequestType()
    {
        bool returnBool = requestJSON;
        try
        {
            string config = "";
            if (Request.QueryString["tstcaption"] != null)
            {
                config = util.GetAdvConfigs("Load Old Model Views", "tstruct", iName);
            }
            else
            {
                config = util.GetAdvConfigs("Load Old Model Views", "iview", iName);
            }
            if (config != "true")
            {
                config = "false";
            }
            returnBool = config == "false";
        }
        catch (Exception ex) { }
        //return false;
        return returnBool;
    }

    public IviewData GetStructDef(string iName, string datakey, string datasubkey, string ivKey)
    {
        IviewData returnIview = null;
        try
        {
            if (flKey == null)
            {
                flKey = GenerateGlobalSmartViewsKey(iName, Request.QueryString["tstcaption"] != null);
            }

            string fileName = "openiview-" + iName;

            string sessionID = Session["nsessionid"].ToString();
            sessionID = util.CheckSpecialChars(sessionID);

            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
            if (fObj == null)
            {
                fObj = new FDR();
                HttpContext.Current.Session["FDR"] = fObj;
            }
            logobj.CreateLog("Get IviewObj from Cache, User: " + user + " Role: " + AxRole, sessionID, fileName, "");

            returnIview = (IviewData)fObj.IviewObjFromRedis(ivKey);

            if (returnIview != null && returnIview.iviewParamsList != null && returnIview.iviewParamsList.Count > 0) {
                ArrayList keyList = returnIview.iviewParamsList;
                //ArrayList keyList = fdrObj.HashGetAllKeys(fldarrkey);
                int keyIndex = -1;

                datasubkey = MakeVarKeyName(returnIview.iviewParams.GlobalVars);
            }

            objParams = (IviewParams)fObj.HashGetParamObjFromRedis(datakey, datasubkey);

            //if (objParams == null) {
            //    objParams = returnIview.iviewParams;
            //}

            //returnIview.iviewParams = objParams;

            if (returnIview != null)
            {
                string ivupdateOn = string.Empty;

                if (returnIview.StructureXml != string.Empty && returnIview.StructureXml != "false")
                {
                    isCache = true;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(returnIview.StructureXml);
                    if (xmlDoc.DocumentElement.Attributes["updatedon"] != null)
                    {
                        ivupdateOn = xmlDoc.DocumentElement.Attributes["updatedon"].Value;
                    }
                }
                bool isStructureUpdated = ivupdateOn != string.Empty && returnIview.IsStructureUpdated(ivupdateOn, iName);
                if (!isStructureUpdated)
                {
                    returnIview.isObjFromCache = true;

                    string fdSettingsKey = Constants.RedisIviewSettings;
                    if (Request.QueryString["tstcaption"] != null)
                    {
                        fdSettingsKey = Constants.RedisListviewSettings;
                    }

                    string smartviewSettingsTemp = fObj.StringFromRedis(fObj.MakeKeyName(fdSettingsKey, iName, user));

                    if (smartviewSettingsTemp != "")
                    {
                        returnIview.smartviewSettings = smartviewSettingsTemp;
                    }

                    logobj.CreateLog("Getting IviewObj from cache " + user + " Role: " + AxRole, sessionID, fileName, "");
                }
                else
                {
                    returnIview = new IviewData();
                }
            }
            else
            {
                returnIview = new IviewData();
            }
        }
        catch (Exception ex)
        {
            returnIview = new IviewData();
        }

        if (returnIview != null && objParams == null) {
            if (returnIview.isObjFromCache) {
                returnIview.isObjFromCache = false;
            }
        }

        return returnIview;
    }

    public bool SetStructDef(string datakey, string datasubkey, string ivKey)
    {
        bool returnSuccess = false;
        try
        {
            if (!(objIview.iviewParamsList.IndexOf(datasubkey) > -1)) {
                objIview.iviewParamsList.Add(datasubkey);
            }

            if (flKey == null)
            {
                flKey = GenerateGlobalSmartViewsKey(iName, Request.QueryString["tstcaption"] != null);
            }

            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
            if (fObj == null)
            {
                fObj = new FDR();
                HttpContext.Current.Session["FDR"] = fObj;
            }

            FDW fdwObj = FDW.Instance;

            objIview.iviewParams = objParams;

            returnSuccess = fdwObj.SaveInRedisServer(ivKey, objIview, "", schemaName);
            //
            fdwObj.HashSetSaveInRedisServer(datakey, datasubkey, objParams, "", schemaName);

            string fdSettingsKey = Constants.RedisIviewSettings;
            if (Request.QueryString["tstcaption"] != null)
            {
                fdSettingsKey = Constants.RedisListviewSettings;
            }
            if (objIview.smartviewSettings != "")
            {
                fdwObj.SaveInRedisServer(fObj.MakeKeyName(fdSettingsKey, iName, user), objIview.smartviewSettings, fdSettingsKey, schemaName);
            }
        }
        catch (Exception ex) { }

        return returnSuccess;
    }

    public object GenerateGlobalSmartViewsKey(string iName, bool isListview)
    {
        string fldarrkey = string.Empty, arraySubKey = string.Empty;

        string fdObjKey = Constants.RedisIviewObj;
        if (isListview)
        {
            fdObjKey = Constants.RedisListviewObj;
        }

        string ivKey = util.GetRedisServerkey(fdObjKey, iName);

        try
        {
            int keyIndex = -1;

            string fdListKey = Constants.RedisIviewObjList;
            if (isListview)
            {
                fdListKey = Constants.RedisListviewObjList;
            }

            FDR fdrObj = (FDR)HttpContext.Current.Session["FDR"];
            if (fdrObj == null)
            {
                fdrObj = new FDR();
                HttpContext.Current.Session["FDR"] = fdrObj;
            }

            fldarrkey = fdrObj.MakeKeyName(fdListKey, iName);
            int ExistKeyind = fdrObj.GetKeyIndex(fldarrkey);
            if (ExistKeyind == 0 && objIview != null)
            {
                ArrayList keyList = objIview.iviewParamsList;
                //ArrayList keyList = fdrObj.HashGetAllKeys(fldarrkey);

                arraySubKey = MakeVarKeyName(objIview.iviewParams.GlobalVars);
            }
        }
        catch (Exception ex)
        {
            LogFile.Log logobj = new LogFile.Log();
            logobj.CreateLog("GenerateGlobalSmartViewsKey -" + ex.Message, HttpContext.Current.Session["nsessionid"].ToString(), "Exception in GenerateGlobalSmartViewsKey", "new");
        }
        return new { arrKey = fldarrkey, arraySubKey = arraySubKey, ivKey = ivKey };
    }

    public IviewData GetGlobalSmartViews(string iName, dynamic flKey)
    {
        IviewData returnIview = null;
        try
        {
            FDR fdrObj = (FDR)HttpContext.Current.Session["FDR"];
            string arrkey = flKey.GetType().GetProperty("arrKey").GetValue(flKey, null);
            string arraySubKey = flKey.GetType().GetProperty("arraySubKey").GetValue(flKey, null);
            string ivKey = flKey.GetType().GetProperty("ivKey").GetValue(flKey, null);
            if (arrkey != string.Empty)
            {
                returnIview = GetStructDef(iName, arrkey, arraySubKey, ivKey);
            }
            else
            {
                returnIview = new IviewData();
            }
        }
        catch (Exception ex)
        {
            LogFile.Log logobj = new LogFile.Log();
            logobj.CreateLog("GetGlobalSmartViews -" + ex.Message, HttpContext.Current.Session["nsessionid"].ToString(), "Exception in GetGlobalSmartViews", "new");
        }
        return returnIview;
    }

    public bool SetGlobalSmartViews(IviewData objIview, string iName, dynamic flKey)
    {
        bool returnSuccess = false;
        try
        {
            string arrkey = flKey.GetType().GetProperty("arrKey").GetValue(flKey, null);
            string arraySubKey = flKey.GetType().GetProperty("arraySubKey").GetValue(flKey, null);
            string ivKey = flKey.GetType().GetProperty("ivKey").GetValue(flKey, null);

            string stsResult = objParams.GlobalVars;

            string stsGlobal = util.ParseJSonResultNode(stsResult);
            string strflKeys = string.Empty;

            strflKeys = stsGlobal;

            FDW fdwObj = FDW.Instance;
                
            returnSuccess = SetStructDef(arrkey, strflKeys, ivKey);
        }
        catch (Exception ex)
        {
            LogFile.Log logobj = new LogFile.Log();
            logobj.CreateLog("SetGlobalSmartViews -" + ex.Message, HttpContext.Current.Session["nsessionid"].ToString(), "Exception in SetGlobalSmartViews", "new");
        }
        return returnSuccess;
    }

    public string processNotificationLoadData(string redisLoadKey, string user, string schemaName)
    {
        string returnData = string.Empty;

        try
        {
            string redisVal = string.Empty;
            FDR fObj = (FDR)HttpContext.Current.Session["FDR"];
            redisVal = fObj.ReadStringKeywithSchema(user + "-notify-" + redisLoadKey, schemaName);
            if (redisVal != string.Empty && redisVal != "redisnotconnected")
            {
                JObject redisJObject = new JObject();

                redisJObject = JObject.Parse(redisVal);

                JArray notifyArray = (JArray)redisJObject["msg"];

                JObject loadTypeNode = new JObject();

                loadTypeNode = (JObject)notifyArray.FirstOrDefault(x => x["loadtype"] != null);

                JObject sessionLoadType = JObject.Parse(Session["iview-" + iName + "-" + loadTypeNode["loadtype"].ToString()].ToString());

                redisLoadType = sessionLoadType["type"].ToString();
                //redisLoadType = "pdf";
                JObject headrow = (JObject)sessionLoadType["headrow"];

                if (headrow != null)
                {
                    objIview.headerJSON = headrow.ToString().Trim();
                }

                string paramsVal = string.Empty;

                paramsVal = sessionLoadType["params"].ToString();

                if (paramsVal != string.Empty)
                {
                    hdnparamValues.Value = paramsVal;
                }

                hdnWebServiceViewName.Value = sessionLoadType["viewName"].ToString();

                JObject cmdNode = (JObject)notifyArray.FirstOrDefault(x => x["cmd"] != null);

                string cmdVal = cmdNode["cmdval"].ToString();

                string ScriptsPath = HttpContext.Current.Application["ScriptsPath"].ToString();

                string folderPath = ScriptsPath + "Axpert\\" + Session["nsessionid"].ToString() + "\\";

                string filePath = folderPath + cmdVal;

                System.IO.FileInfo sfile = new System.IO.FileInfo(filePath);

                if (sfile.Exists)
                {
                    returnData = System.IO.File.ReadAllText(@"" + filePath);
                }
                //redisLoadType = "";
                //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
            }
        }
        catch (Exception ex) { }

        return returnData;
    }

    private JObject generateConfigurationJson(DataTable dt)
    {
        JObject returnJObject = new JObject();
        if (dt != null && (dt.Rows.Count > 0))
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Merge(dt.Copy());
                ds.DataSetName = "configurations";
                ds.Tables[0].TableName = "config";
                //if (resultData != null)
                //{
                //    resultData.Add("configurations", JObject.Parse(JsonConvert.SerializeObject(ds)));
                //}
                returnJObject = JObject.Parse(JsonConvert.SerializeObject(ds));
            }
            catch (Exception ex) { }
        }
        return returnJObject;
    }

    private string MakeVarKeyName(string result)
    {
        string returnString = string.Empty;

        var globalVars = FDR.GetGlobalVars();

        var pickData = JsonConvert.DeserializeObject<globalVar>(result.ToString());
        if (pickData != null && pickData.globalVars != null && pickData.globalVars.Count() > 0 && globalVars.Count > 0)
        {
            returnString = string.Join("♦", pickData.globalVars.Select(i =>
            {
                var filterKeys = globalVars.AsEnumerable().Where(x => x.ToLower().StartsWith(i.n.ToLower() + ":")).ToList();
                if (filterKeys.Count > 0)
                {
                    return filterKeys[0];
                }
                else {
                    return i.n + ":" + "";
                }
            }
            ));
        }

        return returnString;
    }

    private class globalVar
    {
        public List<globalVars> globalVars { get; set; }
    }

    private class globalVars
    {
        public string n { get; set; }
        public string v { get; set; }
    }
}


public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string value)
    {
        return value == null || value.All(char.IsWhiteSpace);
    }
}
