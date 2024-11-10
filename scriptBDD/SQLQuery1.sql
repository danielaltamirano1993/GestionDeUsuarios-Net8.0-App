USE master
GO

CREATE DATABASE BDD_GESTION_ITEMS
GO

USE BDD_GESTION_ITEMS
GO

CREATE TABLE Items (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    Titulo              NVARCHAR(100) NOT NULL,
    Descripcion         NVARCHAR(500) NOT NULL,
    Prioridad           NVARCHAR(10) CHECK (Prioridad IN ('Alta', 'Baja')) NOT NULL,
    FechaEntrega        DATE NOT NULL,
    Estado              NVARCHAR(10) CHECK (Estado IN ('Pendiente', 'Completado')) NOT NULL,
    UsuarioAsignadoId   INT NULL,
    FechaCreacion       DATETIME DEFAULT GETDATE(),
    FechaActualizacion  DATETIME DEFAULT GETDATE()
)


--------------------------------------------------------------------

USE master
GO

CREATE DATABASE BDD_USUARIOS;
GO

USE BDD_USUARIOS;
GO

CREATE TABLE Usuarios (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario       NVARCHAR(50) UNIQUE NOT NULL, 
    ConteoPendientes    INT DEFAULT 0, 
    ConteoAltaPrioridad INT DEFAULT 0 
);
GO

----------------------------------------------------------------
SELECT *
FROM   BDD_GESTION_ITEMS.dbo.Items
SELECT *
FROM BDD_USUARIOS.dbo.Usuarios