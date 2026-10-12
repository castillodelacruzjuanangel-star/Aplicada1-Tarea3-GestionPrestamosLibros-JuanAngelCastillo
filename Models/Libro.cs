using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamosLibros.Models;

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
    public int CantidadDisponible{get; set;}
    public bool EstaDisponible{get; set;} = true;
}
