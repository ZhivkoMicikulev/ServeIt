#pragma checksum "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85c0d6b04459400ac7c119cf34bfe8e86ed2809a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurants_Edit), @"mvc.1.0.view", @"/Views/Restaurants/Edit.cshtml")]
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
#line 1 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\_ViewImports.cshtml"
using ServeIt.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\_ViewImports.cshtml"
using ServeIt.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
using ServeIt.Web.ViewModels.Restaurants;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85c0d6b04459400ac7c119cf34bfe8e86ed2809a", @"/Views/Restaurants/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4178e793a085b6265468725742979c8d767569c", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurants_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServeIt.Web.ViewModels.Restaurants.EditRestaurantViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-family:Playfair Display , serif;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Menus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("forms/contact.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("php-email-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"<br />
<br />

<br />
<br />


<section id=""specials"" class=""specials"">
    <div class=""container"" data-aos=""fade-up"">

        <div class=""section-title"">
            <h2>Restaurant </h2>
            <p>Properties</p>
        </div>

        <div class=""row"" data-aos=""fade-up"" data-aos-delay=""100"">

            <div class=""col-lg-3"">
                <ul class=""nav nav-tabs flex-column"">
                    <li class=""nav-item"">
                        <a class=""nav-link active show"" data-bs-toggle=""tab"" href=""#tab-1"">Menu</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" href=""#tab-2"">Reservations</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" href=""#tab-3"">Information</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" hr");
            WriteLiteral(@"ef=""#tab-4"">Orders</a>
                    </li>

                </ul>
            </div>


            <div class=""col-lg-9 mt-4 mt-lg-0"">
                <div class=""tab-content"">
                    <div class=""tab-pane active show"" id=""tab-1"">
                        <div class=""row"">
                            
                                <section id=""menu"" class=""menu section-bg"">

                                    <div class=""row"" data-aos=""fade-up"" data-aos-delay=""100"">
                                        <div class=""col-lg-12 d-flex justify-content-center"">

                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c0d6b04459400ac7c119cf34bfe8e86ed2809a8037", async() => {
                WriteLiteral("Add Dish");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                                                                       WriteLiteral(Model.RestaurantId);

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
            WriteLiteral(@"

                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <div class=""row"" data-aos=""fade-up"" data-aos-delay=""100"">
                                        <div class=""col-lg-12 d-flex justify-content-center"">
                                            <ul id=""menu-flters"">
                                                <li data-filter=""*"" class=""filter-active"">All</li>
");
#nullable restore
#line 63 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                 foreach (var category in Model.MenuCategories)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li data-filter=\".filter-");
#nullable restore
#line 65 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                        Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 65 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                   Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 66 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"

                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </ul>
                                        </div>
                                    </div>

                                    <div class=""row menu-container"" data-aos=""fade-up"" data-aos-delay=""200"">
");
#nullable restore
#line 74 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                         foreach (var dish in Model.Dishes)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div");
            BeginWriteAttribute("class", " class=\"", 3196, "\"", 3248, 4);
            WriteAttributeValue("", 3204, "col-lg-6", 3204, 8, true);
            WriteAttributeValue(" ", 3212, "menu-item", 3213, 10, true);
            WriteAttributeValue(" ", 3222, "filter-", 3223, 8, true);
#nullable restore
#line 76 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
WriteAttributeValue("", 3230, dish.CategoryName, 3230, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <div class=\"menu-content\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c0d6b04459400ac7c119cf34bfe8e86ed2809a13631", async() => {
#nullable restore
#line 78 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                                                 Write(dish.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                                 WriteLiteral(dish.Id);

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
            WriteLiteral("<span>$");
#nullable restore
#line 78 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                                                                      Write(dish.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                                </div>\r\n\r\n                                                <div class=\"menu-ingredients\">\r\n\r\n                                                    ");
#nullable restore
#line 84 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                               Write(dish.Ingredients);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n\r\n                                            </div>\r\n");
#nullable restore
#line 88 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"


                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </div>


                                </section>


                        </div>
                    </div>
                    <div class=""tab-pane active show"" id=""tab-3"">
                        <div class=""row"">
                            <section id=""contact"" class=""contact"">
                                <div class=""container"" data-aos=""fade-up"">

                                    <div class=""section-title"">
                                        <h2>Restaurant Name</h2>
                                        <p>Contact Us</p>
                                    </div>
                                </div>

                               
                                <div class=""container"" data-aos=""fade-up"">

                                    <div class=""row mt-5"">

                                        <div class=""col-lg-4"">
                                            <div class=""info"">
                                   ");
            WriteLiteral(@"             <div class=""address"">
                                                    <i class=""bi bi-geo-alt""></i>
                                                    <h4>Location:</h4>
                                                    <p>A108 Adam Street, New York, NY 535022</p>
                                                </div>

                                                <div class=""open-hours"">
                                                    <i class=""bi bi-clock""></i>
                                                    <h4>Open Hours:</h4>
                                                    <p>
                                                        Monday-Saturday:<br>
                                                        11:00 AM - 2300 PM
                                                    </p>
                                                </div>

                                                <div class=""email"">
                                                    ");
            WriteLiteral(@"<i class=""bi bi-envelope""></i>
                                                    <h4>Email:</h4>
                                                    <p>info@example.com</p>
                                                </div>

                                                <div class=""phone"">
                                                    <i class=""bi bi-phone""></i>
                                                    <h4>Call:</h4>
                                                    <p>+1 5589 55488 55s</p>
                                                </div>

                                            </div>

                                        </div>

                                        <div class=""col-lg-8 mt-5 mt-lg-0"">

                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c0d6b04459400ac7c119cf34bfe8e86ed2809a20386", async() => {
                WriteLiteral(@"
                                                <div class=""row"">
                                                    <div class=""col-md-6 form-group"">
                                                        <input type=""text"" name=""name"" class=""form-control"" id=""name"" placeholder=""Your Name"" required>
                                                    </div>
                                                    <div class=""col-md-6 form-group mt-3 mt-md-0"">
                                                        <input type=""email"" class=""form-control"" name=""email"" id=""email"" placeholder=""Your Email"" required>
                                                    </div>
                                                </div>
                                                <div class=""form-group mt-3"">
                                                    <input type=""text"" class=""form-control"" name=""subject"" id=""subject"" placeholder=""Subject"" required>
                                                </");
                WriteLiteral(@"div>
                                                <div class=""form-group mt-3"">
                                                    <textarea class=""form-control"" name=""message"" rows=""8"" placeholder=""Message"" required></textarea>
                                                </div>
                                                <div class=""my-3"">
                                                    <div class=""loading"">Loading</div>
                                                    <div class=""error-message""></div>
                                                    <div class=""sent-message"">Your message has been sent. Thank you!</div>
                                                </div>
                                                <div class=""text-center""><button type=""submit"">Send Message</button></div>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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

                                </div>
                            </section>



                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>

</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServeIt.Web.ViewModels.Restaurants.EditRestaurantViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
