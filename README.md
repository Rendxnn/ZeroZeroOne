# ZeroZeroOne

## Descripción
ZeroZeroOne es una herramienta que facilita el registro de horas trabajadas en proyectos directamente desde tus commits de Git. Integra el registro de tiempo en ZeroOne con tu flujo de trabajo diario, eliminando la necesidad de registrar manualmente las horas en la plataforma.

## Características
- Configuración sencilla con un solo comando
- Registro automático de tiempo en ZeroOne con cada commit
- Selección interactiva de cliente, proyecto y actividad
- Integración transparente con el flujo de trabajo de Git
- Disponible como herramienta global que puedes usar en cualquier repositorio Git

## Requisitos
- .NET 6.0 o superior
- PowerShell
- Git
- Credenciales válidas para ZeroOne

## Instalación como herramienta global

Para usar ZeroZeroOne en cualquier repositorio Git, instálalo como una herramienta global de .NET:

```
dotnet tool install --global ZeroZeroOne.CLI
```

Una vez instalada, puedes ejecutar el comando `zeroone` desde cualquier ubicación en tu terminal.

## Uso

1. Navega a cualquier repositorio Git donde quieras configurar el hook de post-commit:
   ```
   cd ruta/a/tu/repositorio-git
   ```

2. Ejecuta el comando de configuración:
   ```
   zeroone startproject
   ```

3. Sigue las instrucciones en pantalla:
   - Ingresa tus credenciales de ZeroOne
   - Selecciona el cliente, proyecto y actividad

Una vez configurado, puedes registrar tiempo incluyendo etiquetas especiales en tus mensajes de commit:

### Formato básico:
```
git commit -m "Descripción del trabajo m:45"
```
Donde `m:45` indica 45 minutos trabajados.

### Formato con observación personalizada:
```
git commit -m "Cualquier texto m:30 o:Trabajando en la funcionalidad X"
```
Donde:
- `m:30` indica 30 minutos trabajados
- `o:Trabajando en la funcionalidad X` es una observación específica que se enviará a ZeroOne

### Notas:
- El parámetro `m:[minutos]` es **obligatorio** para registrar el tiempo
- El parámetro `o:[observacion]` es opcional; si no se proporciona, se utilizará el mensaje completo del commit (sin las etiquetas)
- Los minutos deben ser un número entero positivo

## Ejemplos

```
git commit -m "Implementación de login m:120"
```
Registra 2 horas trabajadas con la descripción "Implementación de login"

```
git commit -m "Corrección de bug m:45 o:Solucionando problema de autenticación"
```
Registra 45 minutos con la observación específica "Solucionando problema de autenticación"

## Funcionamiento interno

El hook de post-commit:
1. Extrae los minutos y la observación del mensaje de commit
2. Valida que los minutos sean un valor válido
3. Se conecta a ZeroOne usando tus credenciales
4. Registra las horas trabajadas en el proyecto y actividad configurados
5. Muestra un mensaje de confirmación

## Solución de problemas

Si el registro de horas no funciona:
- Verifica que el mensaje de commit incluya `m:[minutos]`
- Asegúrate de que tus credenciales de ZeroOne sean correctas
- Comprueba que el archivo `.git/hooks/post-commit.ps1` exista y tenga permisos de ejecución

Si la herramienta global no funciona:
- Asegúrate de tener .NET 6.0 o superior instalado: `dotnet --version`
- Verifica que la herramienta esté instalada: `dotnet tool list -g`
- Intenta reinstalar la herramienta: `dotnet tool update --global ZeroZeroOne.CLI`

## Estructura del proyecto

- `ZeroZeroOne/` - Biblioteca principal
  - `API/ZeroOne/` - Cliente para la API de ZeroOne
  - `Entities/` - Modelos de datos
  - `External/` - Interfaces de usuario (CLI)
  - `SetUp/` - Configuración del hook de post-commit
  - `Templates/` - Plantilla del hook
  - `Utils/` - Constantes y utilidades
- `ZeroZeroOne.CLI/` - Aplicación de consola

## Para desarrolladores

### Empaquetar y publicar la herramienta

Para publicar esta herramienta en NuGet y permitir que otros la instalen fácilmente, sigue estos pasos:

1. Actualiza la información del paquete en `ZeroZeroOne.CLI/ZeroZeroOne.CLI.csproj`:
   - Cambia `Authors`, `Company` y otras propiedades según corresponda
   - Incrementa `Version` cuando publiques nuevas versiones

2. Empaqueta la herramienta:
   ```
   cd ZeroZeroOne.CLI
   dotnet pack -c Release
   ```
   Esto generará un archivo `.nupkg` en la carpeta `./nupkg`

3. Publica en NuGet (necesitas una API key de NuGet):
   ```
   dotnet nuget push ./nupkg/ZeroZeroOne.CLI.1.0.0.nupkg --api-key tu_api_key --source https://api.nuget.org/v3/index.json
   ```

4. Si prefieres probar localmente antes de publicar, puedes instalar desde un directorio local:
   ```
   dotnet tool install --global --add-source ./nupkg ZeroZeroOne.CLI
   ```

## Contacto

Para problemas o sugerencias, por favor abre un issue en este repositorio. 