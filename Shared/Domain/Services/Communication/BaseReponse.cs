namespace PitagorasSNS.API.Shared.Domain.Services.Communication
{
    public abstract class BaseReponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T? Resource { get; protected set; }

        protected BaseReponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }

        protected BaseReponse(string message)
        {
            Message = message;
            Success = false;
            Resource = default;
        }
    }
}
