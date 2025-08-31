-- =====================================================
-- SISTEMA DE GESTIÓN DE ARTÍCULOS - SCRIPT DE BASE DE DATOS
-- =====================================================

-- Creación de la base de datos
CREATE DATABASE CATALOGO_DB;
GO

USE CATALOGO_DB;
GO

-- Tabla de Categorías
CREATE TABLE CATEGORIAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NULL
);

-- Tabla de Marcas
CREATE TABLE MARCAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NULL
);

-- Tabla de Artículos
CREATE TABLE ARTICULOS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NULL,
    Nombre VARCHAR(50) NULL,
    Descripcion VARCHAR(150) NULL,
    IdMarca INT NULL,
    IdCategoria INT NULL,
    ImagenUrl VARCHAR(1000) NULL,
    Precio MONEY NULL,
    FOREIGN KEY (IdMarca) REFERENCES MARCAS(Id),
    FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS(Id)
);

-- Datos iniciales
-- Categorías
INSERT INTO CATEGORIAS (Descripcion) VALUES 
('Electrónicos'),
('Ropa'),
('Hogar'),
('Deportes'),
('Libros'),
('Herramientas'),
('Alimentos'),
('Bebidas'),
('Limpieza'),
('Jardín');

-- Marcas
INSERT INTO MARCAS (Descripcion) VALUES 
('HP'),
('Samsung'),
('Nike'),
('Adidas'),
('Apple'),
('Sony'),
('LG'),
('Philips'),
('Bosch'),
('Black & Decker');

-- Artículos de prueba
INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES 
('ART001', 'Laptop HP Pavilion', 'Laptop 15.6" Intel i5 8GB RAM', 1, 1, 'https://ejemplo.com/laptop.jpg', 850.00),
('ART002', 'Mouse Inalámbrico', 'Mouse óptico inalámbrico USB', 1, 1, 'https://ejemplo.com/mouse.jpg', 25.00),
('ART003', 'Teclado Mecánico', 'Teclado mecánico RGB gaming', 1, 1, 'https://ejemplo.com/teclado.jpg', 120.00),
('ART004', 'Monitor 24"', 'Monitor LED 24" Full HD', 2, 1, 'https://ejemplo.com/monitor.jpg', 200.00),
('ART005', 'Auriculares Bluetooth', 'Auriculares inalámbricos con micrófono', 2, 1, 'https://ejemplo.com/auriculares.jpg', 80.00),
('ART006', 'Camisa de Algodón', 'Camisa formal 100% algodón', 3, 2, 'https://ejemplo.com/camisa.jpg', 45.00),
('ART007', 'Pantalón Vaquero', 'Pantalón vaquero clásico', 4, 2, 'https://ejemplo.com/pantalon.jpg', 65.00),
('ART008', 'Zapatillas Deportivas', 'Zapatillas running profesionales', 3, 2, 'https://ejemplo.com/zapatillas.jpg', 95.00),
('ART009', 'Sofá de 3 Plazas', 'Sofá moderno para living', 7, 3, 'https://ejemplo.com/sofa.jpg', 450.00),
('ART010', 'Mesa de Centro', 'Mesa de centro de madera', 7, 3, 'https://ejemplo.com/mesa.jpg', 120.00);

/*
RELACIONES DEL MODELO:
- MARCAS (1) → ARTICULOS (N)
- CATEGORIAS (1) → ARTICULOS (N)

DESCRIPCIÓN DE TABLAS:
- ARTICULOS: almacena la información de cada artículo con su código, nombre, descripción, marca, categoría, imagen y precio
- CATEGORIAS: contiene los datos de las categorías de artículos
- MARCAS: contiene los datos de las marcas de los artículos

RESTRICCIONES IMPORTANTES:
- Los códigos pueden ser NULL
- Los precios pueden ser NULL
- Las imágenes se almacenan como URLs
- Las relaciones con marcas y categorías son opcionales (NULL permitido)
*/
