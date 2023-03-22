/*
 * @fileoverview    {Propiedades}
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
 * TODO: Definición de {@code Propiedades}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Propiedades {

        [Key]
        public Int64? IntIdPropiedad { get; set; }
        public String? StrDescripcionPropiedad { get; set; }
        public String? StrGrupo { get; set; }
        public String? StrNombrePropiedad { get; set; }
        public String? StrValorPropiedad { get; set; }

    }

}