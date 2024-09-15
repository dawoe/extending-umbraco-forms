using ExtendingForms.Web.NotificationHandlers;
using IbanNet.DependencyInjection.ServiceProvider;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Services.Notifications;

namespace ExtendingForms.Web.Composers
{
	public class FormValidationComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.Services.AddIbanNet();

			builder.AddNotificationHandler<FormValidateNotification, IbanFormValidationHandler>();
		}
	}
}
