using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
   public virtual DbSet<Prestamos> PrestamosLibros{get; set;}
   public virtual DbSet<Libro> Libros{get; set;}
   public virtual DbSet<Estudiante> Estudiantes{get; set;}
}
