using Projekat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OsobaOsnovni
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Polje za ime je obavezno", AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje za prezime je obavezno", AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Display(Name = "Ime jednog roditelja")]
        [Required(ErrorMessage = "Polje za ime jednog roditelja je obavezno", AllowEmptyStrings = false)]
        public string ImeRoditelja { get; set; }

        [Required(ErrorMessage = "Polje za JMBG je obavezno", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\d{13})?$", ErrorMessage = "Neispravna vrednost JMBG-a")]
        public string JMBG { get; set; }


        [Required(ErrorMessage = "Polje za datum rođenja je obavezno", AllowEmptyStrings = false)]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Neispravna vrednost datuma, Primer unosa: 01.01.1970")]
        [Display(Name = "Datum rođenja")]
        public string DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Polje za mesto rođenja je obavezno", AllowEmptyStrings = false)]
        [Display(Name = "Mesto rođenja")]
        public string MestoRodjenja { get; set; }

        [Required(ErrorMessage = "Polje za opštinu rođenja je obavezno", AllowEmptyStrings = false)]
        [Display(Name = "Opština rođenja")]
        public string OpstinaRodjenja { get; set; }

        [Required(ErrorMessage = "Polje za pol je obavezno")]
        public string Pol { get; set; }

        [Required(ErrorMessage = "Polje za broj lk je obavezno", AllowEmptyStrings = false)]
        [Display(Name = "Broj lične karte")]
        [RegularExpression(@"^(\d{9})?$", ErrorMessage = "Neispravna vrednost za broj lične karte")]
        public string BrojLicneKarte { get; set; }

        [Display(Name = "Beleška")]
        public string Beleska { get; set; }

        public string Fotografija { get; set; }

    }
}