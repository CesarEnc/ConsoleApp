<h1 align="center"> Console App </h1>

## Introducción

Saludos, este documento esta diseñado con la intencion de asistírlo el las instalaciones de algunas dependencias que requerirá para poder utilizar este ConsoleApp, utilizando dotnet core y mostrar sus puntos importantes, como manejo de argumentos por consola, el uso de Web APIs, manejo de File IO e IO Errors.

## Pasos a seguir para instalar el SDK de dotnet:

- Abre un navegador web y ve al sitio web oficial de [_.NET Core_](https://dotnet.microsfot.com/download)
- Haz clic en el botón [**_Download .NET_**](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.302-windows-x64-installer) o en el enlace que te lleve a la página de descargas.
- En la página de descargas, selecciona la versión del SDK de .NET que deseas instalar. Asegúrate de elegir la versión correcta según tu sistema operativo y arquitectura (por ejemplo, Windows x64, macOS, Linux, etc.).
- Haz clic en el enlace de descarga correspondiente y se descargará un archivo de instalación en tu computadora.
- Ejecuta el archivo de instalación descargado para iniciar el proceso de instalación. Dependiendo del sistema operativo, el proceso puede variar, pero en general, deberás seguir las instrucciones en pantalla y aceptar los términos y condiciones de la instalación.
- Durante la instalación, se te preguntará si deseas instalar componentes adicionales o herramientas. Puedes seleccionar las opciones que desees según tus necesidades.
- Una vez completada la instalación, abre una ventana de terminal o línea de comandos en tu sistema operativo.
- Para verificar que la instalación se haya realizado correctamente, escribe el siguiente comando en la terminal:

    ```.net
    dotnet --version
    ```
    
## Pasos para Instalar VSCode

- Ve a la página de Microsoft Visual Studio Code en Academic Software y haz clic en el botón _**Descargar Visual Studio Code**_(https://code.visualstudio.com/download) para descargar el archivo de instalación correspondiente a tu SO.
- Abre el archivo de instalación en tu carpeta de descargas para iniciar la instalación.
- Lee y acepta el acuerdo de licencia. Haz clic en Next para continuar.
- Puedes cambiar la ubicación de la carpeta de instalación o mantener la configuración predeterminada. Haz clic en Next para continuar.
- Elige si deseas cambiar el nombre de la carpeta de accesos directos en el menú Inicio o si no deseas instalar accesos directos en absoluto. Haz clic en Next.
- Selecciona las tareas adicionales, por ej. crear un icono en el escritorio o añadir opciones al menú contextual de Windows Explorer. Haz clic en Next.
- El programa está instalado y listo para usar. Haz clic en Finish para finalizar la instalación y lanzar el programa.

## Pasos para instalar Plugin de C# dentro del Visual Studio Code (VSCode)

- Abrir VSCode 
- En la Barra de Herramientas, Seleccionar la pestaña de _**View**_
- Entre las opciones, seleccionar _**Extensiones**_
- Desde la ruta de extensiones, escribir en la Barra de Busqueda localizada debajo del Titulo de extensiones la palabra **C#**
- Del listado filtrado, identificar la Extension llamada **C#** por el autor **Microsoft**
- Hacer click en el boton instalar

# Crear Console App

- En una terminal entrar el siguiente comando.
```
dotnet new console --framework net7.0
```
- Para ejecutar
```
dotnet run
```

# Manejo de argumentos
- En C# 11, podemos acceder a los argumentos de la línea de comandos pasados a una aplicación de consola a través del parámetro args del método Main.
  

# Features unicos de C# 11
- Los patrones de lista amplían la coincidencia de patrones para hacer coincidir secuencias de elementos en una lista o una matriz. Por ejemplo, la secuencia es     [1, 2, 3] es verdadera cuando la secuencia es una matriz o una lista de tres enteros (1, 2 y 3). Puede unir elementos utilizando cualquier patrón, incluidos       patrones constantes, de tipo, de propiedad y relacionales. El patrón de descarte (_) coincide con cualquier elemento individual y el nuevo patrón de rango (..)   coincide con cualquier secuencia de cero o más elementos

 ```cs
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidArg = ContainsValidArguments(args);
            if (isValidArg)
                Console.WriteLine("It is a valid argument")
            else 
                Console.WriteLine("It is not a valid argument")
        }

        private static bool ContainsValidArguments(string[] args)
        {
            if (args is not [])
                return args.Contains("list") || args.Contains("version");
            return false;
        }
    }
}
```
 Capturamos los argumentos enviados por consola para enviarselos a la funcion de ContainsValidArguments.
 Aqui podemos ver como usamos list pattern para comprobar si una lista de strings que nos pasan como args esta vacia o no.
  
# Cancelation Token implementation

- Cuando la app este en ejecución puede precionar "Ctrl + C" para proceder a detener la applicación.
```cs
CancellationTokenSource cancellationToken = new();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true; // prevent the process from terminating.
    cancellationToken.Cancel();
};
await DoSomethingAsync(cancellationToken.Token)
```

# Errores de Salida

- Error-9: Error desconocida en funcionamiento de app, favor reportar a los administradores
- Error-1: Argumento Invalido
- Error-2: Servicio de "Drinks" no disponible


```cs
try
{
    //Main Code
}
catch (Exception e)
{
    Console.Error.WriteLine($"Error-{(int)Errors.InternalError}");
    Console.Error.WriteLine($"Detail: {e.Message}");
    return;
}

enum Errors
{
    InternalError,
    InvalidArgument,
    UnaveilableApi
}
```

#Consumir API de drinks
- Modelo de lo que recibiremos desde el response del API
-  Metodo para consumir el API
- Validar argumentos y ejecutar el metodo de listar si los argumentos enviados son validos
```cs
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidArg = ContainsValidArguments(args);
            if (isValidArg) 
            {
                if (args.Contains("list")) 
                {
                    Console.WriteLine(GetDrinks());
                }
            }
                
            else 
                Console.WriteLine("It is not a valid argument")
        }

        private static bool ContainsValidArguments(string[] args)
        {
            if (args is not [])
                return args.Contains("list") || args.Contains("version");
            return false;
        }

        private static List<Drink> GetDrinks() 
        {
            var client = new HttpClient();
                    var request = new HttpRequestMessage 
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://the-cocktail-db.p.rapidapi.com/list.php?g=list"),
                        Headers =
                        {
                            { "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" }, //use your own API KEY
                            { "X-RapidAPI-Host", "the-cocktail-db.p.rapidapi.com" }, //use yout own Rapi Host
                        },
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsAsync<List<Drink>>();
                        return body;
                    }
        }
    }

    public class Drink 
    {
        public int idDrink { get; set; }
        public string strAlcoholic {get; set; }
        public string strCategory {get; set;}
    }
}
```

# Crear archivos csv basado en resultado de Drinks

```cs
class Drink
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
}

List<Drink> GetDrinks()
{
    //Resultado de Api
}

//To Use on Main Method

List<Drink> list = GetDrinks();
var csv= new StringBuilder();
csv.AppendLine("header");
foreach (var element in list)
{
    csv.AppendLine("elemnt");
}
System.IO.File.WriteAllText(@"C:\Temp\csc.txt", csv.ToString());

```
