using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string LastName { get; set; }
        //public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

    }
}
