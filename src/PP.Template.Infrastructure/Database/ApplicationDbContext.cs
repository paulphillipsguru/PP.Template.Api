using Microsoft.EntityFrameworkCore;
using PP.Template.Application.Interfaces;
using PP.Template.Domain.Entities;

namespace PP.Template.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options),IApplicationDbContext
{       
    public required DbSet<ExampleEntity> Example { get; set; }
}
