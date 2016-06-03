using Microsoft.Data.Entity;

namespace MyQuoteApp.models
{
    public class QuotesAppContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
    }
}
