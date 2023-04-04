<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParamsTstruct.aspx.cs" Inherits="ParamsTstruct" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>ParamsTstruct</title>
    <link href="../assetsnew/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/thirdparty/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/thirdparty/jquery-ui/1.12.1/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Css/thirdparty/jquery-ui/1.12.1/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Css/thirdparty/jquery-ui/1.12.1/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="../Css/globalStyles.min.css?v=36" rel="stylesheet" />
    <script>
        if (typeof localStorage != "undefined") {
            var projUrl = top.window.location.href.toLowerCase().substring("0", top.window.location.href.indexOf("/aspx/"));
            var lsTimeStamp = localStorage["customGlobalStylesExist-" + projUrl]
            if (lsTimeStamp && lsTimeStamp != "false") {
                var appProjName = localStorage["projInfo-" + projUrl] || "";
                var customGS = "<link id=\"customGlobalStyles\" data-proj=\"" + appProjName + "\" href=\"../" + appProjName + "/customGlobalStyles.css?v=" + lsTimeStamp + "\" rel=\"stylesheet\" />";
                document.write(customGS);
            }
        }
    </script>
    <link href="../Css/msgBoxLight.min.css?v=5" rel="stylesheet" type="text/css" />
    <link href="../ThirdParty/jquery-confirm-master/jquery-confirm.min.css?v=1" rel="stylesheet" />
    <link href="../ThirdParty/DataTables-1.10.13/media/css/jquery.dataTables.min.css" rel="stylesheet" />

    <link href="../Css/GridTable.min.css?v=1" rel="stylesheet" />
    <!-- <link href="../Css/Stylesheet.min.css?v=23" rel="stylesheet" /> -->
    <link href="../Css/MergeColumn.min.css" rel="stylesheet" />
    <link href="../Css/Icons/icon.css" rel="stylesheet" />
    <link href="../AssetsNew/css/style.min.css?v=3" rel="stylesheet" />
    <%--<link href="../Css/TstructNew.min.css?v=91" rel="stylesheet" />--%>
    <link href="../Css/thirdparty/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <%--<link href="../Css/Tstruct-auto.min.css?v=22" rel="stylesheet" />--%>
    <link href="../Css/tstructNewUi.min.css?v=82" rel="stylesheet" />
    <script>
        if (typeof localStorage != "undefined") {
            var projUrl = top.window.location.href.toLowerCase().substring("0", top.window.location.href.indexOf("/aspx/"));
            var customStyleTimeStamp = localStorage["customTstructNewUiExist-" + projUrl];
            if (customStyleTimeStamp && customStyleTimeStamp != "false") {
                var appProjName = localStorage["projInfo-" + projUrl] || "";
                var customFormStyle = "<link id=\"customTstructNewUi\" data-proj=\"" + appProjName + "\" href=\"../" + appProjName + "/customTstructNewUi.css?v=" + customStyleTimeStamp + "\" rel=\"stylesheet\" />";
                document.write(customFormStyle);
            }
        }
    </script>
    <%--<link href="../App_Themes/Gray/Stylesheet.min.css?v=23" rel="stylesheet" />--%>
    <link id="themecss" type="text/css" href="" rel="stylesheet" />
    <script>
        if (!('from' in Array)) {
            // IE 11: Load Browser Polyfill
            document.write('<script src="../Js/polyfill.min.js"><\/script>');
        }
    </script>
    <script type="text/javascript" src="../Js/thirdparty/jquery/3.1.1/jquery.min.js"></script>
    <script src="../ThirdParty/DataTables-1.10.13/media/js/jquery.dataTables.min.js"></script>
    <script src="../ThirdParty/DataTables-1.10.13/media/js/dataTables.bootstrap.min.js"></script>
    <script src="../Js/jquery.browser.min.js" type="text/javascript"></script>
    <script src="../Js/printjs.min.js" type="text/javascript"></script>

    <script src="../ThirdParty/jquery-confirm-master/jquery-confirm.min.js?v=2" type="text/javascript"></script>
    <script src="../Js/noConflict.min.js?v=1" type="text/javascript"></script>

    <script type="text/javascript">
        var mode = "form";
        //////////////////////////
        //variables used for new picklist control
        var totalPLRows = 0;
        var pageSize = 10;
        var curPageNo = 1;
        var noOfPLPages = 0;
        var axpRefSelect = false;
        var axpRefSelectID = "";
        var axpSrcSelectID = "";
        var axRefreshSelectType = "";
        var isTstPop = '<%=isTstPop%>';
        var appsessionKey = '<%=appsessionKey%>';
        var firstInput;
        var lastInput;
        //variables used for storing images in folders        
        var imgNames = new Array();
        var imgSrc = new Array();
        var axInlineGridEdit = '<%=Session["AxInlineGridEdit"]%>' == 'true';
        //variables used for new picklist control
        var totalPLRows = 0;
        var pageSize = 10;
        var curPageNo = 1;
        var noOfPLPages = 0;
        var FetchPickListRows = '<%=FetchPickListRows%>';
        //variables used for storing images in folders        
        var imgNames = new Array();
        var imgSrc = new Array();
        var requestProcess_logtime = '<%=requestProcess_logtime%>';
        var serverprocesstime = '<%=serverprocesstime%>';
        var enableBackButton = false;
        var enableForwardButton = false;
    </script>
    <script src="../Js/jquery.browser.min.js" type="text/javascript"></script>
    <script src="../Js/printjs.min.js" type="text/javascript"></script>
    <script src="../ThirdParty/jquery-confirm-master/jquery-confirm.min.js?v=2" type="text/javascript"></script>
    <script src="../Js/noConflict.min.js?v=1" type="text/javascript"></script>
    <%--custom alerts start--%>
    <link href="../Css/animate.min.css" rel="stylesheet" />
    <script src="../Js/alerts.min.js?v=28" type="text/javascript"></script>
    <%--custom alerts end--%>
    <script src="../Js/jQueryUi/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/common.min.js?v=98"></script>
    <script type="text/javascript" src="../Js/ckeditor/ckeditor.js?v=1"></script>
    <script src="../Js/ckRtf.min.js?v=6" type="text/javascript"></script>
    <link href="../Css/workflowNew.min.css?v=10" rel="stylesheet" />
    <!--Links for Tab control -->
    <script type="text/javascript" src="../Js/process.min.js?v=207"></script>
    <script src="../Js/JDate.min.js?v=3" type="text/javascript"></script>
    <script src="../Js/thirdparty/bootstrap/3.3.6/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Js/thirdparty/jquery-ui/jquery-ui-autoCom/jquery-ui-autoCom.min.js?v=3"></script>
    <script src="../Js/jquery.msgBox.min.js?v=2" type="text/javascript"></script>
    <script src="../Js/jQueryUi/jquery.scrollabletab.min.js" type="text/javascript"></script>
    <script src="../Js/tstructvars.min.js?v=65" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/md5.min.js"></script>
    <script type="text/javascript" src="../Js/adjustwindow.min.js?v=1"></script>
    <script type="text/javascript" src="../Js/tstruct.min.js?v=432"></script>
    <script type="text/javascript" src="../Js/helper.min.js?v=123"></script>
    <script type="text/javascript" src="../Js/jsclient.min.js?v=52"></script>
    <script type="text/javascript" src="../Js/util.min.js?v=2"></script>
    <script src="../Js/dimmingdiv.min.js?v=2" type="text/javascript"></script>
    <script src="../Js/main-tstruct.min.js?v=268" type="text/javascript"></script>
    <script src="../Js/tstruct-pdf.min.js?v=4" type="text/javascript"></script>
    <link href="../newPopups/Remodal/remodal-default-theme.min.css?v=2" rel="stylesheet" />
    <link href="../newPopups/Remodal/remodal.min.css?v=4" rel="stylesheet" />
    <script type="text/javascript" src="../Js/newGridJS.min.js?v=171"></script>
    <script src="../newPopups/Remodal/remodal.min.js" type="text/javascript"></script>
    <link href="../newPopups/axpertPopup.min.css?v=24" rel="stylesheet" />
    <script src="../newPopups/axpertPopup.min.js?v=45" type="text/jscript"></script>
    <script src="../Js/handlebars.min.js?v=1" type="text/javascript"></script>
    <script src="../Js/autoComplete.min.js?v=73" type="text/javascript"></script>
    <script src="../Js/thirdparty/velocity.min.js" type="text/javascript"></script>
    <script src="../Js/thirdparty/velocity.ui.min.js" type="text/javascript">login.js</script>
    <script src="../Js/ParamsTstruct.min.js?v=3" type="text/javascript"></script>
    <script src="../ThirdParty/lodash.min.js"></script>
    <script src="../ThirdParty/gridstack.js-0.3.0/dist/gridstack.js?v=2"></script>
    <script src="../ThirdParty/gridstack.js-0.3.0/dist/gridstack.jQueryUI.js"></script>
    <link rel="stylesheet" href="../ThirdParty/gridstack.js-0.3.0/dist/gridstack.css?v=4" />
</head>
<body onload="ChangeDir('<%=direction%>');" class="btextDir-<%=direction%>">

    <div class="" id="dvlayout" runat="server">
        <div id="bbcrumb" runat="server"></div>
        <%=tstHeader %>
        <div id='searchBar' style="display: none">
            <div id="icons" class="right">
                <ul>
                    <%
                        if (rid != "0" && Request.QueryString["recPos"] != null && Request.QueryString["recPos"] != "" && Request.QueryString["recPos"] != "null" && Request.QueryString["recordid"] != null)
                        { %>
                    <li class="lnkPrev"><a href="javascript:void(0)" onclick="lnkPrevClick();" id="lnkPrev" class="glyphicon glyphicon-chevron-left icon-arrows-left nextPrevBtn" title="Previous"></a></li>
                    <li class="lnkNext"><a href="javascript:void(0)" onclick="lnkNextClick();" id="lnkNext" class="glyphicon glyphicon-chevron-left icon-arrows-right nextPrevBtn" title="Next"></a></li>
                    <% } %>
                    <%if (!isTstCustomHtml)
                        { %>
                    <div id="tstToolBarBtn" runat="server">
                        <div id="tstIcons" runat="server">
                            <%= toolbarBtnHtml.ToString() + designModeBtnHtml.ToString() %>
                        </div>
                        <li id="dvRefreshFromLoad" runat="server" visible="false">
                            <span>
                                <button type="submit" title="Refresh FormLoad" onclick="ResetFormLoadCache();">
                                    <i class="fa fa-refresh"></i>
                                </button>
                            </span>
                        </li>
                    </div>
                    <% }
                        else
                        {%>
                    <%= toolbarBtnHtml.ToString()%>
                    <% } %>
                </ul>
            </div>
        </div>
        <div id="designModeToolbar">
            <div id="dvToolbar" runat="server">
                <ul>
                    <li title="TStruct Design Properties">
                        <a class="toolbarIcons" href="javascript:void(0)" id="tstDsignProp" onclick="openProprtySht('tstructPS')"><i class="icon-basic-gear"></i></a>
                    </li>

                    <li title="DC Layouts" id="btnDcLayouts" runat="server">
                        <a class="toolbarIcons" href="javascript:void(0)" id="tstDesigDcLayouts" onclick="javascript:DesignFormDcLayouts();"><i class="icon icon-software-layout-4lines"></i></a>
                    </li>
                    <%-- <li title="Add field">
                        <a class="toolbarIcons" href="javascript:void(0)" id="propSheet" onclick="CheckToOpenPropSheet()"><i class="icon-arrows-circle-plus"></i></a>
                    </li>

                    <li title="Show Field">
                        <a class="toolbardiv toolbarIcons" href="javascript:void(0)" id="showTheField" onclick="javascript:showHideGridStackField('show');">
                            <i class="glyphicon icon-basic-eye"></i>
                        </a>
                    </li>
                    <li title="Hide Field">
                        <a class="toolbardiv toolbarIcons" href="javascript:void(0)" id="hideTheField" onclick="javascript:showHideGridStackField('hide');">
                            <i class="glyphicon icon-basic-eye-closed"></i>
                        </a>
                    </li>--%>
                    <li title="Reset Design">
                        <a class="toolbarIcons" href="javascript:void(0)" id="A7" onclick="javascript:ResetButtonClickedWeb();"><i class="glyphicon glyphicon-refresh icon-arrows-rotate"></i></a>
                    </li>
                    <li title="Save" id="SaveDesign" runat="server">
                        <a class="toolbarIcons" href="javascript:void(0)" id="saveDesign" onclick="javascript:SaveDesignerJSONWeb();"><i class="icon icon-arrows-circle-check"></i></a>
                    </li>
                    <li title="Publish" id="PublishDesignID" runat="server">
                        <a class="toolbarIcons" href="javascript:void(0)" id="PublishDesign" onclick="javascript:PublishDesignerJSONWeb();"><i class="icon icon-basic-upload" onclick=""></i></a>
                    </li>
                    <li title="Save" id="PublishSaveDesignID" runat="server" visible="false">
                        <a class="toolbarIcons" href="javascript:void(0)" id="PublishSaveDesign" onclick="javascript:SavePublishDesignerJSONWeb();"><i class="icon icon-arrows-circle-check" onclick=""></i></a>
                    </li>
                    <li title="Run" id="RunMode" runat="server">
                        <a class="toolbarIcons" href="javascript:void(0)" id="A8" onclick="javascript:goToRenderMode();"><i class="glyphicon glyphicon-remove-circle icon-music-play-button"></i></a>
                    </li>

                    <li title="HTML" id="btnTstHTML" runat="server">
                        <a class="toolbarIcons" href="javascript:void(0)" id="tstructHtml" onclick="javascript:customTstHtml();"><i class="icon-arrows-glide-horizontal"></i></a>
                    </li>

                    <li id="designStatus"></li>
                </ul>
            </div>
        </div>
        <div id="pagebdy" class="Pagebody" onclick="javascript:HideTaskList();">
            <div class="dvheightframe col-lg-12 col-xs-12 col-sm-12 col-md-12" id="heightframe" runat="server" style="float: none">
                <div id="divmainheader" runat="server"></div>
                <div id="formContainer">
                    <form id="form1" runat="server" enctype="multipart/form-data">
                        <div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                <Services>
                                    <asp:ServiceReference Path="../WebService.asmx" />
                                    <asp:ServiceReference Path="../CustomWebService.asmx" />
                                </Services>
                            </asp:ScriptManager>
                            <asp:UpdateProgress ID="Up1" Visible="false" runat="Server">
                                <ProgressTemplate>
                                    <span>
                                        <img src="../AxpImages/icons/loading.gif" alt="Please wait" />
                                        Please wait ...</span>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <asp:HiddenField ID="hdnDataObjId" runat="server" />
                        <asp:HiddenField ID="hdnScriptspath" runat="server" />
                        <asp:HiddenField ID="hdnAxIsPerfCode" runat="server" />
                        <asp:HiddenField ID="SaveID" runat="server" />
                        <asp:HiddenField ID="hdnDraftName" Value="false" runat="server" />
                        <asp:HiddenField ID="hdnFldAlgnProp" Value="" runat="server" />



                        <asp:HiddenField ID="PublishID" runat="server" />
                        <asp:HiddenField ID="isAxpImagePathHidden" runat="server" />
                        <asp:HiddenField ID="IsPublish" runat="server" />
                        <div id="Wrapperpropsheet">
                            <div class='col s3 card hoverable scale-transition scale-out' id='propertySheet'>
                                <div class='hpbHeaderTitle'>
                                    <span class='icon-paint-roller'></span>
                                    <span class='title'>Property Sheet</span>
                                    <button title='Close' type='button' id='propertySrchCls' onclick='closeProprtySht();' class='btn-flat waves-effect btn-floating pull-right'><i class='icon-arrows-remove'></i></button>
                                    <button title='Save' type='button' onclick='updateField();' id='updateWidget' class='btn-flat waves-effect btn-floating pull-right '><span class='icon-arrows-check'></span></button>
                                    <div class='clear'></div>
                                </div>
                                <div id='propertySheetDataWrapper'>
                                    <div class='clear'></div>
                                    <div id='propertySearch'>
                                        <input placeholder='Search...' type='text' id='propertySearchFld' class='normalFld searchFld'>
                                        <span class='srchIcn icon-magnifier'></span>
                                    </div>
                                    <div class='posr' id='propTableContent'>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="addFieldPsWrapper">
                            <table id="addFieldPS" class='bordered' data-parent="addFieldPsWrapper" data-title="Add Field">
                                <tr>
                                    <td class='subHeading' colspan='2'>General <span data-target='general' class='propShtDataToggleIcon icon-arrows-down'></span></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Name<sup>*</sup></td>
                                    <td>
                                        <input id='fldName' class='form-control' type='text'></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Caption<sup>*</sup></td>
                                    <td>
                                        <input id='fldCaption' class='form-control' type='text'></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Data Type</td>
                                    <td>
                                        <select onchange='moeChanger(this)' class='form-control' id='seldataType'>
                                            <option>Character</option>
                                            <option>Numeric</option>
                                            <option>Date/Time</option>
                                            <option>Image</option>
                                            <option>Text</option>
                                        </select></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>DC</td>
                                    <td>
                                        <select runat='server' class='form-control' id='seldc'></select></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Mode of entry</td>
                                    <td>
                                        <select class='form-control' id='selmoe'>
                                            <option value='Accept'>Accept</option>
                                            <option value='Select'>Select</option>
                                        </select></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Width</td>
                                    <td>
                                        <input class='form-control' maxlength='4' id='fldWidth' value='10' type='text'></td>
                                </tr>
                                <tr class='decimalFld notSearchable' data-group='general'>
                                    <td>Decimal</td>
                                    <td>
                                        <input id='fldDecimal' maxlength='2' class='form-control' value='0' type='text'>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Visible</td>
                                    <td>
                                        <select class='form-control' id='selvisible'>
                                            <option value='T'>Yes</option>
                                            <option value='F'>No</option>

                                        </select></td>
                                </tr>
                                <tr>
                                    <td class='subHeading' colspan='2'>Appearance <span data-target='appr' class='propShtDataToggleIcon icon-arrows-down'></span></td>
                                </tr>
                                <tr data-group='appr'>
                                    <td>Normalized</td>
                                    <td>
                                        <select class='form-control' id='selNormalized'>
                                            <option value='F'>No</option>
                                            <option value='T'>Yes</option>
                                        </select>

                                    </td>
                                </tr>
                                <tr data-group='appr'>
                                    <td>Read Only</td>
                                    <td>
                                        <select id='fldReadOnly' class='form-control'>
                                            <option value='F'>No</option>
                                            <option value='T'>Yes</option>
                                        </select></td>
                                </tr>
                                <tr>
                                    <td class='subHeading' colspan='2'>Source <span data-target='src' class='propShtDataToggleIcon icon-arrows-down'></span></td>

                                </tr>
                                <tr data-group='src'>
                                    <td>SQL</td>
                                    <td>
                                        <input onfocus='createSqlWindow()' id='sqlSource' class='form-control' type='text'></td>
                                </tr>
                                <tr>
                                    <td class='subHeading' colspan='2'>Validation <span data-target='valid' class='propShtDataToggleIcon icon-arrows-down'></span></td>
                                </tr>
                                <tr data-group='valid'>
                                    <td>Allow Empty</td>
                                    <td>
                                        <select id='selAlwEmpty' class='form-control'>
                                            <option value='T'>Yes</option>
                                            <option value='F'>No</option>
                                        </select></td>
                                </tr>
                                <tr data-group='valid'>
                                    <td>Allow Duplicate</td>
                                    <td>
                                        <select id='selAlwDup' class='form-control'>
                                            <option value='T'>Yes</option>
                                            <option value='F'>No</option>

                                        </select></td>
                                </tr>
                            </table>
                        </div>

                        <div id="tstructPsWrapper">
                            <table id="tstructPS" class='bordered' data-parent="tstructPsWrapper" data-title="TStruct Design Properties" data-save="false">
                                <tr>
                                    <td class='subHeading' colspan='2'>Tstruct <span data-target='general' class='propShtDataToggleIcon icon-arrows-down'></span></td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Compress Mode<sup>*</sup></td>
                                    <td>
                                        <div class="switch" onclick="toggleCompressedMode('s')">
                                            <a href="javascript:void(0)" class="swtchDummyAnchr">
                                                <input class="tgl tgl-ios" name="optDirectDb" id="ckbCompressedMode" type="checkbox">
                                                <label class="tgl-btn togglecustom toggle_btn" for="ckbCompressedMode" id="lblckbCompressedMode"></label>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Static Run Mode<sup>*</sup></td>
                                    <td>
                                        <div class="switch" onclick="toggleStaticRunMode()">
                                            <a href="javascript:void(0)" class="swtchDummyAnchr">
                                                <input class="tgl tgl-ios" name="optDirectDb" id="ckbStaticRunMode" type="checkbox">
                                                <label class="tgl-btn togglecustom toggle_btn" for="ckbStaticRunMode" id="lblckbStaticRunMode"></label>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Wizard DC<sup>*</sup></td>
                                    <td>
                                        <div class="switch" onclick="toggleWizardDCOption()">
                                            <a href="javascript:void(0)" class="swtchDummyAnchr">
                                                <input class="tgl tgl-ios" name="optDirectDb" id="ckbWizardDC" type="checkbox">
                                                <label class="tgl-btn togglecustom toggle_btn" for="ckbWizardDC" id="lblckbWizardDC"></label>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Layout<sup>*</sup></td>
                                    <td>
                                        <select id="designLayoutSelector" class="form-control">
                                            <option value="default">Default</option>
                                            <option value="tabbed">Tabbed</option>
                                            <!--<option value="tile">Tile</option>-->
                                            <option value="double">Header-Tabbed-Footer</option>
                                            <option value="single">Header-Tabbed</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Font Size<sup>*</sup></td>
                                    <td>
                                        <label for="designForntSizeSelector" style="font-weight: 400;">
                                            Font-Size (px):
                                            <output id="designForntSizeValue" style="display: inline-block; font-weight: 500;">0</output></label>
                                        <input type="range" max="30" min="14" step="2" class="form-range" id="designForntSizeSelector" oninput="designForntSizeValue.value = this.value" />
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Control Height <sup>*</sup></td>
                                    <td>
                                        <label for="designControlHeightSelector" style="font-weight: 400;">
                                            Control Height (px):
                                            <output id="designControlHeightValue" style="display: inline-block; font-weight: 500;">0</output></label>
                                        <input type="range" max="32" min="24" step="2" class="form-range" id="designControlHeightSelector" oninput="designControlHeightValue.value = this.value" />
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Form Width <sup>*</sup></td>
                                    <td>
                                        <label for="designFormWidthSelector" style="font-weight: 400;">
                                            Form Width (%):
                                            <output id="designFormWidthValue" style="display: inline-block; font-weight: 500;">0</output></label>
                                        <input type="range" max="100" min="50" step="10" class="form-range" id="designFormWidthSelector" oninput="designFormWidthValue.value = this.value" />
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Form Alignment: <sup>*</sup></td>
                                    <td>
                                        <select id="designFormAlignmentSelector" class="form-control" data-no-clear="true">
                                            <option value="default">Default</option>
                                            <option value="center">Center</option>
                                            <option value="right">Right</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr data-group='general'>
                                    <td>Field Caption Width <sup>*</sup></td>
                                    <td>
                                        <label for="designFieldCaptionWidthSelector" style="font-weight: 400;">
                                            Caption Width (%):
                                            <output id="designFieldCaptionWidthValue" style="display: inline-block; font-weight: 500;">0</output></label>
                                        <input type="range" max="50" min="10" step="10" class="form-range" id="designFieldCaptionWidthSelector" oninput="designFieldCaptionWidthValue.value = this.value" />
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <%--div to be shown as search dialog--%>
                        <div id="searchFields" style="display: none;">
                            <input type="text" id="srchDynamicText" class="AxSearchField" onkeyup="FindTstructString(this.value);" />&nbsp;&nbsp;&nbsp;&nbsp;<label id="searchResCount"></label>
                            <button type="button" id="SearchPrevBtn" onclick="MovePrev();" class="icon-arrows-up"></button>
                            <button type="button" id="SearchNextBtn" onclick="MoveNext();" class="icon-arrows-down"></button>
                            <button type="button" onclick="UnSelectSearchItem('close');" class="icon-arrows-remove"></button>
                        </div>
                        <%--div to be shown as search dialog On Multi Select--%>
                        <div id="srchMulSelFlds" style="display: none;">
                            <input type="text" id="srchMulSelDynTxt" class="AxSearchField" onkeyup="FndMulSelStr(this.value);" />&nbsp;&nbsp;&nbsp;&nbsp;<label
                                id="srchMulSelResCnt"></label>
                        </div>



                        <div>
                            <div id="searchoverrelay" class="panel panel-primary " style="display: none; margin-top: 5px;">
                                <div class="panel-heading">
                                    <h4>
                                        <asp:Label ID="lblheadsrch" runat="server" meta:resourcekey="lblheadsrch">Search</asp:Label><a class="pull-right" href="javascript:Closediv();"><span class="glyphicon glyphicon-remove icon-arrows-remove"></span></a></h4>

                                </div>

                                <div class="panel-body">


                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <p>

                                                <asp:DropDownList ID="ddlSearch" CssClass="combotem Family form-control nm" runat="server">
                                                </asp:DropDownList>

                                                <% if (langauge == "ARABIC")
                                                    {%>
                                                <asp:Label ID="lblsrch" runat="server" meta:resourcekey="lblsrch" class="col-lg-3 col-xs-12">
                                                    Search For
                                                </asp:Label>
                                                <% }
                                                    else
                                                    { %>
                                                <asp:Label ID="lblwth" runat="server" meta:resourcekey="lblwth">
                                                    With
                                                </asp:Label>
                                                <%} %>

                                                <asp:TextBox ID="searstr" CssClass="tem Family form-control" runat="server" value=""></asp:TextBox>
                                                <asp:HiddenField ID="goval" runat="server" Value=""></asp:HiddenField>

                                                <input id="Button1" class="hotbtn btn" type="button" name="go" value="Go" runat="server" onclick="javascript: valid_submit(); setDocht();" />

                                                <div class="buttgo hide">
                                                    &nbsp;<asp:Button CssClass="searchHeadbar" ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                                                    <asp:HiddenField ID="hdnHtml" runat="server" Value=""></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnFilename" runat="server" Value=""></asp:HiddenField>
                                                    <asp:Button CssClass="searchHeadbar" ID="btnHtml" runat="server" OnClick="btnHtml_Click" />
                                                    <asp:HiddenField ID="hdnSearchStr" runat="server" Value=""></asp:HiddenField>

                                                </div>

                                                <p>
                                                </p>
                                                <div id="srchcontent" runat="server">
                                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
                                                        <asp:GridView CellSpacing="-1" ID="grdSearchRes" runat="server" AllowSorting="false"
                                                            AutoGenerateColumns="false" CellPadding="2" CssClass="gridData customSetupTableMN table"
                                                            GridLines="Vertical" OnPageIndexChanging="grdSearchRes_PageIndexChanging"
                                                            OnRowDataBound="grdSearchRes_RowDataBound" PageSize="10" RowStyle-Wrap="false">
                                                            <HeaderStyle CssClass="Gridview" ForeColor="#000000" />
                                                            <AlternatingRowStyle CssClass="GridAltPage" />
                                                        </asp:GridView>
                                                        &nbsp;&nbsp;&nbsp;<asp:Label ID="records" runat="server" Text=""></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="pgCap" runat="server" CssClass="seartotrecords" Text="Page No."
                                Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="lvPage" runat="server" AutoPostBack="true"
                                                            onchange="javascript:Pagination();" Visible="false" Width="40px">
                                                        </asp:DropDownList>
                                                        <asp:Label ID="pages" Text="" runat="server" CssClass="totrec"></asp:Label>
                                                    </asp:Panel>
                                                </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div id="progressArea" class="Family loadingTheDataPW">
                                                <asp:Label ID="lbldataload" runat="server" meta:resourcekey="lbldataload">
                                Loading the data, please wait...</asp:Label>
                                                <asp:Image ID="LoadingImage" runat="server" AlternateText="Load Image" ImageUrl="../AxpImages/icons/loading.gif" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>



                            </div>
                        </div>
                        <div class="pdfOverlay">
                            <div id="dvPDFDocList" class="panel" style="display: none;">
                                <div class="panel-heading">
                                    <h4>
                                        <asp:Label ID="lblpdfdoc" runat="server" meta:resourcekey="lblpdfdoc">PDF Documents</asp:Label><a class="pull-right" href="javascript:ClosePdfDiv();">
                                            <span class="glyphicon glyphicon-remove-circle icon-arrows-circle-remove"></span></a></h4>
                                </div>
                                <div class="panel-body">

                                    <div id="UpdatePanel2">
                                        <div id="dvPdfDDl">
                                        </div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value=""></asp:HiddenField>
                                        <input id="btnPDF" type="button" class="btn-default" name="print" value="Print" runat="server" onclick="javascript: CallPDFws();" />
                                        <input id="btnCancelPdf" type="button" class="btn-default" name="cancelpdf" value="Cancel" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div runat="server" class="success hide" id="dvMessage">
                        </div>
                        <div id="workflowoverlay" runat="server" class="overlay" style="display: none;">

                            <div class="hide">
                                <p class="left">
                                    <asp:TextBox ID="txtCommentWF" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                </p>
                                <p class="left workflow-buttons">
                                    <input type="button" id="btntabapprove" onclick="CheckFields(this);" value="Approve" class="hotbtn btn" />
                                    <input type="button" id="btntabreject" onclick="CheckFields(this);" value="Reject" class="coldbtn btn" />
                                    <input type="button" id="btntabreview" onclick="CheckFields(this);" value="Approve & Forward" class="hotbtn btn" />
                                    <input type="button" id="btntabreturn" onclick="CheckFields(this);" value="Return" class="coldbtn btn" />
                                    <input type="button" id="btntabcomments" onclick="javascript: ViewComments();" value="View comments" class="coldbtn btn" />
                                </p>
                                <div class="clear">
                                </div>
                                <div class="wfsuccess">
                                    <asp:Label ID="lblStatus" runat="server" class="wkfText" Text="Reviewed by"></asp:Label>
                                    <asp:HiddenField runat="server" ID="hdnWfLno" />
                                    <asp:HiddenField runat="server" ID="hdnWfELno" />
                                </div>

                            </div>

                            <%--New Workflow UI--%>
                            <div id="main">
                                <div class="">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 maincls">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 wrkflw-col-sm-12">
                                                <div id="stratWrkf" class="ApprovalBar workflowdisplayinline" data-content="Open" data-placement="bottom">
                                                </div>

                                                <!--Your Select -->
                                                <div class="dropbox">
                                                    <div class="wfselectbox hide">
                                                        <ul class="" id="selectbox">
                                                        </ul>
                                                    </div>


                                                    <div id="consumergoods2" class="modal" data-easein="expandIn" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-dismiss="modal" data-target="#consumergoods2" data-backdrop="static">
                                                        <div class=" consumergoodsworkflow modal-dialog">
                                                            <div class="consumergoodsworkflow modal-content">
                                                                <div class=" consumergoodsworkflow modal-header">
                                                                    <button type="button" onclick="resetActions()" class="close" data-toggle="popoverone" data-dismiss="modal" data-trigger="hover" data-content="close" data-placement="bottom" aria-hidden="true">x</button>
                                                                    <h4 class=" consumergoodsworkflow modal-title">
                                                                        <asp:Label ID="lblcomments" runat="server" meta:resourcekey="lblcomments">Comments</asp:Label><span id="commentimp" class="impStar">*</span></h4>
                                                                </div>
                                                                <div class=" consumergoodsworkflow modal-body">
                                                                    <div class="form-group">
                                                                        <asp:TextBox TextMode="multiline" Rows="5" ID="comment" placeholder="Comments" MaxLength="4000" runat="server" CssClass="form-control" autocomplete="off" onkeyup="LimtCharacters(this,250,'message');" />
                                                                        <asp:Label runat="server" ID="message" ClientIDMode="Static" AssociatedControlID="comment"></asp:Label>
                                                                        <p id="lblreject" class="customErrorMessage"></p>

                                                                        <div class="consumergoodsworkflow panel-group" id="accordion">
                                                                            <div class=" consumergoodsworkflow panel panel-default">
                                                                                <div class="consumergoodsworkflow panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a class="accordion-toggle" data-toggle="collapse" id="togglearrow" data-parent="#accordion" href="#collapseOne" aria-expanded="false"></a>
                                                                                        <p class="commbox">
                                                                                            <asp:Label ID="lblcomment1" runat="server" meta:resourcekey="lblcomment1">Comments</asp:Label>
                                                                                        </p>
                                                                                    </h4>
                                                                                </div>
                                                                                <div id="collapseOne" class="panel-collapse collapse" aria-expanded="false">
                                                                                    <div id="collapseOneTable" class="consumergoodsworkflow panel-body">
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="consumergoodsworkflow modal-footer">
                                                                    <button type="button" class="btn btn-primary hotbtndynamic" onclick="clickOnWrkBtn()" id="btnWrfSave" data-trigger="hover" data-placement="bottom" aria-hidden="true" title="Save">OK </button>
                                                                    <button type="button" class="btn btn-default coldbtndynamic" data-dismiss="modal" aria-hidden="true" onclick="resetActions()" id="btnWrfCancel" data-placement="bottom" title="Cancel">Cancel</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="consumergoods" class="modal" data-easein="expandIn" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-dismiss="modal" data-target="#consumergoods2" data-backdrop="static">
                                                        <div class=" consumergoodsmodal modal-dialog">
                                                            <div class=" consumergoodsworkflow modal-content">
                                                                <div class="consumergoodsworkflow modal-header">
                                                                    <button type="button" class="close" data-toggle="popoverone" data-dismiss="modal" data-trigger="hover" data-content="close" data-placement="bottom" aria-hidden="true">x</button>
                                                                    <h4 class="consumergoodsworkflow modal-title">
                                                                        <asp:Label ID="lblcomment2" runat="server" meta:resourcekey="lblcomment2">History</asp:Label></h4>
                                                                </div>
                                                                <div class="consumergoodsworkflow modal-body">
                                                                    <div id="tblWrk" class="form-group">
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="icobtn workflowdisplayinline">
                                                    <asp:Label ID="btnViewCommts" runat="server" class="commentbtn" data-toggle="popoverone" data-target="#consumergoods" type="button" onclick="getComntWf()" data-trigger="hover" data-content="View History" data-placement="bottom"><i class="icon-basic-message-multiple"></i></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--End New Workflow UI--%>
                        </div>
                        <div id="file" class="hide" style="display: none;">
                            <table class="tblfile">
                                <tr>
                                    <td class="rowbor">
                                        <asp:Label ID="LabelFs" runat="server" meta:resourcekey="LabelFs" Font-Bold="True" ForeColor="#1e90ff">File Name:</asp:Label>
                                        <input id="filMyFile" accept="text/html" type="file" />
                                        <input type="button" onclick="javascript: CallAfterFileUploadAction();" id="cafterfload"
                                            name="cafterfload" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="rowbor">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="1" Visible="true" BorderStyle="None"
                                            ForeColor="white" BackColor="white"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div style="display: none;">
                                <input type="hidden" id="attachfname" />
                                <input type="button" onclick="javascript: callAfterFileAttach();" id="afterfattach"
                                    name="afterfattach" />
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnScriptsUrlpath" runat="server" />
                        <asp:HiddenField ID="hdnShowAutoGenFldValue" runat="server" />
                        <asp:HiddenField ID="HdnAxAdvPickSearch" runat="server" Value="false" />
                        <asp:HiddenField ID="designHidden" runat="server" />
                        <div id="CustomDiv" runat="server" class="hide">
                        </div>
                        <div id="dvFormatDc" runat="server" class="hide">
                        </div>
                        <asp:HiddenField ID="hdnCompMode" runat="server" Value="false" />
                        <asp:Label ID="lblTaskBtn" runat="server" meta:resourcekey="lblTaskBtn" Style="display: none">Tasks</asp:Label>
                        <asp:HiddenField ID="hdnTabHtml" runat="server" />
                    </form>
                </div>

                <div id="wBdr" class="tstructcontent " runat="server">
                </div>
                <div id="dvPickList" class="randomDivPl pickLstResultWrapper ">
                    <div class="pickLstResultCntnr">
                        <div class="pickLstCloseBtn">
                        </div>
                        <div class="clear"></div>
                        <div id="dvPickHead">
                        </div>
                        <div class="clear"></div>
                        <div id="dvPickFooter" class="pickListFooter">
                            <div class="pickListFLP">
                                <button type="button" id="advancebtn" onclick="javascript:CallSearchOpen();">Advance search<span id="advancesrch" class="glyphicon glyphicon-search icon-basic-magnifier"></span></button>
                            </div>
                            <div class="pickListFRP">
                                <button type="button" id="prevPick" title="previous" class="previousPickList curHand" onclick="javascript:GetData('prev')"><i class="glyphicon glyphicon-arrow-left icon-arrows-left"></i></button>
                                <button type="button" id="nextPick" onclick="javascript:GetData('next');" title="next" class="nextPickList curHand"><i class="glyphicon glyphicon-menu-right icon-arrows-right"></i><i class="glyphicon glyphicon-menu-right"></i></button>

                            </div>
                            <div class="clear"></div>
                        </div>
                        <input type='hidden' id='hdnPickFldId' /><input type="hidden" id="hdnFiltered" />
                        <div id="pickDimmer">
                        </div>
                    </div>
                </div>
                <div id="tstDatePicker"></div>
            </div>
            <div class="btnAxCustomParents" style="display: none">
                <input type="button" value="CustomBtn" visible="false" id="btnAxCuxtom" onclick="javascript: CallAxCustomBtnFunction();" />
            </div>
            <input type="hidden" id="hdnActionName" />
            <asp:Label ID="lblNodata" runat="server" meta:resourcekey="lblNodata" Visible="false">No data found.</asp:Label>


            <div id="dvCustToolbar" class="">
            </div>

            <div class="subres" style="display: none">
                <%=tstJsArrays.ToString() %>
                <%=tstVars.ToString()%>
                <%=tstTabScript.ToString()%>
                <%=tstScript.ToString()%>
                <%=enableBackForwButton%>
                <%=tstDraftsScript.ToString()%>
            </div>
            <div id="dvTip" class="randomDiv hide">
                <div class="tooltipBg Family">
                    <span class="closebtn"><a title="Close"
                        onclick="javascript:HideTooltip();">X</a></span>
                    <div id="dvInnerTip">
                    </div>
                </div>
            </div>
            <!--The below div is used to display the picklist dropdown -->

            <div id="dvFillGrid" style="">
            </div>
            <div id="dvPrintDoc" class="hide">
            </div>
            <div id="divCustomAct" runat="server" visible="false" class="wBdr">
                <div id="divActHeader" class="dcHeaderBar">
                    <a href='javascript:ShowAndHideActDiv("divActBody");'><span
                        id="dcButspan3">
                        <img id="imgAct" alt="show" src="../AxpImages/icons/16x16/expandwt.png;"></span></a>
                    <div class="frameCap">
                        <asp:Label ID="lblactivity" runat="server" meta:resourcekey="lblactivity">Recent activities</asp:Label>
                    </div>
                </div>
                <div id="divActBody">
                    <div id="divActContent">
                    </div>
                </div>
            </div>
            <div id="dvFooter" runat="server">
                <%=dvFooterHtml %>
            </div>
        </div>
    </div>
    <div id="reloaddiv">
        <span class="AVerror">Server is unable to process your request. Please retry...</span>
    </div>
</body>
</html>
