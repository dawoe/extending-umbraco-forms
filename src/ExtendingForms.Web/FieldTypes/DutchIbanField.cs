using System.Text.RegularExpressions;
using IbanNet;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Services;

namespace ExtendingForms.Web.FieldTypes
{
    public class DutchIbanField : Umbraco.Forms.Core.FieldType
    {
        private static Regex DutchIbanRegex = new Regex("^NL[0-9]{2}[A-Z]{4}[0-9]{10}$", RegexOptions.Compiled);

        public DutchIbanField()
        {
            Id = new Guid("c47aab84-c726-4497-a786-76a0db5ec1ae");
            Name = "Dutch IBAN Field";
            Description = "Renders a Dutch IBAN input Field.";
            Icon = "icon-autofill";
            DataType = FieldDataType.String;
            SortOrder = 10;
            SupportsRegex = false;
            SupportsPreValues = false;
            FieldTypeViewName = "FieldType.DutchIbanField.cshtml";
        }

        public override string GetDesignView()
        {
            return "/App_Plugins/UmbracoForms/backoffice/Common/FieldTypes/textfield.html";
        }


        public override IEnumerable<string> ValidateField(Form form, Field field, IEnumerable<object> postedValues, HttpContext context,
            IPlaceholderParsingService placeholderParsingService, IFieldTypeStorage fieldTypeStorage)
        {
            var errors = new List<string>();
            var ibanValidator = new IbanValidator();

            foreach (var value in postedValues)
            {
                var stringValue = value?.ToString() ?? string.Empty;

                if (DutchIbanRegex.IsMatch(stringValue) == false)
                {
                    errors.Add("Not a valid IBAN Number");
                }
                else if (ibanValidator.Validate(stringValue).IsValid == false)
                {
                    {
                        errors.Add("Not a valid Dutch IBAN number");
                    }
                }
            }

            return base.ValidateField(form, field, postedValues, context, placeholderParsingService, fieldTypeStorage, errors);

        }
    }
}
