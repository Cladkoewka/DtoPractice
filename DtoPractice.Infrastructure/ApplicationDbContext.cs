using DtoPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DtoPractice.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }
    
    public DbSet<Product> Products { get; set; }
}