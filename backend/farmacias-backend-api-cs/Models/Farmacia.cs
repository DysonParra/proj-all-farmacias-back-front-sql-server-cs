/*
 * @fileoverview    {Farmacia}
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
 * TODO: Definición de {@code Farmacia}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Farmacia {

        [Key]
        public Int64? IntCodigoFarmacia { get; set; }
        public String? StrCelular { get; set; }
        public String? StrNit { get; set; }
        public String? StrNombre { get; set; }
        public String? StrTelefonoFijo { get; set; }
        public String? StrUrlExtraccion { get; set; }
        public Int64? IntIdBarrio { get; set; }

    }

}