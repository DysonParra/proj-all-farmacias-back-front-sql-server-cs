/*
 * @fileoverview    {MedicamentoOnline}
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
 * TODO: Definición de {@code MedicamentoOnline}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class MedicamentoOnline {

        [Key]
        public Int64? IntIdMedicamento { get; set; }
        public DateTime? DtFechaDescarga { get; set; }
        public String? StrCantidad { get; set; }
        public String? StrConcentracion { get; set; }
        public String? StrDescripcion { get; set; }
        public String? StrEan { get; set; }
        public String? StrImagen { get; set; }
        public String? StrLaboratorio { get; set; }
        public String? StrMarca { get; set; }
        public String? StrNombre { get; set; }
        public String? StrPaginaProducto { get; set; }
        public String? StrPrecioUnitario { get; set; }
        public String? StrPresentacion { get; set; }
        public String? StrPrincipioActivo { get; set; }
        public String? StrRegistroInvima { get; set; }
        public Int64? IntIdPortalOrigen { get; set; }

    }

}