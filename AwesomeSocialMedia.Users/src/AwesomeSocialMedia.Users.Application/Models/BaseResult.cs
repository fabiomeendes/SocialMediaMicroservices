namespace AwesomeSocialMedia.Users.Application.Models
{
    public class BaseResult
    {
        public BaseResult(bool success = true, string message = "")
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
    }

    public class BaseResult<T> : BaseResult
    {
        public BaseResult(T data, bool success = true, string message = "") : base(success, message)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
