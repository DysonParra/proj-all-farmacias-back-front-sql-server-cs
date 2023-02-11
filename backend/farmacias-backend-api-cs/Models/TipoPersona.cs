/*
 * @fileoverview    {TipoPersona} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code TipoPersona}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TipoPersona {

        [Key]
        public Int64? IntIdTipoPersona { get; set; }
        public String? StrDescripcion { get; set; }
        public String? StrNombre { get; set; }

    }

}