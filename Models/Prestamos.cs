using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
namespace RegistroPrestamosLibros.Models;
=======
namespace Models;
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f

public class Prestamos
{
    [Key]
<<<<<<< HEAD
    public int PrestamoId {get; set;}
    public int LibroId {get; set;}
    public int EstudianteId {get; set;}
    public DateOnly FechaPrestamo {get; set;} = DateOnly.FromDateTime(DateTime.Now);

    [ForeignKey(nameof(EstudianteId))]
    public virtual Estudiante? Estudiante {get; set;}

    [ForeignKey(nameof(LibroId))]
    public virtual Libro? Libro {get; set;}
=======
    public int PrestamoId{get; set;}
    public int LibroId{get; set;}
    public int EstudianteId{get; set;}

    [Range(typeof(DateOnly), "2026-9-24", "2200-12-31", ErrorMessage = "Por favor, ingrese una fecha valida")]
    public DateOnly FechaPrestamo{get; set;} = DateOnly.FromDateTime(DateTime.Now);

    [ForeignKey(nameof(LibroId))]
    public virtual Libro? LibroPrestado{get; set;}

    [ForeignKey(nameof(EstudianteId))]
    public virtual Estudiante? Estudiante{get; set;}
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f
}
