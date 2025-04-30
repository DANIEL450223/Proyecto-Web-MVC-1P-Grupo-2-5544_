using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Models
{
    public class Espacios
    {
        [Key]
        [Display(Name = "ID del Espacio")]
        public int espacioId { get; set; }

        [Display(Name = "¿Esta disponible?")]
        public bool estadoEspacio { get; set; } = true;

        [Display(Name = "Vehiculo asignado")]
        public int? vehiculoId { get; set; }

        [ForeignKey("vehiculoId")]
        public Vehiculo? Vehiculo { get; set; }

        public static int espaciosTotales = 0;
        public static int espaciosDisponibles = 0;

        public static void InicializarEspacios(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new Exception("Debe ingresar al menos un espacio.");
            }
            espaciosTotales = cantidad;
            espaciosDisponibles = cantidad;
        }

        public static void OcuparEspacio()
        {
            if (espaciosDisponibles <= 0)
            {
                throw new Exception("No hay espacios disponibles.");
            }
            espaciosDisponibles--;
        }

        public static void LiberarEspacio()
        {
            if (espaciosDisponibles < espaciosTotales)
            {
                espaciosDisponibles++;
            }
        }
    }
}
