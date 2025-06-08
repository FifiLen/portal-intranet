using Microsoft.AspNetCore.Razor.TagHelpers;
using Portal.Services;

namespace Portal.TagHelpers;

[HtmlTargetElement("*", Attributes = "portal-text")]
public class PortalTextTagHelper : TagHelper
{
    private readonly PortalTextService _service;

    public PortalTextTagHelper(PortalTextService service)
    {
        _service = service;
    }

    [HtmlAttributeName("portal-text")]
    public string Key { get; set; } = string.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var value = _service.Get(Key);
        output.Content.SetContent(value);
    }
}
