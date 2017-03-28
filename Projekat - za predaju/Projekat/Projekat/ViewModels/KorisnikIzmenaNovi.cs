using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class KorisnikIzmenaNovi
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "Polje za e-mail je obavezno")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UsernameEmail { get; set; }

        [Required(ErrorMessage = "Polje za lozinku je obavezno")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!% *#?&])[A-Za-z\d$@$!%*#?&]{6,}$", ErrorMessage = "Lozinka treba da sadrži minimum 6 karaktera i među njima minimum jedno slovo, jedan broj i jedan specijalni karakter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Morate da izaberete ulogu novog korisnika")]
        public string UlogaId { get; set; }



    }
}