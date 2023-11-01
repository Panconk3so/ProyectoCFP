using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoCFP.Models;

namespace ProyectoCFP.Data;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<RegistrarCita> DataRegistrarCita {get;set;}
    public DbSet<Carrito> DataCarrito {get;set;}

}