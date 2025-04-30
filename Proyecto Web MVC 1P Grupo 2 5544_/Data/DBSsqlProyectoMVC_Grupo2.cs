using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Web_MVC_1P_Grupo_2_5544_.Models;

    public class DBSsqlProyectoMVC_Grupo2 : DbContext
    {
        public DBSsqlProyectoMVC_Grupo2 (DbContextOptions<DBSsqlProyectoMVC_Grupo2> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_Web_MVC_1P_Grupo_2_5544_.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<Proyecto_Web_MVC_1P_Grupo_2_5544_.Models.Espacios> Espacios { get; set; } = default!;

public DbSet<Proyecto_Web_MVC_1P_Grupo_2_5544_.Models.Pago> Pago { get; set; } = default!;

public DbSet<Proyecto_Web_MVC_1P_Grupo_2_5544_.Models.Registros> Registros { get; set; } = default!;

public DbSet<Proyecto_Web_MVC_1P_Grupo_2_5544_.Models.Vehiculo> Vehiculo { get; set; } = default!;
    }
