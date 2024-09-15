using IbanNet;
using Umbraco.Cms.Core.Events;
using Umbraco.Forms.Core.Services.Notifications;

namespace ExtendingForms.Web.NotificationHandlers
{
	public class IbanFormValidationHandler : INotificationHandler<FormValidateNotification>
	{
		private readonly IIbanValidator ibanValidator;

		public IbanFormValidationHandler(IIbanValidator ibanValidator)
		{
			this.ibanValidator = ibanValidator;
		}

		public void Handle(FormValidateNotification notification)
		{
			if (notification.ModelState.IsValid == false)
			{
				return;
			}

			if (notification.Form.Id.ToString().InvariantEquals("19e1b89c-17b5-4a39-a691-6da11d04e18d") == false)
			{
				return;
			}

			var ibanField = notification.Form.AllFields.FirstOrDefault(x => x.Alias.ToLowerInvariant() == "iban");

			if (ibanField == null)
			{
				return;
			}

			var ibanValue = notification.Context.Request.Form[ibanField.Id.ToString()].ToString();

			if (string.IsNullOrWhiteSpace(ibanValue))
			{
				notification.ModelState.AddModelError(ibanField.Id.ToString(), "IBAN is a required field");
			}

			var result = this.ibanValidator.Validate(ibanValue);

			if (result.IsValid)
			{
				return;
			}

			notification.ModelState.AddModelError(ibanField.Id.ToString(), "IBAN is not valid");
		}
	}
}
