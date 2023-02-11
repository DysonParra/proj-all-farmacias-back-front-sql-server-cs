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
    [Id_Barrio]                         BIGINT              NOT NULL IDENTITY,
    [Id_Ciudad]                         BIGINT                  NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Barrio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ciudad')
CREATE TABLE [dbo].[Ciudad] (
    [Id_Ciudad]                         BIGINT              NOT NULL IDENTITY,
    [Id_Dane]                           INT                     NULL DEFAULT NULL,
    [Id_Estado]                         INT                     NULL DEFAULT NULL,
    [Estado]                            VARCHAR(200)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Ciudad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Farmacia')
CREATE TABLE [dbo].[Farmacia] (
    [Codigo_Farmacia]                   BIGINT              NOT NULL IDENTITY,
    [Id_Barrio]                         BIGINT                  NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Nit]                               VARCHAR(20)             NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    [Telefono_Fijo]                     VARCHAR(20)             NULL DEFAULT NULL,
    [Url_Extraccion]                    VARCHAR(4000)           NULL DEFAULT NULL,
    PRIMARY KEY ([Codigo_Farmacia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Farmacia_Medicamento')
CREATE TABLE [dbo].[Farmacia_Medicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Id_Farmacia]                       BIGINT                  NULL DEFAULT NULL,
    [Id_Medicamento]                    BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Laboratorio')
CREATE TABLE [dbo].[Laboratorio] (
    [Id_Laboratorio]                    BIGINT              NOT NULL IDENTITY,
    [Direccion]                         VARCHAR(200)            NULL DEFAULT NULL,
    [Nit]                               VARCHAR(20)         NOT NULL,
    [Nombre]                            VARCHAR(150)            NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Laboratorio])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Laboratorio_Medicamento')
CREATE TABLE [dbo].[Laboratorio_Medicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Id_Laboratorio]                    BIGINT                  NULL DEFAULT NULL,
    [Id_Medicamento]                    BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Medicamento')
CREATE TABLE [dbo].[Medicamento] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Medicamento_Pos]                   BIT                     NULL DEFAULT NULL,
    [Fecha_Creacion]                    DATETIME                NULL DEFAULT NULL,
    [Id_Laboratorio]                    BIGINT                  NULL DEFAULT NULL,
    [Accion_Terapeutica]                VARCHAR(200)            NULL DEFAULT NULL,
    [Cantidad]                          VARCHAR(10)             NULL DEFAULT NULL,
    [Codigo_Atc]                        VARCHAR(100)            NULL DEFAULT NULL,
    [Concentracion]                     VARCHAR(20)             NULL DEFAULT NULL,
    [Ean]                               VARCHAR(100)            NULL DEFAULT NULL,
    [Marca]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(200)            NULL DEFAULT NULL,
    [Nombre_Comercial]                  VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre_Generico]                   VARCHAR(60)             NULL DEFAULT NULL,
    [Presentacion]                      VARCHAR(100)            NULL DEFAULT NULL,
    [Principio_Activo]                  VARCHAR(100)            NULL DEFAULT NULL,
    [Registro_Invima]                   VARCHAR(100)            NULL DEFAULT NULL,
    [Unidad_Medida]                     VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Medicamento_Online')
CREATE TABLE [dbo].[Medicamento_Online] (
    [Id_Medicamento]                    BIGINT              NOT NULL IDENTITY,
    [Fecha_Descarga]                    DATETIME                NULL DEFAULT NULL,
    [Id_Portal_Origen]                  BIGINT                  NULL DEFAULT NULL,
    [Cantidad]                          VARCHAR(10)             NULL DEFAULT NULL,
    [Concentracion]                     VARCHAR(100)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(500)            NULL DEFAULT NULL,
    [Ean]                               VARCHAR(100)            NULL DEFAULT NULL,
    [Imagen]                            VARCHAR(8000)           NULL DEFAULT NULL,
    [Laboratorio]                       VARCHAR(100)            NULL DEFAULT NULL,
    [Marca]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(100)            NULL DEFAULT NULL,
    [Pagina_Producto]                   VARCHAR(30)             NULL DEFAULT NULL,
    [Precio_Unitario]                   VARCHAR(20)             NULL DEFAULT NULL,
    [Presentacion]                      VARCHAR(100)            NULL DEFAULT NULL,
    [Principio_Activo]                  VARCHAR(100)            NULL DEFAULT NULL,
    [Registro_Invima]                   VARCHAR(100)            NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Medicamento])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [Id_Persona]                        BIGINT              NOT NULL IDENTITY,
    [Id_Barrio]                         BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Persona]                   BIGINT                  NULL DEFAULT NULL,
    [Apellido_Persona]                  VARCHAR(70)             NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(200)            NULL DEFAULT NULL,
    [Genero]                            VARCHAR(20)             NULL DEFAULT NULL,
    [Nombre_Persona]                    VARCHAR(70)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Persona])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Propiedades')
CREATE TABLE [dbo].[Propiedades] (
    [Id_Propiedad]                      BIGINT              NOT NULL IDENTITY,
    [Descripcion_Propiedad]             VARCHAR(100)            NULL DEFAULT NULL,
    [Grupo]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Nombre_Propiedad]                  VARCHAR(100)            NULL DEFAULT NULL,
    [Valor_Propiedad]                   VARCHAR(500)            NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Propiedad])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipo_Persona')
CREATE TABLE [dbo].[Tipo_Persona] (
    [Id_Tipo_Persona]                   BIGINT              NOT NULL IDENTITY,
    [Descripcion]                       VARCHAR(200)            NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY ([Id_Tipo_Persona])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Barrio]
    ADD CONSTRAINT [Fk_Barrio_Id_Ciudad]
        FOREIGN KEY ([Id_Ciudad])
        REFERENCES [Ciudad] ([Id_Ciudad])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Farmacia]
    ADD CONSTRAINT [Fk_Farmacia_Id_Barrio]
        FOREIGN KEY ([Id_Barrio])
        REFERENCES [Barrio] ([Id_Barrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Medicamento_Online]
    ADD CONSTRAINT [Fk_Medicamento_Online_Id_Portal_Origen]
        FOREIGN KEY ([Id_Portal_Origen])
        REFERENCES [Farmacia] ([Codigo_Farmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Farmacia_Medicamento]
    ADD CONSTRAINT [Fk_Farmacia_Medicamento_Id_Farmacia]
        FOREIGN KEY ([Id_Farmacia])
        REFERENCES [Farmacia] ([Codigo_Farmacia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Farmacia_Medicamento_Id_Medicamento]
        FOREIGN KEY ([Id_Medicamento])
        REFERENCES [Medicamento] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Laboratorio_Medicamento]
    ADD CONSTRAINT [Fk_Laboratorio_Medicamento_Id_Laboratorio]
        FOREIGN KEY ([Id_Laboratorio])
        REFERENCES [Laboratorio] ([Id_Laboratorio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Laboratorio_Medicamento_Id_Medicamento]
        FOREIGN KEY ([Id_Medicamento])
        REFERENCES [Medicamento] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Persona]
    ADD CONSTRAINT [Fk_Persona_Id_Tipo_Persona]
        FOREIGN KEY ([Id_Tipo_Persona])
        REFERENCES [Tipo_Persona] ([Id_Tipo_Persona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Persona_Id_Barrio]
        FOREIGN KEY ([Id_Barrio])
        REFERENCES [Barrio] ([Id_Barrio])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
