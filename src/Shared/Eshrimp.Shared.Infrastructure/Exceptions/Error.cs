namespace Eshrimp.Shared.Infrastructure.Exceptions
{
    public record Error(string Code, string Message);
    public record Errors(params Error[] ParamsError);
}
