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
    [Usuario]                           VARCHAR(30)         NOT NULL,
    [Contrasena]                        VARCHAR(50)             NULL DEFAULT NULL,
    PRIMARY KEY ([Usuario])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Barrio')
CREATE TABLE [dbo].[Barrio] (
    [IdBarrio]                          BIGINT              NOT NULL IDENTITY,
    [IdCiudad]                          BIGINT                  NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([IdBarrio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ciudad')
CREATE TABLE [dbo].[Ciudad] (
    [IdCiudad]                          BIGINT              NOT NULL IDENTITY,
    [IdDane]                            INT                     NULL DEFAULT NULL,
    [IdEstado]                          INT                     NULL DEFAULT NULL,
    [Estado]                            VARCHAR(200)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([IdCiudad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Farmacia')
CREATE TABLE [dbo].[Farmacia] (
    [CodigoFarmacia]                    BIGINT              NOT NULL IDENTITY,
    [IdBarrio]                          BIGINT                  NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Nit]                               VARCHAR(20)             NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    [TelefonoFijo]                      VARCHAR(20)             NULL DEFAULT NULL,
    [UrlExtraccion]                     VARCHAR(4000)           NULL DEFAULT NULL,
    PRIMARY KEY ([CodigoFarmacia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'FarmaciaMedicamento')
CREATE TABLE [dbo].[FarmaciaMedicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [IdFarmacia]                        BIGINT                  NULL DEFAULT NULL,
    [IdMedicamento]                     BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Laboratorio')
CREATE TABLE [dbo].[Laboratorio] (
    [IdLaboratorio]                     BIGINT              NOT NULL IDENTITY,
    [Direccion]                         VARCHAR(200)            NULL DEFAULT NULL,
    [Nit]                               VARCHAR(20)         NOT NULL,
    [Nombre]                            VARCHAR(150)            NULL DEFAULT NULL,
    PRIMARY KEY ([IdLaboratorio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'LaboratorioMedicamento')
CREATE TABLE [dbo].[LaboratorioMedicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [IdLaboratorio]                     BIGINT                  NULL DEFAULT NULL,
    [IdMedicamento]                     BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Medicamento')
CREATE TABLE [dbo].[Medicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [MedicamentoPos]                    BIT                     NULL DEFAULT NULL,
    [FechaCreacion]                     DATETIME                NULL DEFAULT NULL,
    [IdLaboratorio]                     BIGINT                  NULL DEFAULT NULL,
    [AccionTerapeutica]                 VARCHAR(200)            NULL DEFAULT NULL,
    [Cantidad]                          VARCHAR(10)             NULL DEFAULT NULL,
    [CodigoAtc]                         VARCHAR(100)            NULL DEFAULT NULL,
    [Concentracion]                     VARCHAR(20)             NULL DEFAULT NULL,
    [Ean]                               VARCHAR(100)            NULL DEFAULT NULL,
    [Marca]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    [NombreComercial]                   VARCHAR(100)            NULL DEFAULT NULL,
    [NombreGenerico]                    VARCHAR(60)             NULL DEFAULT NULL,
    [Presentacion]                      VARCHAR(100)            NULL DEFAULT NULL,
    [PrincipioActivo]                   VARCHAR(100)            NULL DEFAULT NULL,
    [RegistroInvima]                    VARCHAR(100)            NULL DEFAULT NULL,
    [UnidadMedida]                      VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MedicamentoOnline')
CREATE TABLE [dbo].[MedicamentoOnline] (
    [IdMedicamento]                     BIGINT              NOT NULL IDENTITY,
    [FechaDescarga]                     DATETIME                NULL DEFAULT NULL,
    [IdPortalOrigen]                    BIGINT                  NULL DEFAULT NULL,
    [Cantidad]                          VARCHAR(10)             NULL DEFAULT NULL,
    [Concentracion]                     VARCHAR(100)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(500)            NULL DEFAULT NULL,
    [Ean]                               VARCHAR(100)            NULL DEFAULT NULL,
    [Imagen]                            VARCHAR(8000)           NULL DEFAULT NULL,
    [Laboratorio]                       VARCHAR(100)            NULL DEFAULT NULL,
    [Marca]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(100)            NULL DEFAULT NULL,
    [PaginaProducto]                    VARCHAR(30)             NULL DEFAULT NULL,
    [PrecioUnitario]                    VARCHAR(20)             NULL DEFAULT NULL,
    [Presentacion]                      VARCHAR(100)            NULL DEFAULT NULL,
    [PrincipioActivo]                   VARCHAR(100)            NULL DEFAULT NULL,
    [RegistroInvima]                    VARCHAR(100)            NULL DEFAULT NULL,
    PRIMARY KEY ([IdMedicamento])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [IdPersona]                         BIGINT              NOT NULL IDENTITY,
    [IdBarrio]                          BIGINT                  NULL DEFAULT NULL,
    [IdTipoPersona]                     BIGINT                  NULL DEFAULT NULL,
    [ApellidoPersona]                   VARCHAR(70)             NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(200)            NULL DEFAULT NULL,
    [Genero]                            VARCHAR(20)             NULL DEFAULT NULL,
    [NombrePersona]                     VARCHAR(70)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([IdPersona])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Propiedades')
CREATE TABLE [dbo].[Propiedades] (
    [IdPropiedad]                       BIGINT              NOT NULL IDENTITY,
    [DescripcionPropiedad]              VARCHAR(100)            NULL DEFAULT NULL,
    [Grupo]                             VARCHAR(100)            NULL DEFAULT NULL,
    [NombrePropiedad]                   VARCHAR(100)            NULL DEFAULT NULL,
    [ValorPropiedad]                    VARCHAR(500)            NULL DEFAULT NULL,
    PRIMARY KEY ([IdPropiedad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoPersona')
CREATE TABLE [dbo].[TipoPersona] (
    [IdTipoPersona]                     BIGINT              NOT NULL IDENTITY,
    [Descripcion]                       VARCHAR(200)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([IdTipoPersona])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Barrio]
    ADD CONSTRAINT [FkBarrioIdCiudad]
        FOREIGN KEY ([IdCiudad])
        REFERENCES [Ciudad] ([IdCiudad])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Farmacia]
    ADD CONSTRAINT [FkFarmaciaIdBarrio]
        FOREIGN KEY ([IdBarrio])
        REFERENCES [Barrio] ([IdBarrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [MedicamentoOnline]
    ADD CONSTRAINT [FkMedicamentoOnlineIdPortalOrigen]
        FOREIGN KEY ([IdPortalOrigen])
        REFERENCES [Farmacia] ([CodigoFarmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [FarmaciaMedicamento]
    ADD CONSTRAINT [FkFarmaciaMedicamentoIdFarmacia]
        FOREIGN KEY ([IdFarmacia])
        REFERENCES [Farmacia] ([CodigoFarmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkFarmaciaMedicamentoIdMedicamento]
        FOREIGN KEY ([IdMedicamento])
        REFERENCES [Medicamento] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [LaboratorioMedicamento]
    ADD CONSTRAINT [FkLaboratorioMedicamentoIdLaboratorio]
        FOREIGN KEY ([IdLaboratorio])
        REFERENCES [Laboratorio] ([IdLaboratorio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkLaboratorioMedicamentoIdMedicamento]
        FOREIGN KEY ([IdMedicamento])
        REFERENCES [Medicamento] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Persona]
    ADD CONSTRAINT [FkPersonaIdTipoPersona]
        FOREIGN KEY ([IdTipoPersona])
        REFERENCES [TipoPersona] ([IdTipoPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkPersonaIdBarrio]
        FOREIGN KEY ([IdBarrio])
        REFERENCES [Barrio] ([IdBarrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
