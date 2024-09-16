using ExtendingForms.Web.FieldTypes;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;

namespace ExtendingForms.Web.Composers
{
	public class AddCustomFieldsComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.FormsFields().Add<DutchIbanField>();
		}
	}
}
