using System.Collections.Generic;

namespace ppedv.VollE.Model
{
    public class Spieler : Person
    {
        public string Position { get; set; }
        public bool Händigkeit { get; set; }
        public ICollection<Mannschaft> Mannschaft { get; set; } = new HashSet<Mannschaft>();
        public ICollection<Mannschaft> AlsCaptain { get; set; } = new HashSet<Mannschaft>();
    }
}
