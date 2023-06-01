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

- Ve a la página de Microsoft Visual Studio Code en Academic Software y haz clic en el botón _**Descargar Visual Studio Code**_ para descargar el archivo de instalación.
- Abre el archivo de instalación .exe en tu carpeta de descargas para iniciar la instalación.
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

## Manejo de argumentos
- En C# 11, podemos acceder a los argumentos de la línea de comandos pasados a una aplicación de consola a través del parámetro args del método Main. Aquí hay un   ejemplo:
  ![image](https://github.com/CesarEnc/ConsoleApp/assets/83259031/b16dce9a-4b09-4d57-90de-fc5f97e5dc04)
  En este imagen capturamos los parametros y se los pasamos a una funcion que los validara.

## Features unicos de C# 11
- Los patrones de lista amplían la coincidencia de patrones para hacer coincidir secuencias de elementos en una lista o una matriz. Por ejemplo, la secuencia es     [1, 2, 3] es verdadera cuando la secuencia es una matriz o una lista de tres enteros (1, 2 y 3). Puede unir elementos utilizando cualquier patrón, incluidos       patrones constantes, de tipo, de propiedad y relacionales. El patrón de descarte (_) coincide con cualquier elemento individual y el nuevo patrón de rango (..)   coincide con cualquier secuencia de cero o más elementos.
  ![image](https://github.com/CesarEnc/ConsoleApp/assets/83259031/3d850bb9-f421-4208-83ed-72cdc721508d)
  Aqui podemos ver como usamos list pattern para comprobar si una lista de strings que nos pasan como args esta vacia o no.

 
