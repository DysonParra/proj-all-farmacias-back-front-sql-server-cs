/*
 * @fileoverview    {Medicamento}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code Medicamento}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Medicamento {

        [Key]
        public Int64? IntId { get; set; }
        public Boolean? BitMedicamentoPos { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public Int64? IntIdLaboratorio { get; set; }
        public String? StrAccionTerapeutica { get; set; }
        public String? StrCantidad { get; set; }
        public String? StrCodigoAtc { get; set; }
        public String? StrConcentracion { get; set; }
        public String? StrEan { get; set; }
        public String? StrMarca { get; set; }
        public String? StrNombre { get; set; }
        public String? StrNombreComercial { get; set; }
        public String? StrNombreGenerico { get; set; }
        public String? StrPresentacion { get; set; }
        public String? StrPrincipioActivo { get; set; }
        public String? StrRegistroInvima { get; set; }
        public String? StrUnidadMedida { get; set; }

    }

}