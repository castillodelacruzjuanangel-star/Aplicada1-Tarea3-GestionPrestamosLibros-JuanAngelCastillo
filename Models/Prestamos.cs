using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Prestamos
{
    [Key]
    public int PrestamoId{get; set;}
    public int LibroId{get; set;}
    public int EstudianteId{get; set;}

    [Range(typeof(DateOnly), "2026-9-24", "2200-12-31", ErrorMessage = "Por favor, ingrese una fecha valida")]
    public DateOnly FechaPrestamo{get; set;} = DateOnly.FromDateTime(DateTime.Now);

    [ForeignKey(nameof(LibroId))]
    public virtual Libro? LibroPrestado{get; set;}

    [ForeignKey(nameof(EstudianteId))]
    public virtual Estudiante? Estudiante{get; set;}
}
