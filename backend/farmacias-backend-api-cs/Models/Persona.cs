/*
 * @fileoverview    {Persona}
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
 * TODO: Definición de {@code Persona}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Persona {

        [Key]
        public Int64? IntIdPersona { get; set; }
        public String? StrApellidoPersona { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrGenero { get; set; }
        public String? StrNombrePersona { get; set; }
        public String? StrTelefono { get; set; }
        public Int64? IntIdBarrio { get; set; }
        public Int64? IntIdTipoPersona { get; set; }

    }

}