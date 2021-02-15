using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }
        
        public DataResult(string message, bool success, T data)
            : base(message, success)
        {
            Data = data;
        }

        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }

        
    }
}
        
 
    
