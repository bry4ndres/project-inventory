# 📦 Backend (.NET 8)

## ✅ Requisitos

- [.NET SDK 8.0]
- [SQL Server]
- [Visual Studio 2022]
- [Git]

## ⚙️ Ejecución del Backend

Abrir la solución del Backend con visual studio

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


# 🌐 Frontend - Angular 18

Ubicarse en la carpeta Frontend desde el terminal o en vs code

## ✅ Requisitos

- [Node.js] (v20.13.1) preferiblemente esta versión para Angular 18  
- [Angular CLI 18](version 18.2.20i)
- [Git]


## ⚙️ Ejecución del Proyecto
### 1. Asegurarte de tener Angular 18 instalado
npm install -g @angular/cli@18   

### 2. Instalar dependencias
npm install

### 3. Configurar Variables de Entorno
- Edita el archivo src/environments/environment.ts
- Editar apiProductsUrl y apiTransactionsUrl por las URLs que se obtienen de las APIs al ejecutar el proyecto Backend

### 4. Ejecutar

- Ejecutar en el terminal `ng serve` luego Ir al URL `http://localhost:4200/`.

Productos
Formulario de creación de productos 
![image](https://github.com/user-attachments/assets/227a8ed4-f4ca-4ab5-9fdd-242d68fde549)

Formulario de edición de productos 
![image](https://github.com/user-attachments/assets/c66e3a3c-467e-4fa7-881f-303998ccd02b)

Filtros
![image](https://github.com/user-attachments/assets/e9761d23-a14f-474d-96d7-80251fd0ecdd)

Transacciones

Formulario de creación de transacciones
![image](https://github.com/user-attachments/assets/37cf3f81-742a-4a37-9ab9-c54aaf029bb7)

Formulario de edición de transacciones
![image](https://github.com/user-attachments/assets/f92efbb7-d224-4f84-9814-f01e5a6d32be)
