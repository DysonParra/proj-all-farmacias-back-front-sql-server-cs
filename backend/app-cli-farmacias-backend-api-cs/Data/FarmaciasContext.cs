/*
 * @fileoverview    {FarmaciasContext}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Farmacias.Data {

    /**
     * TODO: Description of {@code FarmaciasContext}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class FarmaciasContext : DbContext {

        /**
         * TODO: Description of method {@code FarmaciasContext}.
         *
         */
        public FarmaciasContext(DbContextOptions<FarmaciasContext> options)
            : base(options) {
        }

        public DbSet<Project.Models.Autenticacion> Autenticacion { get; set; } = default!;

        public DbSet<Project.Models.Barrio> Barrio { get; set; }

        public DbSet<Project.Models.Ciudad> Ciudad { get; set; }

        public DbSet<Project.Models.Farmacia> Farmacia { get; set; }

        public DbSet<Project.Models.FarmaciaMedicamento> FarmaciaMedicamento { get; set; }

        public DbSet<Project.Models.Laboratorio> Laboratorio { get; set; }

        public DbSet<Project.Models.LaboratorioMedicamento> LaboratorioMedicamento { get; set; }

        public DbSet<Project.Models.Medicamento> Medicamento { get; set; }

        public DbSet<Project.Models.MedicamentoOnline> MedicamentoOnline { get; set; }

        public DbSet<Project.Models.Persona> Persona { get; set; }

        public DbSet<Project.Models.Propiedades> Propiedades { get; set; }

        public DbSet<Project.Models.TipoPersona> TipoPersona { get; set; }
    }
}
