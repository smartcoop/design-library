
using System.ComponentModel.DataAnnotations;

namespace Smart.Design.Library.Showcase.Models;

public class FieldsForm
{
    [Required(ErrorMessage = "Le champ Nom est requis.")]
    [StringLength(50, ErrorMessage = "La longueur maximale du champ Nom est de 50 caractères.")]
    public string Nom { get; set; }

}