using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OneStore.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string EnderecoEmail { get; set; }

        public string ConteudoEmail { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + EnderecoEmail);
            output.Content.SetContent(ConteudoEmail);
        }
    }
}
