# Sistema de Gestión de Artículos - Documentación Completa

## Introducción

El Sistema de Gestión de Artículos es una aplicación desarrollada para la administración y catalogación de productos. El sistema permite mantener un registro organizado de artículos con sus respectivas categorías y marcas, facilitando la búsqueda y gestión de productos.

El Sistema de Gestión de Artículos permite:
- Mantener un catálogo organizado de artículos
- Categorizar productos por tipo
- Asociar productos con marcas específicas
- Gestionar información básica de productos (código, nombre, descripción, precio)
- Almacenar URLs de imágenes para visualización de productos

## Funcionalidades Principales

### Gestión de Artículos

El sistema permite el registro y gestión de artículos con información básica como código, nombre, descripción, precio e imagen. Cada artículo puede ser asociado a una categoría y marca específica para facilitar su organización y búsqueda.

### Categorización de Productos

El sistema incluye un sistema de categorías que permite clasificar los artículos por tipo (Electrónicos, Ropa, Hogar, Deportes, etc.). Esta funcionalidad facilita la organización y búsqueda de productos por categoría.

### Gestión de Marcas

Los artículos pueden ser asociados a marcas específicas, permitiendo una mejor organización y facilitando la búsqueda de productos por marca.

### Almacenamiento de Imágenes

El sistema permite almacenar URLs de imágenes para cada artículo, facilitando la visualización de los productos en la interfaz de usuario.

## Modelo de Datos (DER)

El modelo de datos está compuesto por las siguientes tablas principales: 

- **ARTICULOS**: almacena la información de cada artículo (Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
- **CATEGORIAS**: contiene los datos de las categorías de artículos (Id, Descripcion)
- **MARCAS**: contiene los datos de las marcas de los artículos (Id, Descripcion)

## Aplicación WinForm

### Arquitectura de la Aplicación

La aplicación de escritorio está desarrollada en C# con Windows Forms (.NET Framework 4.7.2) y se compone de los siguientes módulos principales:

#### 1. Formulario de Artículos (frmArticulos) - Formulario Principal
- **Funcionalidad**: Formulario principal para gestión de artículos
- **Características**:
  - Listado de artículos en GridView
  - Sistema de búsqueda y filtrado avanzado
  - Panel de vista previa de imágenes
  - Navegación a otros formularios
  - Panel de control principal

#### 2. Formulario de Datos (frmDatos) - Agregar Artículo
- **Funcionalidad**: Formulario para agregar nuevos artículos
- **Características**:
  - Formulario de entrada de datos completo
  - Campos para todos los datos del artículo
  - Vista previa de imagen en tiempo real
  - Validaciones de entrada
  - Botón de vista previa de imagen

#### 3. Formulario de Detalles (frmDetalles) - Vista Detallada
- **Funcionalidad**: Visualización detallada de artículos
- **Características**:
  - Vista detallada de un artículo seleccionado
  - Información completa del producto
  - Visualización de imagen del artículo
  - Información de categoría y marca

### Flujo de la Aplicación

#### 1. Inicio de la Aplicación
- La aplicación inicia mostrando el formulario `frmArticulos`
- Este formulario actúa como formulario principal de la aplicación
- Muestra el listado de artículos en un GridView
- Incluye sistema de búsqueda y filtrado avanzado
- Panel de vista previa de imágenes en el lado derecho

#### 2. Búsqueda y Filtrado
- El usuario puede seleccionar el campo de búsqueda (Campo)
- Seleccionar el criterio de búsqueda (Criterio)
- Ingresar el texto de filtro en el campo "Filtro"
- Hacer clic en "Buscar" para aplicar los filtros
- Los resultados se muestran en el GridView principal

#### 3. Agregar Nuevo Artículo (frmDatos)
- Acceso desde el formulario principal haciendo clic en "Agregar"
- Se abre el formulario `frmDatos` para ingresar los datos del nuevo artículo
- El usuario completa todos los campos: URL Imagen, Código, ID Articulo, Nombre, Marca, Precio, Categoria, Descripción
- Botón "Vista Previa" para ver la imagen antes de guardar
- Al hacer clic en "Agregar", el artículo se guarda en la base de datos
- Se retorna al formulario principal con el listado actualizado

#### 4. Gestión de Artículos (frmArticulos)
- Formulario principal que muestra el listado de artículos
- El usuario puede editar artículos existentes seleccionándolos y haciendo clic en "Editar"
- Eliminación de artículos seleccionándolos y haciendo clic en "Eliminar"
- Vista previa de imágenes en el panel derecho
- Navegación a vista de detalles

#### 5. Vista de Detalles (frmDetalles)
- Acceso desde el formulario principal seleccionando un artículo y haciendo clic en "Detalles"
- Muestra información detallada del artículo seleccionado
- Visualización de la imagen del producto en el panel derecho
- Información completa: ID, Código, Nombre, Marca, Precio, Categoria, URL Imagen, Descripción
- Retorno al formulario principal

#### 6. Navegación entre Formularios
- `frmArticulos` → `frmDatos`: Agregar nuevo artículo
- `frmDatos` → `frmArticulos`: Volver al listado principal
- `frmArticulos` → `frmDetalles`: Ver detalles de un artículo
- `frmDetalles` → `frmArticulos`: Volver al listado principal

## Estructura de Base de Datos

### Tabla ARTICULOS
- **Id**: Identificador único del artículo (Primary Key, Identity)
- **Codigo**: Código del artículo (VARCHAR(50), NULL)
- **Nombre**: Nombre del artículo (VARCHAR(50), NULL)
- **Descripcion**: Descripción detallada del artículo (VARCHAR(150), NULL)
- **IdMarca**: Referencia a la tabla MARCAS (Foreign Key, NULL)
- **IdCategoria**: Referencia a la tabla CATEGORIAS (Foreign Key, NULL)
- **ImagenUrl**: URL de la imagen del artículo (VARCHAR(1000), NULL)
- **Precio**: Precio del artículo (MONEY, NULL)

### Tabla CATEGORIAS
- **Id**: Identificador único de la categoría (Primary Key, Identity)
- **Descripcion**: Descripción de la categoría (VARCHAR(50), NULL)

### Tabla MARCAS
- **Id**: Identificador único de la marca (Primary Key, Identity)
- **Descripcion**: Descripción de la marca (VARCHAR(50), NULL)

## Relaciones del Modelo

- **MARCAS (1) → ARTICULOS (N)**: Una marca puede tener múltiples artículos
- **CATEGORIAS (1) → ARTICULOS (N)**: Una categoría puede tener múltiples artículos

## Funcionalidades Técnicas

### Validaciones
- Validación de campos obligatorios al agregar/editar artículos
- Validación de formato de URLs de imágenes
- Validación de precios numéricos
- Validación de códigos únicos

### Operaciones CRUD
- **Create**: Agregar nuevos artículos
- **Read**: Listar artículos y ver detalles
- **Update**: Editar artículos existentes
- **Delete**: Eliminar artículos

### Búsqueda y Filtrado
- Búsqueda por diferentes campos (Campo)
- Múltiples criterios de búsqueda (Criterio)
- Filtrado por texto libre
- Vista previa de imágenes en tiempo real

## Conclusión

El Sistema de Gestión de Artículos proporciona una solución completa para la administración de un catálogo de productos. Su estructura simple pero efectiva permite mantener organizados los artículos por categorías y marcas, facilitando la búsqueda y gestión de productos.

El sistema está diseñado para ser escalable y puede ser extendido con funcionalidades adicionales según las necesidades específicas del negocio, como:
- Gestión de stock
- Reportes de productos
- Integración con sistemas de ventas
- Gestión de proveedores
- Sistema de usuarios y permisos
