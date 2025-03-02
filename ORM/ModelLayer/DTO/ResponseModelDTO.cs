
namespace ModelLayer.DTO
{
    public class ResponseModelDTO<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = " ";
        public T Data { get; set; } = default(T);
    }
}
