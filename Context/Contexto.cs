using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Models;

namespace RegistroPrestamosLibros.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Libro> Libros{get; set;}
    public DbSet<Estudiante> Estudiantes{get; set;}
    public DbSet<Prestamos> PrestamosLibros{get; set;}
}
