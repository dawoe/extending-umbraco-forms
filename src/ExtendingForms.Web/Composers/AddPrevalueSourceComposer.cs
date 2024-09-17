using ExtendingForms.Web.PrevalueSources;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Core.Providers.Extensions;

namespace ExtendingForms.Web.Composers
{
    public class AddPrevalueSourceComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.FormsFieldPreValueSources().Add<DepartmentsPrevalueSource>();
        }
    }
}
