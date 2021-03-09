using HotChocolate;

namespace CustomCountries.API.GraphQl.Filter
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Exception.Message);
        }
    }
}