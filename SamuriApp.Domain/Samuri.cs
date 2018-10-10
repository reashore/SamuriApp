using System.Collections.Generic;

namespace SamuriApp.Domain
{
    public class Samuri
    {
        public Samuri()
        {
            Quotes = new List<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public int BattleId { get; set; }
    }
}
