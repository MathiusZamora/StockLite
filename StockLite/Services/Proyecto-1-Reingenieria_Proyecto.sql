-- 1) StockLiteDB
USE MASTER
GO
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
  --Pistas Auditoria
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


--Procedmientos Almacenados
--Login
CREATE PROC ValidarLogin
@usuario VARCHAR(50)

AS
BEGIN
	SELECT UsuarioId, Nombre, Usuario, Rol, Activo, ClaveHash 
    FROM dbo.Usuario 
    WHERE Usuario = @usuario AND Activo = 1
END
GO

CREATE PROC CheckAdmin
AS
BEGIN
	SELECT COUNT(*) FROM dbo.Usuario WHERE Usuario = 'admin'
END
GO

CREATE PROC CrearAdmin
@hash VARCHAR(200)
AS
BEGIN
        INSERT INTO dbo.Usuario (Nombre, Usuario, ClaveHash, Rol, Activo)
		VALUES ('Administrador del Sistema', 'admin', @hash, 'Administrador', 1)
END
GO

--Usuario
CREATE PROC InsertarUsuario
@nombre VARCHAR(200),
@usuario VARCHAR(50),
@hash VARCHAR(200),
@rol VARCHAR(50)

AS
BEGIN
	INSERT INTO Usuario (Nombre, Usuario, ClaveHash, Rol, Activo)
		VALUES (@nombre, @usuario, @hash, @rol, 1)
	SELECT
		SCOPE_IDENTITY() AS ID;
END
GO
   
CREATE PROC ActualizarUsuario @id INT,
@nombre VARCHAR(200),
@usuario VARCHAR(50),
@hash VARCHAR(200) = NULL,
@rol VARCHAR(50)

AS
BEGIN

	IF (ISNULL(@hash, '') = '')
	BEGIN
		UPDATE dbo.Usuario
			SET Nombre = @nombre, 
			Usuario = @usuario, 
			Rol = @rol
		WHERE UsuarioId = @id
	END
	ELSE
	BEGIN
		UPDATE dbo.Usuario 
		SET Nombre = @nombre, 
			Usuario = @usuario, 
			ClaveHash = @hash 
		WHERE UsuarioId = @id
	END
END
GO

CREATE PROC ListarUsuarios 

AS
BEGIN
	SELECT UsuarioId, Nombre, Usuario, Rol FROM dbo.Usuario WHERE Activo = 1 ORDER BY Nombre
END
GO

CREATE PROC AnularUsuario 
@id INT
AS
BEGIN
	UPDATE Usuario
	SET Activo = 0
	WHERE UsuarioId = @id
END
GO

--Categoria
CREATE PROC InsertarCategoria
@userid INT,
@nombre VARCHAR(200)
AS
BEGIN
	INSERT INTO Categoria(Nombre, CreadoPor, FechaCreacion, Activo)
		VALUES (@nombre, @userId, GETDATE(), 1)
	SELECT
		SCOPE_IDENTITY() AS ID;
END
GO
   
CREATE PROC ActualizarCategoria 
@id INT,
@nombre VARCHAR(200),
@userid VARCHAR(50)

AS
BEGIN
	UPDATE dbo.Categoria 
		SET Nombre = @nombre, 
		ModificadoPor = @userId,
		FechaModificacion = SYSUTCDATETIME()
    WHERE CategoriaId = @id
END
GO

CREATE PROC ListarCategoria 

AS
BEGIN
	SELECT CategoriaId, Nombre, Activo FROM dbo.Categoria WHERE Activo = 1 ORDER BY Nombre
END
GO

CREATE PROC AnularCategoria 
@id INT
AS
BEGIN
	UPDATE Categoria
	SET Activo = 0
	WHERE CategoriaId = @id
END
GO

--Cliente
CREATE PROC InsertarCliente
@nombre VARCHAR(100),
@contacto VARCHAR(100),
@user VARCHAR(100)
AS
BEGIN
	INSERT INTO Cliente(Nombre, Contacto, CreadoPor, FechaCreacion, Activo)
		VALUES (@nombre, @contacto, @user, GETDATE(), 1)
	SELECT
		SCOPE_IDENTITY() AS ID;
END
GO
   
CREATE PROC ActualizarCliente
@id INT,
@nombre VARCHAR(100),
@contacto VARCHAR(100),
@user VARCHAR(100)

AS
BEGIN
	UPDATE dbo.Cliente 
		SET Nombre = @nombre, 
		ModificadoPor = @user,
		FechaModificacion = SYSUTCDATETIME()
    WHERE ClienteId = @id
END
GO

CREATE PROC ListarCliente

AS
BEGIN
	SELECT ClienteId, Nombre, Contacto, Activo FROM dbo.Cliente WHERE Activo = 1 ORDER BY Nombre
END
GO

CREATE PROC AnularCliente
@id INT
AS
BEGIN
	UPDATE Cliente
	SET Activo = 0
	,FechaModificacion = SYSUTCDATETIME()
	WHERE ClienteId = @id
END
GO


--Proveedor
CREATE PROC InsertarProveedor
@Nombre VARCHAR(150),
@Contacto VARCHAR(100),
@Telefono VARCHAR(20),
@Email VARCHAR(100),
@CreadoPor INT
AS
BEGIN
	INSERT INTO Proveedor(Nombre, Contacto, Telefono, Email, CreadoPor, FechaCreacion, Activo)
		VALUES (@Nombre, @Contacto, @Telefono, @Email, @CreadoPor, SYSDATETIME(), 1)
	SELECT
		SCOPE_IDENTITY() AS ID;
END
GO
   
CREATE PROC ActualizarProveedor
@ProveedorId INT,
@Nombre VARCHAR(150),
@Contacto VARCHAR(100),
@Telefono VARCHAR(20),
@Email VARCHAR(100)
AS
BEGIN
                UPDATE Proveedor 
                SET Nombre = @Nombre,
                    Contacto = @Contacto,
                    Telefono = @Telefono,
                    Email = @Email					
                WHERE ProveedorId = @ProveedorId
END
GO

CREATE PROC ListarProveedor

AS
BEGIN
	SELECT ProveedorId, Nombre, Contacto, Telefono, Email, Activo, CreadoPor, FechaCreacion 
	FROM Proveedor 
	WHERE Activo = 1 
	ORDER BY Nombre
END
GO

CREATE PROC AnularProveedor
@id INT
AS
BEGIN
	UPDATE Proveedor SET Activo = 0 
	WHERE ProveedorId = @id
END
GO

---------------

--Producto
CREATE PROC InsertarProducto
@codigo VARCHAR(50),
@nombre VARCHAR(200),
@categoriaId INT,
@costoActual FLOAT,
@precio FLOAT,
@proveedorId INT,
@creadoPor INT
AS
BEGIN
	INSERT INTO Producto 
    (Codigo, Nombre, CategoriaId, CostoActual, PrecioActual, PrecioVenta, ProveedorId, Stock, CreadoPor, FechaCreacion, Activo)
VALUES 
    (@codigo, @nombre, @categoriaId, @costoActual, @precio, @precio, @proveedorId, 0, @creadoPor, SYSDATETIME(), 1)
	SELECT
		SCOPE_IDENTITY() AS ID;
END
GO
   
CREATE PROC ActualizarProducto
@productoId INT,
@nombre VARCHAR(200),
@categoriaId INT,
@costoActual FLOAT,
@precio FLOAT,
@proveedorId INT,
@modificadopor INT
AS
BEGIN
        UPDATE Producto 
        SET Nombre = @nombre,
            CategoriaId = @categoriaId,
            CostoActual = @costoActual,
            PrecioActual = @precio,
            PrecioVenta = @precio,
            ProveedorId = @proveedorId,
            ModificadoPor = @modificadoPor,
            FechaModificacion = SYSDATETIME()
        WHERE ProductoId = @productoId
END
GO

CREATE PROC ListarProducto

AS
BEGIN
	SELECT p.ProductoId,
       p.Codigo,
       p.Nombre,
       p.CategoriaId,
       c.Nombre AS CategoriaNombre,
       p.CostoActual AS PrecioCosto,
       p.PrecioActual AS PrecioVenta,
       p.Stock AS StockActual,
       p.ProveedorId,
       ISNULL(pr.Nombre, '-- Sin proveedor --') AS ProveedorNombre
		FROM dbo.Producto p
		LEFT JOIN dbo.Categoria c ON p.CategoriaId = c.CategoriaId
		LEFT JOIN dbo.Proveedor pr ON p.ProveedorId = pr.ProveedorId AND pr.Activo = 1
		WHERE p.Activo = 1
		ORDER BY p.Nombre
END
GO

CREATE PROC AnularProducto
@id INT
AS
BEGIN
	UPDATE Producto SET Activo = 0 
	WHERE ProductoId = @id
END
GO


--Movimiento Stock
CREATE PROC InsertarMovimientoStock
@esEntrada BIT,
@clienteId INT,
@observacion VARCHAR(300),
@creadoPor INT
AS
BEGIN
	INSERT INTO dbo.MovimientoStock (Fecha, EsEntrada, ClienteId, Observacion, CreadoPor, FechaCreacion)
	VALUES (SYSDATETIME(), @esEntrada, @clienteId, @observacion, @creadoPor, SYSDATETIME());
	SELECT SCOPE_IDENTITY();
END
GO
 
--DetalleMovimientoStock
CREATE PROC InsertarDetalleMovimientoStock
@movId INT,
@prodId INT,
@cant INT,
@pCompra FLOAT,
@pVenta FLOAT,
@creadoPor INT
AS
BEGIN
	INSERT INTO DetalleMovimientoStock
    (MovimientoId, ProductoId, Cantidad, PrecioCompra, PrecioVenta, CreadoPor, FechaCreacion)
VALUES (@movId, @prodId, @cant, @pCompra, @pVenta, @creadoPor, SYSDATETIME())
END
GO

CREATE PROC SumarStock
@cant INT,
@id INT
AS
BEGIN
	UPDATE dbo.Producto SET Stock = Stock + @cant WHERE ProductoId = @id
END 
GO

CREATE PROC RestarStock
@cant INT,
@id INT
AS
BEGIN
	UPDATE dbo.Producto SET Stock = Stock - @cant WHERE ProductoId = @id
END 
GO

CREATE PROC BuscarHistorial
    @desde DATETIME2,
    @hasta DATETIME2,
    @productoId INT = NULL,
    @clienteId INT = NULL,
    @proveedorId INT = NULL
AS
BEGIN
    SELECT 
        m.FechaCreacion AS Fecha,
        CASE WHEN m.EsEntrada = 1 THEN 'ENTRADA' ELSE 'SALIDA' END AS Tipo,
        p.Codigo,
        p.Nombre AS Producto,
        d.Cantidad,
        ISNULL(c.Nombre, 'Sin cliente') AS Cliente,
        ISNULL(pr.Nombre, 'Sin proveedor') AS Proveedor,
        ISNULL(u.Usuario, 'Desconocido') AS Usuario,
        ISNULL(m.Observacion, '') AS Observacion
    FROM MovimientoStock m
    INNER JOIN DetalleMovimientoStock d ON m.MovimientoId = d.MovimientoId
    INNER JOIN Producto p ON d.ProductoId = p.ProductoId
    LEFT JOIN Cliente c ON m.ClienteId = c.ClienteId
    LEFT JOIN Proveedor pr ON p.ProveedorId = pr.ProveedorId
    INNER JOIN Usuario u ON m.CreadoPor = u.UsuarioId
    WHERE m.FechaCreacion >= @desde 
      AND m.FechaCreacion < DATEADD(DAY, 1, @hasta)
      AND (@productoId IS NULL OR d.ProductoId = @productoId)
      AND (@clienteId IS NULL OR m.ClienteId = @clienteId)
      AND (@proveedorId IS NULL OR p.ProveedorId = @proveedorId)
    ORDER BY m.FechaCreacion DESC
END
GO


CREATE PROC BuscarHistorial
@desde datetime2,
@hasta dateTime2,
@productoId INT NULL,
@clienteId INT NULL,
@proveedorId INT NULL
AS
BEGIN
SELECT 
    m.FechaCreacion AS Fecha,
    CASE WHEN m.EsEntrada = 1 THEN 'ENTRADA' ELSE 'SALIDA' END AS Tipo,
    p.Codigo,
    p.Nombre AS Producto,
    d.Cantidad,
    ISNULL(c.Nombre, 'Sin cliente') AS Cliente,
    ISNULL(pr.Nombre, 'Sin proveedor') AS Proveedor,
    ISNULL(u.Usuario, 'Desconocido') AS Usuario,
    ISNULL(m.Observacion, '') AS Observacion
FROM MovimientoStock m
INNER JOIN DetalleMovimientoStock d ON m.MovimientoId = d.MovimientoId
INNER JOIN Producto p ON d.ProductoId = p.ProductoId
LEFT JOIN Cliente c ON m.ClienteId = c.ClienteId
LEFT JOIN Proveedor pr ON p.ProveedorId = pr.ProveedorId
INNER JOIN Usuario u ON m.CreadoPor = u.UsuarioId
WHERE m.FechaCreacion >= @desde 
  AND m.FechaCreacion < DATEADD(DAY, 1, @hasta)
  AND (@productoId IS NULL OR d.ProductoId = @productoId)
  AND (@clienteId IS NULL OR m.ClienteId = @clienteId OR (m.ClienteId IS NULL AND @clienteId = 0))
  AND (@proveedorId IS NULL OR p.ProveedorId = @proveedorId)
ORDER BY m.FechaCreacion DESC
END
GO