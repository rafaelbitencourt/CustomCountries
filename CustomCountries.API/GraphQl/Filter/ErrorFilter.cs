using HotChocolate;

namespace CustomCountries.API.GraphQl.Filter
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception != null)
                error.WithMessage(error.Exception.Message);

            return error;
        }
    }
}