namespace QuickLedger.Models
{
    public class ClientDTO
    {
        public long Id { get; set; }
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool Test { get; set; }
        public string DatabaseName { get; set; }
        public string Url { get; set; }
        
    }
}
