using Umbraco.Forms.Core.Interfaces;

namespace ExtendingForms.Web.ValidationPatterns
{
	public class DutchIbanPattern : IValidationPattern
	{
		public string Alias => "dutchIbanPattern";
		public string LabelKey => string.Empty;
		public string Name => "Dutch IBAN Number";
		public string Pattern => "^NL[0-9]{2}[A-Z]{4}[0-9]{10}$";
		public bool ReadOnly => true;
	}
}
