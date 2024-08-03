using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<PortfolioData> PortfolioDatas { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Footer> Footers { get; set; }
}
