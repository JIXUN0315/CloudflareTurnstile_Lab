namespace CloudflareTurnstile_Lab.Models
{
    public class TurnstileRequest
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public DateTime ChallengeTs { get; set; }
        public string Hostname { get; set; }
        public string Secret { get; set; }
        public string Response { get; set; }
        public string RemoteIp { get; set; }
    }
}
