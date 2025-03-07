USE [templateDB]
GO

/****** Objeto: Table [dbo].[Servicios] Fecha del script: 04/03/2025 19:03:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Servicios] (
    [IdServicio]      INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (100)  NOT NULL,
    [Descripcion]     NVARCHAR (255)  NULL,
    [DuracionMinutos] INT             NOT NULL,
    [Precio]          DECIMAL (10, 2) NOT NULL,
    [Estado]          BIT             NOT NULL
);


