using MessageProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.DataAccessLayer.Context
{
    public class MessageContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q8TR5R2\\SQLEXPRESS;initial catalog=MessageProject;integrated Security=true;");
        }
        public DbSet<Message>   Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Draft> Drafts { get; set; }
    }
}
