using Microsoft.Extensions.Options;
using Umbraco.Forms.Core.Configuration;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Providers;
using Umbraco.Forms.Web.Behaviors;
using Umbraco.Forms.Web.Extensions;
using Umbraco.Forms.Web.Models.Backoffice;

namespace ExtendingForms.Web.DefaultBehaviors
{
    public class ApplyDefaultFieldsBehavior : IApplyDefaultFieldsBehavior
    {
        private readonly FormDesignSettings _formDesignSettings;
        private readonly FieldCollection _fieldCollection;

        public ApplyDefaultFieldsBehavior(
            IOptions<FormDesignSettings> formDesignSettings,
            FieldCollection fieldCollection)
        {
            this._formDesignSettings = formDesignSettings.Value;
            this._fieldCollection = fieldCollection;
        }

        public void ApplyDefaultFields(FormDesign form)
        {
            Page page = new Page();
            form.Pages.Add(page);
            FieldSet fieldSet = new FieldSet()
            {
                Id = Guid.NewGuid()
            };
            page.FieldSets.Add(fieldSet);
            FieldsetContainer container = new FieldsetContainer()
            {
                Width = 12
            };
            fieldSet.Containers.Add(container);

            var firstNameField = new Field
            {
                Alias = "firstName",
                Id = Guid.NewGuid(),
                FieldTypeId = Guid.Parse(Umbraco.Forms.Core.Constants.FieldTypes.Textfield),
                Mandatory = true,
                Caption = "First name"
            };

            container.Fields.Add(firstNameField);


            if (this._formDesignSettings.DisableAutomaticAdditionOfDataConsentField)
                return;
            container.AddDataConsentField(this._formDesignSettings, this._fieldCollection);
        }
    }
}
