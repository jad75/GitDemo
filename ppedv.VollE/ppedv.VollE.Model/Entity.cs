using System;
using System.Collections;
using System.Collections.Generic;

namespace ppedv.VollE.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public Geschlecht Geschlecht { get; set; }
    }

    public enum Geschlecht
    {
        Divers,
        Weiblich,
        Männlich
    }

    public class Trainer : Person
    {
        public Trainerlizenzstufe Trainerlizenzstufe { get; set; }
        public ICollection<Mannschaft> Mannschaft { get; set; } = new HashSet<Mannschaft>();

    }

    public enum Trainerlizenzstufe
    {
        A,
        B,
        C,
        Diplom
    }

    public class Spieler : Entity
    {
        public string Position { get; set; }
        public bool Händigkeit { get; set; }
        public ICollection<Mannschaft> Mannschaft { get; set; } = new HashSet<Mannschaft>();
        public ICollection<Mannschaft> AlsCaptain { get; set; } = new HashSet<Mannschaft>();
    }

    public class Mannschaft : Entity
    {
        public string Name { get; set; }

        public Trainer Trainer { get; set; }
        public Spieler Captain { get; set; }
        public ICollection<Spieler> Spieler { get; set; } = new HashSet<Spieler>();

        public ICollection<Spiel> SpielAlsGast { get; set; } = new HashSet<Spiel>();
        public ICollection<Spiel> SpielAlsHeim { get; set; } = new HashSet<Spiel>();

    }

    public class Spiel : Entity
    {
        public DateTime Datum { get; set; }
        public string Ort { get; set; }
        public Mannschaft HeimMannschaft { get; set; }
        public Mannschaft GastMannschaft { get; set; }
        public int PunkteHeim { get; set; }
        public int PunkteGast { get; set; }
    }
}
