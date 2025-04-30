using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Models
{
    public class Pago
    {
        [Key]
        [Display(Name = "ID Pago")]
        public int pagoId { get; set; }

        [Required]
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }

        [Required]
        public int vehiculoId { get; set; }
        [ForeignKey("vehiculoId")]
        public Vehiculo? Vehiculo { get; set; }

        [Display(Name = "Fecha de Pago")]
        public DateTime fechaPago { get; set; } = DateTime.Now;

        [Display(Name = "Monto Pagado")]
        public decimal montoPagado { get; set; }

        public void CalcularMonto()
        {
            montoPagado = Vehiculo.CalcularPago();
        }
    }
}
