#pragma checksum "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ee16a03a2739ac6a6d01a0d59989a46ef18892f08f3d29cb589f58db5a8eedb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewTributeDetails), @"mvc.1.0.view", @"/Views/Admin/ViewTributeDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\_ViewImports.cshtml"
using Tribute_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\_ViewImports.cshtml"
using Tribute_MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4ee16a03a2739ac6a6d01a0d59989a46ef18892f08f3d29cb589f58db5a8eedb", @"/Views/Admin/ViewTributeDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"17f2948d2904d82f57ce23a9812242a670cd12d65c3c784604704c94c027507b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_ViewTributeDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tribute_MVC.Models.Tribute>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("APJ"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("TributorImage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddFeedback", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rating_img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Layout/Users/avatar7.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
  
    ViewData["Title"] = "ViewTributeDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Id = Context.Session.GetInt32("UserId");
    IEnumerable<TributeLogModel> Comments = ViewData["Comments"] as IEnumerable<TributeLogModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    * {
        margin: 0;
        padding: 0;
        font-family: sans-serif;
    }

    .detail-page {
        background-color: #111;
        /*background-image: linear-gradient( 135deg, rgb(24, 42, 115) 0%, rgb(33, 138, 174) 69%, rgb(32, 167, 172) 89% ) !important;*/
        width: 100%;
        margin-top: 10px;
    }

    #TributorImage {
        width: 200px;
        height: 200px;
        display: block;
        margin-left: auto;
        margin-right: auto;
        margin-top: 10px;
        border-radius: 50%;
    }

    .Bio {
        margin-left: 20px;
        margin-right: 20px;
        border: none;
    }

    p {
        color: white;
        font-family: sans-serif;
    }

    h3 {
        margin: 1em 0 0.5em 0;
        color: white;
        font-size: 22px;
        line-height: 40px;
        font-weight: normal;
        text-transform: uppercase;
        font-family: 'Orienta', sans-serif;
        letter-spacing: 1px;
        font-style: n");
            WriteLiteral(@"ormal;
    }

    User_profile {
        float: left;
        width: 20%;
        margin-top: 6px;
    }

    .Comment_List {
        float: left;
        width: 80%;
        margin-top: 6px;
    }

    .Comment_Box {
        width: 60%;
        margin-left: auto;
        margin-right: auto;
    }

    #userImage {
        width: 70px;
        border-radius: 50%;
    }

    span {
        font-family: sans-serif;
        color: gray;
    }

    textarea {
        width: 100%;
        height: 150px;
        padding: 12px 20px;
        box-sizing: border-box;
        border: 2px solid #ccc;
        border-radius: 4px;
        background-color: #f8f8f8;
        font-size: 16px;
        margin-bottom: 40px;
        resize: none;
    }

    #btnSend {
        background-color: #4CAF50;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        float: right;
        margin-left: 5px;
    }
            WriteLiteral(@"

    #btnCancel {
        background-color: red;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        float: right;
    }

    #btnEdit {
        background-color: #4CAF50;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        float: right;
    }

    .center {
        width: auto;
        margin-top: 20px;
        height: auto;
        background-color: white;
        border: 1px solid #000;
    }

    .rating_img {
        width: 100px;
        padding: 5px;
        height: 100px;
        /* position: relative; */
        border-radius: 59px;
    }

    .rating_label {
        position: relative;
        top: -85px;
        margin-left: 127px;
    }

    #spUserName {
        position: relative;
        margin-left: 15px;
        margin-top: 10px;
        top: -90px;
    }

    div.stars {
        wi");
            WriteLiteral(@"dth: auto;
        position: relative;
        top: -80px;
        margin-left: 113px;
        display: inline-block;
    }

    input.star {
        display: none;
    }

    label.star {
        float: right;
        padding: 10px;
        font-size: 25px;
        color: #444;
        transition: all .2s;
    }

    input.star:checked ~ label.star:before {
        content: '\f005';
        color: #FD4;
        transition: all .25s;
    }

    input.star-5:checked ~ label.star:before {
        color: #FE7;
        text-shadow: 0 0 20px #952;
    }

    input.star-1:checked ~ label.star:before {
        color: #F62;
    }

    label.star:hover {
        transform: rotate(-15deg) scale(1.3);
    }

    label.star:before {
        content: '\f006';
        font-family: FontAwesome;
    }

    .rate {
        float: left;
        height: 46px;
        padding: 0 10px;
    }

        .rate:not(:checked) > input {
            position: absolute;
            top: -");
            WriteLiteral(@"9999px;
        }

        .rate:not(:checked) > label {
            float: right;
            width: 1em;
            overflow: hidden;
            white-space: nowrap;
            cursor: pointer;
            font-size: 30px;
            color: #ccc;
        }

            .rate:not(:checked) > label:before {
                content: '★ ';
            }

        .rate > input:checked ~ label {
            color: #ffc700;
        }

        .rate:not(:checked) > label:hover,
        .rate:not(:checked) > label:hover ~ label {
            color: #deb217;
        }

        .rate > input:checked + label:hover,
        .rate > input:checked + label:hover ~ label,
        .rate > input:checked ~ label:hover,
        .rate > input:checked ~ label:hover ~ label,
        .rate > label:hover ~ input:checked ~ label {
            color: #c59b08;
        }
</style>

<div class=""detail-page"">

    <span style=""color:white; float:right"">Posted By: <strong>");
#nullable restore
#line 249 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                                                         Write(ViewBag.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\r\n    <h2 style=\"color:greenyellow;\">");
#nullable restore
#line 250 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <br />\r\n    <hr />\r\n");
#nullable restore
#line 253 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
     if (Model.UserId == Id)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5588, "\"", 5679, 5);
            WriteAttributeValue("", 5598, "location.href", 5598, 13, true);
            WriteAttributeValue(" ", 5611, "=", 5612, 2, true);
            WriteAttributeValue(" ", 5613, "\'", 5614, 2, true);
#nullable restore
#line 255 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
WriteAttributeValue("", 5615, Url.Action("EditTribute","Admin",new { id = Model.TributeId }), 5615, 63, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5678, "\'", 5678, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnEdit\">Edit</button>\r\n");
#nullable restore
#line 256 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4ee16a03a2739ac6a6d01a0d59989a46ef18892f08f3d29cb589f58db5a8eedb14102", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5730, "~/Layout/img/", 5730, 13, true);
#nullable restore
#line 257 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
AddHtmlAttributeValue("", 5743, Model.ImageUrl, 5743, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div class=\"Bio\">\r\n        <div class=\"container_description\">\r\n\r\n            <h3>Short Description:</h3>\r\n            <p>");
#nullable restore
#line 262 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
          Write(Model.Abstract);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n            <h3>About :</h3>\r\n\r\n            <p>");
#nullable restore
#line 266 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p><br>\r\n\r\n            <h3>Reference Information:</h3>\r\n            <p><a");
            BeginWriteAttribute("href", " href=\"", 6081, "\"", 6109, 1);
#nullable restore
#line 269 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
WriteAttributeValue("", 6088, Model.RefferenceLink, 6088, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">Click For more information</a></p><br>\r\n        </div>\r\n");
            WriteLiteral("\r\n        <div class=\"Commemt_Section\">\r\n            <div class=\"Comment_Box\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ee16a03a2739ac6a6d01a0d59989a46ef18892f08f3d29cb589f58db5a8eedb17321", async() => {
                WriteLiteral("\r\n                    <div>\r\n                        <input type=\"text\"");
                BeginWriteAttribute("value", " value=", 6472, "", 6495, 1);
#nullable restore
#line 277 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
WriteAttributeValue("", 6479, Model.TributeId, 6479, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""id"" hidden />
                    </div>
                    <div class=""rate"">
                        <input type=""radio"" id=""star5"" name=""rate"" value=""5"" />
                        <label for=""star5"" title=""text"">5 stars</label>
                        <input type=""radio"" id=""star4"" name=""rate"" value=""4"" />
                        <label for=""star4"" title=""text"">4 stars</label>
                        <input type=""radio"" id=""star3"" name=""rate"" value=""3"" />
                        <label for=""star3"" title=""text"">3 stars</label>
                        <input type=""radio"" id=""star2"" name=""rate"" value=""2"" />
                        <label for=""star2"" title=""text"">2 stars</label>
                        <input type=""radio"" id=""star1"" name=""rate"" value=""1"" />
                        <label for=""star1"" title=""text"">1 star</label>
                    </div>

                    <textarea name=""comment"" id=""txtComment"" maxlength=""50"" title=""Can't enter more than 50 words"" placeholder=""Share y");
                WriteLiteral(@"our view..."" required></textarea>
                    <div class=""button"">
                        <input type=""submit"" id=""btnSend"" value=""Submit"">
                        <input type=""reset"" id=""btnCancel"" value=""Clear"">
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n            <br /><br />\r\n");
#nullable restore
#line 301 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
             if (Comments is null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"center\">\r\n                <span style=\"color:blue\"><b>No Commnets Available...<br />Be the first to Comment.!</b></span>\r\n            </div>\r\n");
#nullable restore
#line 306 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
            }
            else
            {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 309 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
             foreach (TributeLogModel tribute in Comments)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"center\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4ee16a03a2739ac6a6d01a0d59989a46ef18892f08f3d29cb589f58db5a8eedb22288", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <span id=\"spUserName\">");
#nullable restore
#line 313 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                                 Write(tribute.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <p class=\"rating_label\" style=\"color: black;\">");
#nullable restore
#line 314 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                                                         Write(tribute.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"stars\">\r\n");
#nullable restore
#line 316 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                     for (int i = 1; i <= tribute.Rating; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span style=\"color:orange\" class=\"fa fa-star checked\"></span>\r\n");
#nullable restore
#line 319 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 322 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 322 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\Admin\ViewTributeDetails.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tribute_MVC.Models.Tribute> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591