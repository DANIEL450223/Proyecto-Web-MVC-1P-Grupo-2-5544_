using System.ComponentModel.DataAnnotations;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [Display(Name = "ID del Cliente")]
        public int clienteId { get; set; }

        [Display(Name = "Nombre del cliente")]
        [MaxLength(100)]
        public string nombreCliente { get; set; }

        [Display(Name = "Teléfono del cliente")]
        public int telefonoCliente { get; set; }

        [MaxLength(100)]
        [Display(Name = "Correo del cliente")]
        public string correoCliente { get; set; }

    }
}
