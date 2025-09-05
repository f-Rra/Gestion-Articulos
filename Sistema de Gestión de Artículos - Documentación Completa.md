# Sistema de Gestión de Artículos - Documentación Completa

## Introducción

El Sistema de Gestión de Artículos es una aplicación empresarial desarrollada en C# con arquitectura de 3 capas para la administración completa de inventarios. El sistema implementa un modelo robusto de gestión con autenticación por roles, procedimientos almacenados y una interfaz moderna consistente.

### Características Principales del Sistema:
- ✅ **Arquitectura de 3 capas** (Dominio, Negocio, Presentación)
- ✅ **Sistema de autenticación** con roles diferenciados (Admin/Vendedor)
- ✅ **CRUD completo** para artículos, categorías y marcas
- ✅ **Sistema de reportes** con exportación inteligente
- ✅ **Procedimientos almacenados** para todas las operaciones
- ✅ **Baja lógica** implementada en todas las entidades
- ✅ **Filtros avanzados** con múltiples criterios de búsqueda
- ✅ **Interfaz moderna** con diseño consistente y paleta unificada
- ✅ **Validaciones robustas** en todos los formularios
- ✅ **Manejo de errores** completo con transacciones seguras

## Funcionalidades Principales

### 📋 Gestión de Artículos
- **frmArticulos**: Listado principal con filtros avanzados (Comienza con, Termina con, Contiene)
- **frmDatos**: Formulario de alta/modificación con validaciones completas
- **frmDetalles**: Vista detallada de productos con imagen y información completa
- **Búsqueda en tiempo real** con txtFiltro y actualización automática
- **Operaciones CRUD** completas usando procedimientos almacenados optimizados
- **Baja lógica** implementada para mantener integridad referencial

### 📊 Sistema de Reportes
- **frmReportes**: Interfaz moderna con 3 tipos de reportes especializados
- **Inventario Completo**: Vista optimizada sin columnas innecesarias (sin ImagenUrl, IdMarca, IdCategoria)
- **Estadísticas por Categorías**: Análisis y conteo dinámico por categoría
- **Estadísticas por Marcas**: Análisis y conteo dinámico por marca
- **Exportación Inteligente**: Generación automática en PNG con opción de conversión a PDF
- **ReporteNegocio**: Clase de negocio especializada con consultas optimizadas
- **Estadísticas Generales**: Total artículos, categorías, marcas y precio promedio

### 🏷️ Gestión de Categorías
- **frmCategorias**: Interfaz moderna con diseño consistente
- **frmDatosCategoria**: Formulario dedicado para agregar/editar
- **CRUD completo** con procedimientos almacenados (SP_*Categoria)
- **Validaciones** de longitud y campos obligatorios
- **Baja lógica** implementada para preservar relaciones

### 🔖 Gestión de Marcas
- **frmMarcas**: Interfaz idéntica al patrón de categorías
- **frmDatosMarca**: Formulario especializado
- **Sistema completo** de gestión con procedimientos almacenados
- **Filtrado dinámico** y búsqueda instantánea

### 🔐 Sistema de Autenticación
- **frmLogin**: Validación de credenciales segura con SP_VerificarUsuario
- **Roles diferenciados**: Administrador (acceso completo) y Vendedor (solo artículos)
- **Navegación por permisos**: Control de acceso basado en roles
- **UsuarioNegocio**: Clase de negocio para autenticación y gestión de sesiones

## 🏗️ Arquitectura del Sistema

### Estructura de Capas
```
GdA.sln
├── Dominio/                    # Capa de Entidades
│   ├── Articulo.cs            # Modelo con DisplayName para GridView
│   ├── Categoria.cs           # Modelo con ToString() override
│   ├── Marca.cs              # Modelo con ToString() override
│   └── Usuario.cs            # Modelo para autenticación
├── Negocio/                   # Capa de Lógica de Negocio
│   ├── AccesoDatos.cs        # Clase centralizada para BD
│   ├── ArticuloNegocio.cs    # CRUD con procedimientos almacenados
│   ├── CategoriaNegocio.cs   # CRUD con SP_*Categoria
│   ├── MarcaNegocio.cs       # CRUD con SP_*Marca
│   ├── ReporteNegocio.cs     # Lógica de reportes y estadísticas
│   └── UsuarioNegocio.cs     # Autenticación con SP_VerificarUsuario
└── app/                       # Capa de Presentación
    ├── Program.cs            # Punto de entrada con roles
    ├── frmLogin.cs           # Autenticación inicial
    ├── frmAdmin.cs           # Panel administrativo
    ├── frmArticulos.cs       # Gestión principal de productos
    ├── frmDatos.cs           # Alta/modificación artículos
    ├── frmDetalles.cs        # Vista detallada
    ├── frmReportes.cs        # Sistema de reportes y estadísticas
    ├── frmCategorias.cs      # Gestión de categorías
    ├── frmDatosCategoria.cs  # Alta/modificación categorías
    ├── frmMarcas.cs          # Gestión de marcas
    └── frmDatosMarca.cs      # Alta/modificación marcas
```

### 🗄️ Modelo de Datos

#### Tablas Principales:
- **ARTICULOS**: Información completa de artículos con baja lógica (Estado BIT)
- **CATEGORIAS**: Clasificación de productos con baja lógica
- **MARCAS**: Información de marcas con baja lógica
- **Usuarios**: Sistema de autenticación con roles

#### Procedimientos Almacenados:
- **SP_ListarArticulos**: Listado con JOIN optimizado
- **SP_AltaArticulo**: Inserción con validaciones
- **SP_ModificarArticulo**: Actualización segura
- **SP_BajaArticulo**: Baja lógica (Estado = 0)
- **SP_BuscarArticulos**: Filtros dinámicos corregidos
- **SP_*Categoria/Marca**: Gestión completa de entidades auxiliares

#### Vistas:
- **vw_ArticulosCompletos**: JOIN completo para reportes optimizados

## 🔄 Flujo de Navegación del Sistema

### 🚪 Inicio de Sesión
```
Program.cs → frmLogin → Validar credenciales →
├── 👤 Vendedor → frmArticulos (CRUD completo)
└── 👨‍💼 Admin → frmAdmin → 
    ├── [Artículos] → frmArticulos (CRUD completo)
    ├── [Categorías] → frmCategorias → frmDatosCategoria
    ├── [Marcas] → frmMarcas → frmDatosMarca
    └── [Reportes] → frmReportes → Exportación PNG/PDF
```

### 🛡️ Permisos por Rol

**👤 Vendedor:**
- ✅ CRUD completo de artículos (agregar/modificar/eliminar)
- ✅ Búsqueda y filtros avanzados
- ✅ Vista detallada de productos
- ❌ No accede a gestión de categorías/marcas
- ❌ No accede a reportes administrativos

**👨‍💼 Administrador:**
- ✅ **Acceso completo al sistema**
- ✅ CRUD de artículos, categorías y marcas
- ✅ Sistema de reportes completo
- ✅ Panel administrativo
- ✅ Gestión de usuarios y configuración

## 💻 Aplicación WinForm

### Tecnologías Utilizadas
- **Framework**: .NET Framework 4.8.1
- **Lenguaje**: C# 7.3
- **UI**: Windows Forms con controles modernos
- **Base de Datos**: SQL Server con procedimientos almacenados
- **Arquitectura**: 3 capas (Dominio, Negocio, Presentación)

### Módulos Principales:

#### 1. frmLogin - Autenticación Segura
- **Funcionalidad**: Punto de entrada con validación de credenciales
- **Características**:
  - Validación con SP_VerificarUsuario
  - Control de roles (Admin/Vendedor)
  - Interfaz moderna con diseño corporativo
  - Manejo de errores de autenticación

#### 2. frmAdmin - Panel Administrativo
- **Funcionalidad**: Centro de control para administradores
- **Características**:
  - Navegación a todos los módulos del sistema
  - Acceso a reportes y estadísticas
  - Gestión de artículos, categorías y marcas
  - Diseño moderno con iconografía consistente

#### 3. frmArticulos - Gestión Principal de Productos
- **Funcionalidad**: Módulo central para gestión de artículos
- **Características**:
  - DataGridView optimizado con columnas configurables
  - Sistema de filtros avanzado (Comienza con, Termina con, Contiene)
  - Panel de vista previa de imágenes
  - Operaciones CRUD completas
  - Búsqueda en tiempo real sin recargas innecesarias

#### 4. frmDatos - Alta/Modificación de Artículos
- **Funcionalidad**: Formulario especializado para gestión de datos
- **Características**:
  - Validaciones robustas en todos los campos
  - ComboBox cargados dinámicamente desde BD
  - Vista previa de imagen en tiempo real
  - Manejo de estados (Alta/Modificación)
  - Transacciones seguras con rollback

#### 5. frmReportes - Sistema de Reportes
- **Funcionalidad**: Generación de reportes y estadísticas
- **Características**:
  - 3 tipos de reportes: Inventario, por Categorías, por Marcas
  - Exportación inteligente a PNG con opción PDF
  - Estadísticas dinámicas en tiempo real
  - Interfaz optimizada sin columnas innecesarias
  - ReporteNegocio con consultas especializadas

#### 6. frmCategorias/frmMarcas - Gestión de Entidades Auxiliares
- **Funcionalidad**: Gestión completa de categorías y marcas
- **Características**:
  - Interfaz unificada con diseño consistente
  - CRUD completo con procedimientos almacenados
  - Baja lógica para preservar integridad referencial
  - Validaciones específicas por entidad

## 🎯 Características Técnicas Destacadas

### 📊 Procedimientos Almacenados Implementados
- **SP_ListarArticulos**: Listado completo con JOIN optimizado
- **SP_AltaArticulo**: Inserción con validaciones y transacciones
- **SP_ModificarArticulo**: Actualización segura con control de concurrencia
- **SP_BajaArticulo**: Baja lógica (Estado = 0) preservando integridad
- **SP_BuscarArticulos**: Filtros dinámicos corregidos (sin SQL dinámico)
- **SP_ListarCategorias/Marcas**: Gestión auxiliar con baja lógica
- **SP_VerificarUsuario**: Autenticación segura con roles
- **Consultas de Reportes**: Optimizadas para estadísticas dinámicas

### 🔍 Sistema de Filtros Avanzado
- **Comienza con**: Búsqueda por prefijo con LIKE 'texto%'
- **Termina con**: Búsqueda por sufijo con LIKE '%texto'
- **Contiene**: Búsqueda parcial con LIKE '%texto%'
- **Filtro en tiempo real**: Actualización automática sin recargas
- **Sin resultados**: Mensaje informativo sin recargar todos los artículos
- **Múltiples campos**: Búsqueda por Código, Nombre, Descripción, Marca, Categoría

### 🛠️ Validaciones Implementadas
- **Campos obligatorios**: Verificación en todos los formularios
- **Longitud de texto**: Límites apropiados para cada campo
- **Formato de precios**: Validación numérica con decimales
- **URLs de imágenes**: Verificación de formato válido
- **Duplicados**: Prevención en nombres de categorías/marcas
- **Integridad referencial**: Validación antes de eliminaciones

### 🎨 Estándares de Diseño
- **Paleta de colores**: #012E40 (azul oscuro), #F2E3D5 (beige), #3CA6A6 (verde-azul)
- **Tipografía**: Verdana 9.75pt consistente en toda la aplicación
- **Botones**: FlatStyle.Flat con iconografía moderna
- **DataGridView**: Configuración uniforme con colores alternados
- **Paneles superiores**: Logos y títulos con degradados sutiles

## 🗄️ Estructura de Base de Datos Detallada

### Tablas Principales

#### ARTICULOS
- **Id**: INT IDENTITY(1,1) PRIMARY KEY
- **Codigo**: VARCHAR(50) - Código único del artículo
- **Nombre**: VARCHAR(50) - Nombre del producto
- **Descripcion**: VARCHAR(150) - Descripción detallada
- **IdMarca**: INT FOREIGN KEY → MARCAS(Id)
- **IdCategoria**: INT FOREIGN KEY → CATEGORIAS(Id)
- **ImagenUrl**: VARCHAR(1000) - URL de imagen del producto
- **Precio**: MONEY - Precio del artículo
- **Estado**: BIT DEFAULT 1 - Baja lógica (1=Activo, 0=Inactivo)

#### CATEGORIAS
- **Id**: INT IDENTITY(1,1) PRIMARY KEY
- **Descripcion**: VARCHAR(50) - Nombre de la categoría
- **Estado**: BIT DEFAULT 1 - Baja lógica

#### MARCAS
- **Id**: INT IDENTITY(1,1) PRIMARY KEY
- **Descripcion**: VARCHAR(50) - Nombre de la marca
- **Estado**: BIT DEFAULT 1 - Baja lógica

#### Usuarios
- **Id**: INT IDENTITY(1,1) PRIMARY KEY
- **Usuario**: VARCHAR(50) - Nombre de usuario
- **Pass**: VARCHAR(50) - Contraseña
- **TipoUsuario**: INT - Rol (1=Admin, 2=Vendedor)

### Relaciones del Modelo
- **MARCAS (1) → ARTICULOS (N)**: Una marca puede tener múltiples artículos
- **CATEGORIAS (1) → ARTICULOS (N)**: Una categoría puede tener múltiples artículos
- **Usuarios (1) → Sesiones (N)**: Control de acceso por roles

### Vistas Especializadas

#### vw_ArticulosCompletos
```sql
SELECT 
    a.Id, a.Codigo, a.Nombre, a.Descripcion,
    m.Descripcion AS Marca, c.Descripcion AS Categoria,
    a.ImagenUrl, a.Precio, a.Estado,
    FORMAT(a.Precio, 'C2') AS PrecioFormateado
FROM ARTICULOS a
LEFT JOIN MARCAS m ON a.IdMarca = m.Id
LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id
WHERE a.Estado = 1
```

## 🚀 Guía de Instalación y Configuración

### Requisitos del Sistema
- **Visual Studio 2019 o superior**
- **.NET Framework 4.8.1**
- **SQL Server 2016 o superior** (LocalDB o instancia completa)
- **Windows 10 o superior**

### Configuración de Base de Datos
1. **Ejecutar el script completo**:
   ```sql
   Script_Sistema_Gestion_Articulos_Unificado.sql
   ```
2. **Configurar cadena de conexión** en `AccesoDatos.cs`
3. **Verificar procedimientos almacenados** creados correctamente

### Credenciales de Prueba
- **Administrador**: `admin` / `admin123`
- **Vendedor**: `vendedor` / `vend123`

### Compilación y Ejecución
1. Abrir `GdA.sln` en Visual Studio
2. Restaurar paquetes NuGet si es necesario
3. Compilar solución (Ctrl+Shift+B)
4. Ejecutar (F5) - Se abrirá `frmLogin`

## 📈 Funcionalidades Técnicas Avanzadas

### Sistema de Transacciones
- **Transacciones explícitas** en todos los procedimientos almacenados
- **Rollback automático** en caso de errores
- **Control de concurrencia** en operaciones críticas
- **Manejo de deadlocks** y timeouts

### Optimizaciones de Rendimiento
- **Índices optimizados** en campos de búsqueda frecuente
- **Consultas parametrizadas** para prevenir SQL Injection
- **Lazy loading** en carga de imágenes
- **Cache de ComboBox** para mejorar rendimiento

### Seguridad Implementada
- **Autenticación por roles** con control granular
- **Validación de entrada** en todos los formularios
- **Prevención de SQL Injection** con parámetros
- **Baja lógica** para preservar integridad de datos

## 📊 Sistema de Reportes Detallado

### Tipos de Reportes Disponibles

#### 1. Inventario Completo
- **Descripción**: Listado optimizado de todos los artículos activos
- **Columnas**: Código, Nombre, Descripción, Marca, Categoría, Precio
- **Optimización**: Eliminadas columnas innecesarias (ImagenUrl, IdMarca, IdCategoria)
- **Ordenamiento**: Por nombre alfabéticamente

#### 2. Estadísticas por Categorías
- **Descripción**: Análisis de distribución por categorías
- **Información**: Categoría, Cantidad de artículos, Precio promedio
- **Cálculos**: COUNT(*) y AVG(Precio) dinámicos
- **Agrupamiento**: GROUP BY Categoria

#### 3. Estadísticas por Marcas
- **Descripción**: Análisis de distribución por marcas
- **Información**: Marca, Cantidad de artículos, Precio promedio
- **Cálculos**: COUNT(*) y AVG(Precio) dinámicos
- **Agrupamiento**: GROUP BY Marca

### Exportación Inteligente
- **Formato principal**: PNG de alta calidad
- **Contenido**: Títulos, tabla de datos, estadísticas generales
- **Conversión**: Opción de convertir a PDF desde cualquier visor
- **Apertura automática**: Se abre el archivo generado
- **Ubicación**: Carpeta seleccionada por el usuario

## 🔧 Mejoras Futuras Planificadas

### Funcionalidades Adicionales
- **Gestión de stock**: Control de inventario con alertas
- **Backup automático**: Respaldo programado de base de datos
- **Log de auditoría**: Registro de cambios y operaciones
- **Importación/exportación**: Datos desde/hacia Excel
- **Notificaciones**: Stock bajo, precios actualizados
- **Edición inline**: Para categorías y marcas (placeholders preparados)

### Integraciones Posibles
- **Sistemas de ventas**: Conexión con POS
- **Gestión de proveedores**: Módulo de compras
- **E-commerce**: Sincronización con tiendas online
- **Códigos de barras**: Lectura y generación
- **Reportes avanzados**: Gráficos y dashboards

## 📝 Conclusión

El Sistema de Gestión de Artículos representa una solución empresarial completa y robusta para la administración de inventarios. Con su arquitectura de 3 capas, sistema de autenticación por roles, procedimientos almacenados optimizados y interfaz moderna consistente, proporciona una base sólida para la gestión eficiente de productos.

### Logros Principales:
- ✅ **100% funcional** con todas las características implementadas
- ✅ **Arquitectura escalable** preparada para futuras expansiones
- ✅ **Seguridad robusta** con autenticación y validaciones completas
- ✅ **Rendimiento optimizado** con procedimientos almacenados
- ✅ **Interfaz moderna** con diseño consistente y profesional
- ✅ **Sistema de reportes** con exportación inteligente

El sistema está preparado para entornos de producción y puede ser extendido según las necesidades específicas del negocio, manteniendo siempre los estándares de calidad, seguridad y rendimiento implementados.
