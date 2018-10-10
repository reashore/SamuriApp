using System;
using System.Collections.Generic;

namespace SamuriApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDated { get; set; }
        public List<Samuri> Samuris { get; set; }
    }
}
