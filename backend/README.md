# 📦 Inventory Backend - ProductService (.NET 8)

## ✅ Requisitos

- [.NET SDK 8.0]
- [SQL Server]
- [Visual Studio 2022]
- [Git]

## ⚙️ Ejecución del Backend

### 1. Crear las Bases de Datos y Tablas

- Ejecuta el script ubicado en la raíz del proyecto, en la carpeta `BDScript`.
- Se crearán dos bases de datos:
  - `ProductDB`
  - `TransactionDB`
- Se crearán dos tablas:
  - `Products` en `ProductDB`
  - `Transactions` en `TransactionDB`

### 2. Configurar las Cadenas de Conexión

#### En `ProductService`:

- Abre el archivo `ProductService/ProductService.API/appsettings.json`.
- Modifica el valor de la propiedad `DefaultConnection`:
  - Cambia `Server=ASUS-ROG\\SQLEXPRESS01` por el nombre de tu instancia de SQL Server.
  - Mantén el nombre de la base de datos como está (`ProductDB`).

#### En `TransactionService`:

- Abre el archivo `TransactionService/TransactionService.API/appsettings.json`.
- Modifica el valor de la propiedad `DefaultConnection`:
  - Cambia `Server=ASUS-ROG\\SQLEXPRESS01` por tu instancia de SQL Server.
  - Mantén el nombre de la base de datos como está (`TransactionDB`).
- Actualiza también la clave `ProductService` con la URL del microservicio `ProductService`.

### 3. Ejecutar el Proyecto

- Configura Visual Studio para iniciar múltiples proyectos:
  - Haz clic en la flecha junto al botón **Start** y selecciona **Configure Startup Projects**.
  - Marca la opción **Multiple startup projects**.
  - En la columna **Action**, selecciona `Start` para:
    - `ProductService.API`
    - `TransactionService.API`

- Haz clic en **Start** para iniciar ambos microservicios.

### 🔗 Endpoints

Una vez iniciados los servicios, podrás acceder a las APIs desde sus respectivas URLs. Estas te servirán para:

- Configurar la URL del `ProductService` dentro de `TransactionService`.
- Consumir los endpoints desde el proyecto frontend desarrollado en Angular.

ProductService API
![image](https://github.com/user-attachments/assets/933535e9-9511-4837-9afc-10d6239edfdf)

TransactionService API
![image](https://github.com/user-attachments/assets/1101a686-ce34-42fd-8688-91e1d6baeeee)



