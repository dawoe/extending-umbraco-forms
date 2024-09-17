using ExtendingForms.Web.ParsedPlaceholderFormatters;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;

namespace ExtendingForms.Web.Composers
{
    public class AddParsedPlaceholderFormattersComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.FormsParsedPlaceholderFormatters().Add<PropertyValueParsedPlaceholderFormatter>();
        }
    }
}
