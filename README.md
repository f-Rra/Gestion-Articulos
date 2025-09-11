# 🏪 Sistema de Gestión Comercial

Un sistema completo de gestión comercial desarrollado en C# con Windows Forms, diseñado para la administración integral de inventarios, ventas y reportes empresariales.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8.1-blue)
![C#](https://img.shields.io/badge/C%23-7.3-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2016+-red)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-lightblue)

## 📋 Características Principales

- ✅ **Arquitectura de 3 capas** (Dominio, Negocio, Presentación)
- ✅ **Sistema de autenticación** con roles diferenciados (Admin/Vendedor)
- ✅ **CRUD completo** para artículos, categorías, marcas y ventas
- ✅ **Sistema de ventas** con carrito de compras y gestión de stock
- ✅ **Gestión de stock** con operaciones de ajuste automático
- ✅ **Sistema de reportes** con exportación a PNG/PDF
- ✅ **Procedimientos almacenados** para todas las operaciones críticas
- ✅ **Baja lógica** implementada en todas las entidades
- ✅ **Filtros avanzados** con múltiples criterios de búsqueda
- ✅ **Interfaz moderna** con diseño consistente y profesional
- ✅ **Validaciones robustas** en todos los formularios
- ✅ **Manejo de errores** completo con transacciones seguras

## 🚀 Funcionalidades del Sistema

### 📦 Gestión de Artículos
- **Listado principal** con filtros avanzados
- **Formulario de alta/modificación** con validaciones completas
- **Vista detallada** de productos con imagen y información completa
- **Búsqueda en tiempo real** con actualización automática
- **Operaciones CRUD** completas usando procedimientos almacenados

### 💰 Sistema de Ventas
- **Carrito de compras** interactivo
- **Selección de artículos** con búsqueda y filtros
- **Cálculo automático** de totales y subtotales
- **Actualización de stock** automática mediante triggers
- **Registro completo** de ventas y detalles

### 📊 Gestión de Stock
- **Operaciones de ajuste** Entrada/Salida
- **Control de inventario** en tiempo real
- **Historial de movimientos** de stock

### 📈 Sistema de Reportes
- **Inventario Completo**: Vista optimizada de todos los productos
- **Estadísticas por Categorías**: Análisis y conteo dinámico
- **Estadísticas por Marcas**: Análisis y conteo dinámico
- **Reportes de Ventas**: Análisis de ventas por período
- **Exportación inteligente**: PNG con opción de conversión a PDF

### 🏷️ Gestión de Categorías y Marcas
- **Interfaces modernas** con diseño consistente
- **CRUD completo** con procedimientos almacenados
- **Validaciones** de longitud y campos obligatorios
- **Baja lógica** para preservar relaciones

### 🔐 Sistema de Autenticación
- **Validación segura** de credenciales
- **Roles diferenciados**: Administrador (acceso completo) y Vendedor (ventas)
- **Control de permisos** basado en roles
- **Gestión de sesiones** segura

## 🏗️ Arquitectura del Sistema

### Estructura de Capas
```
Sistema-Gestion-Comercial/
├── Dominio/                  # Capa de Entidades
│   ├── Articulo.cs           # Modelo de artículos
│   ├── Categoria.cs          # Modelo de categorías
│   ├── Marca.cs              # Modelo de marcas
│   ├── Venta.cs              # Modelo de ventas
│   ├── DetalleVenta.cs       # Modelo de detalles de venta
│   └── Usuario.cs            # Modelo de usuarios
├── Negocio/                  # Capa de Lógica de Negocio
│   ├── AccesoDatos.cs        # Clase centralizada para BD
│   ├── ArticuloNegocio.cs    # Lógica de artículos
│   ├── CategoriaNegocio.cs   # Lógica de categorías
│   ├── MarcaNegocio.cs       # Lógica de marcas
│   ├── VentaNegocio.cs       # Lógica de ventas
│   ├── StockNegocio.cs       # Lógica de stock
│   ├── ReporteNegocio.cs     # Lógica de reportes
│   └── UsuarioNegocio.cs     # Lógica de autenticación
└── app/                      # Capa de Presentación
    ├── Program.cs            # Punto de entrada
    ├── frmLogin.cs           # Autenticación
    ├── frmAdmin.cs           # Panel administrativo
    ├── frmArticulos.cs       # Gestión de artículos
    ├── frmVentas.cs          # Sistema de ventas
    ├── frmStock.cs           # Gestión de stock
    ├── frmReportes.cs        # Sistema de reportes
    ├── frmCategorias.cs      # Gestión de categorías
    └── frmMarcas.cs          # Gestión de marcas
```

## 🗄️ Base de Datos

### Tablas Principales
- **ARTICULOS**: Información completa de productos
- **CATEGORIAS**: Clasificación de productos
- **MARCAS**: Información de marcas
- **VENTAS**: Registro de ventas
- **DETALLE_VENTAS**: Detalles de cada venta
- **USUARIOS**: Sistema de autenticación

### Vistas Especializadas
- **vw_ArticulosCompletos**: Vista completa de artículos con stock y estado
- **vw_InventarioPorCategoria**: Estadísticas de inventario agrupadas por categoría
- **vw_InventarioPorMarca**: Estadísticas de inventario agrupadas por marca
- **vw_EstadisticasGenerales**: Resumen general del sistema (totales y promedios)

### Procedimientos Almacenados

#### **Usuarios y Autenticación**
- **SP_VerificarUsuario**: Autenticación segura con roles
- **SP_ListarUsuarios**: Listado de usuarios activos

#### **Gestión de Artículos**
- **SP_ListarArticulos**: Listado completo optimizado con JOINs
- **SP_BuscarArticuloPorId**: Búsqueda específica por ID
- **SP_AltaArticulo**: Inserción con validaciones y stock
- **SP_ModificarArticulo**: Actualización completa con stock
- **SP_BajaArticulo**: Baja lógica preservando integridad
- **SP_BuscarArticulos**: Filtros avanzados por múltiples criterios

#### **Gestión de Categorías**
- **SP_ListarCategorias**: Listado de categorías activas
- **SP_AltaCategoria**: Inserción con validaciones
- **SP_ModificarCategoria**: Actualización segura
- **SP_BajaCategoria**: Baja lógica con validación de dependencias

#### **Gestión de Marcas**
- **SP_ListarMarcas**: Listado de marcas activas
- **SP_AltaMarca**: Inserción con validaciones
- **SP_ModificarMarca**: Actualización segura
- **SP_BajaMarca**: Baja lógica con validación de dependencias
- **SP_BuscarMarcaPorDescripcion**: Búsqueda específica por descripción

#### **Gestión de Stock**
- **SP_ActualizarStock**: Establecer stock específico con validaciones
- **SP_SumarStock**: Incrementar stock (entradas de inventario)
- **SP_RestarStock**: Decrementar stock con validación de suficiencia
- **SP_ArticulosBajoStock**: Listado de artículos con stock bajo
- **SP_ArticulosSinStock**: Listado de artículos sin stock disponible

#### **Sistema de Ventas**
- **SP_BuscarArticulosParaVenta**: Búsqueda de artículos disponibles para venta
- **SP_RegistrarVenta**: Registro de venta principal con transacciones
- **SP_RegistrarDetalleVenta**: Registro de detalles con validación de stock
- **SP_ObtenerVentasPorVendedor**: Historial de ventas por vendedor
- **SP_ValidarStockDisponible**: Validación previa de stock disponible
- **SP_ObtenerDetallesVenta**: Detalles completos de una venta específica

#### **Reportes y Estadísticas**
- **SP_ReporteInventarioGeneral**: Reporte completo con estadísticas generales
- **SP_ReporteArticulosPorPrecio**: Filtrado por rangos de precios

### Triggers
- **tr_ValidarCodigoUnicoArticulo**: Validación de códigos únicos en artículos
- **tr_ActualizarStockEnVenta**: Actualización automática de stock en ventas

## 🛠️ Instalación y Configuración

### Requisitos del Sistema
- **Visual Studio 2019 o superior**
- **.NET Framework 4.8.1**
- **SQL Server 2016 o superior** (LocalDB o instancia completa)
- **Windows 10 o superior**

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/Sistema-Gestion-Comercial.git
   cd Sistema-Gestion-Comercial
   ```

2. **Configurar la Base de Datos**
   - Ejecutar `Script_Sistema_Gestion_Comercial.sql` en SQL Server
   - Ejecutar `Vistas_Triggers_Procedimientos.sql` para componentes adicionales
   - Ejecutar `Datos_Iniciales.sql` para datos de prueba

3. **Configurar Cadena de Conexión**
   - Abrir `Negocio/AccesoDatos.cs`
   - Modificar la cadena de conexión según tu configuración:
   ```csharp
   private string cadenaConexion = "server=.\\SQLEXPRESS; database=SISTEMA_GESTION_COMERCIAL; integrated security=true";
   ```

4. **Compilar y Ejecutar**
   - Abrir `GdA.sln` en Visual Studio
   - Restaurar paquetes NuGet si es necesario
   - Compilar la solución 
   - Ejecutar 

### Credenciales de Prueba
- **Administrador**: `admin` / `admin123`
- **Vendedor**: `vendedor` / `vend123`

## 🎯 Uso del Sistema

### Flujo de Navegación

```
Inicio → frmLogin → Validar credenciales →
├── 👤 Vendedor → frmVentas (Sistema de ventas completo)
└── 👨‍💼 Admin → frmAdmin → 
    ├── [Artículos] → Gestión completa de productos
    ├── [Ventas] → Sistema de ventas
    ├── [Stock] → Gestión de inventario
    ├── [Categorías] → Gestión de categorías
    ├── [Marcas] → Gestión de marcas
    └── [Reportes] → Sistema de reportes y estadísticas
```

### Permisos por Rol

**👤 Vendedor:**
- ✅ Sistema de ventas completo
- ✅ Consulta de artículos y stock
- ❌ No accede a gestión administrativa

**👨‍💼 Administrador:**
- ✅ **Acceso completo al sistema**
- ✅ Gestión de artículos, categorías y marcas
- ✅ Sistema de ventas y stock
- ✅ Reportes y estadísticas
- ✅ Configuración del sistema

## 🔧 Características Técnicas

### Seguridad
- **Autenticación por roles** con control granular
- **Validación de entrada** en todos los formularios
- **Prevención de SQL Injection** con parámetros
- **Transacciones seguras** con rollback automático

### Rendimiento
- **Índices optimizados** en campos de búsqueda
- **Consultas parametrizadas** para mejor rendimiento
- **Cache de datos** en ComboBox y listas
- **Lazy loading** en carga de imágenes

### Validaciones
- **Campos obligatorios** verificados
- **Formato de datos** validado
- **Integridad referencial** preservada
- **Baja lógica** implementada

## 👨‍💻 Autor

**Herrera Facundo**
- GitHub: [@f-Rra](https://github.com/f-Rra)
- Email: Facundo.Herrera@Alumnos.Frgp.Utn.Edu.ar


