using ExtendingForms.Web.DefaultBehaviors;
using Umbraco.Cms.Core.Composing;
using Umbraco.Forms.Web.Behaviors;

namespace ExtendingForms.Web.Composers
{
    public class DefaultBehaviorComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddUnique<IApplyDefaultFieldsBehavior, ApplyDefaultFieldsBehavior>();
        }
    }
}
