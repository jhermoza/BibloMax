#pragma checksum "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebce50003fdbd098186a03cd8ad816c30e6786ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Complejos_SOComplejos), @"mvc.1.0.razor-page", @"/Pages/Complejos/SOComplejos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Complejos/SOComplejos.cshtml", typeof(AspNetCore.Pages_Complejos_SOComplejos), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebce50003fdbd098186a03cd8ad816c30e6786ab", @"/Pages/Complejos/SOComplejos.cshtml")]
    public class Pages_Complejos_SOComplejos : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/complejos/complejos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(109, 39, true);
            WriteLiteral("\r\n<input type=\"hidden\" id=\"__URL_SEDES\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 148, "\"", 190, 1);
#line 7 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 156, Url.Action("ObtenerSedes","Sede"), 156, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(191, 46, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"__URL_COMPLEJOS\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 237, "\"", 287, 1);
#line 8 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 245, Url.Action("ObtenerComplejos","Complejo"), 245, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(288, 44, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"__URL_DETALLE\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 332, "\"", 381, 1);
#line 9 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 340, Url.Action("DetalleComplejo","Complejo"), 340, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(382, 45, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"__URL_ELIMINAR\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 427, "\"", 477, 1);
#line 10 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 435, Url.Action("EliminarComplejo","Complejo"), 435, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(478, 45, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"__URL_REGISTRO\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 523, "\"", 574, 1);
#line 11 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 531, Url.Action("RegistrarComplejo","Complejo"), 531, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(575, 49, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"__ID_ACTUAL\" />\r\n\r\n");
            EndContext();
            DefineSection("PageHeader", async() => {
                BeginContext(644, 226, true);
                WriteLiteral("\r\n    <header class=\"masthead mb-auto\">\r\n        <div class=\"inner\">\r\n            <h3 class=\"masthead-brand\">BibloMax</h3>\r\n            <nav class=\"nav nav-masthead justify-content-center\">\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 870, "\"", 908, 1);
#line 19 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 877, Url.Page("/Principal/SOIndex"), 877, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(909, 48, true);
                WriteLiteral(">Inicio</a>\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 957, "\"", 991, 1);
#line 20 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 964, Url.Page("/Sedes/SOSedes"), 964, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(992, 54, true);
                WriteLiteral(">Sedes</a>\r\n                <a class=\"nav-link active\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1046, "\"", 1088, 1);
#line 21 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 1053, Url.Page("/Complejos/SOComplejos"), 1053, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1089, 51, true);
                WriteLiteral(">Complejos</a>\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1140, "\"", 1181, 1);
#line 22 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Complejos\SOComplejos.cshtml"
WriteAttributeValue("", 1147, Url.Page("/Principal/SONosotros"), 1147, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1182, 66, true);
                WriteLiteral(">Nosotros</a>\r\n            </nav>\r\n        </div>\r\n    </header>\r\n");
                EndContext();
            }
            );
            BeginContext(1251, 339, true);
            WriteLiteral(@"
<main role=""main"" class=""inner cover"">

    <div class=""d-flex flex-wrap bg-light text-dark text-left"" style=""margin-bottom:5%; padding:15px;"">

        <div class=""form-group col-12"">
            <h3>Complejos</h3>
        </div>

        <div class=""form-group col-lg-6 col-sm-12"">
            <label for=""pwd"">Sede:</label>
");
            EndContext();
            BeginContext(1682, 1562, true);
            WriteLiteral(@"            <select class=""form-control"" id=""cboSede"">
                <option value=""0"">Seleccione</option>
            </select>
        </div>

        <div class=""form-group col-lg-6 col-sm-12"">
            <label for=""email"">Localidad:</label>
            <input type=""text"" class=""form-control"" id=""txtLocalidad"" placeholder=""Localidad"">
        </div>

        <div class=""form-group col-lg-6 col-sm-12"">
            <label for=""pwd"">Jefe:</label>
            <input type=""text"" class=""form-control"" id=""txtJefe"" placeholder=""Jefe"">
        </div>

        <div class=""form-group col-lg-6 col-sm-12"">
            <label for=""email"">N° Areas:</label>
            <input type=""number"" class=""form-control"" id=""txtAreas"" placeholder=""N° Areas"">
        </div>

        <div class=""d-flex flex-wrap flex-row-reverse col-12"">
            <button type=""button"" class=""m-1 col-lg-3 col-12 btn btn-dark btn-block"" id=""btnGuardar"">Guardar</button>
            <button type=""button"" class=""m-1 col-lg-3 co");
            WriteLiteral(@"l-12 btn btn-dark btn-block"" id=""btnLimpiar"">Limpiar</button>
        </div>
    </div>

    <table id=""example"" class=""display"" style=""width:100%"">
        <thead class=""bg-dark"">
            <tr>
                <th scope=""col"">Sede</th>
                <th scope=""col"">Localidad</th>
                <th scope=""col"">Jefe</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody style=""background-color: rgba(0,0,0,0.3);"" class=""text-dark"">
        </tbody>
    </table>

</main>

");
            EndContext();
            DefineSection("Javascript", async() => {
                BeginContext(3264, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3270, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e06bf6728b14ffdb77b5e2f17a01cb9", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3321, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hermoza.BibloMax.Integracion.Pages.Complejos.SOComplejosModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hermoza.BibloMax.Integracion.Pages.Complejos.SOComplejosModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hermoza.BibloMax.Integracion.Pages.Complejos.SOComplejosModel>)PageContext?.ViewData;
        public Hermoza.BibloMax.Integracion.Pages.Complejos.SOComplejosModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
