#pragma checksum "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c4ed9fd44e1c59e6f66f8d69bf3a16b975c6ccb"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c4ed9fd44e1c59e6f66f8d69bf3a16b975c6ccb", @"/Views/Restaurants/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4178e793a085b6265468725742979c8d767569c", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurants_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServeIt.Web.ViewModels.Restaurants.EditRestaurantViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-family:Playfair Display , serif;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Menus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Restaurants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-menu animated fadeInUp scrollto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"<br />
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
                        <a class=""nav-link active show"" data-bs-toggle=""tab"" href=""#tab-1"">Orders</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" href=""#tab-2"">Reservations</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" href=""#tab-3"">Menu</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-bs-toggle=""tab"" href=""#tab-4""");
            WriteLiteral(@">Information</a>
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
                                        <ul id=""menu-flters"">
                                            <li data-filter=""*"" class=""filter-waiting"">Waiting</li>
                                            <li data-filter="".filter-ready"">ready</li>
                                        </ul>
                                    </div>
                                </div>

                                <div id=""orders"" class=""row menu-container"" data-aos=""fa");
            WriteLiteral(@"de-up"" data-aos-delay=""200"">
                                  
                                </div>


                            </section>


                        </div>
                    </div>

                    <div class=""tab-pane "" id=""tab-3"">
                        <div class=""row"">

                            <section id=""menu"" class=""menu section-bg"">

                                <div class=""row"" data-aos=""fade-up"" data-aos-delay=""100"">
                                    <div class=""col-lg-12 d-flex justify-content-center"">

                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4ed9fd44e1c59e6f66f8d69bf3a16b975c6ccb8452", async() => {
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
#line 75 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
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
#line 86 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                             foreach (var category in Model.MenuCategories)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <li data-filter=\".filter-");
#nullable restore
#line 88 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                    Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 88 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                               Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 89 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"

                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </ul>\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div class=\"row menu-container\" data-aos=\"fade-up\" data-aos-delay=\"200\">\r\n");
#nullable restore
#line 97 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                     foreach (var dish in Model.Dishes)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div");
            BeginWriteAttribute("class", " class=\"", 4113, "\"", 4165, 4);
            WriteAttributeValue("", 4121, "col-lg-6", 4121, 8, true);
            WriteAttributeValue(" ", 4129, "menu-item", 4130, 10, true);
            WriteAttributeValue(" ", 4139, "filter-", 4140, 8, true);
#nullable restore
#line 99 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
WriteAttributeValue("", 4147, dish.CategoryName, 4147, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <div class=\"menu-content\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4ed9fd44e1c59e6f66f8d69bf3a16b975c6ccb13961", async() => {
#nullable restore
#line 101 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
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
#line 101 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
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
#line 101 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                                                                  Write(dish.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                            </div>\r\n\r\n                                            <div class=\"menu-ingredients\">\r\n                                                <p class=\"col-sm-8\"> ");
#nullable restore
#line 106 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                Write(dish.Ingredients);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                                            </div>\r\n\r\n                                        </div>\r\n");
#nullable restore
#line 111 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"


                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>


                            </section>


                        </div>
                    </div>


                    <div class=""tab-pane "" id=""tab-4"">
                        <div class=""row"">
                            <section id=""contact"" class=""contact"">
                                <div class=""container"" data-aos=""fade-up"">

                                    <div class=""section-title"">
                                        <h2>");
#nullable restore
#line 130 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                       Write(Model.RestaurantInfo.RestaurantName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                                        <p>Contact Us</p>
                                    </div>
                                </div>


                                <div class=""container"" data-aos=""fade-up"">

                                    <div class=""row mt-5"">

                                        <div class=""col-lg-4"">
                                            <div class=""info"">
                                                <div class=""address"">
                                                    <i class=""bi bi-geo-alt""></i>
                                                    <h4>Location:</h4>
                                                    <p>");
#nullable restore
#line 145 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                  Write(Model.RestaurantInfo.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                </div>

                                                <div class=""open-hours"">
                                                    <i class=""bi bi-info""></i>
                                                    <h4>About us:</h4>
                                                    <p>
                                                        ");
#nullable restore
#line 152 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                   Write(Model.RestaurantInfo.About);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </p>
                                                </div>

                                                <div class=""email"">
                                                    <i class=""bi bi-envelope""></i>
                                                    <h4>Email:</h4>
                                                    <p>");
#nullable restore
#line 159 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                  Write(Model.RestaurantInfo.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                </div>

                                                <div class=""phone"">
                                                    <i class=""bi bi-phone""></i>
                                                    <h4>Call:</h4>
                                                    <p>");
#nullable restore
#line 165 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                  Write(Model.RestaurantInfo.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                </div>

                                            </div>

                                        </div>


                                    </div>

                                </div>
                                <div class=""btns"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c4ed9fd44e1c59e6f66f8d69bf3a16b975c6ccb21820", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 177 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                                                                                           WriteLiteral(Model.RestaurantId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                            </section>



                        </div>
                    </div>





                </div>

            </div>
        </div>

    </div>

</section>


<script src=""//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js""></script>
<script>
   

        $.get('/api/getOrders/");
#nullable restore
#line 204 "D:\ServeIt\ServeIt\Web\ServeIt.Web\Views\Restaurants\Edit.cshtml"
                         Write(Model.RestaurantId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', (data) => {
            var a = document.getElementById(""orders"");
            console.log(a);
            for (var i = 0; i < data.length; i++) {
                var type;
                if (data[0].isItPayed == false) {
                    type = 'waiting';
                }
                else {
                    type = 'done';
                }
                $(""#orders"").append(
                    '<div class=""col-lg-6 menu-item filter-' + type + '"">'
                    + '<div class=""menu-content"">'
                    + '<a href=""/Orders/OrderedItems/' + data[i].orderId + '""  > Order: ' + data[i].orderId + '</a>'
                    + '<span>' + (data[i].amount).toFixed(2) + '$</span>'
                    + '</div>'
                    + ' <div class=""menu-ingredients"">'
                    + '<p class=""col-sm-8"">Name: ' + data[i].fullName + '</p>'
                    + '<p class=""col-sm-8"">Phone: ' + data[i].phone + '</p>'
                    + '<p class=""col-sm-8"">Street");
            WriteLiteral(@": ' + data[i].street + '</p>'
                    + '<p class=""col-sm-8"">Email: ' + data[i].email + '<p>'
                    + '<p class=""col-sm-8"">Date: ' + data[i].date + '<p>'
                    + ' <p class=""col-sm-8"">Hour: ' + data[i].hour + '<p>'
                    + '</div>'
                    + '</div>');
            }

        })


    


    





    $(document).ready(setTimeout(GetAllOrders()
        , 2000));


</script>







");
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
