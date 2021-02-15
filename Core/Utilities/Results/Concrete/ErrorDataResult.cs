namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message, T data) 
            : base(message, false, data)
        {
        }

        public ErrorDataResult( T data) : base(false, data)
        {
        }
    }
}