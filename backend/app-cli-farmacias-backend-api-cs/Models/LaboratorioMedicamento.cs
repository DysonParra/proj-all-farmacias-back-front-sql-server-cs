/*
 * @fileoverview    {LaboratorioMedicamento}
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
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Description of {@code LaboratorioMedicamento}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class LaboratorioMedicamento {

        [Key]
        public Int64? IntId { get; set; }
        public Int64? IntIdLaboratorio { get; set; }
        public Int64? IntIdMedicamento { get; set; }

    }

}