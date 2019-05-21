using Exchange.Core.Model;

namespace Exchange.Services
{
    public interface IInputValidationService
    {
        InputParamsForExchange Validate(string[] args);
    }
}