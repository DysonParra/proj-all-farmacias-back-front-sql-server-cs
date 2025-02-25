/*
 * @fileoverview    {TipoPersona}
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
     * TODO: Description of {@code TipoPersona}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TipoPersona {

        [Key]
        public Int64? IntIdTipoPersona { get; set; }
        public String? StrDescripcion { get; set; }
        public String? StrNombre { get; set; }

    }

}