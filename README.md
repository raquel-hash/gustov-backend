# Gustov Restaurant - Backend
## Descripción

Gustov Restaurant Backend es una API desarrollada en .NET para la gestión y operación de un restaurante. Proporciona endpoints para manejar el menú, ventas, administracion de platos, reporte diario de las ventas y la autenticación de usuarios.

## Características

- Listar el menú
- Gestión de platos
- Raelizar ventas
- Autenticación y autorización de usuarios
- Reporte diario de las ventas

## Instalación

Para instalar y ejecutar este proyecto localmente, sigue estos pasos:

1. Clona el repositorio:

   ```sh
   git clone https://github.com/tu-usuario/gustov-restaurant-backend.git
   cd gustov-restaurant-backend
   ```

2. Restaura las dependencias de .NET:

   ```sh
   dotnet restore
   ```

## Uso

### Desarrollo

Para ejecutar la aplicación en modo de desarrollo, usa el siguiente comando:

```sh
dotnet run
```

Esto iniciará el servidor de desarrollo y abrirá la API en `http://localhost::7115/`.

## Configuración

### Variables de Entorno

Asegúrate de configurar las siguientes variables de entorno para que la aplicación funcione correctamente:

- `DefaultConnection`: Cadena de conexión a la base de datos.
- `JwtSecret`: Cadena de conexión a la base de datos.

### Configuración de Base de Datos

Asegúrate de tener una base de datos configurada y ejecutando. Puedes actualizar la cadena de conexión en el archivo `appsettings.json`:

```json name=appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "JwtSecret": "JwtSecret",
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-8R6LOB0;Database=GustovRestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

_Desarrollado con ♥ por [Raquel](https://github.com/raquel-hash)_
