using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimoneZangrilli.Models
{
    public class ContactInfo
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Inserisci il tuo nome")]
        [StringLength(15, ErrorMessage = "Nome troppo lungo")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Cognome troppo lungo")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Inserisci una email valida")]
        [RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", 
            ErrorMessage = "Inserisci una email valida")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
