#pragma checksum "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d56703eff054bb2a95d03b4c3851d55cab334e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_SysPar_Details), @"mvc.1.0.view", @"/Areas/System/Views/SysPar/Details.cshtml")]
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
#line 1 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\_ViewImports.cshtml"
using WalkingTec.Mvvm.TagHelpers.LayUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d56703eff054bb2a95d03b4c3851d55cab334e6", @"/Areas/System/Views/SysPar/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571771ad2524a5b15bad41ff1d0a67772ba5508c", @"/Areas/_ViewImports.cshtml")]
    public class Areas_System_Views_SysPar_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WXSM.ViewModel.System.SysParVMs.SysParVM>
    {
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
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.FormTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_FormTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.RowTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.CloseButtonTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_CloseButtonTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d56703eff054bb2a95d03b4c3851d55cab334e63541", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:row", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d56703eff054bb2a95d03b4c3851d55cab334e63802", async() => {
                    WriteLiteral("\r\n");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d56703eff054bb2a95d03b4c3851d55cab334e64070", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 6 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.parTitle);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("field", __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d56703eff054bb2a95d03b4c3851d55cab334e65620", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 7 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.parValue);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("field", __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d56703eff054bb2a95d03b4c3851d55cab334e67170", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 8 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.remark);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("field", __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
                }
                );
                __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.RowTagHelper>();
                __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper);
#nullable restore
#line 5 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper.ItemsPerRow = ItemsPerRowEnum.Two;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("items-per-row", __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper.ItemsPerRow, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:row", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d56703eff054bb2a95d03b4c3851d55cab334e69919", async() => {
                    WriteLiteral("\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:closebutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d56703eff054bb2a95d03b4c3851d55cab334e610193", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_CloseButtonTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.CloseButtonTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_CloseButtonTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n    ");
                }
                );
                __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.RowTagHelper>();
                __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper);
#nullable restore
#line 10 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper.Align = AlignEnum.Right;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("align", __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper.Align, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            __WalkingTec_Mvvm_TagHelpers_LayUI_FormTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.FormTagHelper>();
            __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_FormTagHelper);
#nullable restore
#line 4 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\System\Views\SysPar\Details.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_FormTagHelper.Vm = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("vm", __WalkingTec_Mvvm_TagHelpers_LayUI_FormTagHelper.Vm, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<WalkingTec.Mvvm.Core.Program> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WXSM.ViewModel.System.SysParVMs.SysParVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
