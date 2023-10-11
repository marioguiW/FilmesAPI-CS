using FimesAPI.Modules;
using Microsoft.EntityFrameworkCore;

namespace FimesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
            
    }

    public DbSet<Filme> Filmes { get; set; }
}
