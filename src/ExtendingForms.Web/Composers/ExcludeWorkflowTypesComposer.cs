using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;
using Umbraco.Forms.Core.Providers.WorkflowTypes;

namespace ExtendingForms.Web.Composers
{
	public class ExcludeWorkflowTypesComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.FormsWorkflows()
				.Exclude<Slack>()
				.Exclude<SlackV2>()
				.Exclude<SendXsltEmail>()
				.Exclude<SaveAsUmbracoNode>()
				.Exclude<SaveAsFile>()
				.Exclude<PostAsXml>()
				.Exclude<PostToUrl>()
				.Exclude<SendEmail>();
		}
	}
}
