namespace SamuriApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Samuri Samuri { get; set; }
        public int SamuriId { get; set; }
    }
}
