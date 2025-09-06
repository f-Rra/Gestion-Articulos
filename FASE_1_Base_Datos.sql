-- =====================================================
-- SCRIPT COMPLETO - SISTEMA DE GESTIÓN DE ARTÍCULOS CON STOCK
-- =====================================================

-- Eliminar base de datos si existe y crear nueva
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'CATALOGO_P3_DB')
BEGIN
    DROP DATABASE CATALOGO_P3_DB;
END
GO

CREATE DATABASE CATALOGO_P3_DB;
GO

USE CATALOGO_P3_DB;
GO

-- =====================================================
-- CREACIÓN DE TABLAS
-- =====================================================

-- Tabla de Categorías
CREATE TABLE CATEGORIAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);

-- Tabla de Marcas
CREATE TABLE MARCAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);

-- Tabla de Artículos (CON CAMPO STOCK INCLUIDO)
CREATE TABLE ARTICULOS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150) NULL,
    IdMarca INT NOT NULL,
    IdCategoria INT NOT NULL,
    ImagenUrl VARCHAR(1000) NULL,
    Precio MONEY NOT NULL,
    Stock INT NOT NULL DEFAULT 0,  -- CAMPO STOCK AGREGADO
    Estado BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (IdMarca) REFERENCES MARCAS(Id),
    FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS(Id)
);

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Pass VARCHAR(50) NOT NULL,
    TipoUsuario INT NOT NULL DEFAULT 2  -- 1=Admin, 2=Vendedor
);

-- =====================================================
-- DATOS DE PRUEBA
-- =====================================================

-- Insertar Categorías
INSERT INTO CATEGORIAS (Descripcion) VALUES 
('Electrónicos'),
('Periféricos'),
('Monitores'),
('Accesorios'),
('Software');

-- Insertar Marcas
INSERT INTO MARCAS (Descripcion) VALUES 
('HP'),
('Logitech'),
('Razer'),
('Samsung'),
('Microsoft'),
('Apple');

-- Insertar Usuarios
INSERT INTO Usuarios (Usuario, Pass, TipoUsuario) VALUES 
('admin', 'admin123', 1),
('vendedor', 'vend123', 2);

-- Insertar Artículos CON STOCK
INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, ImagenUrl) VALUES 
('ART001', 'Notebook HP Pavilion', 'Laptop HP Pavilion 15" Intel i5 8GB RAM', 1, 1, 1200.00, 15, 'https://example.com/notebook.jpg'),
('ART002', 'Mouse Logitech MX', 'Mouse inalámbrico Logitech MX Master 3', 2, 2, 45.00, 25, 'https://example.com/mouse.jpg'),
('ART003', 'Teclado Razer Mecánico', 'Teclado mecánico Razer BlackWidow V3', 3, 2, 120.00, 8, 'https://example.com/teclado.jpg'),
('ART004', 'Monitor Samsung 24"', 'Monitor Samsung 24" Full HD 75Hz', 4, 3, 350.00, 12, 'https://example.com/monitor.jpg'),
('ART005', 'Webcam Logitech C920', 'Webcam Logitech C920 HD 1080p', 2, 4, 80.00, 0, 'https://example.com/webcam.jpg'),
('ART006', 'Surface Pro Microsoft', 'Microsoft Surface Pro 8 i7 16GB', 5, 1, 2500.00, 3, 'https://example.com/surface.jpg');

-- =====================================================
-- VISTA OPTIMIZADA CON STOCK
-- =====================================================

CREATE VIEW vw_ArticulosCompletos AS
SELECT 
    a.Id, a.Codigo, a.Nombre, a.Descripcion,
    m.Id as IdMarca, m.Descripcion AS Marca, 
    c.Id as IdCategoria, c.Descripcion AS Categoria,
    a.ImagenUrl, a.Precio, a.Stock, a.Estado,
    CASE 
        WHEN a.Stock > 0 THEN 'Disponible'
        ELSE 'Sin Stock'
    END AS EstadoStock
FROM ARTICULOS a
LEFT JOIN MARCAS m ON a.IdMarca = m.Id
LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id
WHERE a.Estado = 1;

-- =====================================================
-- PROCEDIMIENTOS ALMACENADOS BÁSICOS
-- =====================================================

-- Listar artículos con stock
CREATE OR ALTER PROCEDURE SP_ListarArticulos
AS
BEGIN
    SELECT * FROM vw_ArticulosCompletos
    ORDER BY Nombre;
END
GO

-- Agregar artículo con stock
CREATE OR ALTER PROCEDURE SP_AltaArticulo
    @Codigo VARCHAR(50),
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150),
    @IdMarca INT,
    @IdCategoria INT,
    @ImagenUrl VARCHAR(1000),
    @Precio MONEY,
    @Stock INT = 0
AS
BEGIN
    INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, Stock)
    VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio, @Stock);
END
GO

-- Modificar artículo con stock
CREATE OR ALTER PROCEDURE SP_ModificarArticulo
    @Id INT,
    @Codigo VARCHAR(50),
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150),
    @IdMarca INT,
    @IdCategoria INT,
    @ImagenUrl VARCHAR(1000),
    @Precio MONEY,
    @Stock INT
AS
BEGIN
    UPDATE ARTICULOS 
    SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion,
        IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl,
        Precio = @Precio, Stock = @Stock
    WHERE Id = @Id;
END
GO

-- Verificar usuario
CREATE OR ALTER PROCEDURE SP_VerificarUsuario
    @Usuario VARCHAR(50),
    @Pass VARCHAR(50)
AS
BEGIN
    SELECT Id, Usuario, TipoUsuario 
    FROM Usuarios 
    WHERE Usuario = @Usuario AND Pass = @Pass;
END
GO

-- =====================================================
-- VERIFICACIÓN FINAL
-- =====================================================

PRINT '✅ Base de datos creada exitosamente';
PRINT '✅ Tablas creadas con campo Stock incluido';
PRINT '✅ Datos de prueba insertados';
PRINT '✅ Vista vw_ArticulosCompletos creada';
PRINT '✅ Procedimientos almacenados creados';
PRINT '';
PRINT '📊 RESUMEN DE ARTÍCULOS CON STOCK:';

SELECT 
    Codigo, Nombre, Marca, Categoria, 
    FORMAT(Precio, 'C2') as Precio, 
    Stock, EstadoStock
FROM vw_ArticulosCompletos
ORDER BY Stock DESC;

PRINT '';
PRINT '🎉 FASE 1 COMPLETADA: Base de datos lista para usar';
