/*
 * @fileoverview    {Medicamento} se encarga de realizar tareas específicas.
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Medicamento}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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