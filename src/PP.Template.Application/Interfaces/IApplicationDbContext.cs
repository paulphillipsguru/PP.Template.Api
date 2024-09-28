namespace PP.Template.Application.Interfaces;
public  interface IApplicationDbContext
{
    DbSet<ExampleEntity> Example { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


}
