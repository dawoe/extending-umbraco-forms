using Umbraco.Cms.Core.Web;
using Umbraco.Forms.Core.Interfaces;

namespace ExtendingForms.Web.ParsedPlaceholderFormatters
{
    public class PropertyValueParsedPlaceholderFormatter : IParsedPlaceholderFormatter
    {
        private readonly IUmbracoContextAccessor contextAccessor;

        public PropertyValueParsedPlaceholderFormatter(IUmbracoContextAccessor contextAccessor) => this.contextAccessor = contextAccessor;

        public string FunctionName => "propertyValue";

        public string FormatValue(string value, string[] args)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            if (args.Length != 1)
            {
                return value;
            }

            var propertyAlias = args.First();

            if (string.IsNullOrWhiteSpace(propertyAlias))
            {
                return value;
            }

            if (int.TryParse(value, out var contentId) == false)
            {
                return value;
            }

            var umbracoContext = this.contextAccessor.GetRequiredUmbracoContext();

            if (umbracoContext.Content is null)
            {
                return value;
            }

            var content = umbracoContext.Content.GetById(contentId);

            if (content is null)
            {
                return value;
            }

            if (content.HasProperty(propertyAlias) == false)
            {
                return value;
            }

            return content.Value<string>(propertyAlias) ?? value;
        }
    }
}
