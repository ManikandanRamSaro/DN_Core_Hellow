namespace HellowWorld.Models
{
    public class ServiceResponse<T> // It act as template for all classes
    {
        public T data { get; set; }

        public bool Success { get; set; }=true;

        public string Message { get; set; }=null;
    }
}