namespace ChromaComics.Recommendations.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; protected set; }

        protected BaseResponse(bool success, string message, T resource)
        {
            Success = success;
            Message = message;
            Resource = resource;
        }

        protected BaseResponse(T resource) : this(true, string.Empty, resource) { }

        protected BaseResponse(string message) : this(false, message, default) { }
    }
}