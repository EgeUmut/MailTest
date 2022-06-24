using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models.Models
{
    public class Tablo
    {
        [Key]
        public int TabloId { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
