#pragma checksum "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe8bbc43680a3d16a5314ef284ed3956fc0fc1fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Eventos_SOEvento), @"mvc.1.0.razor-page", @"/Pages/Eventos/SOEvento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Eventos/SOEvento.cshtml", typeof(AspNetCore.Pages_Eventos_SOEvento), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe8bbc43680a3d16a5314ef284ed3956fc0fc1fe", @"/Pages/Eventos/SOEvento.cshtml")]
    public class Pages_Eventos_SOEvento : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(104, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("PageHeader", async() => {
                BeginContext(132, 226, true);
                WriteLiteral("\r\n    <header class=\"masthead mb-auto\">\r\n        <div class=\"inner\">\r\n            <h3 class=\"masthead-brand\">BibloMax</h3>\r\n            <nav class=\"nav nav-masthead justify-content-center\">\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 358, "\"", 396, 1);
#line 15 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
WriteAttributeValue("", 365, Url.Page("/Principal/SOIndex"), 365, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(397, 48, true);
                WriteLiteral(">Inicio</a>\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 445, "\"", 479, 1);
#line 16 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
WriteAttributeValue("", 452, Url.Page("/Sedes/SOSedes"), 452, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(480, 47, true);
                WriteLiteral(">Sedes</a>\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 527, "\"", 569, 1);
#line 17 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
WriteAttributeValue("", 534, Url.Page("/Complejos/SOComplejos"), 534, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(570, 58, true);
                WriteLiteral(">Complejos</a>\r\n                <a class=\"nav-link active\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 628, "\"", 666, 1);
#line 18 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
WriteAttributeValue("", 635, Url.Page("/Eventos/SOEventos"), 635, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(667, 49, true);
                WriteLiteral(">Eventos</a>\r\n                <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 716, "\"", 757, 1);
#line 19 "E:\USB_SOY50GB\BibloMax\Hermoza.BibloMax.Integracion\Pages\Eventos\SOEvento.cshtml"
WriteAttributeValue("", 723, Url.Page("/Principal/SONosotros"), 723, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(758, 66, true);
                WriteLiteral(">Nosotros</a>\r\n            </nav>\r\n        </div>\r\n    </header>\r\n");
                EndContext();
            }
            );
            BeginContext(827, 446, true);
            WriteLiteral(@"
<main role=""main"" class=""inner cover"">
    <h1 class=""cover-heading"">Te ayudaremos con la gestión de los complejos.</h1>
    <p class=""lead"">
        Puedes revisar los eventos programados a la fecha, cambiar la fecha de estos de ser necesario, registrar nuevos complejos o la apertura de nuevas instalaciones en estos.
    </p>
    <p class=""lead"">
        <a href=""#"" class=""btn btn-lg btn-secondary"">Learn more</a>
    </p>
</main>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hermoza.BibloMax.Integracion.Pages.Eventos.SOEventoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hermoza.BibloMax.Integracion.Pages.Eventos.SOEventoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hermoza.BibloMax.Integracion.Pages.Eventos.SOEventoModel>)PageContext?.ViewData;
        public Hermoza.BibloMax.Integracion.Pages.Eventos.SOEventoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
