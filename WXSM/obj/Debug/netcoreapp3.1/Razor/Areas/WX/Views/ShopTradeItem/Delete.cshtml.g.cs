#pragma checksum "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_WX_Views_ShopTradeItem_Delete), @"mvc.1.0.view", @"/Areas/WX/Views/ShopTradeItem/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef7", @"/Areas/WX/Views/ShopTradeItem/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571771ad2524a5b15bad41ff1d0a67772ba5508c", @"/Areas/_ViewImports.cshtml")]
    public class Areas_WX_Views_ShopTradeItem_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WXSM.ViewModel.WX.ShopTradeItemVMs.ShopTradeItemVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("text", "删除", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.QuoteTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_QuoteTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.RowTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_RowTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.HiddenTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_HiddenTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.SubmitButtonTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper;
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.CloseButtonTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_CloseButtonTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef74240", async() => {
                WriteLiteral("\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:quote", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef74501", async() => {
#nullable restore
#line 5 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
         Write(Model.Localizer["DeleteConfirm"]);

#line default
#line hidden
#nullable disable
                }
                );
                __WalkingTec_Mvvm_TagHelpers_LayUI_QuoteTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.QuoteTagHelper>();
                __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_QuoteTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:row", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef75672", async() => {
                    WriteLiteral("\r\n");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef75940", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 7 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.outItemId);

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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef77493", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 8 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.item.barcode);

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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef79049", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 9 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.salePrice);

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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef710602", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 10 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.listPrice);

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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef712157", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 11 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.purchaseQuantity);

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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:display", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef713719", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.DisplayTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper);
#nullable restore
#line 12 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_DisplayTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.Order.outerTrade);

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
#line 6 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef716484", async() => {
                }
                );
                __WalkingTec_Mvvm_TagHelpers_LayUI_HiddenTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.HiddenTagHelper>();
                __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_HiddenTagHelper);
#nullable restore
#line 14 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_HiddenTagHelper.Field = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Entity.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("field", __WalkingTec_Mvvm_TagHelpers_LayUI_HiddenTagHelper.Field, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:row", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef717972", async() => {
                    WriteLiteral("\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:submitbutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef718247", async() => {
                    }
                    );
                    __WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.SubmitButtonTagHelper>();
                    __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper);
#nullable restore
#line 16 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper.Theme =  ButtonThemeEnum.Warm;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("theme", __WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper.Theme, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __WalkingTec_Mvvm_TagHelpers_LayUI_SubmitButtonTagHelper.Text = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:closebutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ea89b4a02b1d4816c6da3c79ff94972aa1c5ef719986", async() => {
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
#line 15 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
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
#line 4 "D:\Users\admin\Source\Repos\WXSM\WXSM\Areas\WX\Views\ShopTradeItem\Delete.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WXSM.ViewModel.WX.ShopTradeItemVMs.ShopTradeItemVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
