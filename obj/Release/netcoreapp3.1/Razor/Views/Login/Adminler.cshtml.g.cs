#pragma checksum "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "baadb86e52fface67f5afaa844bbccb4550c3d7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Adminler), @"mvc.1.0.view", @"/Views/Login/Adminler.cshtml")]
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
#nullable restore
#line 1 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
using DergiAboneProje.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
using DergiAboneProje.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"baadb86e52fface67f5afaa844bbccb4550c3d7c", @"/Views/Login/Adminler.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3da3daaf701e9a129f2e18589ab3a9a401fbd2ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Adminler : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Admin>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
  
    ViewData["Title"] = "Adminler" + ViewBag.UID;
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div>


    <div>
        <table id=""AdminTable"" class=""row-border stripe hover table-bordered"">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Kullanıcı Adı</th>
                    <th>Şifre</th>
                    <th>Rol</th>
                    <th>Düzenle</th>
                    <th>Sil</th>
                </tr>
            </thead>

");
#nullable restore
#line 27 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
             foreach (var x in Model)
            {
                if (x.Rol == "O") continue;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                   Write(x.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                   Write(x.KullaniciAD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <input type=\"password\" disabled=\"disabled\"");
            BeginWriteAttribute("value", " value=\"", 908, "\"", 924, 1);
#nullable restore
#line 34 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 916, x.Sifre, 916, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 925, "\"", 944, 3);
            WriteAttributeValue("", 930, "MyInput(", 930, 8, true);
#nullable restore
#line 34 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 938, x.ID, 938, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 943, ")", 943, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />  <input type=\"checkbox\" class=\"w3-check\"");
            BeginWriteAttribute("onclick", " onclick=\"", 989, "\"", 1016, 3);
            WriteAttributeValue("", 999, "myFunction(", 999, 11, true);
#nullable restore
#line 34 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 1010, x.ID, 1010, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1015, ")", 1015, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 37 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                         if (x.Rol == "A")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label>Admin</label>\r\n");
#nullable restore
#line 40 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                        }
                        else if (x.Rol == "U")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label>User</label>\r\n");
#nullable restore
#line 44 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1425, "\"", 1452, 2);
            WriteAttributeValue("", 1432, "/Login/Duzenle/", 1432, 15, true);
#nullable restore
#line 46 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 1447, x.ID, 1447, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Düzenle</a></td>\r\n                    <td><a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1531, "\"", 1555, 3);
            WriteAttributeValue("", 1541, "Confirm(", 1541, 8, true);
#nullable restore
#line 47 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 1549, x.ID, 1549, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1554, ")", 1554, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger ksilbtn\">Sil</a></td>\r\n\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 52 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n        <a href=\"/Login/AdminEkle/\" class=\"btn btn-success\">Yeni Admin Ekle</a>\r\n    </div>\r\n\r\n");
            WriteLiteral(@"
    <script>
        function myFunction(id) {
            var x = document.getElementById(""MyInput("" + id + "")"");
            if (x.type === ""password"") {
                x.type = ""text"";
            } else {
                x.type = ""password"";
            }
        }
        function Confirm(id) {
            swal({
                title: ""Silmek istediğinize emin misiniz ?"",
                text: ""(ID: "" + id + "")"",
                icon: ""warning"",
                buttons: {
                    cancel: ""Hayır"",
                    true: ""Evet"",
                },
            })
                .then((willDelete) => {
                    if (willDelete) {
                        window.location.href = ""/Login/Sil/"" + id;
                        swal({
                            title: ""Hesap silme işlemi başarılı!"",
                            icon: ""success"",
                            buttons: ""Tamam"",
                        }).then(value => {
                            w");
            WriteLiteral(@"indow.location.href = ""/Login/Adminler/"";
                        });
                    }

                });
        }

        $(document).ready(function () {
            $('#AdminTable').DataTable({
                ""language"": {
                    ""url"": ""//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json""
                }
            });
        });

    </script>
</div>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Admin>> Html { get; private set; }
    }
}
#pragma warning restore 1591