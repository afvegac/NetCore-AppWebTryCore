using System.ComponentModel.DataAnnotations;

namespace TryCoreTestDeveloper.Models
{
    public class UsrUsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        [StringLength(250, ErrorMessage = "La descripción debe ser menor a 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese una dirección")]
        [StringLength(250, ErrorMessage = "La dirección debe ser menor a 250 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese una identificación")]
        [StringLength(50, ErrorMessage = "La identificación debe ser menor a 50 caracteres.")]
        public string Identificacion { get; set; }

        public int? MonedaId { get; set; }
    }
}
