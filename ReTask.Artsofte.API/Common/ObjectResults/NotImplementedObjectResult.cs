using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ReTask.Artsofte.API.Common.ObjectResults
{
    public class NotImplementedObjectResult : ObjectResult
    {
        public NotImplementedObjectResult([ActionResultObjectValue] object value) : base(value)
        {
            StatusCode = StatusCodes.Status501NotImplemented;
        }
    }
}
