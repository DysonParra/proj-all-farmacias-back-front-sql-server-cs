/*
 * @fileoverview    {Ciudad}
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
     * TODO: Description of {@code Ciudad}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Ciudad {

        [Key]
        public Int64? IntIdCiudad { get; set; }
        public Int32? IntIdDane { get; set; }
        public Int32? IntIdEstado { get; set; }
        public String? StrEstado { get; set; }
        public String? StrNombre { get; set; }

    }

}