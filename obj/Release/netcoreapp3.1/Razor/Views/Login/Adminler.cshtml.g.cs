#pragma checksum "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d053111ad155cac505f39c1de726e54683417801"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d053111ad155cac505f39c1de726e54683417801", @"/Views/Login/Adminler.cshtml")]
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
                    <th>Düzenle</th>
                    <th>Sil</th>
                </tr>
            </thead>

");
#nullable restore
#line 26 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
             foreach (var x in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                   Write(x.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
                   Write(x.KullaniciAD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <input type=\"password\" disabled=\"disabled\"");
            BeginWriteAttribute("value", " value=\"", 829, "\"", 845, 1);
#nullable restore
#line 32 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 837, x.Sifre, 837, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 846, "\"", 865, 3);
            WriteAttributeValue("", 851, "MyInput(", 851, 8, true);
#nullable restore
#line 32 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 859, x.ID, 859, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 864, ")", 864, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />  <input type=\"checkbox\" class=\"w3-check\"");
            BeginWriteAttribute("onclick", " onclick=\"", 910, "\"", 937, 3);
            WriteAttributeValue("", 920, "myFunction(", 920, 11, true);
#nullable restore
#line 32 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 931, x.ID, 931, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 936, ")", 936, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 994, "\"", 1021, 2);
            WriteAttributeValue("", 1001, "/Login/Duzenle/", 1001, 15, true);
#nullable restore
#line 34 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 1016, x.ID, 1016, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Düzenle</a></td>\r\n                    <td><a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1100, "\"", 1124, 3);
            WriteAttributeValue("", 1110, "Confirm(", 1110, 8, true);
#nullable restore
#line 35 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
WriteAttributeValue("", 1118, x.ID, 1118, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1123, ")", 1123, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger ksilbtn\">Sil</a></td>\r\n    \r\n\r\n                </tr>\r\n");
#nullable restore
#line 39 "C:\Users\berka\source\repos\dergi-abone-takip-sistemi\Views\Login\Adminler.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </table>
        <a href=""/Login/AdminEkle/"" class=""btn btn-success"">Yeni Admin Ekle</a>
    </div>

    <script>
        //şifre göster gizle
        function myFunction(id) {
            var x = document.getElementById(""MyInput("" + id + "")"");
            if (x.type === ""password"") {
                x.type = ""text"";
            } else {
                x.type = ""password"";
            }
        }
         //sweetalert ile  silme işlemi onayı
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
                            title: ""Hesap si");
            WriteLiteral(@"lme işlemi başarılı!"",
                            icon: ""success"",
                            buttons: ""Tamam"",
                        }).then(value => {
                            window.location.href = ""/Login/Adminler/"";
                        });
                    }

                });
        }
         //datatables JS kütüphanesi kullanıldı ve türkçe arayüz yüklendi
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
