﻿using System.Collections.Generic;

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
        //public int BattleId { get; set; }
        public List<SamuriBattle> SamuriBattles { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
    }
}
