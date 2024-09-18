using ExtendingForms.Web.Workflows;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;

namespace ExtendingForms.Web.Composers
{
	public class AddCustomWorkFlows : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.FormsWorkflows().Add<DutchIbanWorkFlowType>();
		}
	}
}
