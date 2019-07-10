using System;

namespace ppedv.VollE.Model
{
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
