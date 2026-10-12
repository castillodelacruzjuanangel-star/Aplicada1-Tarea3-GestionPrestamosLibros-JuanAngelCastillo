using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrestamosLibros.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId {get; set;}
    public int LibroId {get; set;}
    public int EstudianteId {get; set;}
    public DateOnly FechaPrestamo {get; set;} = DateOnly.FromDateTime(DateTime.Now);

    [ForeignKey(nameof(EstudianteId))]
    public virtual Estudiante? Estudiante {get; set;}

    [ForeignKey(nameof(LibroId))]
    public virtual Libro? Libro {get; set;}
}
