namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(string message, T data) 
            : base(message, true, data)
        {
        }

        public SuccessDataResult(T data) : base(true, data)
        {
        }
    }
}