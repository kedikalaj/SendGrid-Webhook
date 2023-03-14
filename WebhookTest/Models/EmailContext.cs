using Microsoft.EntityFrameworkCore;

namespace WebhookTest.Models
{
    public class EmailContext : DbContext
    {
        private readonly DbContextOptions<EmailContext> _options;
        public DbContextOptions<EmailContext> Options
        {
            get
            {
                return _options;
            }
        }
        public EmailContext(DbContextOptions<EmailContext> options):base(options)
        {
            _options = options;

        }
        public DbSet<Email> Emails { get; set; }
    }
}
