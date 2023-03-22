/*
 * @fileoverview    {Barrio}
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
 * TODO: Definición de {@code Barrio}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Barrio {

        [Key]
        public Int64? IntIdBarrio { get; set; }
        public String? StrNombre { get; set; }
        public Int64? IntIdCiudad { get; set; }

    }

}