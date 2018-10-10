namespace SamuriApp.Domain
{
    public class SamuriBattle
    {
        public int SamuriId { get; set; } 
        public Samuri Samuri { get; set; } 
        public int BattleId { get; set; } 
        public Battle Battle { get; set; } 
    }
}
