# FASE 14: Sistema de Ventas - Guía Completa de Implementación

## 🎯 **OBJETIVO PRINCIPAL**
Crear un sistema de ventas completo que permita a los vendedores realizar transacciones con control automático de stock, manteniendo la separación de roles y la integridad de datos.

---

## 📋 **RESUMEN DE CAMBIOS**

### ❌ **QUÉ SACAR (Eliminar/Modificar)**
1. **En `Program.cs`**: Modificar la lógica de redirección de vendedores
2. **En `frmLogin.cs`**: Agregar validación para abrir frmVentas
3. **En consultas existentes**: Convertir algunas a procedimientos almacenados

### ✅ **QUÉ AGREGAR (Nuevos archivos)**
1. **`Dominio/Venta.cs`** - Clases Venta y DetalleVenta
2. **`Negocio/VentaNegocio.cs`** - Lógica de negocio para ventas
3. **`app/frmVentas.cs`** - Formulario principal de ventas
4. **`app/frmVentas.Designer.cs`** - Diseño del formulario
5. **`app/frmVentas.resx`** - Recursos del formulario

### 🔧 **QUÉ MODIFICAR (Archivos existentes)**
1. **Base de datos**: Agregar tablas VENTAS y DETALLE_VENTAS
2. **Script SQL**: Nuevos procedimientos almacenados y triggers
3. **`Program.cs`**: Lógica de navegación por roles
4. **`app.csproj`**: Referencias a nuevos archivos

---

## 🏗️ **PASO 1: MODELO DE DATOS**

### **Archivo:** `Dominio/Venta.cs`

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        
        [DisplayName("Número de Venta")]
        public string NumeroVenta { get; set; }
        
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }
        
        [DisplayName("Vendedor")]
        public string Vendedor { get; set; }
        
        [DisplayName("Cliente")]
        public string Cliente { get; set; }
        
        [DisplayName("Total")]
        public decimal Total { get; set; }
        
        [DisplayName("Estado")]
        public string Estado { get; set; }
        
        public List<DetalleVenta> Detalles { get; set; }
        
        public Venta()
        {
            Detalles = new List<DetalleVenta>();
            Fecha = DateTime.Now;
            Estado = "Pendiente";
        }
        
        // Método para generar número de venta único
        public string GenerarNumeroVenta()
        {
            return "V-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss");
        }
        
        // Método para calcular total de la venta
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in Detalles)
            {
                total += detalle.Subtotal;
            }
            Total = total;
            return total;
        }
    }
    
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        
        [DisplayName("Código")]
        public string CodigoArticulo { get; set; }
        
        [DisplayName("Artículo")]
        public string NombreArticulo { get; set; }
        
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        
        [DisplayName("Precio Unit.")]
        public decimal PrecioUnitario { get; set; }
        
        [DisplayName("Subtotal")]
        public decimal Subtotal { get; set; }
        
        [DisplayName("Stock Disp.")]
        public int StockDisponible { get; set; }
        
        public DetalleVenta()
        {
            Cantidad = 1;
        }
        
        // Método para calcular subtotal
        public decimal CalcularSubtotal()
        {
            Subtotal = Cantidad * PrecioUnitario;
            return Subtotal;
        }
        
        // Método para validar stock suficiente
        public bool StockSuficiente()
        {
            return StockDisponible >= Cantidad;
        }
    }
}
```

---

## 🏗️ **PASO 2: CAPA DE NEGOCIO**

### **Archivo:** `Negocio/VentaNegocio.cs`

**¿Por qué crear esta clase?**
- Centraliza toda la lógica de ventas
- Maneja transacciones de base de datos
- Valida stock antes de vender
- Convierte consultas complejas en procedimientos almacenados

```csharp
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        /// <summary>
        /// Busca artículos disponibles para venta (con stock > 0)
        /// CONVIERTE: Consulta directa → Procedimiento almacenado
        /// </summary>
        public DataTable buscarArticulosParaVenta(string filtro = "")
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                // NUEVO: Usar procedimiento almacenado en lugar de consulta directa
                datos.setearConsulta("SP_BuscarArticulosParaVenta");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@Filtro", filtro ?? "");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        /// <summary>
        /// Registra una nueva venta y actualiza el stock automáticamente
        /// NUEVO: Transacción completa con validaciones
        /// </summary>
        public void registrarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SP_RegistrarVenta");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@NumeroVenta", venta.NumeroVenta);
                datos.setearParametro("@Vendedor", venta.Vendedor);
                datos.setearParametro("@Cliente", venta.Cliente ?? "");
                datos.setearParametro("@Total", venta.Total);
                
                // Convertir detalles a XML para el procedimiento
                string detallesXml = convertirDetallesAXml(venta.Detalles);
                datos.setearParametro("@DetallesXml", detallesXml);
                
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        /// <summary>
        /// Obtiene el historial de ventas del vendedor
        /// NUEVO: Procedimiento almacenado para mejor rendimiento
        /// </summary>
        public DataTable obtenerVentasPorVendedor(string vendedor)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SP_ObtenerVentasPorVendedor");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@Vendedor", vendedor);
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        /// <summary>
        /// Valida disponibilidad de stock antes de la venta
        /// NUEVO: Procedimiento almacenado para validación rápida
        /// </summary>
        public bool validarStockDisponible(int idArticulo, int cantidadSolicitada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SP_ValidarStockDisponible");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@CantidadSolicitada", cantidadSolicitada);
                datos.ejecutarLectura();
                
                if (datos.Lector.Read())
                {
                    return (bool)datos.Lector["StockSuficiente"];
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        /// <summary>
        /// Obtiene detalles de una venta específica
        /// NUEVO: Para mostrar detalles completos de ventas
        /// </summary>
        public DataTable obtenerDetallesVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SP_ObtenerDetallesVenta");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        /// <summary>
        /// Convierte lista de detalles a XML para el procedimiento almacenado
        /// NUEVO: Método auxiliar para manejo de datos complejos
        /// </summary>
        private string convertirDetallesAXml(List<DetalleVenta> detalles)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<Detalles>");
            
            foreach (var detalle in detalles)
            {
                xml.Append("<Detalle ");
                xml.Append($"IdArticulo='{detalle.IdArticulo}' ");
                xml.Append($"Cantidad='{detalle.Cantidad}' ");
                xml.Append($"PrecioUnitario='{detalle.PrecioUnitario}' ");
                xml.Append($"Subtotal='{detalle.Subtotal}' ");
                xml.Append("/>");
            }
            
            xml.Append("</Detalles>");
            return xml.ToString();
        }
    }
}
```

---

## 🗄️ **PASO 3: BASE DE DATOS**

### **¿Qué agregar al script SQL existente?**

**NUEVAS TABLAS:**
1. **VENTAS** - Registro principal de cada venta
2. **DETALLE_VENTAS** - Artículos vendidos en cada venta

**NUEVOS PROCEDIMIENTOS ALMACENADOS:**
1. **SP_BuscarArticulosParaVenta** - Reemplaza consulta directa
2. **SP_RegistrarVenta** - Transacción completa de venta
3. **SP_ObtenerVentasPorVendedor** - Historial de ventas
4. **SP_ValidarStockDisponible** - Validación rápida de stock
5. **SP_ObtenerDetallesVenta** - Detalles de venta específica

**NUEVO TRIGGER:**
1. **tr_ActualizarStockEnVenta** - Actualiza stock automáticamente

### **Script SQL a agregar:**

```sql
-- =====================================================
-- SISTEMA DE VENTAS - NUEVAS TABLAS Y PROCEDIMIENTOS
-- =====================================================

-- Tabla VENTAS
CREATE TABLE VENTAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroVenta VARCHAR(20) NOT NULL UNIQUE,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Vendedor VARCHAR(100) NOT NULL,
    Cliente VARCHAR(200),
    Total DECIMAL(10,2) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Completada',
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

-- Tabla DETALLE_VENTAS
CREATE TABLE DETALLE_VENTAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdArticulo INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdVenta) REFERENCES VENTAS(Id) ON DELETE CASCADE,
    FOREIGN KEY (IdArticulo) REFERENCES ARTICULOS(Id)
);

-- =====================================================
-- NUEVOS PROCEDIMIENTOS ALMACENADOS
-- =====================================================

-- 1. Buscar artículos disponibles para venta (REEMPLAZA consulta directa)
CREATE OR ALTER PROCEDURE SP_BuscarArticulosParaVenta
    @Filtro VARCHAR(100) = ''
AS
BEGIN
    SELECT 
        a.Id,
        a.Codigo,
        a.Nombre,
        a.Descripcion,
        a.Precio,
        a.Stock,
        m.Descripcion AS Marca,
        c.Descripcion AS Categoria,
        CASE 
            WHEN a.Stock > 0 THEN 'Disponible'
            ELSE 'Sin Stock'
        END AS EstadoStock
    FROM ARTICULOS a
    INNER JOIN MARCAS m ON a.IdMarca = m.Id
    INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id
    WHERE a.Estado = 1 
      AND a.Stock > 0
      AND (@Filtro = '' OR 
           a.Codigo LIKE '%' + @Filtro + '%' OR 
           a.Nombre LIKE '%' + @Filtro + '%' OR 
           a.Descripcion LIKE '%' + @Filtro + '%')
    ORDER BY a.Nombre;
END;
GO

-- 2. Registrar venta completa con transacción
CREATE OR ALTER PROCEDURE SP_RegistrarVenta
    @NumeroVenta VARCHAR(20),
    @Vendedor VARCHAR(100),
    @Cliente VARCHAR(200),
    @Total DECIMAL(10,2),
    @DetallesXml XML
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DECLARE @IdVenta INT;
        
        -- Insertar venta principal
        INSERT INTO VENTAS (NumeroVenta, Vendedor, Cliente, Total)
        VALUES (@NumeroVenta, @Vendedor, @Cliente, @Total);
        
        SET @IdVenta = SCOPE_IDENTITY();
        
        -- Insertar detalles de la venta
        INSERT INTO DETALLE_VENTAS (IdVenta, IdArticulo, Cantidad, PrecioUnitario, Subtotal)
        SELECT 
            @IdVenta,
            T.c.value('@IdArticulo', 'int'),
            T.c.value('@Cantidad', 'int'),
            T.c.value('@PrecioUnitario', 'decimal(10,2)'),
            T.c.value('@Subtotal', 'decimal(10,2)')
        FROM @DetallesXml.nodes('/Detalles/Detalle') T(c);
        
        -- Actualizar stock de artículos
        UPDATE a 
        SET Stock = Stock - d.Cantidad
        FROM ARTICULOS a
        INNER JOIN (
            SELECT 
                T.c.value('@IdArticulo', 'int') as IdArticulo,
                T.c.value('@Cantidad', 'int') as Cantidad
            FROM @DetallesXml.nodes('/Detalles/Detalle') T(c)
        ) d ON a.Id = d.IdArticulo;
        
        -- Verificar que no haya stock negativo
        IF EXISTS (SELECT 1 FROM ARTICULOS WHERE Stock < 0)
        BEGIN
            RAISERROR('Error: Stock insuficiente para completar la venta', 16, 1);
            RETURN;
        END
        
        COMMIT TRANSACTION;
        
        -- Retornar ID de la venta creada
        SELECT @IdVenta AS IdVentaCreada;
        
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR('Error al registrar la venta: %s', 16, 1, ERROR_MESSAGE());
    END CATCH
END;
GO

-- 3. Obtener ventas por vendedor (REEMPLAZA consulta directa)
CREATE OR ALTER PROCEDURE SP_ObtenerVentasPorVendedor
    @Vendedor VARCHAR(100)
AS
BEGIN
    SELECT 
        v.Id,
        v.NumeroVenta,
        v.Fecha,
        v.Cliente,
        v.Total,
        v.Estado,
        COUNT(d.Id) AS CantidadArticulos
    FROM VENTAS v
    LEFT JOIN DETALLE_VENTAS d ON v.Id = d.IdVenta
    WHERE v.Vendedor = @Vendedor
    GROUP BY v.Id, v.NumeroVenta, v.Fecha, v.Cliente, v.Total, v.Estado
    ORDER BY v.Fecha DESC;
END;
GO

-- 4. Validar stock disponible (NUEVO procedimiento)
CREATE OR ALTER PROCEDURE SP_ValidarStockDisponible
    @IdArticulo INT,
    @CantidadSolicitada INT
AS
BEGIN
    DECLARE @StockActual INT;
    
    SELECT @StockActual = Stock 
    FROM ARTICULOS 
    WHERE Id = @IdArticulo AND Estado = 1;
    
    SELECT 
        CASE 
            WHEN @StockActual IS NULL THEN 0
            WHEN @StockActual >= @CantidadSolicitada THEN 1
            ELSE 0
        END AS StockSuficiente,
        ISNULL(@StockActual, 0) AS StockActual;
END;
GO

-- 5. Obtener detalles de una venta específica (NUEVO)
CREATE OR ALTER PROCEDURE SP_ObtenerDetallesVenta
    @IdVenta INT
AS
BEGIN
    SELECT 
        d.Id,
        d.IdArticulo,
        a.Codigo,
        a.Nombre,
        d.Cantidad,
        d.PrecioUnitario,
        d.Subtotal
    FROM DETALLE_VENTAS d
    INNER JOIN ARTICULOS a ON d.IdArticulo = a.Id
    WHERE d.IdVenta = @IdVenta
    ORDER BY a.Nombre;
END;
GO

-- =====================================================
-- NUEVO TRIGGER PARA SISTEMA DE VENTAS
-- =====================================================

-- Trigger que se ejecuta automáticamente al insertar detalles de venta
-- Actualiza el stock y registra la operación
CREATE OR ALTER TRIGGER tr_ActualizarStockEnVenta
ON DETALLE_VENTAS
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Actualizar stock de artículos vendidos
        UPDATE a 
        SET Stock = Stock - i.Cantidad
        FROM ARTICULOS a
        INNER JOIN inserted i ON a.Id = i.IdArticulo
        WHERE a.Estado = 1;
        
        -- Verificar que no haya stock negativo
        IF EXISTS (SELECT 1 FROM ARTICULOS WHERE Stock < 0 AND Estado = 1)
        BEGIN
            RAISERROR('Error: Stock insuficiente detectado por trigger', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Log de la operación (opcional - para auditoría)
        INSERT INTO LOG_OPERACIONES (TipoOperacion, Descripcion, Fecha, Usuario)
        SELECT 
            'VENTA',
            'Venta registrada - Artículo: ' + a.Nombre + ' - Cantidad: ' + CAST(i.Cantidad AS VARCHAR),
            GETDATE(),
            v.Vendedor
        FROM inserted i
        INNER JOIN ARTICULOS a ON i.IdArticulo = a.Id
        INNER JOIN VENTAS v ON i.IdVenta = v.Id;
        
    END TRY
    BEGIN CATCH
        RAISERROR('Error en trigger de actualización de stock: %s', 16, 1, ERROR_MESSAGE());
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

-- Tabla opcional para log de operaciones (si no existe)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LOG_OPERACIONES' AND xtype='U')
BEGIN
    CREATE TABLE LOG_OPERACIONES (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        TipoOperacion VARCHAR(50) NOT NULL,
        Descripcion VARCHAR(500) NOT NULL,
        Fecha DATETIME NOT NULL DEFAULT GETDATE(),
        Usuario VARCHAR(100)
    );
END;
GO
```

---

## 🎨 **PASO 4: INTERFAZ DE USUARIO**

### **Archivo:** `app/frmVentas.cs`

**¿Por qué crear este formulario?**
- Interfaz especializada para vendedores
- Carrito de compras intuitivo
- Control de stock en tiempo real
- Diseño consistente con el resto del sistema

### **Estructura del Formulario:**

```csharp
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmVentas : Form
    {
        private VentaNegocio ventaNegocio;
        private List<DetalleVenta> carrito;
        private string vendedorActual;
        
        public frmVentas(string vendedor)
        {
            InitializeComponent();
            vendedorActual = vendedor;
            ventaNegocio = new VentaNegocio();
            carrito = new List<DetalleVenta>();
            
            // Configurar interfaz
            configurarInterfaz();
            cargarArticulos();
        }
        
        // Métodos principales que debes implementar:
        private void configurarInterfaz()
        {
            // Configurar DataGridViews, botones, etc.
        }
        
        private void cargarArticulos()
        {
            // Cargar artículos disponibles usando SP_BuscarArticulosParaVenta
        }
        
        private void agregarAlCarrito()
        {
            // Agregar artículo seleccionado al carrito
            // Validar stock antes de agregar
        }
        
        private void quitarDelCarrito()
        {
            // Quitar artículo del carrito
        }
        
        private void calcularTotal()
        {
            // Calcular total de la venta
        }
        
        private void procesarVenta()
        {
            // Procesar venta completa usando SP_RegistrarVenta
        }
        
        private void limpiarCarrito()
        {
            // Limpiar carrito de compras
        }
        
        private void mostrarHistorial()
        {
            // Mostrar historial usando SP_ObtenerVentasPorVendedor
        }
    }
}
```

### **Diseño Visual Sugerido:**

```
┌─────────────────────────────────────────────────────────────┐
│ [LOGO] Sistema de Ventas - Vendedor: [Nombre]              │
├─────────────────────────────────────────────────────────────┤
│ Buscar: [________________] [Buscar]                         │
├─────────────────────────────────────────────────────────────┤
│ ARTÍCULOS DISPONIBLES          │ CARRITO DE COMPRAS         │
│ ┌─────────────────────────────┐ │ ┌─────────────────────────┐ │
│ │ Código │ Nombre │ Precio │S │ │ │ Art │ Cant │ Precio │Sub │ │
│ │        │        │        │t │ │ │     │      │        │    │ │
│ │        │        │        │o │ │ │     │      │        │    │ │
│ │        │        │        │c │ │ │     │      │        │    │ │
│ │        │        │        │k │ │ │     │      │        │    │ │
│ └─────────────────────────────┘ │ └─────────────────────────┘ │
│ [Agregar al Carrito]            │ [Quitar] [Limpiar Carrito] │
├─────────────────────────────────┼─────────────────────────────┤
│ Cliente: [_________________]    │ TOTAL: $______              │
│                                 │ [Procesar Venta]            │
├─────────────────────────────────┴─────────────────────────────┤
│ [Ver Historial] [Salir]                                     │
└─────────────────────────────────────────────────────────────┘
```

---

## 🔧 **PASO 5: MODIFICACIONES NECESARIAS**

### **1. Modificar `Program.cs`**

**¿Qué cambiar?**
- Redirigir vendedores a `frmVentas` en lugar de `frmArticulos`

```csharp
// ANTES (línea 30):
Application.Run(new frmArticulos());

// DESPUÉS:
Application.Run(new frmVentas(login.UsuarioLogueado.NombreUsuario));
```

### **2. Modificar `app.csproj`**

**¿Qué agregar?**
- Referencias a los nuevos archivos del formulario de ventas

```xml
<Compile Include="frmVentas.cs">
  <SubType>Form</SubType>
</Compile>
<Compile Include="frmVentas.Designer.cs">
  <DependentUpon>frmVentas.cs</DependentUpon>
</Compile>
<EmbeddedResource Include="frmVentas.resx">
  <DependentUpon>frmVentas.cs</DependentUpon>
</EmbeddedResource>
```

### **3. Actualizar archivos SQL**

**¿Qué agregar?**
- **`Script_Sistema_Gestion_Comercial.sql`**: Solo las nuevas tablas (VENTAS, DETALLE_VENTAS)
- **`Vistas_Triggers_Procedimientos.sql`**: Todos los procedimientos, vistas y triggers (incluyendo los de la Fase 14)

**Estructura de archivos SQL actualizada:**
1. **`Script_Sistema_Gestion_Comercial.sql`** - Solo estructura de tablas
2. **`Vistas_Triggers_Procedimientos.sql`** - Toda la lógica de negocio
3. **`Datos_Iniciales.sql`** - Datos de prueba (opcional)

---

## 📋 **PASO 6: PLAN DE IMPLEMENTACIÓN PASO A PASO**

### **🔢 ORDEN DE IMPLEMENTACIÓN RECOMENDADO:**

#### **1️⃣ PRIMERO: Base de Datos**
```sql
-- Ejecutar en este orden:
1. Script_Sistema_Gestion_Comercial.sql (estructura de tablas)
2. Vistas_Triggers_Procedimientos.sql (lógica de negocio)
3. Datos_Iniciales.sql (opcional, para pruebas)
4. Probar procedimientos manualmente
```

#### **2️⃣ SEGUNDO: Modelo de Datos**
```csharp
// Crear en este orden:
1. Dominio/Venta.cs (clases Venta y DetalleVenta)
2. Compilar proyecto para verificar sintaxis
3. Probar que las clases se instancien correctamente
```

#### **3️⃣ TERCERO: Capa de Negocio**
```csharp
// Crear en este orden:
1. Negocio/VentaNegocio.cs
2. Implementar método buscarArticulosParaVenta()
3. Probar conexión con base de datos
4. Implementar resto de métodos uno por uno
```

#### **4️⃣ CUARTO: Interfaz de Usuario**
```csharp
// Crear en este orden:
1. frmVentas.cs (estructura básica)
2. frmVentas.Designer.cs (diseño visual)
3. frmVentas.resx (recursos)
4. Implementar eventos básicos
```

#### **5️⃣ QUINTO: Lógica de Negocio**
```csharp
// Implementar en este orden:
1. cargarArticulos() - Cargar artículos disponibles
2. agregarAlCarrito() - Agregar al carrito
3. calcularTotal() - Calcular totales
4. procesarVenta() - Procesar venta completa
5. mostrarHistorial() - Mostrar historial
```

#### **6️⃣ SEXTO: Integración**
```csharp
// Modificar en este orden:
1. Program.cs - Redirigir vendedores
2. app.csproj - Agregar referencias
3. Probar flujo completo de login
4. Validar navegación por roles
```

#### **7️⃣ SÉPTIMO: Pruebas y Validación**
```csharp
// Probar en este orden:
1. Login como vendedor → debe abrir frmVentas
2. Búsqueda de artículos
3. Agregar/quitar del carrito
4. Procesar venta
5. Verificar actualización de stock
6. Ver historial de ventas
```

---

## ⚠️ **CONSIDERACIONES IMPORTANTES**

### **🔒 Seguridad:**
- Los vendedores **NO** deben acceder a `frmArticulos` (gestión administrativa)
- Solo pueden ver artículos con stock > 0
- Las ventas se asocian automáticamente al vendedor logueado

### **📊 Rendimiento:**
- **TODAS** las consultas usan procedimientos almacenados
- El trigger actualiza stock automáticamente
- Validaciones de stock en tiempo real

### **🎨 Diseño:**
- Mantener la paleta de colores existente
- Usar la misma tipografía (Verdana)
- Diseño consistente con el resto del sistema

### **🔄 Transacciones:**
- **SP_RegistrarVenta** maneja toda la transacción
- Si falla algo, se hace rollback automático
- El trigger valida stock antes de confirmar

---

## 📁 **RESUMEN DE ARCHIVOS**

### **✅ NUEVOS ARCHIVOS A CREAR:**
1. `Dominio/Venta.cs` - Modelo de datos
2. `Negocio/VentaNegocio.cs` - Lógica de negocio
3. `app/frmVentas.cs` - Formulario principal
4. `app/frmVentas.Designer.cs` - Diseño del formulario
5. `app/frmVentas.resx` - Recursos del formulario

### **🔧 ARCHIVOS A MODIFICAR:**
1. `Script_Sistema_Gestion_Comercial.sql` - Agregar tablas de ventas
2. `Vistas_Triggers_Procedimientos.sql` - Agregar SP y triggers de ventas
3. `Program.cs` - Cambiar redirección de vendedores
4. `app.csproj` - Agregar referencias a nuevos archivos

### **📊 NUEVOS PROCEDIMIENTOS ALMACENADOS:**
1. `SP_BuscarArticulosParaVenta` - Reemplaza consulta directa
2. `SP_RegistrarVenta` - Transacción completa
3. `SP_ObtenerVentasPorVendedor` - Historial
4. `SP_ValidarStockDisponible` - Validación de stock
5. `SP_ObtenerDetallesVenta` - Detalles específicos

### **⚡ NUEVO TRIGGER:**
1. `tr_ActualizarStockEnVenta` - Actualiza stock automáticamente

---

## 🎯 **RESULTADO FINAL**

Al completar esta implementación tendrás:

✅ **Sistema de ventas completo** para vendedores  
✅ **Control automático de stock** con triggers  
✅ **Procedimientos almacenados** para mejor rendimiento  
✅ **Interfaz intuitiva** con carrito de compras  
✅ **Historial de ventas** por vendedor  
✅ **Transacciones seguras** con rollback automático  
✅ **Separación de roles** mantenida  
✅ **Integridad de datos** garantizada  

**¡El sistema estará listo para uso en producción!** 🚀
