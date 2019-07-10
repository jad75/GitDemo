using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GebDatum { get; set; } = DateTime.Now;
    }

    public class Kunde : Person
    {
        public string KdNummer { get; set; }
    }

    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; }
    }

    public class Abteilung
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
    }



}
