using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCodeFirst.Model
{


    public class Mitarbeiter : Person
    {
        [MaxLength(98)]
        [Column("Job 👔")]
        public string Beruf { get; set; }

        public ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();

    }



}
