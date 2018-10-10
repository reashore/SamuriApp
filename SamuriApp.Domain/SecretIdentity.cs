namespace SamuriApp.Domain
{
    public class SecretIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public Samuri Samuri { get; set; }
        public int SamuriId { get; set; }
    }
}
