#pragma checksum "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c319ec083a5dc7516871a02d7af4e0fb6368f46e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WalletManagement_SelfOrder), @"mvc.1.0.view", @"/Views/WalletManagement/SelfOrder.cshtml")]
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
#line 1 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\_ViewImports.cshtml"
using ALOS_Web_Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\_ViewImports.cshtml"
using ALOS_Web_Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
using Microsoft.CodeAnalysis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
using ALOS_Web_Admin.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c319ec083a5dc7516871a02d7af4e0fb6368f46e", @"/Views/WalletManagement/SelfOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fd62b964d76cc667954a39adebc40b01569649a", @"/Views/_ViewImports.cshtml")]
    public class Views_WalletManagement_SelfOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- DataTables -->
<link rel=""stylesheet"" href=""/Admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"">
<link rel=""stylesheet"" href=""/Admin/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"">
<link rel=""stylesheet"" href=""/Admin/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"">
<link href=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css"" rel=""stylesheet"" />
<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"">
    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <!-- Small boxes (Stat box) -->
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""card card-primary"">
                        <div class=""card-header"">
                            <h3 class=""card-title"">Self Order</h3>
                        </div>
                        <!-- /.card-header -->
                        <!-- form start -->
         ");
            WriteLiteral("               ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c319ec083a5dc7516871a02d7af4e0fb6368f46e5343", async() => {
                WriteLiteral("\r\n                            <div class=\"card-body\">\r\n");
#nullable restore
#line 27 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                 if (ViewContext.ViewData.ModelState.ContainsKey("User"))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""alert alert-danger alert-dismissible fade show"">
                                        <button type=""button"" class=""close"" data-dismiss=""alert"">&times;</button>
                                        <strong>");
#nullable restore
#line 31 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                           Write(Html.ValidationMessage("User", "", new { @class = "text-default" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                    </div>\r\n");
#nullable restore
#line 33 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                 if (ViewBag.Message != null)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""alert alert-success alert-dismissible fade show"">
                                        <button type=""button"" class=""close"" data-dismiss=""alert"">&times;</button>
                                        <strong>");
#nullable restore
#line 38 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                           Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                    </div>\r\n");
#nullable restore
#line 40 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <div class=""form-group col-sm-4 float-left"">
                                    <div class=""col"">
                                        <label for=""user"">Order Amount <strong class=""text-danger"">*</strong></label>
                                        <input type=""number"" class=""form-control"" id=""amount"" name=""amount"" required>
                                    </div>
                                </div>
                                <div class=""form-group col-sm-4 float-left"">
                                    <div class=""col"">
                                        <label for=""user"">Order Remarks <strong class=""text-danger"">*</strong></label>
                                        <input type=""text"" class=""form-control"" name=""remark"" required>
                                    </div>
                                </div>


                                <div class=""form-group col-sm-4 float-left"">
                                    <div clas");
                WriteLiteral(@"s=""col"">
                                        <label>Action</label>
                                        <button type=""submit"" id=""submit"" class=""btn btn-primary"" style=""width: 100%"">Submit</button>
                                    </div>


                                </div>
                            </div>


                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 25 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\WalletManagement\SelfOrder.cshtml"
AddHtmlAttributeValue("", 1174, Url.Action("SelfOrder","WalletManagement"), 1174, 43, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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


                <!-- /.row -->
                <!-- Main row -->
                <!-- /.row (main row) -->
            </div><!-- /.container-fluid -->
        </div>
    </section>
    <!-- /.content -->
</div>

");
            DefineSection("dataTableScripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js""></script>
    <script>
        $(document).ready(function () {
            $('.js-example-basic-single').select2();
        });
    </script>
    <!-- Bootstrap 4 -->
    <script src=""/Admin/plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
    <!-- DataTables  & Plugins -->
    <script src=""/Admin/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/Admin/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script src=""/Admin/plugins/datatables-responsive/js/dataTables.responsive.min.js""></script>
    <script src=""/Admin/plugins/datatables-responsive/js/responsive.bootstrap4.min.js""></script>
    <script src=""/Admin/plugins/datatables-buttons/js/dataTables.buttons.min.js""></script>
    <script src=""/Admin/plugins/datatables-buttons/js/buttons.bootstrap4.min.js""></script>
    <script src=""/Admin/plugins/jszip/jszip.min.js""></script>
    <script src=""/Admin/plug");
                WriteLiteral(@"ins/pdfmake/pdfmake.min.js""></script>
    <script src=""/Admin/plugins/pdfmake/vfs_fonts.js""></script>
    <script src=""/Admin/plugins/datatables-buttons/js/buttons.html5.min.js""></script>
    <script src=""/Admin/plugins/datatables-buttons/js/buttons.print.min.js""></script>
    <script src=""/Admin/plugins/datatables-buttons/js/buttons.colVis.min.js""></script>
    <script src=""https://cdn.jsdelivr.net/gh/gitbrent/bootstrap-switch-button@1.1.0/dist/bootstrap-switch-button.min.js""></script>
    <!-- AdminLTE App -->
    <script src=""/Admin/dist/js/adminlte.min.js""></script>
    <!-- AdminLTE for demo purposes -->
    <script src=""/Admin/dist/js/demo.js""></script>
    <!-- Page specific script -->
    <script>
        $(function () {
            $(""#example1"").DataTable({
                ""responsive"": true, ""lengthChange"": false, ""autoWidth"": false,
                ""buttons"": [""copy"", ""csv"", ""excel"", ""pdf"", ""print"", ""colvis""]
            }).buttons().container().appendTo('#example1_wrapper .col-md-");
                WriteLiteral(@"6:eq(0)');
            $('#example2').DataTable({
                ""paging"": true,
                ""lengthChange"": false,
                ""searching"": false,
                ""ordering"": true,
                ""info"": true,
                ""autoWidth"": false,
                ""responsive"": true,
            });
        });
    </script>
");
            }
            );
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