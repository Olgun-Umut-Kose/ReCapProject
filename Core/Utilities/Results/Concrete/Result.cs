using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        
        public bool Success { get; }
        public string Message { get; set; }

        public Result(string message, bool success) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        
    }
}