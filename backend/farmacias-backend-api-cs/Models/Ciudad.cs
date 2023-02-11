/*
 * @fileoverview    {Ciudad} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Ciudad}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Ciudad {

        [Key]
        public Int64? IntIdCiudad { get; set; }
        public Int32? IntIdDane { get; set; }
        public Int32? IntIdEstado { get; set; }
        public String? StrEstado { get; set; }
        public String? StrNombre { get; set; }

    }

}