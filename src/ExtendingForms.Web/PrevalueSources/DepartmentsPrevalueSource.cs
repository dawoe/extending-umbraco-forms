using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Models;

namespace ExtendingForms.Web.PrevalueSources
{
    public class DepartmentsPrevalueSource : FieldPreValueSourceType
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public DepartmentsPrevalueSource(IUmbracoContextAccessor umbracoContextAccessor)
        {
            Id = new Guid("42C8158D-2AA8-4621-B653-6A63C7545768");
            Name = "Departments";
            Description = "List of departments managed in the data folder in the content section";

            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override List<PreValue> GetPreValues(Field? field, Form? form)
        {
            var preValues = new List<PreValue>();

            if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext) == false)
            {
                return preValues;
            }

            if (umbracoContext.Content is null)
            {
                return preValues;
            }

            var departments = umbracoContext.Content.GetAtRoot().FirstOrDefault()?.Descendants<Department>().ToList() ??
                             new List<Department>();

            foreach (var department in departments)
            {
                preValues.Add(new PreValue
                {
                    Id = department.Id.ToString(),
                    Value = department.Id.ToString(),
                    Caption = department.Name,
                });
            }

            return preValues;
        }

        public override List<Exception> ValidateSettings()
        {
            var exceptions = new List<Exception>();
            return exceptions;
        }
    }
}
