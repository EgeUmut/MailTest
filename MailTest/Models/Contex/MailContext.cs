using MailTest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Models.Contex
{
    public class MailContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MailDB;Trusted_Connection=true");
        }

        public DbSet<Users> Mails { get; set; }
        public DbSet<MailMessage> MailMessage { get; set; }
        //public DbSet<Tablo> Tablo { get; set; }

    }
}
