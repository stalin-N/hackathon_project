namespace MarstonX.Application.Wrappers;

public interface IResponseData<T>
{
    T Data { get; set; }
    string Message { get; set; }
    bool Success { get; set; }
}

public class ResponseData<T> : IResponseData<T>
{
    public T Data { get; set; } = default(T)!;
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; } = true;
}