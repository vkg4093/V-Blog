namespace V.Blog.Test.Framework.JSON
{
    public class JsonErrorMessage : JsonResponse<string>
    {
        public JsonErrorMessage(string aMessage)
        {
            success = false;
            data = aMessage;
        }
    }
    public class JsonResponse<T> : JsonResponse
    {
        public T data { get; set; }
    }
    public class JsonResponse
    {
        public bool success { get; set; }
        public JsonResponse()
        {
        }
        public JsonResponse(bool success)
        {
            this.success = success;
        }
    }
}
