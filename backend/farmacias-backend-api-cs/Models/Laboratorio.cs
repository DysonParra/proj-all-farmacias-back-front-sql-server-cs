/*
 * @fileoverview    {Laboratorio}
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
 * TODO: Definición de {@code Laboratorio}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Laboratorio {

        [Key]
        public Int64? IntIdLaboratorio { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrNit { get; set; }
        public String? StrNombre { get; set; }

    }

}