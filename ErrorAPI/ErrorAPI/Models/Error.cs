namespace ErrorAPI.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
