#pragma checksum "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbf06cee99f07676b21a9dee5d1bfe53472d5590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\_ViewImports.cshtml"
using DAboneTakip;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\_ViewImports.cshtml"
using DAboneTakip.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbf06cee99f07676b21a9dee5d1bfe53472d5590", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3da3daaf701e9a129f2e18589ab3a9a401fbd2ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ChartScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/web/css/jqvmap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("screen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cbf06cee99f07676b21a9dee5d1bfe53472d55904897", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Anasayfa";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <!-- Custom Theme files -->
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""keywords"" content=""Metro Panel Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template,
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design"" />
    <script type=""application/x-javascript""> addEventListener(""load"", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfont-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cbf06cee99f07676b21a9dee5d1bfe53472d55907139", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div>\r\n\r\n        <div class=\"total-content\">\r\n            <div class=\"list_of_members\">\r\n                <div class=\"sales\" style=\"background-color:#1abc9c\">\r\n  \r\n                    <div class=\"icon-text\">\r\n                        <h3>");
#nullable restore
#line 25 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_uye);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Üye Sayısı</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""new-users"" style=""background-color:#2ecc71"">
                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 32 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_abone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Toplam Abonelik Kaydı</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""orders"" style=""background-color:#3498db"">

                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 40 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_dergi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Dergi Sayısı</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""visitors"" style=""background-color:#9b59b6"">
                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 47 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_kategori);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Kategori Sayısı</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""clearfix""></div>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""total-content"">
            <div class=""list_of_members"">
                <div class=""sales"" style=""background-color:#16a085"">
                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 60 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_aktifabone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Aktif Abonelikler</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""new-users"" style=""background-color:#27ae60"">
                    <div class=""icon-text "" >
                        <h3>");
#nullable restore
#line 67 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                        Write(ViewBag.count_abone - ViewBag.count_aktifabone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Pasif Abonelikler</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""orders"" style=""background-color:#2980b9"">

                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 75 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.bugun_eklenen);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Bugün Eklenen Abonelikler</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""visitors"" style=""background-color:#8e44ad"">

                    <div class=""icon-text"">
                        <h3>");
#nullable restore
#line 83 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                       Write(ViewBag.count_bitecek);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p>Yakında Bitecek Abonelikler</p>
                    </div>
                    <div class=""clearfix""></div>
                </div>
                <div class=""clearfix""></div>
            </div>
        </div>
</div>

        <div class=""row"">
            <div id=""KategoriChart"" style=""margin:auto""></div>
            <div id=""DergiChart"" style=""margin:auto""></div>
            <div id=""AbonelikChart""></div>
            <div id=""UyelerChart""></div>
        </div>

        <script>
            $(document).ready(function () {
                $.ajax({
                type: ""GET"",
                dataType: ""json"",
                contentType: ""application/json"",
                url: '");
#nullable restore
#line 106 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                 Write(Url.Action("VKategoriChart", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                success: function (result) {
                    google.charts.load('current', {
                        'packages': ['corechart']
                    });
                    google.charts.setOnLoadCallback(function () {
                        drawChart(result);
                    });
                }
            });

                $.ajax({
                type: ""GET"",
                dataType: ""json"",
                contentType: ""application/json"",
                url: '");
#nullable restore
#line 121 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                 Write(Url.Action("VDergiChart", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                success: function (result2) {
                    google.charts.load('current', {
                        'packages': ['corechart']
                    });
                    google.charts.setOnLoadCallback(function () {
                        drawChart2(result2);
                    });
                }
            });

                $.ajax({
                type: ""GET"",
                dataType: ""json"",
                contentType: ""application/json"",
                url: '");
#nullable restore
#line 136 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Home\Index.cshtml"
                 Write(Url.Action("VDergiChart", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                success: function (result2) {
                    google.charts.load('current', {
                        'packages': ['corechart']
                    });
                    google.charts.setOnLoadCallback(function () {
                        drawChart2(result2);
                    });
                }
            });
        });

             
    function drawChart(result) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Kategori');
            data.addColumn('number', 'Dergi Sayısı');
            var dataArray = [];

            $.each(result, function (i, obj) {
                dataArray.push([obj.kategori, obj.dergisayi]);
            });
            data.addRows(dataArray);

            var columnChartOptions = {
                title: ""Kategori - Dergi Sayısı Grafiği"",
                width: 600,
                height: 400,
                bar: { groupWidth: ""20%"" },
            };

        var c");
            WriteLiteral(@"olumnChart = new google.visualization.PieChart(document.getElementById('KategoriChart'));

            columnChart.draw(data, columnChartOptions);
    }


           
    function drawChart2(result2) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Dergi');
        data.addColumn('number', 'Abone Sayısı');
        var dataArray2 = [];

        $.each(result2, function (i, obj) {
            dataArray2.push([obj.dergi, obj.abonesayi]);
        });
        data.addRows(dataArray2);

        var columnChartOptions = {
            title: ""Dergi - Aktif Abone Sayısı Grafiği"",
            width: 600,
            height: 400,
            bar: { groupWidth: ""20%"" },
        };

        var columnChart = new google.visualization.PieChart(document.getElementById('DergiChart'));

        columnChart.draw(data, columnChartOptions);
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
