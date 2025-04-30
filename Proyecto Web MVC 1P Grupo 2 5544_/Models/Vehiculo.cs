using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Models
{
    public class Vehiculo
    {
        [Key]
        [Required]
        [Display(Name = "ID Vehiculo")]
        public int vehiculoId { get; set; }

        [Display(Name = "Placa del vehiculo")]
        [MaxLength(8)]
        public string placaVehiculo { get; set; }

        [Display(Name = "Modelo del vehiculo")]
        [MaxLength(20)]
        public string modeloVehiculo { get; set; }

        [Display(Name = "Marca del vehiculo")]
        [MaxLength(20)]
        public string marcaVehiculo { get; set; }

        [Display(Name = "Color del vehiculo")]
        [MaxLength(20)]
        public string colorVehiculo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y Hora de Ingreso")]
        public DateTime fechaIngreso { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y Hora de Salida")]
        public DateTime? fechaSalida { get; set; } 

        [Required]
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        [Display(Name = "ID Cliente")]
        public Cliente? Cliente { get; set; }

        // Metodo para calcular horas se hizo con ayuda de chatGPT
        public double CalcularHoras()
        {
            if (fechaSalida.HasValue)
            {
                TimeSpan duracion = fechaSalida.Value - fechaIngreso;
                return Math.Ceiling(duracion.TotalHours); 
            }
            return 0;
        }

        public decimal CalcularPago()
        {
            return (decimal)CalcularHoras() * 1.00m; 
        }
    }
}
