# Sistema de Gestión Comercial - Especificación Técnica

## Introducción

El Sistema de Gestión Comercial es una aplicación empresarial desarrollada en C# con Windows Forms que proporciona una solución integral para la administración de inventarios, ventas y reportes. El sistema implementa una arquitectura de 3 capas robusta con autenticación por roles, procedimientos almacenados optimizados y una interfaz moderna consistente.

El sistema permite:
- Gestionar inventarios de productos de manera eficiente
- Procesar ventas con actualización automática de stock
- Generar reportes detallados para análisis empresarial
- Controlar acceso mediante roles diferenciados
- Mantener trazabilidad completa de operaciones

## Funcionalidades Principales

### Gestión de Artículos

El sistema maneja un catálogo completo de productos donde cada artículo incluye código único, nombre, descripción, marca, categoría, precio, stock e imagen. Los usuarios pueden realizar búsquedas avanzadas por múltiples criterios y mantener el inventario actualizado mediante operaciones CRUD completas con validaciones robustas.

### Sistema de Ventas

El módulo de ventas opera mediante un carrito de compras interactivo que permite seleccionar productos, especificar cantidades y procesar transacciones completas. El sistema valida automáticamente la disponibilidad de stock, calcula totales y actualiza el inventario en tiempo real mediante triggers de base de datos.

### Control de Stock

La gestión de inventario incluye operaciones de entrada y salida de mercadería, con validaciones que previenen stock negativo y alertas para productos con bajo inventario. Cada movimiento queda registrado para mantener trazabilidad completa del inventario.

### Gestión de Categorías y Marcas

El sistema permite organizar productos mediante categorías y marcas, facilitando la clasificación y búsqueda. Ambas entidades implementan baja lógica para preservar la integridad referencial y mantener el historial de productos asociados.

### Sistema de Reportes

El módulo de reportes genera análisis detallados incluyendo inventario completo, estadísticas por categorías y marcas, y reportes de ventas. Los reportes se pueden exportar en formato PNG con opción de conversión a PDF para documentación empresarial.

### Autenticación y Roles

El sistema implementa un modelo de seguridad basado en roles diferenciados: Administrador con acceso completo al sistema y Vendedor con acceso limitado al módulo de ventas. La autenticación se realiza mediante usuario y contraseña con validación contra base de datos.

### Arquitectura de la Aplicación

La aplicación de escritorio está desarrollada en C# con Windows Forms (.NET Framework 4.8.1) y se compone de los siguientes módulos principales:

#### 1. Módulo de Login 
- **Funcionalidad**: Autenticación de usuarios del sistema
- **Características**:
  - Formulario de login con usuario y contraseña
  - Validación de credenciales mediante SP_VerificarUsuario
  - Redirección según rol del usuario (Admin/Vendedor)
  - Manejo de errores de autenticación

#### 2. Módulo Principal Administrativo 
- **Funcionalidad**: Panel de control para administradores
- **Características**:
  - Acceso a todos los módulos del sistema
  - Navegación centralizada con botones principales
  - Información del usuario logueado
  - Diseño moderno con iconografía consistente

#### 3. Módulo de Gestión de Artículos 
- **Funcionalidad**: Administración completa del catálogo de productos
- **Características**:
  - DataGridView con listado completo de artículos
  - Sistema de filtros avanzado con múltiples criterios
  - Panel de vista previa de imágenes
  - Operaciones CRUD mediante botones de acción
  - Búsqueda en tiempo real sin recargas innecesarias

#### 4. Formulario de Datos de Artículos 
- **Funcionalidad**: Alta y modificación de productos
- **Características**:
  - Formulario con todos los campos del artículo
  - ComboBox cargados dinámicamente desde base de datos
  - Vista previa de imagen en tiempo real
  - Validaciones completas en todos los campos
  - Manejo de estados (Alta/Modificación)

#### 5. Módulo de Ventas 
- **Funcionalidad**: Procesamiento de transacciones de venta
- **Características**:
  - Panel izquierdo con productos disponibles
  - Panel derecho con carrito de compras
  - Búsqueda y filtrado de productos
  - Cálculo automático de totales
  - Validación de stock en tiempo real

#### 6. Módulo de Stock 
- **Funcionalidad**: Control de inventario y movimientos
- **Características**:
  - Operaciones de entrada y salida de mercadería
  - Validaciones de stock negativo
  - Historial de movimientos
  - Alertas de stock bajo

#### 7. Módulo de Reportes 
- **Funcionalidad**: Generación de reportes y estadísticas
- **Características**:
  - Múltiples tipos de reportes disponibles
  - Exportación a PNG con opción PDF
  - Estadísticas en tiempo real
  - Filtros por fecha y categorías

#### 8. Módulos de Gestión Auxiliar 
- **Funcionalidad**: Administración de entidades auxiliares
- **Características**:
  - CRUD completo para categorías y marcas
  - Validaciones de integridad referencial
  - Interfaz unificada con diseño consistente

## Aspectos Técnicos

### Arquitectura de 3 Capas

La aplicación implementa una separación clara de responsabilidades:

**Capa de Presentación (app/)**
- Formularios de Windows Forms
- Controles de usuario personalizados
- Manejo de eventos de interfaz
- Validaciones de entrada del usuario

**Capa de Negocio (Negocio/)**
- Lógica de negocio centralizada
- Validaciones de reglas empresariales
- Procesamiento de datos
- Comunicación con la capa de datos

**Capa de Datos (Dominio/)**
- Modelos de entidades
- Definición de estructuras de datos
- Propiedades y métodos de dominio

### Seguridad y Confiabilidad

**Control de Acceso**
- Autenticación mediante usuario y contraseña
- Roles diferenciados con permisos específicos
- Validación de sesiones activas
- Cierre seguro de aplicación

**Integridad de Datos**
- Transacciones ACID en todas las operaciones críticas
- Validaciones múltiples en capas de presentación y negocio
- Baja lógica para preservar integridad referencial
- Respaldos automáticos de base de datos

**Manejo de Errores**
- Try-catch en todas las operaciones críticas
- Mensajes de error descriptivos para el usuario
- Logging de errores para diagnóstico
- Rollback automático en transacciones fallidas

## Conclusión

El Sistema de Gestión Comercial representa una solución integral y robusta para la administración empresarial. Su arquitectura de 3 capas, sistema de autenticación por roles, procedimientos almacenados optimizados y interfaz moderna consistente proporcionan una base sólida para la gestión eficiente de inventarios y ventas.

La implementación permite agilizar los procesos comerciales, eliminar errores manuales, mantener control preciso del inventario y generar reportes automáticos confiables para la toma de decisiones empresariales.

El sistema está preparado para entornos de producción y puede ser extendido según las necesidades específicas del negocio, manteniendo siempre los estándares de calidad, seguridad y rendimiento implementados.
