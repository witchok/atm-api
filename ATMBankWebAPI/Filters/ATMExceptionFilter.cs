using ATMBankWebAPI.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ATMBankWebAPI.Filters
{
    public class ATMExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            IActionResult actionResult;
            var ex = context.Exception;
            if(ex is CardNotFoundException)
            {
                actionResult = new NotFoundObjectResult(
                    new { Error = "Card Issue.", Message = ex.Message});
            }
            else if(ex is CardNotValidException)
            {
                actionResult = new ObjectResult(
                    new { Error = "Card Validity Issue", Message = ex.Message })
                { StatusCode = 409};
            }

            else if (ex is PinNotValidException)
            {
                actionResult = new ObjectResult(
                    new { Error = "PIN Validity Issue", Message = ex.Message })
                { StatusCode = 409 }; ;
            }
            else if (ex is WrongPinException)
            {
                actionResult = new ObjectResult(
                    new { Error = "PIN Issue", Message = ex.Message })
                { StatusCode = 403 };
            }
            else
            {
                actionResult = new ObjectResult(
                    new { Error = "General Error.", Message = ex.Message})
                {
                    StatusCode = 500
                };
            }

            context.Result = actionResult;
        }
    }
}
