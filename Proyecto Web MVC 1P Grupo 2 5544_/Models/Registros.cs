using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Models
{
    public class Registros
    {
        [Key]
        [Display(Name = "ID del Registro")]
        public int registroId { get; set; }

        [Required]
        public int vehiculoId { get; set; }
        [ForeignKey("vehiculoId")]
        public Vehiculo? Vehiculo { get; set; }

        [Required]
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y Hora de Entrada")]
        public DateTime fechaEntrada { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y Hora de Salida")]
        public DateTime? fechaSalida { get; set; }

        [Display(Name = "Pago Realizado")]
        public decimal pagoRealizado { get; set; }

        // Este metodo fue con ayuda de chatgpt
        public void FinalizarRegistro()
        {
            fechaSalida = DateTime.Now;
            pagoRealizado = Vehiculo.CalcularPago();
        }
    }
}
