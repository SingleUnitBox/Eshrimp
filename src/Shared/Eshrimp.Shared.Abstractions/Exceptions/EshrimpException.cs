namespace Eshrimp.Shared.Abstractions.Exceptions
{
    public abstract class EshrimpException : Exception
    {
        public EshrimpException(string message) : base(message)
        {
            
        }
    }
}
