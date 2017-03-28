using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Osoba
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Display(Name ="Ime jednog roditelja")]
        [Required]
        public string ImeRoditelja { get; set; }

        [Required]
        public string JMBG { get; set; }

        [Required]
        [Display(Name = "Datum rođenja")]     
        [DataType(DataType.Date)]  
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [Display(Name = "Mesto rođenja")]
        public string MestoRodjenja { get; set; }

        [Required]
        [Display(Name = "Opština rođenja")]
        public string OpstinaRodjenja { get; set; }

        [Required]
        public string Pol { get; set; }

        [Required]
        [Display(Name = "Broj lične karte")]
        public string BrojLicneKarte { get; set; }

        [Display(Name = "Beleška")]
        public string Beleska { get; set; }

        public string Fotografija { get; set; }

        public IEnumerable<Telefon> BrojeviTelefona { get; set; }

        public IEnumerable<Mail> MailAdrese { get; set; }

        public IEnumerable<PostanskaAdresa> PostanskeAdrese { get; set; }


    }
}