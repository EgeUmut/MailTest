using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models.Models
{
    public class MailMessage
    {
        [Key]
        public int MessageId { get; set; }
        [NotNull]
        public string MessageSubject { get; set; }
        [NotNull]
        public string MessageText { get; set; }
    }
}
