using Crypto.Presentation.Api.ActionBase.TbcTask.Domain.Models.Responses;
using Newtonsoft.Json;

namespace Crypto.Presentation.Api.ApiHelpers.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                string jsonResponse = "";
                var errorResponse = Result<object>.ReturnCode(ex);
                jsonResponse = JsonConvert.SerializeObject(errorResponse);
                context.Response.StatusCode = (int)errorResponse.StatusCode;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
