#pragma checksum "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efc92bda54433fb98f50b11a8adda3cea93fe2f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Administration_Users), @"mvc.1.0.view", @"/Areas/Administration/Views/Administration/Users.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\_ViewImports.cshtml"
using ServeIt.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\_ViewImports.cshtml"
using ServeIt.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efc92bda54433fb98f50b11a8adda3cea93fe2f9", @"/Areas/Administration/Views/Administration/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4178e793a085b6265468725742979c8d767569c", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Administration_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("book-a-table-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BlockUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<br />
<br />
<br />
<section id=""menu"" class=""menu section-bg"">
    <div class=""container"" data-aos=""fade-up"">

        <div class=""section-title"">
            <h2>All</h2>
            <p>Users</p>
        </div>
        <div class=""col-lg-4 col-md-6 form-group"">
            <input type=""text"" onkeyup=""myFunction()"" name=""town"" class=""form-control"" id=""search"" placeholder=""Search..."">

        </div>


        <div class=""row menu-container"" data-aos=""fade-up"" data-aos-delay=""200"">

");
#nullable restore
#line 20 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
             foreach( var user in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-6 menu-item \">\r\n                <div class=\"menu-content\">\r\n                    <a class=\"username\"> Username: ");
#nullable restore
#line 24 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                              Write(user.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n                <div class=\"menu-ingredients\">\r\n                    <div class=\"menu-ingredients\">\r\n                        <p class=\"col-sm-8 fullname\">Name: ");
#nullable restore
#line 28 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                      Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                        <p class=\"col-sm-8 phone\">Phone: ");
#nullable restore
#line 29 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                    Write(user.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                        <p class=\"col-sm-8 email\">Email: ");
#nullable restore
#line 30 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                    Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n                        <p class=\"col-sm-8\">Register Date: ");
#nullable restore
#line 31 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                      Write(user.RegisterDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"col-sm-8\">Restaurant Owner: ");
#nullable restore
#line 32 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                         Write(user.IsOwner);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n\r\n                    <div class=\"text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc92bda54433fb98f50b11a8adda3cea93fe2f97713", async() => {
                WriteLiteral("<i class=\"bi bi-person-x\"></i> Remove");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
                                                                                                                                       WriteLiteral(user.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 42 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Areas\Administration\Views\Administration\Users.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>

    </div>
</section>
<script>
    function myFunction() {
        // Declare variables
        var input, filter, i, txtValue;
        input = document.getElementById('search');
        filter = input.value.toUpperCase();

        usernames = document.querySelectorAll("".username"");


        for (var i = 0; i < usernames.length; i++) {
          
            txtValue = usernames[i].textContent + "" "" || usernames[i].innerText + "" "";
            console.log(txtValue)

            var parrent = usernames[i].parentElement.parentElement;

            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                parrent.style.display = ""block"";
            }
            else {
                parrent.style.display = ""none"";
            }
        }




    }
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
