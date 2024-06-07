#pragma checksum "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a155921dd6b76129b3cc5d621bd6ce2e1d69538"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_OrganisationList_OrganisationList), @"mvc.1.0.view", @"/Areas/Admin/Views/OrganisationList/OrganisationList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a155921dd6b76129b3cc5d621bd6ce2e1d69538", @"/Areas/Admin/Views/OrganisationList/OrganisationList.cshtml")]
    public class Areas_Admin_Views_OrganisationList_OrganisationList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductMate.Areas.Admin.Models.OrganisationListGrid>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/ApplevelCSS/OrganisationList_CSS.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--Import Layout in every page.-->\r\n");
#nullable restore
#line 3 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a155921dd6b76129b3cc5d621bd6ce2e1d695383874", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<!--Form Heading Section-->
<h3 class=""uk-heading-line uk-text-center""><span>Organisation List</span></h3>

<!--Button Section-->
<hr class=""uk-divider-icon"">
<div class=""uk-margin"">
    <button class=""uk-button uk-button-primary uk-button-small uk-margin-small-left uk-margin-small-right""
            id=""btnUpdate"">
        Update
    </button>
    <button class=""uk-button uk-button-danger uk-button-small uk-margin-small-left uk-margin-small-right""
            id=""btnDelete"">
        Delete
    </button>
</div>

<hr class=""uk-divider-icon"">

<!--Table Section-->
<div id=""tblOrganisationList"">
    <table id=""OrganisationList"">
        <thead>
            <tr>
                <th><!--Checkbox--></th>
                <th>Organisation Name</th>
                <th>Delegate Name</th>
                <th>Contract From Date</th>
                <th>Contract To Date</th>
                <th>Create Date</th>
                <th>Created By</th>
                <th>Status</th>
        ");
            WriteLiteral("    </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 42 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
             if(Model != null)
            {
                if(Model.Count() != 0)
                {
                    foreach(var clsOrganisationListGrid in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td><input type=\"checkbox\" class=\"uk-checkbox\" id=\"chkOrganisationId\" name=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 1644, "\"", 1694, 1);
#nullable restore
#line 49 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
WriteAttributeValue("", 1652, clsOrganisationListGrid.intOrganisationId, 1652, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                            <td>");
#nullable restore
#line 50 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.strOrganisationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.strDelegateName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 52 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.dteContractFromDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.dteContractToDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.dteContractToDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 55 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.strCreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 56 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                           Write(clsOrganisationListGrid.strStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 58 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td rowspan=\"8\">Currently no Organisation present</td>\r\n                    </tr>\r\n");
#nullable restore
#line 65 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script type=""text/javascript"">

    //Common function to select single checkbox at a time.
    $(""input:checkbox"").on('click', function () {
        // in the handler, 'this' refers to the box clicked on
        var $box = $(this);
        if ($box.is("":checked"")) {
            // the name of the box is retrieved using the .attr() method
            // as it is assumed and expected to be immutable
            var group = ""input:checkbox[name='"" + $box.attr(""name"") + ""']"";
            // the checked state of the group/box on the other hand will change
            // and the current value is retrieved using .prop() method
            $(group).prop(""checked"", false);
            $box.prop(""checked"", true);
        } else {
            $box.prop(""checked"", false);
        }
    });

    $(""#btnUpdate"").click(function () {
        try {
            var intOrganisationId = $(""#OrganisationList td :checkbox:checked"").val();

            if (intOrganis");
            WriteLiteral(@"ationId > 0) {
                $.ajax({
                    contentType: ""application/x-www-form-urlencoded"",
                    async: false,
                    type: ""PUT"",
                    dataType: ""json"",
                    data: { ""intOrganisationId"": intOrganisationId },
                    url: '");
#nullable restore
#line 101 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                     Write(Url.Action("UpdateOrganisation","OrganisationList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                    success: function (data) {\r\n                        if (data.message == \"OK\") {\r\n                            window.location.href = \'");
#nullable restore
#line 104 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                                               Write(Url.Action("RegisterOrganisation", "RegisterOrganisation"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
                        }
                    },
                    error: function (data) {
                        UIkit.modal.alert(""Error-Something bad happened."");
                    }
                });
            }
            else {
                UIKit.modal.alert(""Please select at least one record from the grid"");
            }
        }
        catch (ex) {
            throw ex;
        }
    });

    $(""#btnDelete"").click(function () {
        try {
            var intOrganisationId = $(""#OrganisationList td :checkbox:checked"").val();
            if (intOrganisationId > 0) {
                UIkit.modal.alert(""Are you sure you want to delete the organisation?"").then(function () {
                    $.ajax({
                        contentType: ""application/x-www-form-urlencoded"",
                        async: false,
                        type: ""DELETE"",
                        dataType: ""json"",
                        data: { ""intOrganisationId"": intOrganisati");
            WriteLiteral("onId },\r\n                        url: \'");
#nullable restore
#line 132 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                         Write(Url.Action("DeleteOrganisation","OrganisationList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                        success: function (data) {
                            if (data.message == ""OK"") {
                                UIkit.modal.alert(""Organisation Deleted Successfully!"");
                                window.location.href = '");
#nullable restore
#line 136 "H:\CompanyProductManagementSystem\CompanyProductManagementSystem\CompanyProductManagementTool\Areas\Admin\Views\OrganisationList\OrganisationList.cshtml"
                                                   Write(Url.Action("OrganisationList", "OrganisationList"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
                            }
                            else {
                                UIKit.modal.alert(""Organisation not deleted into the system due to technical error"");
                            }
                        },
                        error: function (data) {
                            UIkit.modal.alert(""Error-Something bad happened"");
                        }
                    });
                }, function () {
                    console.log(""Delete Rejected"");
                });
            }
            else {
                UIkit.modal.alert(""Please select at least one record from the grid"");
            }
        }
        catch (ex) {
            throw ex;
        }
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductMate.Areas.Admin.Models.OrganisationListGrid>> Html { get; private set; }
    }
}
#pragma warning restore 1591
