using System.Collections.Generic;

namespace ppedv.VollE.Model
{
    public class Mannschaft : Entity
    {
        public string Name { get; set; }

        public Trainer Trainer { get; set; }
        public Spieler Captain { get; set; }
        public ICollection<Spieler> Spieler { get; set; } = new HashSet<Spieler>();

        public ICollection<Spiel> SpielAlsGast { get; set; } = new HashSet<Spiel>();
        public ICollection<Spiel> SpielAlsHeim { get; set; } = new HashSet<Spiel>();

    }
}
