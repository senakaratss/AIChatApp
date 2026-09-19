using AIChatApp.Domain;
using AIChatApp.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Persistence.Context
{
    public class AIChatContext : IdentityDbContext<AppUser>
    {
        public AIChatContext(DbContextOptions<AIChatContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
