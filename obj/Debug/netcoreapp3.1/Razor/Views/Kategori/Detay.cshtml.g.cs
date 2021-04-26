#pragma checksum "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e3a87d2d28ff3f6105e3717b248a82e233b91d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kategori_Detay), @"mvc.1.0.view", @"/Views/Kategori/Detay.cshtml")]
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
#line 1 "C:\Users\berka\source\repos\DAboneTakip\Views\_ViewImports.cshtml"
using DAboneTakip;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\berka\source\repos\DAboneTakip\Views\_ViewImports.cshtml"
using DAboneTakip.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
using DergiAboneProje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e3a87d2d28ff3f6105e3717b248a82e233b91d9", @"/Views/Kategori/Detay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3da3daaf701e9a129f2e18589ab3a9a401fbd2ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Kategori_Detay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Dergiler>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
  
    ViewData["Title"] = @ViewBag.kategoriad + " Kategorisindeki Dergiler || Kategori ID: " + @ViewBag.ktgid;
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div>

    <script>
        $(document).ready(function () {
            $('#DergiTable').DataTable({
                ""language"": {
                    ""url"": ""//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json""
                }
            });
        });
    </script>

    <br />
    
    <table id=""DergiTable"" class=""row-border stripe hover table-bordered"">
        <thead>
            <tr>
                <th>Dergi ID</th>
                <th>Dergi Adı</th>
");
            WriteLiteral("                <th>Dergi Kayıt Tarih</th>\r\n                <th>Düzenle</th>\r\n                <th>Sil</th>\r\n                <th>Detaylar</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 36 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
             foreach (var x in Model)
            {   

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 39 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
               Write(x.DergiID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
               Write(x.DergiAD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                <td>");
#nullable restore
#line 42 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
               Write(x.DergiTARIH.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1234, "\"", 1266, 2);
            WriteAttributeValue("", 1241, "/Dergi/Duzenle/", 1241, 15, true);
#nullable restore
#line 43 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
WriteAttributeValue("", 1256, x.DergiID, 1256, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Düzenle</a></td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1332, "\"", 1360, 2);
            WriteAttributeValue("", 1339, "/Dergi/Sil/", 1339, 11, true);
#nullable restore
#line 44 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
WriteAttributeValue("", 1350, x.DergiID, 1350, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1421, "\"", 1451, 2);
            WriteAttributeValue("", 1428, "/Dergi/Detay/", 1428, 13, true);
#nullable restore
#line 45 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
WriteAttributeValue("", 1441, x.DergiID, 1441, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Detaylar</a></td>\r\n            </tr>\r\n");
#nullable restore
#line 47 "C:\Users\berka\source\repos\DAboneTakip\Views\Kategori\Detay.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tbody>\r\n\r\n    </table>\r\n    \r\n    \r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Dergiler>> Html { get; private set; }
    }
}
#pragma warning restore 1591
