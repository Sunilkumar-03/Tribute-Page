#pragma checksum "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a86ab32a278ef3843c8d5ac042039fa054fb38174d4fd1f6be5f638456872e7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_DisplayUser), @"mvc.1.0.view", @"/Views/User/DisplayUser.cshtml")]
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
#line 2 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a86ab32a278ef3843c8d5ac042039fa054fb38174d4fd1f6be5f638456872e7a", @"/Views/User/DisplayUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"17f2948d2904d82f57ce23a9812242a670cd12d65c3c784604704c94c027507b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_DisplayUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tribute_MVC.Models.User>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Course"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
  
    ViewData["Title"] = "DisplayUser";
    Layout = "~/Views/Shared/_UserLayout.cshtml";
    var image = Context.Session.GetString("ImageUrl").ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86ab32a278ef3843c8d5ac042039fa054fb38174d4fd1f6be5f638456872e7a4738", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">

    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>

    <style>
        body {
            color: #6F8BA4;
            margin-top: 20px;
        }

        .section {
            padding: 100px 0;
            position: relative;
        }

        .gray-bg {
            background-color: #f5f5f5;
        }

        img {
            max-width: 100%;
        }

        img {
            vertical-align: middle;
            border-style");
                WriteLiteral(@": none;
        }
        /* About Me
        ---------------------*/
        .about-text h3 {
            font-size: 45px;
            font-weight: 700;
            margin: 0 0 6px;
        }

        .media (max-width: 767px) {
            .about-text h3

        {
            font-size: 35px;
        }

        }

        .about-text h6 {
            font-weight: 600;
            margin-bottom: 15px;
        }

        .media (max-width: 767px) {
            .about-text h6

        {
            font-size: 18px;
        }

        }

        .about-text p {
            font-size: 18px;
            max-width: 450px;
        }

            .about-text p mark {
                font-weight: 600;
                color: #20247b;
            }

        .about-list {
            padding-top: 10px;
        }

            .about-list .media {
                padding: 5px 0;
            }

            .about-list label {
                color: #20247b;
            ");
                WriteLiteral(@"    font-weight: 600;
                width: 88px;
                margin: 0;
                position: relative;
            }

                .about-list label:after {
                    content: """";
                    position: absolute;
                    top: 0;
                    bottom: 0;
                    right: 11px;
                    width: 1px;
                    height: 12px;
                    background: #20247b;
                    -moz-transform: rotate(15deg);
                    -o-transform: rotate(15deg);
                    -ms-transform: rotate(15deg);
                    -webkit-transform: rotate(15deg);
                    transform: rotate(15deg);
                    margin: auto;
                    opacity: 0.5;
                }

            .about-list p {
                margin: 0;
                font-size: 15px;
            }

        .media (max-width: 500px) {
            .about-avatar

        {
            margin-top: 30px;
    ");
                WriteLiteral(@"    }

        }

        .about-section .counter {
            padding: 22px 20px;
            background: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 30px rgba(31, 45, 61, 0.125);
        }

            .about-section .counter .count-data {
                margin-top: 10px;
                margin-bottom: 10px;
            }

            .about-section .counter .count {
                font-weight: 700;
                color: #20247b;
                margin: 0 0 5px;
            }

            .about-section .counter p {
                font-weight: 600;
                margin: 0;
            }

        .dark-color {
            color: #20247b;
        }
    </style>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86ab32a278ef3843c8d5ac042039fa054fb38174d4fd1f6be5f638456872e7a9667", async() => {
                WriteLiteral(@"
    <section class=""section about-section gray-bg"" id=""about"">
        <div class=""col-lg-9"" style=""position: relative; width: 100%; padding-right: 15px; padding-left: 15px;"">
            <div class=""main-content"">
                <div class=""row align-items-center"" style=""padding-left:130px;width:1000px!important"">
                    <div class=""col-lg-6"">
                        <div class=""about-avatar"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a86ab32a278ef3843c8d5ac042039fa054fb38174d4fd1f6be5f638456872e7a10412", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4556, "~/Layout/Users/", 4556, 15, true);
#nullable restore
#line 169 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
AddHtmlAttributeValue("", 4571, image, 4571, 6, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-lg-6"">
                        <div class=""about-text go-to"">
                            <div class=""row about-list"">
                                <h2 class=""title"" style=""font-family:Nunito;color: #111111;margin: 0 0 26px;"">");
#nullable restore
#line 175 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
                                                                                                         Write(Html.DisplayFor(model => model.Role));

#line default
#line hidden
#nullable disable
                WriteLiteral(" Profile</h2>\r\n                                <div class=\"col-md-6\">\r\n                                    <div class=\"media\">\r\n                                        <b>Name</b>\r\n                                        <p>");
#nullable restore
#line 179 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
                                      Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"media\">\r\n                                        <b>E-mail</b>\r\n                                        <p>");
#nullable restore
#line 183 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
                                      Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"media\">\r\n                                        <b>Phone</b>\r\n                                        <p>");
#nullable restore
#line 187 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
                                      Write(Html.DisplayFor(model => model.Mobile));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class=""counter"">
                        <div class=""row"">
                            <div class=""col"">
                                <div class=""count-data text-center"">
                                    <h6 class=""count h2"" data-to=""50"" data-speed=""50"">");
#nullable restore
#line 198 "C:\Users\sanib\Documents\.Net Framework\Projects\Tribute_Page_Original\TributePage\Tribute_MVC\Views\User\DisplayUser.cshtml"
                                                                                 Write(ViewBag.TributesCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h6>
                                    <p class=""m-0px font-w-600"">Tributes Posted</p>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tribute_MVC.Models.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
