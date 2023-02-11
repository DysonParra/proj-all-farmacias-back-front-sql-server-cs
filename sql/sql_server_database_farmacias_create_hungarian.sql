USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Farmacias') DROP DATABASE [Farmacias]
GO
CREATE DATABASE [Farmacias];
GO
USE [Farmacias];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Autenticacion')
CREATE TABLE [dbo].[Autenticacion] (
    [StrUsuario]                        VARCHAR(30)         NOT NULL,
    [StrContrasena]                     VARCHAR(50)             NULL DEFAULT NULL,
    PRIMARY KEY ([StrUsuario])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Barrio')
CREATE TABLE [dbo].[Barrio] (
    [IntIdBarrio]                       BIGINT              NOT NULL IDENTITY,
    [IntIdCiudad]                       BIGINT                  NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdBarrio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ciudad')
CREATE TABLE [dbo].[Ciudad] (
    [IntIdCiudad]                       BIGINT              NOT NULL IDENTITY,
    [IntIdDane]                         INT                     NULL DEFAULT NULL,
    [IntIdEstado]                       INT                     NULL DEFAULT NULL,
    [StrEstado]                         VARCHAR(200)            NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdCiudad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Farmacia')
CREATE TABLE [dbo].[Farmacia] (
    [IntCodigoFarmacia]                 BIGINT              NOT NULL IDENTITY,
    [IntIdBarrio]                       BIGINT                  NULL DEFAULT NULL,
    [StrCelular]                        VARCHAR(255)            NULL DEFAULT NULL,
    [StrNit]                            VARCHAR(20)             NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(200)            NULL DEFAULT NULL,
    [StrTelefonoFijo]                   VARCHAR(20)             NULL DEFAULT NULL,
    [StrUrlExtraccion]                  VARCHAR(4000)           NULL DEFAULT NULL,
    PRIMARY KEY ([IntCodigoFarmacia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'FarmaciaMedicamento')
CREATE TABLE [dbo].[FarmaciaMedicamento] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntIdFarmacia]                     BIGINT                  NULL DEFAULT NULL,
    [IntIdMedicamento]                  BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Laboratorio')
CREATE TABLE [dbo].[Laboratorio] (
    [IntIdLaboratorio]                  BIGINT              NOT NULL IDENTITY,
    [StrDireccion]                      VARCHAR(200)            NULL DEFAULT NULL,
    [StrNit]                            VARCHAR(20)         NOT NULL,
    [StrNombre]                         VARCHAR(150)            NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdLaboratorio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'LaboratorioMedicamento')
CREATE TABLE [dbo].[LaboratorioMedicamento] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntIdLaboratorio]                  BIGINT                  NULL DEFAULT NULL,
    [IntIdMedicamento]                  BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Medicamento')
CREATE TABLE [dbo].[Medicamento] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [BitMedicamentoPos]                 BIT                     NULL DEFAULT NULL,
    [DtFechaCreacion]                   DATETIME                NULL DEFAULT NULL,
    [IntIdLaboratorio]                  BIGINT                  NULL DEFAULT NULL,
    [StrAccionTerapeutica]              VARCHAR(200)            NULL DEFAULT NULL,
    [StrCantidad]                       VARCHAR(10)             NULL DEFAULT NULL,
    [StrCodigoAtc]                      VARCHAR(100)            NULL DEFAULT NULL,
    [StrConcentracion]                  VARCHAR(20)             NULL DEFAULT NULL,
    [StrEan]                            VARCHAR(100)            NULL DEFAULT NULL,
    [StrMarca]                          VARCHAR(100)            NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(200)            NULL DEFAULT NULL,
    [StrNombreComercial]                VARCHAR(100)            NULL DEFAULT NULL,
    [StrNombreGenerico]                 VARCHAR(60)             NULL DEFAULT NULL,
    [StrPresentacion]                   VARCHAR(100)            NULL DEFAULT NULL,
    [StrPrincipioActivo]                VARCHAR(100)            NULL DEFAULT NULL,
    [StrRegistroInvima]                 VARCHAR(100)            NULL DEFAULT NULL,
    [StrUnidadMedida]                   VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MedicamentoOnline')
CREATE TABLE [dbo].[MedicamentoOnline] (
    [IntIdMedicamento]                  BIGINT              NOT NULL IDENTITY,
    [DtFechaDescarga]                   DATETIME                NULL DEFAULT NULL,
    [IntIdPortalOrigen]                 BIGINT                  NULL DEFAULT NULL,
    [StrCantidad]                       VARCHAR(10)             NULL DEFAULT NULL,
    [StrConcentracion]                  VARCHAR(100)            NULL DEFAULT NULL,
    [StrDescripcion]                    VARCHAR(500)            NULL DEFAULT NULL,
    [StrEan]                            VARCHAR(100)            NULL DEFAULT NULL,
    [StrImagen]                         VARCHAR(8000)           NULL DEFAULT NULL,
    [StrLaboratorio]                    VARCHAR(100)            NULL DEFAULT NULL,
    [StrMarca]                          VARCHAR(100)            NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(100)            NULL DEFAULT NULL,
    [StrPaginaProducto]                 VARCHAR(30)             NULL DEFAULT NULL,
    [StrPrecioUnitario]                 VARCHAR(20)             NULL DEFAULT NULL,
    [StrPresentacion]                   VARCHAR(100)            NULL DEFAULT NULL,
    [StrPrincipioActivo]                VARCHAR(100)            NULL DEFAULT NULL,
    [StrRegistroInvima]                 VARCHAR(100)            NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdMedicamento])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [IntIdPersona]                      BIGINT              NOT NULL IDENTITY,
    [IntIdBarrio]                       BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoPersona]                  BIGINT                  NULL DEFAULT NULL,
    [StrApellidoPersona]                VARCHAR(70)             NULL DEFAULT NULL,
    [StrDireccion]                      VARCHAR(200)            NULL DEFAULT NULL,
    [StrGenero]                         VARCHAR(20)             NULL DEFAULT NULL,
    [StrNombrePersona]                  VARCHAR(70)             NULL DEFAULT NULL,
    [StrTelefono]                       VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdPersona])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Propiedades')
CREATE TABLE [dbo].[Propiedades] (
    [IntIdPropiedad]                    BIGINT              NOT NULL IDENTITY,
    [StrDescripcionPropiedad]           VARCHAR(100)            NULL DEFAULT NULL,
    [StrGrupo]                          VARCHAR(100)            NULL DEFAULT NULL,
    [StrNombrePropiedad]                VARCHAR(100)            NULL DEFAULT NULL,
    [StrValorPropiedad]                 VARCHAR(500)            NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdPropiedad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoPersona')
CREATE TABLE [dbo].[TipoPersona] (
    [IntIdTipoPersona]                  BIGINT              NOT NULL IDENTITY,
    [StrDescripcion]                    VARCHAR(200)            NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([IntIdTipoPersona])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Barrio]
    ADD CONSTRAINT [FkBarrioIdCiudad]
        FOREIGN KEY ([IntIdCiudad])
        REFERENCES [Ciudad] ([IntIdCiudad])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Farmacia]
    ADD CONSTRAINT [FkFarmaciaIdBarrio]
        FOREIGN KEY ([IntIdBarrio])
        REFERENCES [Barrio] ([IntIdBarrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [MedicamentoOnline]
    ADD CONSTRAINT [FkMedicamentoOnlineIdPortalOrigen]
        FOREIGN KEY ([IntIdPortalOrigen])
        REFERENCES [Farmacia] ([IntCodigoFarmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [FarmaciaMedicamento]
    ADD CONSTRAINT [FkFarmaciaMedicamentoIdFarmacia]
        FOREIGN KEY ([IntIdFarmacia])
        REFERENCES [Farmacia] ([IntCodigoFarmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkFarmaciaMedicamentoIdMedicamento]
        FOREIGN KEY ([IntIdMedicamento])
        REFERENCES [Medicamento] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [LaboratorioMedicamento]
    ADD CONSTRAINT [FkLaboratorioMedicamentoIdLaboratorio]
        FOREIGN KEY ([IntIdLaboratorio])
        REFERENCES [Laboratorio] ([IntIdLaboratorio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkLaboratorioMedicamentoIdMedicamento]
        FOREIGN KEY ([IntIdMedicamento])
        REFERENCES [Medicamento] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Persona]
    ADD CONSTRAINT [FkPersonaIdTipoPersona]
        FOREIGN KEY ([IntIdTipoPersona])
        REFERENCES [TipoPersona] ([IntIdTipoPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkPersonaIdBarrio]
        FOREIGN KEY ([IntIdBarrio])
        REFERENCES [Barrio] ([IntIdBarrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
