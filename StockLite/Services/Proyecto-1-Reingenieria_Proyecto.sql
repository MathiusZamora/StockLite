-- 1) StockLiteDB
IF DB_ID('StockLiteDB') IS NULL CREATE DATABASE StockLiteDB;
GO
USE StockLiteDB;
GO

CREATE TABLE dbo.Usuario(
  UsuarioId INT IDENTITY PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Usuario VARCHAR(50) NOT NULL UNIQUE,
  ClaveHash VARCHAR(200) NOT NULL,
  Rol VARCHAR(50) NOT NULL,
  Activo BIT NOT NULL Default 1
);

CREATE TABLE dbo.Cliente(
  ClienteId INT IDENTITY PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Contacto VARCHAR(100) NULL,
  CreadoPor INT NULL,
  FechaCreacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ModificadoPor INT NULL,
  FechaModificacion DATETIME2 NULL,
  Activo BIT NOT NULL Default 1

);

CREATE TABLE dbo.Categoria(
  CategoriaId INT IDENTITY PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL UNIQUE,
  CreadoPor INT NULL,
  FechaCreacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ModificadoPor INT NULL,
  FechaModificacion DATETIME2 NULL,
  Activo BIT NOT NULL Default 1

);

CREATE TABLE dbo.Producto(
  ProductoId INT IDENTITY PRIMARY KEY,
  CategoriaId INT NOT NULL FOREIGN KEY REFERENCES dbo.Categoria(CategoriaId),
  Codigo VARCHAR(50) NOT NULL UNIQUE,
  Nombre VARCHAR(200) NOT NULL,
  CostoActual FLOAT NOT NULL,
  PrecioActual FLOAT NOT NULL,
  PrecioVenta FLOAT NOT NULL DEFAULT 0,
  Stock INT NOT NULL DEFAULT 0,
  CreadoPor INT NULL,
  FechaCreacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ModificadoPor INT NULL,
  FechaModificacion DATETIME2 NULL,
  Activo BIT NOT NULL Default 1
  );
CREATE INDEX IX_Producto_Categoria ON dbo.Producto(CategoriaId);

CREATE TABLE dbo.MovimientoStock(
  MovimientoId INT IDENTITY PRIMARY KEY,
  Fecha DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  EsEntrada BIT NOT NULL,
  ClienteId INT NULL FOREIGN KEY REFERENCES dbo.Cliente(ClienteId),
  Observacion VARCHAR(300) NULL,
  CreadoPor INT NULL,
  FechaCreacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ModificadoPor INT NULL,
  FechaModificacion DATETIME2 NULL,
  Activo BIT NOT NULL Default 1
);

CREATE TABLE dbo.DetalleMovimientoStock(
  DetalleId INT IDENTITY PRIMARY KEY,
  MovimientoId INT NOT NULL FOREIGN KEY REFERENCES MovimientoStock(MovimientoId),
  ProductoId INT NOT NULL FOREIGN KEY REFERENCES dbo.Producto(ProductoId),
  Cantidad INT NOT NULL CHECK (Cantidad>0),
  PrecioCompra FLOAT NOT NULL,
  PrecioVenta FLOAT NOT NULL,
  CreadoPor INT NULL,
  FechaCreacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ModificadoPor INT NULL,
  FechaModificacion DATETIME2 NULL,
  Activo BIT NOT NULL Default 1
);

CREATE TABLE Proveedor (
    ProveedorId INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Contacto VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Activo BIT DEFAULT 1,
    CreadoPor INT,
    FechaCreacion DATETIME2 DEFAULT SYSDATETIME()
);


ALTER TABLE Producto ADD ProveedorId INT NULL 
    FOREIGN KEY REFERENCES Proveedor(ProveedorId);




CREATE INDEX IX_Mov_Prod ON dbo.DetalleMovimientoStock(ProductoId, MovimientoId DESC);
GO
