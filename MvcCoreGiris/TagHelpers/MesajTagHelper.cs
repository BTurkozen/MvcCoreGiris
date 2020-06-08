using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreGiris.TagHelpers
{
    public  class MesajTagHelper : TagHelper
    {
        //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-3.1
        public bool KapatGoster { get; set; }
        public override  void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div"; // <mesaj> ile <div>'i yer değiştirir.
            output.Attributes.SetAttribute("class", "alert alert-success");

            if (KapatGoster)
            {
                output.PostContent.AppendHtml(
                   "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">"
                   + "<span aria-hidden=\"true\">&times;</span>"
                   + "</button>");
            }
        }
    }
}
