using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Lab_01.Models;

namespace Lab_01.CustomFilter
{
    public class LocationFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("dept"))
            {
                var department = context.ActionArguments["dept"] as Department;

                if (department.Location.ToUpper() != "EGY" && department.Location.ToUpper() != "USA")
                {
                    
                    context.Result =new  BadRequestObjectResult("Invalid Location, Should Be EGY or USA");
                    return ;
                }

            }
            base.OnActionExecuting(context);
        }
    }
}
