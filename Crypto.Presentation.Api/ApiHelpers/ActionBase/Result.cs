using Crypto.Domain.Models.Responses.Base;
using Crypto.Infrastructure.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Crypto.Presentation.Api.ActionBase
{
    namespace TbcTask.Domain.Models.Responses
    {
        public class Result<T> : ObjectResult
        {
            public Result(object? value, int StatusCode) : base(value)
            {
                this.StatusCode = StatusCode;

            }
            public static Result<T> Ok(T value)
            {

                return new Result<T>(new Response<T>(value), 200);
            }
            public static Result<T> NotFound()
            {

                return new Result<T>(new Response<T>(HttpStatusCode.NotFound, "Data Not Found"), 404);
            }
            public static Result<T> ReturnCode(HttpStatusCode code, string message)
            {

                return new Result<T>(new Response<T>(code, message), (int)code);
            }
            public static Result<T> ReturnCode(Exception ex)
            {
                switch (ex)
                {
                    case DataNotFoundException:
                        return new Result<T>(new Response<T>(HttpStatusCode.NotFound, ex.Message), (int)HttpStatusCode.NotFound);
                    default:
                        return new Result<T>(new Response<T>(HttpStatusCode.InternalServerError, ex.Message), (int)HttpStatusCode.InternalServerError);
                }
            }



        }
    }

}
