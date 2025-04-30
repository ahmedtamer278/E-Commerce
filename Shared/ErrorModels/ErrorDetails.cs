namespace Shared.ErrorModels
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public String ErrorMessage { get; set; } = string.Empty;
        public List<string>? Errors { get; set; }
    }
}
