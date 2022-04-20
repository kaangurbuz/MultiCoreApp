using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;

namespace MultiCoreApp.API.Filters
{
    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _catService;

        public CategoryNotFoundFilter(ICategoryService catService)
        {
            _catService = catService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Guid id = (Guid)context.ActionArguments.Values.FirstOrDefault()!;
            var cat = await _catService.GetByIdAsync(id);
            if (cat == null)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.StatusCode = 404; // Not Found
                errorDto.Errors.Add($"Id'si {id} olan kategori bulunamadi.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
            else
            {
                await next();
            }
            //return base.OnActionExecutionAsync(context, next);
        }
    }
}
