using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Libro> Libros{get; set;}
    public DbSet<Estudiante> Estudiantes{get; set;}
    public DbSet<Prestamos> PrestamosLibros{get; set;}
=======
using Models;

namespace Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
   public virtual DbSet<Prestamos> PrestamosLibros{get; set;}
   public virtual DbSet<Libro> Libros{get; set;}
   public virtual DbSet<Estudiante> Estudiantes{get; set;}

>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f
}
