using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace RegistroPrestamosLibros.Models;
=======
namespace Models;
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f

public class Libro
{
    [Key]
    public int LibroId{get; set;}

    [Required(ErrorMessage = "El titulo no puede estar vacio")]
    public string Titulo{get; set;} = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar el nombre del autor")]
    public string Autor{get; set;} = string.Empty;
    
    [Range(1, 2026, ErrorMessage = "Por favor, ingresar un año valido")]
    public int AnoPublicacion{get; set;}
<<<<<<< HEAD
    public int CantidadDisponible{get; set;}
    public bool EstaDisponible{get; set;} = true;
=======
    public bool EstaDisponible{get; set;} = true;

>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f
}
