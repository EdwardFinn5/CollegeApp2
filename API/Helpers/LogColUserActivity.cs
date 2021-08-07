using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers
{
    public class LogColUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var colUserId = resultContext.HttpContext.User.GetColUserId();
            var repo = resultContext.HttpContext.RequestServices.GetService<IColUserRepository>();
            var colUser = await repo.GetColUserByIdAsync(colUserId);
            colUser.LastActive = System.DateTime.Now;
            await repo.SaveAllAsync();

        }
    }
}