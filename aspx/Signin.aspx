<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin" %>

<%@ OutputCache Duration="1" Location="None" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="description" content="Axpert Sign in" />
    <meta name="keywords" content="Agile Cloud, Axpert,HMS,BIZAPP,ERP" />
    <meta name="author" content="Agile Labs" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>
        <%=appTitle%></title>
    <%--<link href="../UI/axpertUI/plugins.bundle.css?v=2" rel="stylesheet" type="text/css" />
    <link href="../UI/axpertUI/style.bundle.css?v=5" rel="stylesheet" type="text/css" />--%>
   
    <asp:PlaceHolder runat="server">
        <%:Styles.Render(direction == "ltr" ? "~/UI/axpertUI/ltrBundleCss" : "~/UI/axpertUI/rtlBundleCss") %>
    </asp:PlaceHolder>

    <!-- <link rel="canonical" href="Https://preview.keenthemes.com/-free" /> -->
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
    <%--<link href="../Css/thirdparty/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet" />--%>
   <%-- <link href="../Css/thirdparty/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" />--%>
    <link href="../ThirdParty/jquery-confirm-master/jquery-confirm.min.css?v=1" rel="stylesheet" />
    <%--<link href="../Css/thirdparty/jquery-ui/1.12.1/jquery-ui.min.css" rel="stylesheet" />--%>
    <%--<link href="../Css/login.min.css?v=23" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../Css/globalStyles.min.css?v=36" rel="stylesheet" />--%>
    <%--<linkk href=<%="'../CustomPages/customGlobalStyles.css?v="+ DateTime.Now.ToString("yyyyMMddhhmmss") +"'"%> rel="stylesheet" />--%>
    <script>
        if (typeof localStorage != "undefined") {
            var customGS = "<link id=\"customGlobalStyles\" data-proj=\"\" href=\"\" rel=\"stylesheet\" />";
            document.write(customGS);
        }
    </script>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta http-equiv="EXPIRES" content="0" />
    <link href="../Css/Icons/icon.css" rel="stylesheet" />
    <script>
        if (!('from' in Array)) {
            document.write('<script src="../Js/polyfill.min.js"><\/script>');
        }
    </script>
   <%-- <script src="../Js/thirdparty/jquery/3.1.1/jquery.min.js" type="text/javascript"></script>--%>
    <%--<script src="../UI/axpertUI/plugins.bundle.js?v=1"></script>
	<script src="../UI/axpertUI/scripts.bundle.js?v=3"></script>--%>
    <asp:PlaceHolder runat="server">
        <%:Scripts.Render("~/UI/axpertUI/bundleJs") %>
    </asp:PlaceHolder>
    <script src="../Js/jquery.browser.min.js" type="text/javascript"></script>
    <script src="../Js/noConflict.min.js?v=1" type="text/javascript"></script>
   <%-- <script src="../ThirdParty/jquery-confirm-master/jquery-confirm.min.js?v=2" type="text/javascript"></script>--%>
   <%-- <link href="../Css/animate.min.css" rel="stylesheet" />--%>
    
    <script src="../Js/alerts.min.js?v=28" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/login.min.js?v=66"></script>
   <%-- <link href="../ThirdParty/Linearicons/Font/library/linearIcons.css" rel="stylesheet" />--%>
    <script type="text/javascript" src="../Js/lang/content-<%=langType%>.js?v=51"></script>
    <script src="../Js/common.min.js?v=98" type="text/javascript"></script>
    <script type="text/javascript">
        history.go(1);
        var cdt = new Date();
        let bst = cdt.getDate() + "-" + (cdt.getMonth() + 1) + "-" + cdt.getFullYear() + " " + cdt.getHours() + ":" + cdt.getMinutes() + ":" + cdt.getSeconds() + "." + cdt.getMilliseconds();
        let appTUrl = top.window.location.href.toLowerCase().substring("0", top.window.location.href.indexOf("/aspx/"));
        var ispost = '<%=isPostback%>';
        if (ispost == "false")
            localStorage.setItem("BST-" + appTUrl, bst);
        var gllangType = '<%=langType%>';
        var isUserLang = '<%=isUserLang%>';
        var isPowerBy = '<%=isPowerBy%>';
        var diFileInfo = '<%=strFileinfo%>';
        var hybridGUID = '<%=hybridGUID%>';
        var hybridDeviceId = '<%=hybridDeviceId%>';
        var keepMeAutoLogin = '<%=KeepMeAutoLogin%>';
        var keepMeAutoPwd = '<%=KeepMeAutoPwd%>';
        var KeepMeAutoLoginWeb = '<%=KeepMeAutoLoginWeb%>';
        var isMobile = isMobileDevice();
        var isOfficeSSO = '<%=isOfficeSSO%>';
        var oktaclientKey = '<%=oktaclientKey%>';
        var oktadomain = '<%=oktadomain%>';
        var office365clientKey = '<%=office365clientKey%>';
        var ssoredirecturl = '<%=ssoredirecturl%>';
       
    </script>

    <script src="../Js/sso.min.js?v=2" type="text/javascript"></script>
    <script src="../Js/msal.min.js" type="text/javascript"></script>
    <script src="../Js/okta-auth-js.min.js" type="text/javascript"></script>

    <noscript>
        <div>
            JavaScript is turned off in your web browser. Turn it on to take full advantage
            of this site, then refresh the page.
        </div>
    </noscript>

</head>
<body class="page-header-fixed login" id="main_body" runat="server" dir="<%=direction%>">
    <video id="bgvid" runat="server" playsinline="" autoplay="" muted="" loop="" class="d-none">
        <source src="" type="video/mp4" id="bgvidsource" runat="server" />
    </video>
    <form name="form2" method="post" action="mainnew.aspx" id="form2" defaultfocus="uname" class="form-vertical login-form" novalidate>
        <div>
            <%=strParams.ToString() %>
        </div>
    </form>
    <div class="row-fluid login-main card login-inner w-lg-500px m-auto">
        <div class="center-view">
            <div class="page-loader-wrapper" style="display: none">
                <div class="loader">
                    <div class="preloader">
                        <div class="spinner-layer pl-blue-grey">
                            <div class="circle-clipper left">
                                <div class="circle"></div>
                            </div>
                            <div class="circle-clipper right">
                                <div class="circle"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="center-view">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        <Services>
                            <asp:ServiceReference Path="../WebService.asmx" />
                            <asp:ServiceReference Path="../CustomWebService.asmx" />
                        </Services>
                    </asp:ScriptManager>
                    <div id="SigninTemplate" class="position-fixed top-0 start-0 vw-100 vh-100 overflow-auto" runat="server">
                        <asp:Literal ID="LandPageTemplate" runat="server" Text=""></asp:Literal>
                    </div>

                    <asp:Panel runat="server" ID="panelSignin">
                        <div class="login-wrapper" runat="server" id="divPanelSignin" style="display: none">
                            <%--<div class="card login-inner w-lg-500px m-auto">--%>
                                <div class="w-lg-500px p-8 p-lg-12 mx-auto">
                                <div class="text-center mb-8">
                                <div class="form-title">
                                   
                                    <img class="mb-2" src="assets/media/axpert/loginlogo.png" loading="lazy" />
                                    <div><asp:Label ID="lblSignin" class="form-label fs-1 fw-bolder text-dark" runat="server" meta:resourcekey="lblSignin">Sign In</asp:Label>
                                        </div>
                                </div>
                                    </div>
                                <div class="control-group" id="selectProj" runat="server">
                                     <div class= "fv-row mb-8 fv-plugins-icon-container">
                                        <%--<div class="input-icon left">--%>
                                         <div class="d-flex flex-stack">
                                            <asp:Label ID="lblslctproj"  class="form-label fs-6 fw-bolder text-dark" runat="server" meta:resourcekey="lblslctproj">Select Project
                            </asp:Label>
                                             </div>
														<!-- <input class="form-control" value="" /> -->
														<select class="form-select form-select-solid m-wrap placeholder-no-fix"  runat="server" data-control="select2" data-placeholder="Select Project" data-allow-clear="true" data-select2-id="select2-data-11-3n80" aria-hidden="true" onblur="GetProjLang();" id='axSelectProj' name="axSelectProj" tabindex="2">
														</select>
													</div>
                                         <%--</div>--%>
                                    </div>
                                <%--<div class="control-group" id="selectProj" runat="server">
                                    <div class="controls field-wrapper">
                                        <div class="input-icon left">
                                            <input runat="server" type='text' value='' onblur="GetProjLang();" id='axSelectProj' name="axSelectProj" title="Select Project" tabindex='2' data-placeholder="Select an option" class='form-select select2-hidden-accessible' required />
                                            <div class="field-placeholder">
                                                <asp:Label ID="lblslctproj" runat="server" meta:resourcekey="lblslctproj">
                            Select Project</asp:Label>
                                            </div>
                                            <i class="icon-cross" title="Clear" onclick="$('#axSelectProj').val('').focus();"></i>
                                            <i class="icon-chevron-down autoClickddl" title="Select Project" onclick="$('#axSelectProj').autocomplete('search','').focus();"></i>
                                        </div>
                                    </div>
                                </div>--%>
                             <%--    <div class="fv-row mb-8 fv-plugins-icon-container">
                        <!--begin::Label-->
                        <label class="form-label fs-6 fw-bolder text-dark">User Name</label>
                        <!--end::Label-->
                        <!--begin::Input-->
                        <input class="form-control form-control-lg form-control-solid" id="axUserName" type="text" name="email" autocomplete="off">
                        <!--end::Input-->
                        <div class="fv-plugins-message-container invalid-feedback"></div>
                                     </div>--%>
                                <%--<div class="fv-row mb-8 fv-plugins-icon-container">--%>
                                <div class="control-group">
                                    <div class= "fv-row mb-8 fv-plugins-icon-container">
                                        <%--<div class="input-icon left">--%>
                                            <div class="d-flex flex-stack">
                                            <asp:Label ID="lblusername"  class="form-label fs-6 fw-bolder text-dark" runat="server" meta:resourcekey="lblusername">
                            User Name</asp:Label>
                                                </div>
                                            <input class="m-wrap placeholder-no-fix form-control form-control-solid" id="axUserName" tabindex="3" runat="server" type="text"
                                                autocomplete="off" placeholder="" name="axUserName" title="Username" required >
                                            <%--<div class="field-placeholder">--%>
                                                
                                            <%--</div>--%>
                                        
                                    </div>
                                </div>
                                    <div class="fv-plugins-message-container invalid-feedback"></div>
                                    <%--</div>--%>
                  <%--                     <div class="fv-row mb-4 fv-plugins-icon-container">
                        <!--begin::Wrapper-->
                        <div class="d-flex flex-stack mb-2">
                            <!--begin::Label-->
                            <label class="form-label fw-bolder text-dark fs-6 mb-0">Password</label>
                            <!--end::Label-->
                            <!--begin::Link-->
                            <a href="/-html-pro/authentication/base/password-reset.html" class="link-primary fs-6 fw-bolder">Forgot Password ?</a>
                            <!--end::Link-->
                        </div>
                        <!--end::Wrapper-->
                        <!--begin::Input-->
                        <input class="form-control form-control-lg form-control-solid" type="password" name="password" autocomplete="off">
                        <!--end::Input-->
                        <div class="fv-plugins-message-container invalid-feedback"></div>
                    </div>--%>
                                <div class="control-group">
                                    <div class="fv-row mb-4 fv-plugins-icon-container">
                                        <div class="input-icon left">
                                        <div class="d-flex flex-stack mb-2">
                                        
                                            <asp:Label ID="lblpwd" class="form-label fw-bolder text-dark fs-6 mb-0" runat="server" meta:resourcekey="lblpwd">
                            Password</asp:Label>
                                             <%--<a href="/-html-pro/authentication/base/password-reset.html" class="link-primary fs-6 fw-bolder">Forgot Password ?</a>--%>
                                            <a href="javascript:void(0)" class="link-primary fs-6 fw-bolder" tabindex="1" onclick="OpenForgotPwd()">
                                        <asp:Label ID="lblForgot" runat="server" meta:resourcekey="lblForgot">Forgot password?</asp:Label>
                                    </a>
                                            </div>     
                                           <input id="axPassword" runat="server" class="m-wrap placeholder-no-fix form-control form-control-solid" tabindex="4" type="password" autocomplete="off"
                                                placeholder="" name="axPassword"  title="Password" required />
                                            <div class="fv-plugins-message-container invalid-feedback"></div>
                                            <%--<div class="field-placeholder">
                                                
                                            </div>--%>
                                           
                                        </div>
                                        <input type="hidden" runat="server" name="hdnAxProjs" id="hdnAxProjs" />
                                        <input type="hidden" runat="server" name="hdnMobDevice" id="hdnMobDevice" />
                                        <input type="hidden" runat="server" name="hdnHybridGUID" id="hdnHybridGUID" />
                                        <input type="hidden" runat="server" name="hdnHybridDeviceId" id="hdnHybridDeviceId" />
                                        <input type="hidden" runat="server" name="hdnTimeZone" id="hdnTimeZone" />
                                        <input type="hidden" runat="server" name="hdnTimeZone" id="hdnProjName" />
                                        <input type="hidden" runat="server" name="hdnTimeZone" id="hdnProjLang" />
                                        <asp:Label ID="lblCustomerror" runat="server" meta:resourcekey="lblCustomerror" Visible="false">Server error. Please try again.If the problem continues, please contact your administrator.</asp:Label>
                                    </div>
                                </div>
                                     <div class="hide control-group" id="axLangFld" runat="server">
                                     <div class= "fv-row my-8 mb-4 fv-plugins-icon-container">
                                        <div class="input-icon left">
                                         <div class="d-flex flex-stack mb-1">
                                            <asp:Label ID="lblslctlang"  class="form-label fs-6 fw-bolder text-dark" runat="server" meta:resourcekey="lblslctlang">Select Language
                            </asp:Label>
                                             </div>
														<!-- <input class="form-control" value="" /> -->
                                         <select class="form-select form-select-solid" data-control="select2" data-placeholder="Select Language" data-allow-clear="true" id="axLanguage" name="axLanguage"  runat="server" value=''>
														<%--<select class="form-select form-select-solid m-wrap placeholder-no-fix"  runat="server" data-control="select2" data-placeholder="Select Language" data-allow-clear="true" data-select2-id="select2-data-11-3n80" tabindex="-1" aria-hidden="true" onblur="GetProjLang();" id='axLanguage' name="axLanguage">--%>
														</select>
                                             <div class="fv-plugins-message-container invalid-feedback"></div>
													</div>
                                         </div>
                                    </div>
                                <%--<div class="hide control-group" id="axLangFld1" runat="server">
                                    <div class="controls field-wrapper">
                                        <div class="input-icon left">
                                            <input type='text' value='' id='axLanguage1' runat="server" name="axLanguage" title="Select Language" tabindex='2' placeholder='Select Language' class='m-wrap placeholder-no-fix new-search-input search-input' required />
                                            <div class="field-placeholder">
                                                <asp:Label ID="lblslctlang1" runat="server" meta:resourcekey="lblslctlang">
                            Select Language</asp:Label>
                                            </div>
                                            <i class="icon-cross" title="Clear" onclick="$('#axLanguage').val('').focus();"></i>
                                            <i class="icon-chevron-down autoClickddl" title="Select Language" onclick="$('#axLanguage').autocomplete('search','').focus();"></i>
                                        </div>
                                    </div>
                                </div>--%>
                                <%--<div class="agform form-check form-check-custom form-check-solid px-1 align-self-end mb-4">
                        <input class="form-check-input h-20px w-20px" type="checkbox" value="" id="signin">
                        <label class="form-check-label form-label col-form-label fw-bolder text-dark fs-6 mb-0" for="signin">
                            Keep me sign in?
                        </label>
                    </div>--%>
                                <div class="control-group">
                                <div class=" agform form-check form-switch form-check-custom form-check-solid px-1 align-self-end mb-4" id="axstaysignin" runat="server" visible="false">
                                    <div class="controls my-2">
                                        <div class="input-icon left">
                                            <input type="checkbox" id="signedin" runat="server" class="m-wrap placeholder-no-fix form-check-input h-25px w-40px" tabindex="5"  title="Keep me sign in?" />
                                            <asp:Label runat="server" ID="lblstaysin" meta:resourcekey="lblstaysin" class="form-check-label form-label col-form-label fw-bolder text-dark fs-6 mb-0" for="signedin">Keep me sign in?</asp:Label>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                <%--<div class="d-flex flex-row-fluid">
                                <!--begin::Submit button-->
                                <button type="submit" id="kt_sign_in_submit" class="btn btn-lg btn-primary mb-5 w-100">
                                    <span class="indicator-label">Continue</span>
                                    <span class="indicator-progress">
                                        Please wait...
                                        <span class="spinner-border spinner-border-sm align-middle ms-2"></span>
                                    </span>
                                </button>
                                <!--begin::Separator-->
                                <!--<div class="text-center text-muted text-uppercase fw-bolder mb-5">or</div>-->
                                <!--end::Separator-->
                            </div>--%> 
                                    <%--<a href="#" class="btn btn-icon btn-light-facebook me-2 btn-sm "><i class="fab fa-facebook-f fs-4"></i></a>--%>
                                <div class="form-actions d-flex flex-row flex-column-fluid">
                                    <div class="d-flex flex-row-fluid">
                                    <asp:Button runat="server" Text="Login" title="Login" tabindex="6" ID="btnSubmit" class="btn btn-lg btn-primary mb-5 w-100" OnClientClick="return chkLoginForm();" OnClick="btnSubmit_Click" />
                                        </div>
                                    <div class="d-flex flex-row-auto ms-4 mt-1">
                                        <%--<svg xmlns="http://www.w3.org/2000/svg" width="64" height="64"><path d="M32 0C14.37 0 0 14.267 0 32s14.268 32 32 32 32-14.268 32-32S49.63 0 32 0zm0 48c-8.866 0-16-7.134-16-16s7.134-16 16-16 16 7.134 16 16-7.134 16-16 16z" fill="#007dc1"/></svg>--%>
                                        <a href="#" ID="OktaBtn"  runat="server" class="btn btn-icon btn-light-okta me-2 btn-sm" OnClientClick="axOktaLogin();return false;" Text="" Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Okta"><span class="svg-icon svg-icon-4" >
                                        <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 64 64"><path d="M32 0C14.37 0 0 14.267 0 32s14.268 32 32 32 32-14.268 32-32S49.63 0 32 0zm0 48c-8.866 0-16-7.134-16-16s7.134-16 16-16 16 7.134 16 16-7.134 16-16 16z" fill=""/></svg></span></a>
                                    
                                        <a href="#" ID="Office365Btn"  runat="server" class="btn btn-icon btn-light-office365 me-2 btn-sm" OnClientClick="Office365Init();return false;" Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Office365"><span class="svg-icon svg-icon-4"><svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="50" height="50" viewBox="0 0 48 48" style={{height: "25px"}}><g id="surface1"><path <%--style={{fill: "#fff"}}--%> d="M 7 12 L 29 4 L 41 7 L 41 41 L 29 44 L 7 36 L 29 39 L 29 10 L 15 13 L 15 33 L 7 36 Z " fill=""/></g></svg></span></a>
                                    
                                        <a href="#" ID="GoogleBtn" class="btn btn-icon btn-light-google me-2 btn-sm " runat="server" OnClick="GoogleBtn_Click" Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Google"><span class="svg-icon svg-icon-4"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 488 512"><!--! Font Awesome Pro 6.0.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M488 261.8C488 403.3 391.1 504 248 504 110.8 504 0 393.2 0 256S110.8 8 248 8c66.8 0 123 24.5 166.3 64.9l-67.5 64.9C258.5 52.6 94.3 116.6 94.3 256c0 86.5 69.1 156.6 153.7 156.6 98.2 0 135-70.4 140.8-106.9H248v-85.3h236.1c2.3 12.7 3.9 24.9 3.9 41.4z" fill=""/></svg></span></a>
                                        
                                    <%--<%--<asp:Button ID="GoogleBtn" Visible="false" class="hotbtn btn" runat="server" Text="Google account" OnClick="GoogleBtn_Click"></asp:Button>--%>
                                        <a href="#" id="FacebookBtn" class="btn btn-icon btn-light-facebook me-2 btn-sm " runat="server" onclick="FacebookBtn_Click" Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Facebook"><span class="svg-icon svg-icon-4">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512" width="24" height="24"><path d="M279.14 288l14.22-92.66h-88.91v-60.13c0-25.35 12.42-50.06 52.24-50.06h40.42V6.26S260.43 0 225.36 0c-73.22 0-121.08 44.38-121.08 124.72v70.62H22.89V288h81.39v224h100.17V288z" fill=""></path></svg>
                                    </span></a>
                                  
                                        <a href="#"  ID="WindowsBtn" class="btn btn-icon btn-light-windows me-2 btn-sm" runat="server" OnClientClick="return chkLoginForm();" OnClick="WindowsBtn_Click"  Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Windows"><span class="svg-icon svg-icon-4"><svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" shape-rendering="geometricPrecision" text-rendering="geometricPrecision" image-rendering="optimizeQuality" fill-rule="evenodd" clip-rule="evenodd" viewBox="0 0 640 640"><path d="M.2 298.669L0 90.615l256.007-34.76v242.814H.201zM298.658 49.654L639.905-.012v298.681H298.657V49.654zM640 341.331l-.071 298.681L298.669 592V341.332h341.33zM255.983 586.543L.189 551.463v-210.18h255.794v245.26z" fill=""></path></svg></span></a>
                                        
                                        <a href="#" id="SamlBtn" class="btn btn-icon btn-light-saml me-2 btn-sm " runat="server" OnClientClick="return chkSSOLogin();"  onclick="SamlBtn_Click" Visible="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="SAML"><span class="svg-icon svg-icon-4">
                                    <svg version="1.0" xmlns="http://www.w3.org/2000/svg"width="24pt" height="24pt" viewBox="0 0 24 24"><g transform="translate(0,24) scale(0.10,-0.1)" ><path d="M97 210 c-8 -19 -18 -46 -22 -60 -5 -21 -3 -20 14 8 32 49 55 41 119
-43 l23 -30 -15 30 c-8 17 -35 53 -59 80 l-45 50 -15 -35z" fill=""/><path d="M32 148 c-11 -29 -23 -68 -27 -85 -7 -37 0 -40 66 -26 l34 7 -29 6
c-45 8 -53 30 -33 91 22 70 14 75 -11 7z" fill=""/><path d="M165 105 c21 -55 19 -65 -19 -80 -19 -8 -46 -16 -58 -16 -19 -1 -20
-2 -4 -6 27 -7 136 18 136 31 0 6 -15 29 -32 51 -17 22 -27 31 -23 20z" fill=""/></g></svg>
                                    </span></a>
                                    <%--<asp:Button ID="SamlBtn1" Visible="false" class="hotbtn btn" runat="server" Text="SAML Login" OnClientClick="return chkSSOLogin();" OnClick="SamlBtn_Click"></asp:Button>--%>
                                        </div>
                                </div>
                                <%--<div class="copyrightlabs">
                                    <div class=""><span id="dvCopyRight" runat="server" class="copyrightpara text-dark mb-2 fw-bolder">�2020 Agile Labs Pvt. Ltd. All Rights Reserved.</span>
                                    <span id="axpertVer" runat="server" class="copyrightpara text-dark mb-2 fw-bolder"></span>
                                        </div>
                                    <div class="clearfix"></div>
                                    </div>--%>
                                     <div class="copyrightlabs">
                                    <div class=""><span id="dvCopyRight" runat="server" class="copyrightpara text-dark mb-2 fw-bolder">�2020 Agile Labs Pvt. Ltd. All Rights Reserved.</span>
                                    <%--<div class="col-sm-6 col-md-6 col-xs-6">--%><span id="axpertVer" class="text-dark mb-2 fw-bolder float-end" runat="server"></span><%--</div>--%></div>
                                    <div class="clearfix"></div>
                                </div>
                              
                               <%-- <div class="create-account">
                                    <a href="javascript:void(0)" class="subtextblue" tabindex="3" onclick="OpenForgotPwd()">
                                        <asp:Label ID="lblForgot" runat="server" meta:resourcekey="lblForgot">Forgot password?</asp:Label>
                                    </a>
                                </div>--%>
                <%--                    <div class="btn btn-icon btn-white btn-color-gray-800 btn-active-primary shadow-sm position-fixed m-4 bottom-0 end-0" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Axpert Configuration">
            <span class="material-icons material-icons-style">
                settings
            </span>
        </div>--%>
                                <div class="create-account btn btn-icon btn-white  btn-active-primary  m-4  position-absolute top-0 end-0" id="axpertConfig" runat="server"  data-bs-toggle="tooltip" data-bs-placement="top" data-bs-dismiss="click" data-bs-trigger="hover" data-bs-original-title="Axpert Configuration" visible="false" onclick="OpenNewConnection()">
                                    <span class="material-icons material-icons-style">settings</span>
                                    
                                </div>
                            </div>
                                 </div>
                        
            
                        <input type="hidden" id="browserElapsTime" runat="server" />
                        <input type="hidden" id="hdnLangs" runat="server" disabled="disabled" />
                        <input type="hidden" id="hdnAppTitle" runat="server" disabled="disabled" />
                        <input type="hidden" id="hdnLastOpenpage" runat="server" disabled="disabled" />
                        <input type="hidden" id="hdnbtforLogin" runat="server" />
                        <input type="hidden" id="hdnBwsrid" runat="server" />
                    </asp:Panel>
               <%-- </form>--%>
                        </form>
                        </div>
            </div>
            </div>
        <%--</div>--%>
    
   

    <form id="form3" class="d-none">
        <input type="hidden" runat="server" name="mobDevice" id="mobDevice" />
        <input type="hidden" runat="server" name="duplicateUser" id="duplicateUser" />
        <input type="hidden" runat="server" name="hbtforDupLogin" id="hbtforDupLogin" />
        <button type="submit" runat="server" title="Login" id="btnSubmitUser" class="hotbtn btn hide" />
    </form>
    <%--<script src="../assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>--%>
    <%--<script src="../assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>--%>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <%--<script src="../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>--%>
    <script src="../ThirdParty/jquery-confirm-master/jquery-confirm.min.js?v=2" type="text/javascript"></script>
   <%-- <script src="../Js/thirdparty/bootstrap/3.3.6/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js"
        type="text/javascript"></script>--%>
    <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->
    <%--<script src="../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js?v=3" type="text/javascript"></script>--%>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../assets/scripts/app.min.js?v=1" type="text/javascript"></script>
    <script src="../assets/scripts/tasks.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL STYLES -->
    <!-- END PAGE LEVEL SCRIPTS -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            KTApp.init();
            App.init(); // initlayout and core plugins            
            $("#sidemenu-leftt").click();
        });
    </script>
    <!-- <script src="../Js/common.min.js?v=98" type="text/javascript"></script> -->
</body>
</html>
