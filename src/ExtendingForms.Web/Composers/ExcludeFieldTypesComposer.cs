using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;
using Umbraco.Forms.Core.Providers.FieldTypes;

namespace ExtendingForms.Web.Composers
{
	public class ExcludeFieldTypesComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.FormsFields().Exclude<Recaptcha2>();
		}
	}
}
