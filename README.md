# Proyecto de compiladores

## Entrega 1
Para la entrea 1 se construye un lexer que distinga entre los
*terminals* y los *non terminals*.


## Instalar y ejecutar
Este proyecto utiliza .net 6. Para compilar el código fuente y ejecutarlo
es necesario instalar el SDK de .net para el sistema 
operativo usado. El script `install-and-run.sh` automaticamente
instala el SDK si es que no está instalado, y utiliza la instalación para
compilar y ejecutar el proyecto. Si .net 6 para linux NO
se encuentra instalado, será necesario descargarlo con un script
proporcionado por Microsoft. La descarga puede tardar unos segundos o 
minutos ya que pueden ser varios MB. Se recomienda
**no** desinstalar .net una vez descargado. 
La descarga se guarda en `$HOME/.dotnet`.

Es posible que primero deba proporcionar permisos de ejecución al lanzador
y al script de ejecución. Esto se puede lograr con el comando `chmod +x *.sh`.

La primera vez que se corre .net en una máquina, es posible que se muestre
un mensaje de bienvenida. 
