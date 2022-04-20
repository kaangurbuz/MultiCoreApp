namespace MultiCoreApp.MVC.DTOs
{
    public class ErrorDto
    {
        public List<String> Errors { get; set; } = new List<string>();
        public int StatusCode { get; set; }
    }
}
