using Microsoft.EntityFrameworkCore;
using PP.Template.Domain.Entities;

namespace PP.Template.Application.Interfaces
{
    public  interface IApplicationDbContext
    {
        DbSet<ExampleEntity> Example { get; set; }
    }
}
