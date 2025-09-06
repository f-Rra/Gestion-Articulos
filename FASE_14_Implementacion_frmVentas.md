# FASE 14: Implementación del Formulario de Ventas (frmVentas)

## Objetivo
Crear un formulario especializado para vendedores que permita realizar ventas con control de stock, sin acceso a la gestión administrativa de artículos.

## Arquitectura y Diseño

### 1. Modelo de Datos - Crear clase Venta
**Archivo:** `Dominio\Venta.cs`

```csharp
using System;
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
    }
    
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int StockDisponible { get; set; }
    }
}
```

### 2. Capa de Negocio - Crear VentaNegocio
**Archivo:** `Negocio\VentaNegocio.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Data;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        /// <summary>
        /// Busca artículos disponibles para venta (con stock > 0)
        /// </summary>
        public DataTable buscarArticulosParaVenta(string filtro = "")
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                string consulta = @"SELECT 
                    Id, Codigo, Nombre, Descripcion, Precio, Stock,
                    (SELECT Descripcion FROM CATEGORIAS WHERE Id = a.IdCategoria) as Categoria,
                    (SELECT Descripcion FROM MARCAS WHERE Id = a.IdMarca) as Marca
                FROM ARTICULOS a 
                WHERE Estado = 1 AND Stock > 0";
                
                if (!string.IsNullOrEmpty(filtro))
                {
                    consulta += " AND (Codigo LIKE @filtro OR Nombre LIKE @filtro OR Descripcion LIKE @filtro)";
                    datos.setearParametro("@filtro", "%" + filtro + "%");
                }
                
                consulta += " ORDER BY Nombre";
                datos.setearConsulta(consulta);
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
        /// Registra una nueva venta y actualiza el stock
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
                datos.setearParametro("@Cliente", venta.Cliente);
                datos.setearParametro("@Total", venta.Total);
                
                // Convertir detalles a XML o JSON para pasar como parámetro
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
        /// </summary>
        public DataTable obtenerVentasPorVendedor(string vendedor)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta(@"SELECT 
                    NumeroVenta, Fecha, Cliente, Total, Estado 
                FROM VENTAS 
                WHERE Vendedor = @vendedor 
                ORDER BY Fecha DESC");
                datos.setearParametro("@vendedor", vendedor);
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
        /// </summary>
        public bool validarStockDisponible(int idArticulo, int cantidadSolicitada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Stock FROM ARTICULOS WHERE Id = @id AND Estado = 1");
                datos.setearParametro("@id", idArticulo);
                datos.ejecutarLectura();
                
                if (datos.Lector.Read())
                {
                    int stockActual = (int)datos.Lector["Stock"];
                    return stockActual >= cantidadSolicitada;
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
        
        private string convertirDetallesAXml(List<DetalleVenta> detalles)
        {
            // Implementar conversión a XML para pasar al SP
            // Esto se puede hacer con StringBuilder o XDocument
            return ""; // Placeholder
        }
    }
}
```

### 3. Base de Datos - Agregar tablas y procedimientos

**Agregar al script unificado:**

```sql
-- Tabla VENTAS
CREATE TABLE VENTAS (
    Id int IDENTITY(1,1) PRIMARY KEY,
    NumeroVenta varchar(20) NOT NULL UNIQUE,
    Fecha datetime NOT NULL DEFAULT GETDATE(),
    Vendedor varchar(100) NOT NULL,
    Cliente varchar(200),
    Total decimal(10,2) NOT NULL,
    Estado varchar(20) NOT NULL DEFAULT 'Completada'
);

-- Tabla DETALLE_VENTAS
CREATE TABLE DETALLE_VENTAS (
    Id int IDENTITY(1,1) PRIMARY KEY,
    IdVenta int NOT NULL,
    IdArticulo int NOT NULL,
    Cantidad int NOT NULL,
    PrecioUnitario decimal(10,2) NOT NULL,
    Subtotal decimal(10,2) NOT NULL,
    FOREIGN KEY (IdVenta) REFERENCES VENTAS(Id),
    FOREIGN KEY (IdArticulo) REFERENCES ARTICULOS(Id)
);

-- Procedimiento para registrar venta
CREATE PROCEDURE SP_RegistrarVenta
    @NumeroVenta varchar(20),
    @Vendedor varchar(100),
    @Cliente varchar(200),
    @Total decimal(10,2),
    @DetallesXml xml
AS
BEGIN
    BEGIN TRANSACTION
    
    DECLARE @IdVenta int
    
    -- Insertar venta
    INSERT INTO VENTAS (NumeroVenta, Vendedor, Cliente, Total)
    VALUES (@NumeroVenta, @Vendedor, @Cliente, @Total)
    
    SET @IdVenta = SCOPE_IDENTITY()
    
    -- Insertar detalles y actualizar stock
    INSERT INTO DETALLE_VENTAS (IdVenta, IdArticulo, Cantidad, PrecioUnitario, Subtotal)
    SELECT 
        @IdVenta,
        T.c.value('@IdArticulo', 'int'),
        T.c.value('@Cantidad', 'int'),
        T.c.value('@PrecioUnitario', 'decimal(10,2)'),
        T.c.value('@Subtotal', 'decimal(10,2)')
    FROM @DetallesXml.nodes('/Detalles/Detalle') T(c)
    
    -- Actualizar stock
    UPDATE a SET Stock = Stock - d.Cantidad
    FROM ARTICULOS a
    INNER JOIN (
        SELECT 
            T.c.value('@IdArticulo', 'int') as IdArticulo,
            T.c.value('@Cantidad', 'int') as Cantidad
        FROM @DetallesXml.nodes('/Detalles/Detalle') T(c)
    ) d ON a.Id = d.IdArticulo
    
    COMMIT TRANSACTION
END
```

### 4. Interfaz de Usuario - Crear frmVentas

**Archivo:** `app\frmVentas.cs`

#### Controles necesarios:
- **Panel superior**: Logo y título "Sistema de Ventas"
- **Panel búsqueda**: TextBox para filtrar artículos
- **DataGridView artículos**: Lista de artículos disponibles
- **Panel carrito**: 
  - DataGridView con artículos seleccionados
  - Labels para totales
  - Botones Agregar/Quitar/Limpiar
- **Panel cliente**: TextBox para nombre del cliente
- **Botones**: Procesar Venta, Ver Historial, Salir

#### Funcionalidades principales:

```csharp
public partial class frmVentas : Form
{
    private VentaNegocio ventaNegocio;
    private List<DetalleVenta> carrito;
    private string vendedorActual;
    
    // Métodos principales:
    // - cargarArticulos()
    // - agregarAlCarrito()
    // - quitarDelCarrito()
    // - calcularTotal()
    // - procesarVenta()
    // - validarStock()
    // - limpiarCarrito()
    // - mostrarHistorial()
}
```

### 5. Diseño del Formulario (frmVentas.Designer.cs)

#### Layout sugerido:
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

### 6. Integración con el Sistema Principal

#### Modificar frmLogin.cs:
- Agregar lógica para abrir frmVentas cuando el usuario sea "Vendedor"
- Pasar el nombre del vendedor al formulario

#### Modificar frmAdmin.cs:
- Mantener acceso solo para administradores
- El frmVentas será independiente para vendedores

### 7. Validaciones y Reglas de Negocio

1. **Validación de Stock**: Verificar disponibilidad antes de agregar al carrito
2. **Validación de Cantidad**: No permitir cantidades negativas o cero
3. **Validación de Cliente**: Campo opcional pero recomendado
4. **Numeración de Ventas**: Auto-generar número único (formato: V-YYYYMMDD-####)
5. **Control de Sesión**: Asociar ventas al vendedor logueado

### 8. Pasos de Implementación

#### Paso 1: Base de Datos
1. Ejecutar script para crear tablas VENTAS y DETALLE_VENTAS
2. Crear procedimiento SP_RegistrarVenta
3. Probar procedimientos manualmente

#### Paso 2: Modelo de Datos
1. Crear clase Venta.cs en carpeta Dominio
2. Crear clase DetalleVenta.cs
3. Compilar y verificar

#### Paso 3: Capa de Negocio
1. Crear VentaNegocio.cs en carpeta Negocio
2. Implementar métodos básicos
3. Probar conexión y consultas

#### Paso 4: Interfaz de Usuario
1. Crear frmVentas.cs y frmVentas.Designer.cs
2. Diseñar layout con controles
3. Implementar eventos básicos

#### Paso 5: Lógica de Negocio
1. Implementar búsqueda de artículos
2. Implementar carrito de compras
3. Implementar proceso de venta
4. Implementar historial

#### Paso 6: Integración
1. Modificar frmLogin para direccionar vendedores
2. Probar flujo completo
3. Validar actualización de stock

#### Paso 7: Pruebas
1. Probar con diferentes escenarios
2. Validar stock insuficiente
3. Probar historial de ventas
4. Verificar integridad de datos

### 9. Consideraciones Adicionales

- **Seguridad**: Los vendedores no deben acceder a gestión de artículos
- **Performance**: Optimizar consultas para búsquedas rápidas
- **UX**: Interfaz intuitiva para usuarios no técnicos
- **Reportes**: Considerar reportes de ventas por vendedor
- **Backup**: Asegurar respaldo de transacciones de venta

### 10. Archivos a Crear/Modificar

**Nuevos archivos:**
- `Dominio\Venta.cs`
- `Negocio\VentaNegocio.cs`
- `app\frmVentas.cs`
- `app\frmVentas.Designer.cs`
- `app\frmVentas.resx`

**Archivos a modificar:**
- `Script_Sistema_Gestion_Articulos_Unificado.sql`
- `app\frmLogin.cs`
- `app\app.csproj`

Este plan detallado te permitirá implementar el sistema de ventas paso a paso, manteniendo la consistencia con el sistema existente y agregando la funcionalidad necesaria para los vendedores.
