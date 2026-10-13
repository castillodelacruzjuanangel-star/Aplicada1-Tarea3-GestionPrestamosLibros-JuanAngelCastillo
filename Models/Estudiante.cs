using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace RegistroPrestamosLibros.Models;
=======
namespace Models;
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f

public class Estudiante
{
    [Key]
    public int EstudianteId{get; set;}

    [Required(ErrorMessage ="El nombre no debe estar vacio.")]
    public string Nombre{get; set;} = string.Empty;

    [Required(ErrorMessage ="Es necesario agregar una direccion.")]
    public string Direccion{get; set;} = string.Empty;

    [Required(ErrorMessage ="Es necesario agregar un email.")]
    [EmailAddress(ErrorMessage ="Por favor, ingrese una direccion de correo valida")]
    public string Email{get; set;} = string.Empty;

    [Range(typeof(DateOnly), "1950-01-01", "2026-12-31", ErrorMessage = "Por favor, ingrese una fecha entre 1950 y 2026.")]
<<<<<<< HEAD
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly FechaNacimiento{get; set;}
=======
    public DateOnly? FechaNacimiento{get; set;}

>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f
}
