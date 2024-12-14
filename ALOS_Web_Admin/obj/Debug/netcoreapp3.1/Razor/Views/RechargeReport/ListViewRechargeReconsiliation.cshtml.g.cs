#pragma checksum "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ad000766574de45d4b1373e3be8a7cdc92cefed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RechargeReport_ListViewRechargeReconsiliation), @"mvc.1.0.view", @"/Views/RechargeReport/ListViewRechargeReconsiliation.cshtml")]
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
#line 1 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
using Microsoft.CodeAnalysis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
using ALOS_Web_Admin.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ad000766574de45d4b1373e3be8a7cdc92cefed", @"/Views/RechargeReport/ListViewRechargeReconsiliation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fd62b964d76cc667954a39adebc40b01569649a", @"/Views/_ViewImports.cshtml")]
    public class Views_RechargeReport_ListViewRechargeReconsiliation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
  
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
                            <h3 class=""card-title"">List View</h3>
                        </div>

");
#nullable restore
#line 24 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                         if (ViewBag.Transactions != null)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""card"">
                                <!-- /.card-header -->
                                <div class=""card-body"">
                                    <table id=""example1"" class=""table table-bordered table-striped"">
                                        <thead>
                                            <tr>
                                                <th>Trn Date</th>
                                                <th>Trn No </th>
                                                <th>Source</th> 
                                                <th>User ID </th> 
                                                <th>Firm</th> 
                                                <th>Provider</th> 
                                                <th>Cust No</th>
                                                <th>Amount</th>
                                                <th>Status</th>
                                                <th>Opr ID</th>
  ");
            WriteLiteral("                                              <th>API Name</th> \r\n                                            </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                             foreach (var trans in ViewBag.Transactions)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                               <tr>\r\n                                                    <td>");
#nullable restore
#line 50 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.TrnDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 51 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.TrnNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 52 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.Source);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 53 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 54 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.Firm);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 55 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.Provider);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 56 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.CustomerNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 57 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 58 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 59 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.OprId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 60 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                                   Write(trans.ApiName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 62 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </tbody>\r\n                                    </table>\r\n                                </div>\r\n                                <!-- /.card-body -->\r\n                            </div>\r\n");
#nullable restore
#line 69 "C:\Users\Niaz-PC\source\repos\ALOS_Web_API\ALOS_Web_Admin\Views\RechargeReport\ListViewRechargeReconsiliation.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>

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
        function deleteConfirm() {
            var message = confirm('Are sure to delete member ?');
            if (message) {
                return true;
            } else {
                return false;
            }
        }
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