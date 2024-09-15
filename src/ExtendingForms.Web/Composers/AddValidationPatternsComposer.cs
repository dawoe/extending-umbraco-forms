using ExtendingForms.Web.ValidationPatterns;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;

namespace ExtendingForms.Web.Composers
{
	public class AddValidationPatternsComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.FormsValidationPatterns().Append<DutchIbanPattern>();
		}
	}
}
