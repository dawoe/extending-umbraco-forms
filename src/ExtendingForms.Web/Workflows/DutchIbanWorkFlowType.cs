using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Umbraco.Cms.Core.Web;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;

namespace ExtendingForms.Web.Workflows
{
    public class DutchIbanWorkFlowType : WorkflowType
    {
	    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
	    private readonly IHttpContextAccessor _httpContextAccessor;
	    private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

	    public DutchIbanWorkFlowType(IUmbracoContextAccessor umbracoContextAccessor, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
	    {
		    _umbracoContextAccessor = umbracoContextAccessor;
		    _httpContextAccessor = httpContextAccessor;
		    _tempDataDictionaryFactory = tempDataDictionaryFactory;

		    this.Id = new Guid("30008022-e05e-4b05-9348-733498bedbc8");
		    this.Name = "Dutch IBAN Processor";
		    this.Description = "Demo work flow for processing form data";
		    this.Icon = "icon-piggy-bank";
		    this.Group = "Services";
		}

	    [Umbraco.Forms.Core.Attributes.Setting("Error page", View = "Pickers.ContentWithXPath", IsMandatory = true)]
		public string ErrorPage { get; set; }

	    public override Task<WorkflowExecutionStatus> ExecuteAsync(WorkflowExecutionContext context)
	    {
			// we are assuming something went wrong in processing here.
			if (_httpContextAccessor.HttpContext is null)
			{
				return Task.FromResult(WorkflowExecutionStatus.Failed);
			}

			// save error in temp data
			var tempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
			tempData.Add("FormError", "I am not able to process your IBAN");


			// set custom error page url here
			if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
			{
				if (umbracoContext.Content is not null)
				{
					var content = umbracoContext.Content.GetById(int.Parse(this.ErrorPage));

					if (content != null)
					{
						_httpContextAccessor.HttpContext.Items[Constants.ItemKeys.RedirectAfterFormSubmitUrl] = content.Url();
					}
				}
			}

			context.Record.State = FormState.Rejected;
			
		    return Task.FromResult(WorkflowExecutionStatus.Failed);
	    }

	    public override List<Exception> ValidateSettings()
	    {
		    return new List<Exception>();
	    }
    }
}
